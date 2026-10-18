using Lab07.Forms;
using Lab07.Models; 
using System;
using System.Windows.Forms;

namespace Lab07.Forms
{
    public partial class FrmMain : Form
    {
        private User currentUser; 

        public FrmMain(User user)
        {
            InitializeComponent();
            this.currentUser = user;

            // Gắn sự kiện
            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;

            this.mnuSanPham.Click += MnuSanPham_Click;
            this.mnuKhachHang.Click += MnuKhachHang_Click;
            this.mnuGioiThieu.Click += MnuGioiThieu_Click;

            this.mnuDangXuat.Click += MnuDangXuat_Click;
            this.mnuThoat.Click += MnuThoat_Click;
        }

        // Cập nhật thông tin lên StatusStrip khi mở Form
        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = $"Người dùng: {currentUser.FullName} | Vai trò: {currentUser.Role}";
            lblTime.Text = $"Đăng nhập lúc: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        // --- HÀM MỞ FORM CON KHÔNG TRÙNG LẶP ---
        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra xem Form đã được mở chưa
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate(); // Nếu mở rồi thì focus (kích hoạt) lại nó
                    return;
                }
            }

            // Nếu chưa mở thì cài đặt nó là form con và hiển thị
            childForm.MdiParent = this;
            childForm.Show();
        }

        // Sự kiện click Menu Quản lý sản phẩm
        private void MnuSanPham_Click(object sender, EventArgs e)
        {
            FrmProduct frmProduct = new FrmProduct();
            OpenChildForm(frmProduct);
        }

        // Sự kiện click Menu Quản lý khách hàng
        private void MnuKhachHang_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer();
            OpenChildForm(frmCustomer);
        }

        // Sự kiện click Menu Giới thiệu
        private void MnuGioiThieu_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(); // Form Giới thiệu thường mở dạng hộp thoại chặn (Dialog)
        }

        // Xử lý Đăng xuất
        private void MnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.currentUser = login.LoggedInUser;
                FrmMain_Load(null, null); // Cập nhật lại thông tin user
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        // Xử lý nút Thoát trên Menu
        private void MnuThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Sẽ gọi đến sự kiện FormClosing ở dưới
        }

        // Xác nhận khi thoát bằng nút X đỏ góc phải
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy lệnh đóng form
            }
        }
    }
}