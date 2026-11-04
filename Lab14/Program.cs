using System;
using System.Windows.Forms;
using Lab14.GUI; // Thêm thư viện chứa FrmMonHoc

namespace Lab14
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Đổi Form1 thành FrmMonHoc
            Application.Run(new Form1());
        }
    }
}