namespace Indigo
{
    public partial class EndingForm : Form
    {
        private readonly int[] _sizesOfObjects;
        private readonly float _percent;
        private readonly List<string>? _playerColors;
        private readonly MultiplayerManager? _mp;

        // Pass these in from wherever you create WinLoseForm
        public EndingForm(int[] sizesOfObjects, float percent, List<string>? playerColors, MultiplayerManager? mp, bool youWon)
        {
            InitializeComponent();

            _sizesOfObjects = sizesOfObjects;
            _percent = percent;
            _playerColors = playerColors;
            _mp = mp;

            if (youWon)
            {
                resultLabel.Text += "won!";
                resultLabel.BackColor = Color.Green;
            }
            else
                resultLabel.Text += "lost";
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            if (_mp is null)
            {
                MessageBox.Show(
                    "No multiplayer session available to review.",
                    "Review unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var gameForm = Application.OpenForms.OfType<GameForm>().FirstOrDefault();
            gameForm?.Hide();
            this.Hide();

            var reviewForm = new GameForm(_sizesOfObjects, _percent, _playerColors);

            reviewForm.FormClosed += (s, args) =>
            {
                gameForm?.Show();
                this.Show();
            };

            reviewForm.Show();
            reviewForm.Shown += async (s, args) =>
            {
                await reviewForm.StartReviewAsync(_mp, intervalMs: 1000);
            };
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
