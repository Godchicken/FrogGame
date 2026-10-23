using System;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: กู] จุดเริ่มโปรแกรม เปิดหน้าเมนูเป็นหน้าแรก
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMenu());
        }
    }

}
