namespace Indigo
{
    public partial class EndingForm : Form
    {
        private readonly int[] _sizesOfObjects;
        private readonly float _percent;
        private readonly List<string>? _playerColors;
        private readonly MultiplayerManager? _mp;

        // Pass these in from wherever you create WinLoseForm
        public EndingForm(int[] sizesOfObjects, float percent, List<string>? playerColors, MultiplayerManager? mp)
        {
            InitializeComponent();
            _sizesOfObjects = sizesOfObjects;
            _percent = percent;
            _playerColors = playerColors;
            _mp = mp;
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            if (_mp is null)
            {
                MessageBox.Show("No multiplayer session to review.");
                return;
            }

            // Open GameForm in review mode — no mp passed so no live multiplayer
            var reviewForm = new GameForm(_sizesOfObjects, _percent, _playerColors);

            reviewForm.FormClosed += (s, args) => this.Show();
            reviewForm.Show();
            Hide();

            // Start the replay after the form is fully shown
            reviewForm.Shown += async (s, args) =>
            {
                await reviewForm.StartReviewAsync(_mp, intervalMs: 5000);
            };
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
