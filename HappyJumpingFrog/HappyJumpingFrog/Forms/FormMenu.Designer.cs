namespace HappyJumpingFrog
{
    partial class FormMenu
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonHighScore = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.Location = new System.Drawing.Point(110, 120);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(180, 44);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonHighScore
            // 
            this.buttonHighScore.BackColor = System.Drawing.Color.Transparent;
            this.buttonHighScore.Location = new System.Drawing.Point(110, 180);
            this.buttonHighScore.Name = "buttonHighScore";
            this.buttonHighScore.Size = new System.Drawing.Size(180, 44);
            this.buttonHighScore.TabIndex = 2;
            this.buttonHighScore.Text = "High Score";
            this.buttonHighScore.UseVisualStyleBackColor = false;
            this.buttonHighScore.Click += new System.EventHandler(this.buttonHighScore_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(110, 240);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(180, 44);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::HappyJumpingFrog.Properties.Resources.LINE_ALBUM_171069_261024_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 360);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonHighScore);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Happy Jumping Frog";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonHighScore;
        private System.Windows.Forms.Button buttonExit;
    }
}
