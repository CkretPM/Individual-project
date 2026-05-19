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
            st2Players = new Button();
            st3Players = new Button();
            st4Players = new Button();
            scaleLabel = new Label();
            stScale = new NumericUpDown();
            label1 = new Label();
            video1Button = new Button();
            video2Button = new Button();
            rules1Button = new Button();
            rules2Button = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)stScale).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startButton.Location = new Point(1159, 934);
            startButton.Margin = new Padding(4, 4, 4, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(219, 66);
            startButton.TabIndex = 1;
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Gray;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(729, 781);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(401, 65);
            label2.TabIndex = 7;
            label2.Text = "Settings:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // st2Players
            // 
            st2Players.BackColor = Color.FromArgb(192, 255, 192);
            st2Players.Font = new Font("Segoe UI", 12F);
            st2Players.Location = new Point(729, 875);
            st2Players.Margin = new Padding(4, 4, 4, 4);
            st2Players.Name = "st2Players";
            st2Players.Size = new Size(126, 50);
            st2Players.TabIndex = 8;
            st2Players.Text = "2 Players";
            st2Players.UseVisualStyleBackColor = false;
            st2Players.Click += st2Players_Click;
            // 
            // st3Players
            // 
            st3Players.BackColor = Color.FromArgb(255, 192, 192);
            st3Players.Font = new Font("Segoe UI", 12F);
            st3Players.Location = new Point(868, 875);
            st3Players.Margin = new Padding(4, 4, 4, 4);
            st3Players.Name = "st3Players";
            st3Players.Size = new Size(126, 50);
            st3Players.TabIndex = 9;
            st3Players.Text = "3 Players";
            st3Players.UseVisualStyleBackColor = false;
            st3Players.Click += st3Players_Click;
            // 
            // st4Players
            // 
            st4Players.BackColor = Color.FromArgb(255, 192, 192);
            st4Players.Font = new Font("Segoe UI", 12F);
            st4Players.Location = new Point(1004, 875);
            st4Players.Margin = new Padding(4, 4, 4, 4);
            st4Players.Name = "st4Players";
            st4Players.Size = new Size(126, 50);
            st4Players.TabIndex = 10;
            st4Players.Text = "4 Players";
            st4Players.UseVisualStyleBackColor = false;
            st4Players.Click += st4Players_Click;
            // 
            // scaleLabel
            // 
            scaleLabel.BackColor = Color.Gray;
            scaleLabel.Font = new Font("Segoe UI", 12F);
            scaleLabel.Location = new Point(729, 948);
            scaleLabel.Margin = new Padding(4, 0, 4, 0);
            scaleLabel.Name = "scaleLabel";
            scaleLabel.Size = new Size(264, 48);
            scaleLabel.TabIndex = 13;
            scaleLabel.Text = "Game scale: (%)";
            scaleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // stScale
            // 
            stScale.Font = new Font("Segoe UI", 14F);
            stScale.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            stScale.Location = new Point(1004, 948);
            stScale.Margin = new Padding(4, 4, 4, 4);
            stScale.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            stScale.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            stScale.Name = "stScale";
            stScale.Size = new Size(126, 45);
            stScale.TabIndex = 14;
            stScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            stScale.ValueChanged += stScale_ValueChanged;
            // 
            // label1
            // 
            label1.BackColor = Color.Gray;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(268, 781);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(401, 65);
            label1.TabIndex = 15;
            label1.Text = "Game Rules:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // video1Button
            // 
            video1Button.Font = new Font("Segoe UI", 12F);
            video1Button.Location = new Point(488, 875);
            video1Button.Margin = new Padding(4, 4, 4, 4);
            video1Button.Name = "video1Button";
            video1Button.Size = new Size(181, 50);
            video1Button.TabIndex = 16;
            video1Button.Text = "Video (Rus)";
            video1Button.UseVisualStyleBackColor = true;
            video1Button.Click += video1Button_Click;
            // 
            // video2Button
            // 
            video2Button.Font = new Font("Segoe UI", 12F);
            video2Button.Location = new Point(268, 875);
            video2Button.Margin = new Padding(4, 4, 4, 4);
            video2Button.Name = "video2Button";
            video2Button.Size = new Size(181, 50);
            video2Button.TabIndex = 17;
            video2Button.Text = "Video (Eng)";
            video2Button.UseVisualStyleBackColor = true;
            video2Button.Click += video2Button_Click;
            // 
            // rules1Button
            // 
            rules1Button.Font = new Font("Segoe UI", 12F);
            rules1Button.Location = new Point(488, 945);
            rules1Button.Margin = new Padding(4, 4, 4, 4);
            rules1Button.Name = "rules1Button";
            rules1Button.Size = new Size(181, 50);
            rules1Button.TabIndex = 18;
            rules1Button.Text = "Rules (Rus)";
            rules1Button.UseVisualStyleBackColor = true;
            rules1Button.Click += rules1Button_Click;
            // 
            // rules2Button
            // 
            rules2Button.Font = new Font("Segoe UI", 12F);
            rules2Button.Location = new Point(268, 945);
            rules2Button.Margin = new Padding(4, 4, 4, 4);
            rules2Button.Name = "rules2Button";
            rules2Button.Size = new Size(181, 50);
            rules2Button.TabIndex = 19;
            rules2Button.Text = "Rules (Eng)";
            rules2Button.UseVisualStyleBackColor = true;
            rules2Button.Click += rules2Button_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Gray;
            label3.Font = new Font("Times New Roman", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(466, 255);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(467, 251);
            label3.TabIndex = 20;
            label3.Text = "Indigo";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TitleScreenForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1406, 1019);
            Controls.Add(label3);
            Controls.Add(rules2Button);
            Controls.Add(rules1Button);
            Controls.Add(video2Button);
            Controls.Add(video1Button);
            Controls.Add(label1);
            Controls.Add(stScale);
            Controls.Add(scaleLabel);
            Controls.Add(st4Players);
            Controls.Add(st3Players);
            Controls.Add(st2Players);
            Controls.Add(label2);
            Controls.Add(startButton);
            Margin = new Padding(4, 4, 4, 4);
            Name = "TitleScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TitleScreenForm";
            ((System.ComponentModel.ISupportInitialize)stScale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private Label label2;
        private Button st2Players;
        private Button st3Players;
        private Button st4Players;
        private Label scaleLabel;
        private NumericUpDown stScale;
        private Label label1;
        private Button video1Button;
        private Button video2Button;
        private Button rules1Button;
        private Button rules2Button;
        private Label label3;
    }
}