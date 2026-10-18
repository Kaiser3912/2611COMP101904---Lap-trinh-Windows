using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Lab07.Models;

namespace Lab07.Forms
{
    public partial class FrmProduct : Form
    {
        // Sử dụng BindingList để DataGridView tự động cập nhật khi có thay đổi
        private BindingList<Product> productList = new BindingList<Product>();

        public FrmProduct()
        {
            InitializeComponent();

            // Gắn sự kiện
            this.Load += FrmProduct_Load;
            this.dgvProducts.CellClick += DgvProducts_CellClick;
            this.btnThem.Click += BtnThem_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnLamMoi.Click += BtnLamMoi_Click;
            this.btnTimKiem.Click += BtnTimKiem_Click;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboLoaiSP.SelectedIndex = 0;
            dgvProducts.DataSource = productList;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Mã SP và Tên SP không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho thêm sản phẩm trùng mã
            if (productList.Any(p => p.MaSP.Equals(txtMaSP.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product newProduct = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value
            };

            productList.Add(newProduct);
            BtnLamMoi_Click(null, null);
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product p)
            {
                txtMaSP.Text = p.MaSP;
                txtMaSP.ReadOnly = true; // Không cho sửa Mã SP
                txtTenSP.Text = p.TenSP;
                cboLoaiSP.Text = p.LoaiSP;
                numDonGia.Value = p.DonGia;
                numSoLuong.Value = p.SoLuong;
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product p)
            {
                if (string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Tên SP không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                p.TenSP = txtTenSP.Text.Trim();
                p.LoaiSP = cboLoaiSP.Text;
                p.DonGia = numDonGia.Value;
                p.SoLuong = (int)numSoLuong.Value;

                dgvProducts.Refresh(); // Làm mới hiển thị
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product p)
            {
                // Khi xóa phải hỏi xác nhận
                DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    productList.Remove(p);
                    BtnLamMoi_Click(null, null);
                }
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtMaSP.ReadOnly = false;
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            txtTimKiem.Clear();
            dgvProducts.DataSource = productList; // Xóa kết quả tìm kiếm
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvProducts.DataSource = productList;
                return;
            }

            var result = productList.Where(p => p.MaSP.ToLower().Contains(keyword) || p.TenSP.ToLower().Contains(keyword)).ToList();
            dgvProducts.DataSource = result;
        }
    }
}