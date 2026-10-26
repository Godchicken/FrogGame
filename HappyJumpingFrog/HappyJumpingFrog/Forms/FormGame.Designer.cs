namespace HappyJumpingFrog
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            this.panelSide = new System.Windows.Forms.Panel();
            this.labelTimeCaption = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelLevelCaption = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelScoreCaption = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelLivesCaption = new System.Windows.Forms.Label();
            this.labelLives = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.SystemColors.Info;
            this.panelSide.Controls.Add(this.labelTimeCaption);
            this.panelSide.Controls.Add(this.labelTime);
            this.panelSide.Controls.Add(this.labelLevelCaption);
            this.panelSide.Controls.Add(this.labelLevel);
            this.panelSide.Controls.Add(this.labelScoreCaption);
            this.panelSide.Controls.Add(this.labelScore);
            this.panelSide.Controls.Add(this.labelLivesCaption);
            this.panelSide.Controls.Add(this.labelLives);
            this.panelSide.Controls.Add(this.buttonPause);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSide.Location = new System.Drawing.Point(985, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 600);
            this.panelSide.TabIndex = 0;
            // 
            // labelTimeCaption
            // 
            this.labelTimeCaption.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.labelTimeCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTimeCaption.Location = new System.Drawing.Point(20, 30);
            this.labelTimeCaption.Name = "labelTimeCaption";
            this.labelTimeCaption.Size = new System.Drawing.Size(160, 23);
            this.labelTimeCaption.TabIndex = 1;
            this.labelTimeCaption.Text = "Time";
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelTime.ForeColor = System.Drawing.Color.Green;
            this.labelTime.Location = new System.Drawing.Point(20, 55);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(160, 30);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "00:00";
            // 
            // labelLevelCaption
            // 
            this.labelLevelCaption.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.labelLevelCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelLevelCaption.Location = new System.Drawing.Point(20, 110);
            this.labelLevelCaption.Name = "labelLevelCaption";
            this.labelLevelCaption.Size = new System.Drawing.Size(160, 23);
            this.labelLevelCaption.TabIndex = 3;
            this.labelLevelCaption.Text = "Level";
            // 
            // labelLevel
            // 
            this.labelLevel.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelLevel.ForeColor = System.Drawing.Color.Green;
            this.labelLevel.Location = new System.Drawing.Point(20, 135);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(160, 30);
            this.labelLevel.TabIndex = 4;
            this.labelLevel.Text = "1 - 1";
            // 
            // labelScoreCaption
            // 
            this.labelScoreCaption.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.labelScoreCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelScoreCaption.Location = new System.Drawing.Point(20, 190);
            this.labelScoreCaption.Name = "labelScoreCaption";
            this.labelScoreCaption.Size = new System.Drawing.Size(160, 23);
            this.labelScoreCaption.TabIndex = 5;
            this.labelScoreCaption.Text = "Score";
            // 
            // labelScore
            // 
            this.labelScore.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelScore.ForeColor = System.Drawing.Color.Green;
            this.labelScore.Location = new System.Drawing.Point(20, 215);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(160, 30);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = "0";
            // 
            // labelLivesCaption
            // 
            this.labelLivesCaption.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.labelLivesCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelLivesCaption.Location = new System.Drawing.Point(20, 270);
            this.labelLivesCaption.Name = "labelLivesCaption";
            this.labelLivesCaption.Size = new System.Drawing.Size(160, 23);
            this.labelLivesCaption.TabIndex = 7;
            this.labelLivesCaption.Text = "Lives";
            // 
            // labelLives
            // 
            this.labelLives.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelLives.ForeColor = System.Drawing.Color.Red;
            this.labelLives.Location = new System.Drawing.Point(20, 295);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(160, 30);
            this.labelLives.TabIndex = 8;
            this.labelLives.Text = "5 / 5";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(40, 520);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(120, 40);
            this.buttonPause.TabIndex = 9;
            this.buttonPause.TabStop = false;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1185, 600);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Happy Jumping Frog";
            this.panelSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Label labelTimeCaption;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelLevelCaption;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelScoreCaption;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelLivesCaption;
        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Timer timer1;
    }
}
