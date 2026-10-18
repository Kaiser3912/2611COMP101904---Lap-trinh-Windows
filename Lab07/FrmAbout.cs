using System;
using System.Windows.Forms;

namespace Lab07.Forms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();

            this.btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            // Đóng form giới thiệu khi người dùng nhấn nút
            this.Close();
        }
    }
}