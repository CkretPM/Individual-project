using System.Diagnostics;

namespace Indigo
{
    public partial class TitleScreenForm : Form
    {
        readonly List<string> colors = [];
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

        private bool _isClosing = false;
        string videoLink = "https://www.youtube.com/watch?v=LJwy7qXWuNI&t=38s";
        string rulesLink = "https://cdn.ultraboardgames.com/indigo/game-rules.php";

        public TitleScreenForm()
        {
            InitializeComponent();
        }

        private void VideoButton_Click(object sender, EventArgs e)
        {
            GoToLink(videoLink);
        }
        private void RulesButton_Click(object sender, EventArgs e)
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

        private void SetScale_ValueChanged(object sender, EventArgs e)
        {
            percent = (float)setScale.Value / 100;
            scaleLabel.Text = "100 is for Full HD";
        }

        private void StartSPGameButton_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm(sizesOfObjects, percent - 0.1f);

            gameForm.FormClosed += (s, args) => Show();

            gameForm.Show();
            Hide();

            scaleLabel.Text = "Game scale: (%)";
        }

        private void StartMPGameButton_Click(object sender, EventArgs e)
        {
            var multiplayerForm = new MultiplayerForm(sizesOfObjects);

            multiplayerForm.FormClosed += (s, args) => Show();

            multiplayerForm.Show();
            Hide();

            scaleLabel.Text = "Game scale: (%)";
        }
    }
}
