using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ซุงแบบที่ 1 (คาปิบาร่า)
    public class Friend1 : FriendMonster
    {
        private static readonly Image ImgLeft = Image.FromFile("Resources/capy_left.png");
        private static readonly Image ImgRight = Image.FromFile("Resources/capy_right.png");

        public Friend1(int x, int y, int speed) : base(x, y, speed)
        {
            this.Width = 65;
            this.Height = 32;
        }

        public override void Draw(Graphics g)
        {
            Image img = (speed > 0) ? ImgRight : ImgLeft;
            g.DrawImage(img, X, Y, Width, Height);
        }
    }
}
