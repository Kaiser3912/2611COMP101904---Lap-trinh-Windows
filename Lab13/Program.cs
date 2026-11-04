using Form1.Forms;
using System;
using System.Windows.Forms;

namespace Form1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBaoCaoSinhVien());
        }
    }
}