using Npgsql;
using System.Diagnostics;

namespace Indigo
{
    public sealed class MultiplayerManager : IAsyncDisposable
    {
        private readonly string _connectionString;

        private Guid _myId;
        private string _myName = string.Empty;
        private string _myColor = "White";
        private int _currentSessionId = -1;
        private int _myPlayerIndex = -1;
        private int _turnCounter = 0;

        private NpgsqlConnection? _listenerConn;
        private CancellationTokenSource? _cts;


        public event Action<Guid, string>? OnRegistered;
        public event Action? OnGameStart;
        public event Action? OnLobbyRefresh;
        public event Action? OnGameClosed;

        internal event Action<Tile, int>? OnTurnReceived;
        public event Action<Exception>? OnError;

        public MultiplayerManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SetMyPlayerIndex(int index) => _myPlayerIndex = index;
        public async Task<bool> RegisterPlayerAsync(string color = "White")
        {
            try
            {
                _myId = Guid.NewGuid();
                _myName = "Player_" + _myId.ToString()[..4];
                _myColor = color;

                using var conn = new NpgsqlConnection(_connectionString);
                await conn.OpenAsync();

                const string sql =
                    """
                    INSERT INTO players (player_id, player_name, color, is_ready)
                    VALUES (@id, @name, @color, FALSE)
                    """;

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", _myId);
                cmd.Parameters.AddWithValue("name", _myName);
                cmd.Parameters.AddWithValue("color", _myColor);
                await cmd.ExecuteNonQueryAsync();

                OnRegistered?.Invoke(_myId, _myName);

                StartListening();

                return true;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    $"Cannot connect to database.\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        public async Task SetReadyAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql =
                "UPDATE players SET is_ready = TRUE WHERE player_id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", _myId);
            await cmd.ExecuteNonQueryAsync();
        }

        internal async Task SendTurnAsync(Tile tile)
        {
            if (_currentSessionId < 0)
                throw new InvalidOperationException("Game session has not started yet.");

            int turnNumber = Interlocked.Increment(ref _turnCounter);

            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql =
                """
                INSERT INTO turns
                    (session_id, player_id, player_index, tile_id, num_of_rotation, tile_index, turn_number)
                VALUES
                    (@session, @player, @index, @tile, @rot, @idx, @turn)
                """;

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("session", _currentSessionId);
            cmd.Parameters.AddWithValue("player", _myId);
            cmd.Parameters.AddWithValue("index", _myPlayerIndex);
            cmd.Parameters.AddWithValue("tile", tile.id);
            cmd.Parameters.AddWithValue("rot", tile.numOfRotation);
            cmd.Parameters.AddWithValue("idx", tile.index);
            cmd.Parameters.AddWithValue("turn", turnNumber);
            await cmd.ExecuteNonQueryAsync();

            // The DB trigger fires pg_notify('new_turn', '…') automatically.
        }

        private void StartListening()
        {
            if (_listenerConn != null) return;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            // Fire-and-forget task; errors are surfaced via OnError event.
            _ = Task.Run(() => ListenLoopAsync(token), token);
        }

        private async Task ListenLoopAsync(CancellationToken ct)
        {
            try
            {
                _listenerConn = new NpgsqlConnection(_connectionString);
                await _listenerConn.OpenAsync(ct);

                // Subscribe to both channels
                await using (var listenCmd = new NpgsqlCommand(
                                "LISTEN game_start; LISTEN new_turn; LISTEN lobby_refresh; LISTEN game_closed;",
                                _listenerConn))
                {
                    await listenCmd.ExecuteNonQueryAsync(ct);
                }

                _listenerConn.Notification += HandleNotification;

                // Keep the connection alive by waiting for notifications
                while (!ct.IsCancellationRequested)
                {
                    await _listenerConn.WaitAsync(ct);
                }
            }
            catch (OperationCanceledException)
            {
                // Normal shutdown — swallow.
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }
            finally
            {
                if (_listenerConn is not null)
                {
                    _listenerConn.Notification -= HandleNotification;
                    await _listenerConn.DisposeAsync();
                    _listenerConn = null;
                }
            }
        }

        private void HandleNotification(object sender, NpgsqlNotificationEventArgs e)
        {
            switch (e.Channel)
            {
                case "game_start":
                    HandleGameStart();
                    break;

                case "new_turn":
                    HandleNewTurn(e.Payload);
                    break;

                case "lobby_refresh":
                    OnLobbyRefresh?.Invoke();
                    break;

                case "game_closed":
                    OnGameClosed?.Invoke();
                    break;
            }
        }

