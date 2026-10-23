using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ศัตรูแบบที่ 2 (รถบรรทุก)
    public class Enemy2 : EnemyMonster
    {
        private static readonly Image ImgLeft = Image.FromFile("Resources/truck_left.png");
        private static readonly Image ImgRight = Image.FromFile("Resources/truck_right.png");

        public Enemy2(int x, int y, int speed) : base(x, y, speed)
        {
            this.Width = 95;
            this.Height = 34;
        }

        public override void Draw(Graphics g)
        {
            Image img = (speed > 0) ? ImgRight : ImgLeft;
            g.DrawImage(img, X, Y, Width, Height);
        }
    }
}
