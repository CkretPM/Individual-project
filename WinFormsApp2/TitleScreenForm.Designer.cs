namespace Indigo
{
    partial class TitleScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startButton = new Button();
            label2 = new Label();
            scaleLabel = new Label();
            stScale = new NumericUpDown();
            label1 = new Label();
            videoButton = new Button();
            rulesButton = new Button();
            label3 = new Label();
            connectionButton = new Button();
            statusLabel = new Label();
            readyButton = new Button();
            lobbyListBox = new ListBox();
            languageComboBox = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            colorComboBox = new ComboBox();
            choose_color_label = new Label();
            lobbyClearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)stScale).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startButton.Location = new Point(252, 663);
            startButton.Name = "startButton";
            startButton.Size = new Size(227, 48);
            startButton.TabIndex = 1;
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Gray;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(252, 589);
            label2.Name = "label2";
            label2.Size = new Size(227, 52);
            label2.TabIndex = 7;
            label2.Text = "Single-player";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scaleLabel
            // 
            scaleLabel.BackColor = Color.Gray;
            scaleLabel.Font = new Font("Segoe UI", 12F);
            scaleLabel.Location = new Point(604, 334);
            scaleLabel.Name = "scaleLabel";
            scaleLabel.Size = new Size(211, 38);
            scaleLabel.TabIndex = 13;
            scaleLabel.Text = "Scale of the game: (%)";
            scaleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // stScale
            // 
            stScale.Font = new Font("Segoe UI", 14F);
            stScale.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            stScale.Location = new Point(824, 334);
            stScale.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            stScale.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            stScale.Name = "stScale";
            stScale.Size = new Size(101, 39);
            stScale.TabIndex = 14;
            stScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            stScale.ValueChanged += StScale_ValueChanged;
            // 
            // label1
            // 
            label1.BackColor = Color.Gray;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(214, 334);
            label1.Name = "label1";
            label1.Size = new Size(321, 52);
            label1.TabIndex = 15;
            label1.Text = "Game Rules:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // videoButton
            // 
            videoButton.Font = new Font("Segoe UI", 12F);
            videoButton.Location = new Point(390, 456);
            videoButton.Name = "videoButton";
            videoButton.Size = new Size(145, 40);
            videoButton.TabIndex = 17;
            videoButton.Text = "Video";
            videoButton.UseVisualStyleBackColor = true;
            videoButton.Click += Video1Button_Click;
            // 
            // rulesButton
            // 
            rulesButton.Font = new Font("Segoe UI", 12F);
            rulesButton.Location = new Point(214, 456);
            rulesButton.Name = "rulesButton";
            rulesButton.Size = new Size(145, 40);
            rulesButton.TabIndex = 19;
            rulesButton.Text = "Rulebook";
            rulesButton.UseVisualStyleBackColor = true;
            rulesButton.Click += Rules1Button_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Gray;
            label3.Font = new Font("Times New Roman", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(379, 82);
            label3.Name = "label3";
            label3.Size = new Size(405, 201);
            label3.TabIndex = 20;
            label3.Text = "Indigo";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // connectionButton
            // 
            connectionButton.Location = new Point(604, 701);
            connectionButton.Name = "connectionButton";
            connectionButton.Size = new Size(116, 47);
            connectionButton.TabIndex = 21;
            connectionButton.Text = "Connect to DB";
            connectionButton.UseVisualStyleBackColor = true;
            connectionButton.Click += Connectection_button_Click;
            // 
            // statusLabel
            // 
            statusLabel.BackColor = Color.Gray;
            statusLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            statusLabel.Location = new Point(604, 400);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(321, 33);
            statusLabel.TabIndex = 22;
            statusLabel.Text = "StatusLabel";
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Visible = false;
            // 
            // readyButton
            // 
            readyButton.BackColor = Color.Silver;
            readyButton.Enabled = false;
            readyButton.Location = new Point(726, 701);
            readyButton.Name = "readyButton";
            readyButton.Size = new Size(110, 47);
            readyButton.TabIndex = 23;
            readyButton.Text = "Ready?";
            readyButton.UseVisualStyleBackColor = false;
            readyButton.Click += ReadyButton_Click;
            // 
            // lobbyListBox
            // 
            lobbyListBox.FormattingEnabled = true;
            lobbyListBox.Location = new Point(604, 452);
            lobbyListBox.Name = "lobbyListBox";
            lobbyListBox.Size = new Size(321, 84);
            lobbyListBox.TabIndex = 24;
            lobbyListBox.Visible = false;
            // 
            // languageComboBox
            // 
            languageComboBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            languageComboBox.FormattingEnabled = true;
            languageComboBox.ItemHeight = 25;
            languageComboBox.Items.AddRange(new object[] { "English", "Russian" });
            languageComboBox.Location = new Point(390, 406);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(145, 33);
            languageComboBox.TabIndex = 25;
            languageComboBox.Text = "English";
            languageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.BackColor = Color.Gray;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(214, 400);
            label4.Name = "label4";
            label4.Size = new Size(145, 39);
            label4.TabIndex = 26;
            label4.Text = "Language:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Gray;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(604, 570);
            label5.Name = "label5";
            label5.Size = new Size(348, 52);
            label5.TabIndex = 27;
            label5.Text = "Multiplayer ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colorComboBox
            // 
            colorComboBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            colorComboBox.FormattingEnabled = true;
            colorComboBox.ItemHeight = 25;
            colorComboBox.Items.AddRange(new object[] { "Blue", "Green", "Red", "Yellow" });
            colorComboBox.Location = new Point(807, 641);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(145, 33);
            colorComboBox.TabIndex = 28;
            colorComboBox.Text = "Blue";
            // 
            // choose_color_label
            // 
            choose_color_label.BackColor = Color.Gray;
            choose_color_label.Font = new Font("Segoe UI", 12F);
            choose_color_label.Location = new Point(604, 641);
            choose_color_label.Name = "choose_color_label";
            choose_color_label.Size = new Size(144, 33);
            choose_color_label.TabIndex = 29;
            choose_color_label.Text = "Choose color:";
            choose_color_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lobbyClearButton
            // 
            lobbyClearButton.BackColor = Color.Silver;
            lobbyClearButton.Enabled = false;
            lobbyClearButton.Location = new Point(842, 701);
            lobbyClearButton.Name = "lobbyClearButton";
            lobbyClearButton.Size = new Size(110, 47);
            lobbyClearButton.TabIndex = 30;
            lobbyClearButton.Text = "Clear lobby";
            lobbyClearButton.UseVisualStyleBackColor = false;
            lobbyClearButton.Click += LobbyClearButton_Click;
            // 
            // TitleScreenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1125, 815);
            Controls.Add(lobbyClearButton);
            Controls.Add(choose_color_label);
            Controls.Add(colorComboBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(languageComboBox);
            Controls.Add(lobbyListBox);
            Controls.Add(readyButton);
            Controls.Add(statusLabel);
            Controls.Add(connectionButton);
            Controls.Add(label3);
            Controls.Add(rulesButton);
            Controls.Add(videoButton);
            Controls.Add(label1);
            Controls.Add(stScale);
            Controls.Add(scaleLabel);
            Controls.Add(label2);
            Controls.Add(startButton);
            Name = "TitleScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TitleScreenForm";
            FormClosing += TitleScreenForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)stScale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private Label label2;
        private Label scaleLabel;
        private NumericUpDown stScale;
        private Label label1;
        private Button videoButton;
        private Button rulesButton;
        private Label label3;
        private Button connectionButton;
        private Label statusLabel;
        private Button readyButton;
        private ListBox lobbyListBox;
        private ComboBox languageComboBox;
        private Label label4;
        private Label label5;
        private ComboBox colorComboBox;
        private Label choose_color_label;
        private Button lobbyClearButton;
    }
}