using System.Diagnostics;
using System.Numerics;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Indigo
{
    public partial class TitleScreenForm : Form
    {
        int playerCount = 2;
        float percent = 1;

        int[] sizesOfObjects = [
            BoardImage.Width,
            BoardImage.Height,
            Tile.Width,
            Tile.Height,
            Gem.Width,
            Gem.Height,
            PlayerToken.Width,
            PlayerToken.Height
        ];

        private readonly string _connectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Database=gamedb;" +
            "Username=gameuser;" +
            "Password=gamepass;";

        private MultiplayerManager? _mp;

        private bool _isClosing = false;

        public TitleScreenForm()
        {
            InitializeComponent();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            if (playerCount != 2)       //ToDo
            {
                return;
            }

            // _mp is null here if player never connected — that's fine, GameForm handles it
            var gameForm = new GameForm(sizesOfObjects, percent - 0.1f, playerCount, _mp);

            gameForm.FormClosed += (s, args) => this.Show();

            gameForm.Show();
            this.Hide();

            scaleLabel.Text = "Game scale: (%)";
            //          Another variant but does not free up memory :(
            //
            //using (var gameForm = new GameForm(sizesOfObjects, percent, playerCount))
            //{
            //    this.Hide();
            //    gameForm.ShowDialog(); // blocks here
            //    this.Show();           // executes after GameForm closes
            //}
        }
        private void video1Button_Click(object sender, EventArgs e)
        {
            goToLink("https://www.youtube.com/watch?v=I7kXYYuxgro&t=47s");
        }
        private void video2Button_Click(object sender, EventArgs e)
        {
            goToLink("https://www.youtube.com/watch?v=LJwy7qXWuNI&t=38s");
        }
        private void rules1Button_Click(object sender, EventArgs e)
        {
            goToLink("https://tesera.ru/images/items/125371/rules_indigo_rus.pdf");
        }
        private void rules2Button_Click(object sender, EventArgs e)
        {
            goToLink("https://cdn.ultraboardgames.com/indigo/game-rules.php");
        }
        public void goToLink(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void stScale_ValueChanged(object sender, EventArgs e)
        {
            percent = (float)stScale.Value / 100;
            scaleLabel.Text = "100 is for Full HD";
        }
        private void st2Players_Click(object sender, EventArgs e)
        {
            playerCount = 2;

            startButton.BackColor = Color.White;
        }
        private void st3Players_Click(object sender, EventArgs e)
        {
            playerCount = 3;

            startButton.BackColor = Color.Gray;
        }
        private void st4Players_Click(object sender, EventArgs e)
        {
            playerCount = 4;

            startButton.BackColor = Color.Gray;
        }

        private async void Connectection_button_Click(object sender, EventArgs e)
        {
            ConnectionButton.Enabled = false;   // prevent double-click

            _mp = new MultiplayerManager(_connectionString);

            _mp.OnRegistered += OnRegistered;
            _mp.OnGameStart += OnGameStart;
            _mp.OnLobbyRefresh += OnLobbyRefresh;
            _mp.OnGameClosed += OnGameClosed;
            _mp.OnError += OnError;

            // Pick a colour from a ComboBox / colour picker in your form:
            string color = /* ColorComboBox.SelectedItem?.ToString() ?? */ "White";

            await _mp.RegisterPlayerAsync(color);
        }
        private void OnRegistered(Guid id, string name)
        {
            // Always marshal back to the UI thread when touching controls.
            Invoke(() =>
            {
                StatusLabel.Text = $"Connected as {name}";
                StatusLabel.Visible = true;
                ReadyButton.Enabled = true;

                _ = RefreshLobbyAsync();
            });
        }
        private void OnGameStart()
        {
            Invoke(() =>
            {
                var gameForm = new GameForm(sizesOfObjects, percent - 0.1f, playerCount, _mp);
                gameForm.FormClosed += (s, args) => this.Show();
                gameForm.Show();
                this.Hide();
            });
        }
        private void OnLobbyRefresh()
        {
            Invoke(() => _ = RefreshLobbyAsync());
        }
        private void OnGameClosed()
        {
            Invoke(() =>
            {
                this.Show();
                StatusLabel.Text = "Host closed the game. Returning to lobby.";
                ReadyButton.Enabled = false;
                ReadyButton.Text = "Ready";
                _ = RefreshLobbyAsync();
            });
        }
        /*
        private void OnTurnReceived(Tile tile, string fromPlayerPrefix)
        {
            Invoke(() =>
            {
                // TODO: call your game logic to apply the incoming move.
                ApplyTurn(tile, fromPlayerPrefix);
            });
        }
        private void ApplyTurn(Tile tile, string fromPlayerPrefix)
        {
            // TODO: implement this with your real board/game logic.
            // tile.Id            – which tile was placed
            // tile.NumOfRotation – how many times it was rotated
            // tile.Index         – which palace/board slot it went to
            // fromPlayerPrefix   – first 8 chars of the sender's GUID

            StatusLabel.Text = $"Player {fromPlayerPrefix} placed tile {tile}";

            /* e.g.
               var boardTile = tileRegistry.GetById(tile.Id);
               boardTile.Rotate(tile.NumOfRotation);
               board.PlaceAt(boardTile, tile.Index);
               boardPanel.Invalidate();
            
        }
        */
        private void OnError(Exception ex)
        {
            Invoke(() =>
                MessageBox.Show(
                    $"Multiplayer error:\n{ex.Message}",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error));
        }
        private async Task RefreshLobbyAsync()
        {
            if (_mp is null) return;

            var players = await _mp.GetConnectedPlayersAsync();

            Invoke((Delegate)(() =>
            {
                LobbyListBox.Items.Clear();
                foreach (var p in players)
                    LobbyListBox.Items.Add(
                        $"{p.Name}  [{p.Color}]  {(p.IsReady ? "✓ Ready" : "Not ready")}");
            }));
        }

        private async void ReadyButton_Click(object sender, EventArgs e)
        {
            if (_mp is null) return;

            ReadyButton.Text = "Ready";
            ReadyButton.Enabled = false;
            StatusLabel.Text = "Waiting for other players…";

            await _mp.SetReadyAsync();
            _ = RefreshLobbyAsync();
        }

        private void TitleScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mp is null || _isClosing) return;

            e.Cancel = true;  // stop the close for now

            Task.Run(async () =>
            {
                await _mp.DisposeAsync();
                _mp = null;
                _isClosing = true;
                Invoke(Application.Exit);
            });
        }
    }
}
