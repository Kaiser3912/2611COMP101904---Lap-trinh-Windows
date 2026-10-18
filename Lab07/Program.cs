using Lab07;
using Lab07.Forms;
using System;
using System.Windows.Forms;

namespace Lab07.Forms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy form đăng nhập theo dạng hộp thoại
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Nếu đăng nhập thành công, truyền thông tin User vào FrmMain
                Application.Run(new FrmMain(login.LoggedInUser));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}