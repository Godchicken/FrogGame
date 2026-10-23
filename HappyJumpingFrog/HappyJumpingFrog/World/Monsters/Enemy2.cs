using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ศัตรูแบบที่ 2 (รถบรรทุก)
    public class Enemy2 : EnemyMonster
    {
        public Enemy2(int x, int y, int speed) : base(x, y, speed) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Yellow, X, Y, Width, Height);
        }
    }
}
