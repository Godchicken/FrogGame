namespace HappyJumpingFrog
{
    partial class FormHighScore
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
            this.listBoxScores = new System.Windows.Forms.ListBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(50, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(300, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Top 5";
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxScores
            // 
            this.listBoxScores.Location = new System.Drawing.Point(40, 65);
            this.listBoxScores.Name = "listBoxScores";
            this.listBoxScores.Size = new System.Drawing.Size(320, 200);
            this.listBoxScores.TabIndex = 1;
            this.listBoxScores.FormattingEnabled = true;
            this.listBoxScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(140, 295);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 40);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // FormHighScore
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.listBoxScores);
            this.Controls.Add(this.buttonBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FormHighScore";
            this.Text = "High Score";
            this.Load += new System.EventHandler(this.FormHighScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox listBoxScores;
        private System.Windows.Forms.Button buttonBack;
    }
}
