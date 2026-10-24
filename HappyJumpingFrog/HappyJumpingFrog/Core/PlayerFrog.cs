using System;
using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: กูอีก]
    public class PlayerFrog : GameObject
    {
        public const int Step = 40;       // เดินทีละ 1 ช่อง = 40 พิกเซล
        public const int MaxLives = 5;

        private readonly int startX;
        private readonly int startY;
        private Image sprite = Properties.Resources.LINE_ALBUM_171069_261024_frog;
        private Image spritejump = Properties.Resources.LINE_ALBUM_171069_261024_frogjump;
        private bool isJumping = false;
        private int jumpTimer = 0;
        private DateTime jumpEnd;

        public int Score { get; private set; }
        public int Lives { get; private set; } = MaxLives;

        // true = tick นี้กบยืนอยู่บนซุง (FormGame จะรีเซ็ตเป็น false ทุก tick)
        public bool OnLog { get; set; }


        public PlayerFrog(int x, int y) : base(x, y, 40, 40)
        {
            startX = x;
            startY = y;
        }

        // dx, dy เป็น -1, 0, 1 (จำนวนช่อง)
        public void Move(int dx, int dy)
        {
            X += dx * Step;
            Y += dy * Step;
            StartJump();

        }

        private void StartJump()
        {
            isJumping = true;
            jumpEnd = DateTime.Now.AddMilliseconds(200);
        }


        public override void Update()
        {
            if (jumpTimer > 0)
            {
                jumpTimer--;
                if (jumpTimer == 0) isJumping = false;
            }
        }

        public void ResetPosition()
        {
            X = startX;
            Y = startY;
            isJumping = false;
        }

        public void Die()
        {
            Lives = Math.Max(0, Lives - 1);
            ResetPosition();
        }

        // ซุงพากบไปด้วย: เลื่อนตามความเร็วซุง และบอกว่า ตอนนี้อยู่บนซุง
        public void Carry(int dx)
        {
            X += dx;
            OnLog = true;
        }

        public void AddScore(int points)
        {
            Score += points;
        }

        public void AddLife()
        {
            if (Lives < MaxLives) Lives++;
        }

        public bool IsOutOfBounds(int screenWidth, int screenHeight)
        {
            return X < 0 || X > screenWidth - Width || Y < 0 || Y > screenHeight - Height;
        }

        public override void Draw(Graphics g)
        {
            if (isJumping && DateTime.Now >= jumpEnd) isJumping = false;

            Image current = isJumping ? spritejump : sprite;
            g.DrawImage(current, X, Y, Width, Height);
        }

        public override void Reset()
        {
            base.Reset();
            Score = 0;
            Lives = MaxLives;
            ResetPosition();
        }
        
    }
}
