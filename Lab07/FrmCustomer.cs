using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Lab07.Models;

namespace Lab07.Forms
{
    public partial class FrmCustomer : Form
    {
        // Danh sách lưu trữ khách hàng trong bộ nhớ
        private BindingList<Customer> customerList = new BindingList<Customer>();

        public FrmCustomer()
        {
            InitializeComponent();

            // Gắn các sự kiện
            this.Load += FrmCustomer_Load;
            this.dgvCustomers.CellClick += DgvCustomers_CellClick;
            this.btnThem.Click += BtnThem_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnLamMoi.Click += BtnLamMoi_Click;
            this.btnTimKiem.Click += BtnTimKiem_Click;
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cboLoaiKH.SelectedIndex = 0;
            dgvCustomers.DataSource = customerList;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã KH và Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã khách hàng
            if (customerList.Any(c => c.MaKH.Equals(txtMaKH.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer newCustomer = new Customer
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                LoaiKH = cboLoaiKH.Text
            };

            customerList.Add(newCustomer);
            BtnLamMoi_Click(null, null); 
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.DataBoundItem is Customer c)
            {
                txtMaKH.Text = c.MaKH;
                txtMaKH.ReadOnly = true; 
                txtHoTen.Text = c.HoTen;
                txtSDT.Text = c.SoDienThoai;
                cboLoaiKH.Text = c.LoaiKH;
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.DataBoundItem is Customer c)
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                c.HoTen = txtHoTen.Text.Trim();
                c.SoDienThoai = txtSDT.Text.Trim();
                c.LoaiKH = cboLoaiKH.Text;

                dgvCustomers.Refresh(); 
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.DataBoundItem is Customer c)
            {
                DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {c.HoTen}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    customerList.Remove(c);
                    BtnLamMoi_Click(null, null);
                }
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtMaKH.ReadOnly = false;
            txtHoTen.Clear();
            txtSDT.Clear();
            cboLoaiKH.SelectedIndex = 0;
            txtTimKiem.Clear();
            dgvCustomers.DataSource = customerList; 
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvCustomers.DataSource = customerList;
                return;
            }

            var result = customerList.Where(c => c.MaKH.ToLower().Contains(keyword) || c.HoTen.ToLower().Contains(keyword)).ToList();
            dgvCustomers.DataSource = result;
        }
    }
}