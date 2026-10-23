namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] แม่ของ "ศัตรู" (รถ): วิ่งวนซ้าย-ขวา ชนแล้วกบตาย
    public abstract class EnemyMonster : GameObject
    {
        protected int speed;   // ค่าลบ = วิ่งซ้าย, ค่าบวก = วิ่งขวา

        protected EnemyMonster(int x, int y, int speed) : base(x, y, 80, 40)
        {
            this.speed = speed;
        }

        // TODO(B): override Update()
        //   X = X + speed
        //   ถ้าวิ่งซ้ายแล้วออกขอบซ้าย (X <= 0)      → X = JumpingField.FieldWidth
        //   ถ้าวิ่งขวาแล้วออกขอบขวา (X >= FieldWidth) → X = 0
        public override void Update()
        {
            X += speed;
            if (speed < 0 && X <= 0)
            {
                X = JumpingField.FieldWidth;
            }
            else if (speed > 0 && X >= JumpingField.FieldWidth)
            {
                X = 0;
            }
        }

        public override void OnHit(PlayerFrog frog)
        {
            frog.Die();
        }
    }
}
