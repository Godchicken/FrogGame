namespace HappyJumpingFrog
{
    partial class FormGameOver
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
            this.buttonTryAgain = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(300, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Game Over";
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScoreCaption
            // 
            this.labelScoreCaption.Location = new System.Drawing.Point(20, 70);
            this.labelScoreCaption.Name = "labelScoreCaption";
            this.labelScoreCaption.Size = new System.Drawing.Size(300, 23);
            this.labelScoreCaption.TabIndex = 1;
            this.labelScoreCaption.Text = "Your score";
            this.labelScoreCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelScoreCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFinalScore
            // 
            this.labelFinalScore.Location = new System.Drawing.Point(20, 95);
            this.labelFinalScore.Name = "labelFinalScore";
            this.labelFinalScore.Size = new System.Drawing.Size(300, 36);
            this.labelFinalScore.TabIndex = 2;
            this.labelFinalScore.Text = "0";
            this.labelFinalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelFinalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTryAgain
            // 
            this.buttonTryAgain.Location = new System.Drawing.Point(40, 160);
            this.buttonTryAgain.Name = "buttonTryAgain";
            this.buttonTryAgain.Size = new System.Drawing.Size(120, 40);
            this.buttonTryAgain.TabIndex = 3;
            this.buttonTryAgain.Text = "Try Again";
            this.buttonTryAgain.UseVisualStyleBackColor = true;
            this.buttonTryAgain.DialogResult = System.Windows.Forms.DialogResult.Retry;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(180, 160);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(120, 40);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "Submit Score";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // FormGameOver
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(340, 240);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelScoreCaption);
            this.Controls.Add(this.labelFinalScore);
            this.Controls.Add(this.buttonTryAgain);
            this.Controls.Add(this.buttonSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FormGameOver";
            this.Text = "Game Over";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelScoreCaption;
        private System.Windows.Forms.Label labelFinalScore;
        private System.Windows.Forms.Button buttonTryAgain;
        private System.Windows.Forms.Button buttonSubmit;
    }
}
