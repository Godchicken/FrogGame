namespace HappyJumpingFrog
{
    partial class PauseDialog
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
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonSound = new System.Windows.Forms.Button();
            this.buttonMusic = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitle.Location = new System.Drawing.Point(50, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Paused";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonContinue
            // 
            this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonContinue.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Bold);
            this.buttonContinue.ForeColor = System.Drawing.Color.Green;
            this.buttonContinue.Location = new System.Drawing.Point(80, 70);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(140, 36);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonSound
            // 
            this.buttonSound.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Bold);
            this.buttonSound.ForeColor = System.Drawing.Color.Green;
            this.buttonSound.Location = new System.Drawing.Point(80, 115);
            this.buttonSound.Name = "buttonSound";
            this.buttonSound.Size = new System.Drawing.Size(140, 36);
            this.buttonSound.TabIndex = 2;
            this.buttonSound.Text = "Sound: On";
            this.buttonSound.UseVisualStyleBackColor = true;
            this.buttonSound.Click += new System.EventHandler(this.buttonSound_Click);
            // 
            // buttonMusic
            // 
            this.buttonMusic.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Bold);
            this.buttonMusic.ForeColor = System.Drawing.Color.Green;
            this.buttonMusic.Location = new System.Drawing.Point(80, 160);
            this.buttonMusic.Name = "buttonMusic";
            this.buttonMusic.Size = new System.Drawing.Size(140, 36);
            this.buttonMusic.TabIndex = 3;
            this.buttonMusic.Text = "Music: On";
            this.buttonMusic.UseVisualStyleBackColor = true;
            this.buttonMusic.Click += new System.EventHandler(this.buttonMusic_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonMenu.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Bold);
            this.buttonMenu.ForeColor = System.Drawing.Color.Red;
            this.buttonMenu.Location = new System.Drawing.Point(80, 205);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(140, 36);
            this.buttonMenu.TabIndex = 4;
            this.buttonMenu.Text = "Back to Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // PauseDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(300, 260);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonSound);
            this.Controls.Add(this.buttonMusic);
            this.Controls.Add(this.buttonMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PauseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paused";
            this.Load += new System.EventHandler(this.PauseDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonSound;
        private System.Windows.Forms.Button buttonMusic;
        private System.Windows.Forms.Button buttonMenu;
    }
}
