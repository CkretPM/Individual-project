using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Indigo
{
    public partial class TitleScreenForm : Form
    {
        int playerCount = 2;
        List<string> colors = [];
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
        string videoLink = "https://www.youtube.com/watch?v=LJwy7qXWuNI&t=38s";
        string rulesLink = "https://cdn.ultraboardgames.com/indigo/game-rules.php";

        public TitleScreenForm()
        {
            InitializeComponent();
        }

        private void Video1Button_Click(object sender, EventArgs e)
        {
            GoToLink(videoLink);
        }
        private void Rules1Button_Click(object sender, EventArgs e)
        {
            GoToLink(rulesLink);
        }
        public static void GoToLink(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (languageComboBox.SelectedIndex)
            {
                case 0:
                    videoLink = "https://www.youtube.com/watch?v=LJwy7qXWuNI&t=38s";
                    rulesLink = "https://cdn.ultraboardgames.com/indigo/game-rules.php";
                    break;
                case 1:
                    videoLink = "https://www.youtube.com/watch?v=I7kXYYuxgro&t=47s";
                    rulesLink = "https://tesera.ru/images/items/125371/rules_indigo_rus.pdf";
                    break;
                default:
                    break;
            }
        }

        private void StScale_ValueChanged(object sender, EventArgs e)
        {
            percent = (float)stScale.Value / 100;
            scaleLabel.Text = "100 is for Full HD";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm(sizesOfObjects, percent - 0.1f, null, null);

            gameForm.FormClosed += (s, args) => this.Show();

            gameForm.Show();
            this.Hide();

            scaleLabel.Text = "Game scale: (%)";
        }
        private async void Connectection_button_Click(object sender, EventArgs e)
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
                this.Show();
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


        private void TitleScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mp is null || _isClosing) return;

            e.Cancel = true;

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
