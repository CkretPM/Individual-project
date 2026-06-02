namespace Indigo
{
    public partial class MultiplayerForm : Form
    {
        List<string> colors = [];
        float percent = 1;

        int[] sizesOfObjects = [];

        private readonly string _connectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Database=gamedb;" +
            "Username=gameuser;" +
            "Password=gamepass;";

        private MultiplayerManager? _mp;

        private bool _isClosing = false;

        public MultiplayerForm(int[] sizesOfObjects)
        {
            this.sizesOfObjects = sizesOfObjects;

            InitializeComponent();
        }

        private void SetScale_ValueChanged(object sender, EventArgs e)
        {
            percent = (float)setScale.Value / 100;
            scaleLabel.Text = "100 is for Full HD";
        }

        private async void ConnectectionButton_Click(object sender, EventArgs e)
        {
            connectionButton.Enabled = false;   // prevent double-click

            if (_mp is null)
            {
                _mp = new MultiplayerManager(_connectionString);

                _mp.OnRegistered += OnRegistered;
                _mp.OnGameStart += OnGameStart;
                _mp.OnLobbyRefresh += OnLobbyRefresh;
                _mp.OnGameClosed += OnGameClosed;
                _mp.OnError += OnError;
            }

            string color = colorComboBox.SelectedItem?.ToString() ?? "Blue";

            bool success = await _mp.RegisterPlayerAsync(color);

            if (!success)
            {
                connectionButton.Enabled = true;
                return;
            }
        }
        private async void ReadyButton_Click(object sender, EventArgs e)
        {
            if (_mp is null) return;

            readyButton.Text = "Ready";
            readyButton.Enabled = false;
            statusLabel.Text = "Waiting for other players…";

            await _mp.SetReadyAsync();
            _ = RefreshLobbyAsync();
        }
        private async void LobbyClearButton_Click(object sender, EventArgs e)
        {
            if (_mp is null) return;

            await _mp.LobbyClearAsync();
            statusLabel.Text = "Disconnected from the lobby";

            connectionButton.Enabled = true;

            lobbyClearButton.BackColor = Color.Silver;
            readyButton.BackColor = Color.Silver;
            readyButton.Text = "Ready?";


            _ = RefreshLobbyAsync();
        }

        private void OnRegistered(Guid id, string name)
        {
            // Always marshal back to the UI thread when touching controls.
            Invoke(() =>
            {
                statusLabel.Text = $"Connected as {name}";
                statusLabel.Visible = true;
                lobbyListBox.Visible = true;
                readyButton.Enabled = true;
                readyButton.BackColor = Color.LightGreen;

                lobbyClearButton.Enabled = true;
                lobbyClearButton.BackColor = Color.White;


                _ = RefreshLobbyAsync();
            });
        }
        private async void OnGameStart()
        {
            if (_mp is null) return;

            colors.Clear();
            var players = await _mp.GetConnectedPlayersAsync();

            foreach (var p in players)
                colors.Add(p.Color);

            Invoke(() =>
            {
                var gameForm = new GameForm(sizesOfObjects, percent - 0.1f, colors, _mp);
                gameForm.FormClosed += (s, args) => this.Show();
                gameForm.Show();
                this.Hide();

                connectionButton.Enabled = true;
            });
        }
        private void OnLobbyRefresh()
        {
            Invoke(() =>
            {
                _ = RefreshLobbyAsync();
                connectionButton.Enabled = true;
            });
        }
        private void OnGameClosed()
        {
            Invoke(() =>
            {
                Show();
                statusLabel.Text = "Host closed the game";
                readyButton.Enabled = true;
                readyButton.Text = "Ready";
                _ = RefreshLobbyAsync();
            });
        }
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
                lobbyListBox.Items.Clear();
                foreach (var p in players)
                    lobbyListBox.Items.Add(
                        $"{p.Name}  [{p.Color}]  {(p.IsReady ? "✓ Ready" : "Not ready")}");
            }));
        }


        private void MultiplayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mp is null || _isClosing) return;

            e.Cancel = true;

            Task.Run(async () =>
            {
                await _mp.DisposeAsync();
                _mp = null;
                _isClosing = true;
                Invoke(() => Close());
            });
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
