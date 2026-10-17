using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] ดอกบัวเป้าหมาย: กบแตะแล้วหายไป และกบกลับจุดเริ่มต้น
    public class TargetLotus : GameObject
    {
        public TargetLotus(int x, int y) : base(x, y, 40, 40) { }

        public override void Draw(Graphics g)
        {
            if (IsActive)
                g.FillEllipse(Brushes.Pink, X, Y, Width, Height);
        }

        public override void OnHit(PlayerFrog frog)
        {
            IsActive = false;
            frog.ResetPosition();
        }
    }
}
