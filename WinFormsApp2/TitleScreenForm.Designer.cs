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
            startSPGameButton = new Button();
            label2 = new Label();
            scaleLabel = new Label();
            setScale = new NumericUpDown();
            label1 = new Label();
            videoButton = new Button();
            rulesButton = new Button();
            label3 = new Label();
            languageComboBox = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            startMPGameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)setScale).BeginInit();
            SuspendLayout();
            // 
            // startSPGameButton
            // 
            startSPGameButton.AutoSize = true;
            startSPGameButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startSPGameButton.Location = new Point(262, 638);
            startSPGameButton.Name = "startSPGameButton";
            startSPGameButton.Size = new Size(227, 48);
            startSPGameButton.TabIndex = 1;
            startSPGameButton.Text = "Play";
            startSPGameButton.UseVisualStyleBackColor = true;
            startSPGameButton.Click += StartSPGameButton_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Gray;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(262, 564);
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
            scaleLabel.Location = new Point(605, 406);
            scaleLabel.Name = "scaleLabel";
            scaleLabel.Size = new Size(211, 38);
            scaleLabel.TabIndex = 13;
            scaleLabel.Text = "Scale of the game: (%)";
            scaleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // setScale
            // 
            setScale.Font = new Font("Segoe UI", 14F);
            setScale.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            setScale.Location = new Point(825, 406);
            setScale.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            setScale.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            setScale.Name = "setScale";
            setScale.Size = new Size(101, 39);
            setScale.TabIndex = 14;
            setScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            setScale.ValueChanged += SetScale_ValueChanged;
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
            videoButton.Click += VideoButton_Click;
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
            rulesButton.Click += RulesButton_Click;
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
            label5.Location = new Point(659, 564);
            label5.Name = "label5";
            label5.Size = new Size(227, 52);
            label5.TabIndex = 27;
            label5.Text = "Multiplayer ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startMPGameButton
            // 
            startMPGameButton.AutoSize = true;
            startMPGameButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startMPGameButton.Location = new Point(659, 638);
            startMPGameButton.Name = "startMPGameButton";
            startMPGameButton.Size = new Size(227, 48);
            startMPGameButton.TabIndex = 31;
            startMPGameButton.Text = "Play";
            startMPGameButton.UseVisualStyleBackColor = true;
            startMPGameButton.Click += StartMPGameButton_Click;
            // 
            // TitleScreenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1125, 815);
            Controls.Add(startMPGameButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(languageComboBox);
            Controls.Add(label3);
            Controls.Add(rulesButton);
            Controls.Add(videoButton);
            Controls.Add(label1);
            Controls.Add(setScale);
            Controls.Add(scaleLabel);
            Controls.Add(label2);
            Controls.Add(startSPGameButton);
            Name = "TitleScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TitleScreenForm";
            ((System.ComponentModel.ISupportInitialize)setScale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startSPGameButton;
        private Label label2;
        private Label scaleLabel;
        private NumericUpDown setScale;
        private Label label1;
        private Button videoButton;
        private Button rulesButton;
        private Label label3;
        private ComboBox languageComboBox;
        private Label label4;
        private Label label5;
        private Button startMPGameButton;
    }
}