using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ศัตรูแบบที่ 1 (รถยนต์)
    public class Enemy1 : EnemyMonster
    {
        private static readonly Image ImgLeft = Image.FromFile("Resources/car_left.png");
        private static readonly Image ImgRight = Image.FromFile("Resources/car_right.png");

        public Enemy1(int x, int y, int speed) : base(x, y, speed)
        {
            this.Width = GameConfig.Scale(75);
            this.Height = GameConfig.Scale(40);
            this.Y += (GameConfig.Cell - Height) / 2;
        }

        public override void Draw(Graphics g)
        {
            Image img = (speed > 0) ? ImgRight : ImgLeft;
            g.DrawImage(img, X, Y, Width, Height);
        }
    }
}
