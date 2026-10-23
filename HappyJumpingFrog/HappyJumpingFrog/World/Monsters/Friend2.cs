using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ซุงแบบที่ 2 (คาปิบาร่าเหมือนกันแต่ชื่อเจมส์)
    public class Friend2 : FriendMonster
    {
        private static readonly Image ImgLeft = Image.FromFile("Resources/fish_left.png");
        private static readonly Image ImgRight = Image.FromFile("Resources/fish_right.png");

        public Friend2(int x, int y, int speed) : base(x, y, speed)
        {
            this.Width = 75;
            this.Height = 32;
        }

        public override void Draw(Graphics g)
        {
            Image img = (speed > 0) ? ImgRight : ImgLeft;
            g.DrawImage(img, X, Y, Width, Height);
        }
    }
}
