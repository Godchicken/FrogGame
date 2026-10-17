using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: กูเอง]  ไอ้เหี้ยซีน
    // คลาสแม่ของ "ทุกอย่างที่อยู่ในสนาม" (กบ, รถ, ซุง, ดอกบัว, ไอเท็ม, ถนน, แม่น้ำ)
    public abstract class GameObject
    {
        // ตำแหน่งและขนาด: อ่านได้จากข้างนอก แก้ได้เฉพาะในคลาสตัวเองและคลาสลูก
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        // true = ยังอยู่ในเกม, false = หายไปแล้ว (เช่น ดอกบัวที่ถูกแตะแล้ว)
        public bool IsActive { get; protected set; } = true;

        protected GameObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        // กรอบสี่เหลี่ยมของวัตถุ ใช้เช็คการชน
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        // ชนกับวัตถุอีกชิ้นหรือไม่ (ต้องยัง active ทั้งคู่)
        public bool Intersects(GameObject other)
        {
            return IsActive && other.IsActive && Bounds.IntersectsWith(other.Bounds);
        }

        // abstract: ทุกคลาสลูกต้องเขียนวิธีวาดตัวเอง
        public abstract void Draw(Graphics g);

        // virtual: ถูกเรียกทุก tick ของเกม คลาสลูกจะ override หรือไม่ก็ได้ (เช่น รถวิ่ง)
        public virtual void Update() { }

        // virtual: เกิดอะไรขึ้นเมื่อ "กบชนวัตถุนี้" (ค่าเริ่มต้น = ไม่เกิดอะไร)
        public virtual void OnHit(PlayerFrog frog) { }

        public virtual void Reset()
        {
            IsActive = true;
        }
    }
}
