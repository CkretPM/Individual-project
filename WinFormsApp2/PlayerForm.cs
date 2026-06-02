namespace Indigo
{
    public partial class PlayerForm : Form
    {
        public List<string> playerColors { get; set; } = [];

        int numOfPlayers;
        Label[] labels;
        string[] colors;
        public PlayerForm()
        {
            InitializeComponent();

            this.numOfPlayers = 2;
            labels = [playerLabel1, playerLabel2, playerLabel3, playerLabel4];
            colors = ["Blue", "Green", "Red", "Yellow"];
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            ChooseColor(0);
        }
        private void Green_Click(object sender, EventArgs e)
        {
            ChooseColor(1);
        }
        private void Red_Click(object sender, EventArgs e)
        {
            ChooseColor(2);
        }
        private void Yellow_Click(object sender, EventArgs e)
        {
            ChooseColor(3);
        }

        public void ChooseColor(int num)
        {
            string colorName = colors[num];
            Label label = labels[num];

            if (!label.Visible) // && playerColors.Count < numOfPlayers)
            {
                playerColors.Add(colorName);

                label.Visible = true;
                label.Text = "Player " + playerColors.Count;
            }
            else
            {
                playerColors.Remove(colorName);
                label.Visible = false;

                if (!playerColors.Any())
                    return;

                for (int i = 0; i < 4; i++)
                    if (labels[i].Visible)
                        labels[i].Text = "Player " + (playerColors.IndexOf(colors[i]) + 1);
            }

            /*
            if (playerColors.Count == numOfPlayers)
                doneButton.BackColor = Color.White;
            else
                doneButton.BackColor = Color.DarkGray;
            */
        }
        private void DoneButton_Click(object sender, EventArgs e)
        {
            //if (playerColors.Count == numOfPlayers)
                DialogResult = DialogResult.OK;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
