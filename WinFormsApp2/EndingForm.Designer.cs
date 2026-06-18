namespace Indigo
{
    partial class EndingForm
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
            backButton = new Button();
            reviewButton = new Button();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.BackColor = Color.White;
            backButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            backButton.Location = new Point(436, 333);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(182, 80);
            backButton.TabIndex = 42;
            backButton.Text = "Back to the \r\ngame board";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += BackButton_Click;
            // 
            // reviewButton
            // 
            reviewButton.AutoSize = true;
            reviewButton.BackColor = Color.White;
            reviewButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            reviewButton.Location = new Point(183, 333);
            reviewButton.Margin = new Padding(3, 2, 3, 2);
            reviewButton.Name = "reviewButton";
            reviewButton.Size = new Size(182, 80);
            reviewButton.TabIndex = 43;
            reviewButton.Text = "Review played \r\ngame";
            reviewButton.UseVisualStyleBackColor = false;
            reviewButton.Click += ReviewButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.BackColor = Color.Gray;
            resultLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            resultLabel.Location = new Point(284, 89);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(234, 127);
            resultLabel.TabIndex = 44;
            resultLabel.Text = "You've ";
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EndingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(resultLabel);
            Controls.Add(reviewButton);
            Controls.Add(backButton);
            Name = "EndingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EndingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Button reviewButton;
        private Label resultLabel;
    }
}