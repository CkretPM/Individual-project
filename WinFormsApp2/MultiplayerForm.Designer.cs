namespace Indigo
{
    partial class MultiplayerForm
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
            lobbyClearButton = new Button();
            choose_color_label = new Label();
            colorComboBox = new ComboBox();
            lobbyListBox = new ListBox();
            readyButton = new Button();
            statusLabel = new Label();
            connectionButton = new Button();
            setScale = new NumericUpDown();
            scaleLabel = new Label();
            label5 = new Label();
            backButton = new Button();
            ((System.ComponentModel.ISupportInitialize)setScale).BeginInit();
            SuspendLayout();
            // 
            // lobbyClearButton
            // 
            lobbyClearButton.BackColor = Color.Silver;
            lobbyClearButton.Enabled = false;
            lobbyClearButton.Location = new Point(197, 227);
            lobbyClearButton.Name = "lobbyClearButton";
            lobbyClearButton.Size = new Size(110, 47);
            lobbyClearButton.TabIndex = 39;
            lobbyClearButton.Text = "Clear lobby";
            lobbyClearButton.UseVisualStyleBackColor = false;
            lobbyClearButton.Click += LobbyClearButton_Click;
            // 
            // choose_color_label
            // 
            choose_color_label.BackColor = Color.Gray;
            choose_color_label.Font = new Font("Segoe UI", 12F);
            choose_color_label.Location = new Point(197, 167);
            choose_color_label.Name = "choose_color_label";
            choose_color_label.Size = new Size(144, 33);
            choose_color_label.TabIndex = 38;
            choose_color_label.Text = "Choose color:";
            choose_color_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colorComboBox
            // 
            colorComboBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            colorComboBox.FormattingEnabled = true;
            colorComboBox.ItemHeight = 25;
            colorComboBox.Items.AddRange(new object[] { "Blue", "Green", "Red", "Yellow" });
            colorComboBox.Location = new Point(400, 167);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(145, 33);
            colorComboBox.TabIndex = 37;
            colorComboBox.Text = "Blue";
            // 
            // lobbyListBox
            // 
            lobbyListBox.FormattingEnabled = true;
            lobbyListBox.Location = new Point(197, 378);
            lobbyListBox.Name = "lobbyListBox";
            lobbyListBox.Size = new Size(348, 84);
            lobbyListBox.TabIndex = 36;
            lobbyListBox.Visible = false;
            // 
            // readyButton
            // 
            readyButton.BackColor = Color.Silver;
            readyButton.Enabled = false;
            readyButton.Location = new Point(313, 227);
            readyButton.Name = "readyButton";
            readyButton.Size = new Size(110, 47);
            readyButton.TabIndex = 35;
            readyButton.Text = "Ready?";
            readyButton.UseVisualStyleBackColor = false;
            readyButton.Click += ReadyButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.BackColor = Color.Gray;
            statusLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            statusLabel.Location = new Point(197, 310);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(348, 56);
            statusLabel.TabIndex = 34;
            statusLabel.Text = "StatusLabel";
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Visible = false;
            // 
            // connectionButton
            // 
            connectionButton.Location = new Point(429, 227);
            connectionButton.Name = "connectionButton";
            connectionButton.Size = new Size(116, 47);
            connectionButton.TabIndex = 33;
            connectionButton.Text = "Connect to DB";
            connectionButton.UseVisualStyleBackColor = true;
            connectionButton.Click += ConnectectionButton_Click;
            // 
            // setScale
            // 
            setScale.Font = new Font("Segoe UI", 14F);
            setScale.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            setScale.Location = new Point(444, 95);
            setScale.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            setScale.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            setScale.Name = "setScale";
            setScale.Size = new Size(101, 39);
            setScale.TabIndex = 32;
            setScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            setScale.ValueChanged += SetScale_ValueChanged;
            // 
            // scaleLabel
            // 
            scaleLabel.BackColor = Color.Gray;
            scaleLabel.Font = new Font("Segoe UI", 12F);
            scaleLabel.Location = new Point(197, 96);
            scaleLabel.Name = "scaleLabel";
            scaleLabel.Size = new Size(232, 38);
            scaleLabel.TabIndex = 31;
            scaleLabel.Text = "Scale of the game: (%)";
            scaleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Gray;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(197, 24);
            label5.Name = "label5";
            label5.Size = new Size(348, 52);
            label5.TabIndex = 40;
            label5.Text = "Multiplayer ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.BackColor = Color.White;
            backButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            backButton.Location = new Point(379, 488);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(166, 80);
            backButton.TabIndex = 41;
            backButton.Text = "Back to the \r\ntitle screen";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += BackButton_Click;
            // 
            // MultiplayerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(747, 601);
            Controls.Add(backButton);
            Controls.Add(label5);
            Controls.Add(lobbyClearButton);
            Controls.Add(choose_color_label);
            Controls.Add(colorComboBox);
            Controls.Add(lobbyListBox);
            Controls.Add(readyButton);
            Controls.Add(statusLabel);
            Controls.Add(connectionButton);
            Controls.Add(setScale);
            Controls.Add(scaleLabel);
            Name = "MultiplayerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MultiplayerForm";
            FormClosing += MultiplayerForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)setScale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button lobbyClearButton;
        private Label choose_color_label;
        private ComboBox colorComboBox;
        private ListBox lobbyListBox;
        private Button readyButton;
        private Label statusLabel;
        private Button connectionButton;
        private NumericUpDown setScale;
        private Label scaleLabel;
        private Label label5;
        private Button backButton;
    }
}