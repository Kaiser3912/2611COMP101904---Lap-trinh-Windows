using System.Text;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Toán - Tin học");
            cboKhoa.Items.Add("Vật lý");
            cboKhoa.Items.Add("Hóa học");
            cboKhoa.SelectedIndex = 0;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtNamSinh.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên, năm sinh và email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra năm sinh hợp lệ
            int namSinh;
            int namHienTai = DateTime.Now.Year;
            if (!int.TryParse(txtNamSinh.Text, out namSinh) || namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show("Năm sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                return;
            }

            int tuoi = namHienTai - namSinh;

            //Giới tính
            string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";

            //Khoa
            string khoa = cboKhoa.SelectedItem.ToString();

            //Hiển thị thông tin
            string ketQua = $"--- THÔNG TIN CÁ NHÂN ---\n" +
                             $"Họ tên: {txtHoTen.Text}\n" +
                             $"Năm sinh: {namSinh} (Tuổi: {tuoi})\n" +
                             $"Giới tính: {gioiTinh}\n" +
                             $"Khoa: {khoa}\n" +
                             $"Email: {txtEmail.Text}";

            //MessageBox
            MessageBox.Show(ketQua, "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            rdoNam.Checked = true;
            cboKhoa.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