        private void HandleGameStart()
        {
            // Fetch the active session ID so SendTurnAsync can reference it.
            _ = Task.Run(async () =>
            {
                try
                {
                    using var conn = new NpgsqlConnection(_connectionString);
                    await conn.OpenAsync();

                    const string sql =
                        "SELECT session_id FROM game_sessions WHERE is_active = TRUE ORDER BY started_at DESC LIMIT 1";

                    using var cmd = new NpgsqlCommand(sql, conn);
                    var result = await cmd.ExecuteScalarAsync();
                    if (result is int sid)
                        _currentSessionId = sid;

                    OnGameStart?.Invoke();
                }
                catch (Exception ex)
                {
                    OnError?.Invoke(ex);
                }
            });
        }

        private void HandleNewTurn(string payload)
        {
            // Payload format: "tileId:rotations:placementIndex:playerIndex"
            var parts = payload.Split(':');
            if (parts.Length < 4) return;

            if (!int.TryParse(parts[0], out int tileId)) return;
            if (!int.TryParse(parts[1], out int rotations)) return;
            if (!int.TryParse(parts[2], out int placementIdx)) return;
            if (!int.TryParse(parts[3], out int playerIndex)) return;

            // Ignore own turns using player index
            if (playerIndex == _myPlayerIndex) return;

            var tile = new Tile(tileId, rotations, placementIdx);

            OnTurnReceived?.Invoke(tile, playerIndex);
        }

        public async Task NotifyGameClosedAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await new NpgsqlCommand(
                "UPDATE players SET is_ready = FALSE", conn)
                .ExecuteNonQueryAsync();

            await new NpgsqlCommand(
                "DELETE FROM turns", conn)
                .ExecuteNonQueryAsync();

            await new NpgsqlCommand(
                "UPDATE game_sessions SET is_active = FALSE", conn)
                .ExecuteNonQueryAsync();

            await new NpgsqlCommand(
                "SELECT pg_notify('game_closed', '')", conn)
                .ExecuteNonQueryAsync();
        }

        public async Task DisconnectAsync()
        {
            // Stop the listener first
            _cts?.Cancel();

            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = "DELETE FROM players WHERE player_id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", _myId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async ValueTask DisposeAsync()
        {
            try { await DisconnectAsync(); }
            catch { /* best-effort */ }

            _cts?.Dispose();
        }
        public async Task LobbyClearAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = "DELETE FROM players";

            using var cmd = new NpgsqlCommand(sql, conn);
            await cmd.ExecuteNonQueryAsync();

            using var notifyCmd = new NpgsqlCommand(
                "SELECT pg_notify('lobby_refresh', '')",
                conn);
            await notifyCmd.ExecuteNonQueryAsync();
        }

        internal async Task<PlayerInfo[]> GetConnectedPlayersAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql =
                "SELECT player_id, player_name, color, is_ready FROM players ORDER BY joined_at";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            var list = new System.Collections.Generic.List<PlayerInfo>();
            while (await reader.ReadAsync())
            {
                list.Add(new PlayerInfo(
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetBoolean(3)));
            }

            return list.ToArray();
        }
        public async Task<int> GetMyPlayerIndexAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            // Returns 0-based position this player joined in (join order = player index)
            const string sql =
                """
                SELECT COUNT(*) FROM players
                WHERE joined_at < (SELECT joined_at FROM players WHERE player_id = @id)
                """;

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", _myId);

            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        internal async Task<TurnRecord[]> GetLastSessionHistoryAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql =
                """
                SELECT t.turn_number,
                       p.player_name,
                       (SELECT COUNT(*) FROM players p2
                        WHERE p2.joined_at < p.joined_at) AS player_index,
                       t.tile_id,
                       t.num_of_rotation,
                       t.tile_index
                FROM   turns t
                JOIN   players p ON p.player_id = t.player_id
                ORDER  BY t.turn_number
                """;

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            var list = new List<TurnRecord>();
            while (await reader.ReadAsync())
            {
                list.Add(new TurnRecord(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    Convert.ToInt32(reader.GetInt64(2)),
                    new Tile(reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)),
                    DateTime.MinValue));
            }

            return list.ToArray();
        }
    }


    internal sealed record PlayerInfo(
        Guid PlayerId,
        string Name,
        string Color,
        bool IsReady);

    internal sealed record TurnRecord(
        int TurnNumber,
        string PlayerName,
        int PlayerIndex,
        Tile Tile,
        DateTime PlayedAt);

}
