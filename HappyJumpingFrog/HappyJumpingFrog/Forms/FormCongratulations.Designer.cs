namespace HappyJumpingFrog
{
    partial class FormCongratulations
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelScoreCaption = new System.Windows.Forms.Label();
            this.labelFinalScore = new System.Windows.Forms.Label();
            this.buttonPlayAgain = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(102, 38);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(117, 29);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "You Win!";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScoreCaption
            // 
            this.labelScoreCaption.AutoSize = true;
            this.labelScoreCaption.BackColor = System.Drawing.Color.Transparent;
            this.labelScoreCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelScoreCaption.Location = new System.Drawing.Point(102, 67);
            this.labelScoreCaption.Name = "labelScoreCaption";
            this.labelScoreCaption.Size = new System.Drawing.Size(106, 25);
            this.labelScoreCaption.TabIndex = 1;
            this.labelScoreCaption.Text = "Your score";
            this.labelScoreCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFinalScore
            // 
            this.labelFinalScore.AutoSize = true;
            this.labelFinalScore.BackColor = System.Drawing.Color.Transparent;
            this.labelFinalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelFinalScore.Location = new System.Drawing.Point(147, 92);
            this.labelFinalScore.Name = "labelFinalScore";
            this.labelFinalScore.Size = new System.Drawing.Size(27, 29);
            this.labelFinalScore.TabIndex = 2;
            this.labelFinalScore.Text = "0";
            this.labelFinalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPlayAgain
            // 
            this.buttonPlayAgain.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.buttonPlayAgain.Location = new System.Drawing.Point(39, 124);
            this.buttonPlayAgain.Name = "buttonPlayAgain";
            this.buttonPlayAgain.Size = new System.Drawing.Size(120, 40);
            this.buttonPlayAgain.TabIndex = 3;
            this.buttonPlayAgain.Text = "Play Again";
            this.buttonPlayAgain.UseVisualStyleBackColor = true;
            this.buttonPlayAgain.Click += new System.EventHandler(this.buttonPlayAgain_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSubmit.Location = new System.Drawing.Point(165, 124);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(120, 40);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "Submit Score";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // FormCongratulations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::HappyJumpingFrog.Properties.Resources.congrats;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(340, 240);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelScoreCaption);
            this.Controls.Add(this.labelFinalScore);
            this.Controls.Add(this.buttonPlayAgain);
            this.Controls.Add(this.buttonSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCongratulations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Congratulations!";
            this.Load += new System.EventHandler(this.FormCongratulations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelScoreCaption;
        private System.Windows.Forms.Label labelFinalScore;
        private System.Windows.Forms.Button buttonPlayAgain;
        private System.Windows.Forms.Button buttonSubmit;
    }
}
