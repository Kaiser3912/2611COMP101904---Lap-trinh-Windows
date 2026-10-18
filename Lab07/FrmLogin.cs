using Microsoft.VisualBasic.ApplicationServices;
using Lab07.Models; 
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab07.Forms
{
    public partial class FrmLogin : Form
    {
        // Thuộc tính (Property) dùng để truyền dữ liệu người dùng sang FrmMain
        public Models.User LoggedInUser { get; private set; }

        private List<Models.User> sampleUsers = new List<Models.User>
        {
            new Models.User { Username = "admin", Password = "123", FullName = "Quản trị viên", Role = "Admin" },
            new Models.User { Username = "user", Password = "123", FullName = "Nhân viên bán hàng", Role = "User" }
        };

        public FrmLogin()
        {
            InitializeComponent();

            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            // Code xử lý khi click vào nhãn (nếu cần)
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var user in sampleUsers)
            {
                if (user.Username == username && user.Password == password)
                {
                    // Đăng nhập thành công
                    LoggedInUser = user;
                    this.DialogResult = DialogResult.OK; // Trả về kết quả OK để mở FrmMain
                    this.Close();
                    return;
                }
            }

            // Nếu sai tài khoản/mật khẩu
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }

}