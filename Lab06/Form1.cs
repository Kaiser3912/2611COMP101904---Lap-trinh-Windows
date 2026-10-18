using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        // Khai báo danh sách lưu trữ trong bộ nhớ và BindingSource làm trung gian
        private BindingList<Product> products = new BindingList<Product>();
        private BindingSource productSource = new BindingSource();
        private string selectedImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            
            // Gắn các sự kiện (Events)
            this.Load += Form1_Load;
            this.dgvProducts.CellClick += dgvProducts_CellClick;
            this.btnChonAnh.Click += btnChonAnh_Click;
            this.btnTimKiem.Click += btnTimKiem_Click;
            
            // Gắn sự kiện cho ToolStrip
            this.tsbThem.Click += btnThem_Click;
            this.tsbSua.Click += btnSua_Click;
            this.tsbXoa.Click += btnXoa_Click;
            this.tsbLamMoi.Click += btnLamMoi_Click;
            
            // Gắn sự kiện cho ContextMenuStrip
            this.cmsSua.Click += tsbSua_Click; // Gọi lại nút sửa
            this.cmsXoa.Click += tsbXoa_Click; // Gọi lại nút xóa
            this.cmsChiTiet.Click += cmsChiTiet_Click;
            
            // Gắn sự kiện File -> Thoát
            this.mnuFileExit.Click += mnuFileExit_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu loại sản phẩm vào ComboBox
            cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
            cboLoaiSP.SelectedIndex = 0;

            // Thêm dữ liệu mẫu
            products.Add(new Product { MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử", DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today, ConKinhDoanh = true });
            products.Add(new Product { MaSP = "SP02", TenSP = "Bút bi", LoaiSP = "Văn phòng", DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today, ConKinhDoanh = true });
            products.Add(new Product { MaSP = "SP03", TenSP = "Balo laptop", LoaiSP = "Thời trang", DonGia = 350000, SoLuong = 15, NgayNhap = DateTime.Today.AddDays(-2), ConKinhDoanh = true });

            // Liên kết dữ liệu với DataGridView
            productSource.DataSource = products;
            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = productSource;
            
            UpdateStatus("Sẵn sàng");
        }

        // Hàm kiểm tra dữ liệu đầu vào
        private bool ValidateInput(bool isEdit = false)
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được rỗng");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được rỗng");
                isValid = false;
            }
            if (numDonGia.Value <= 0)
            {
                errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
                isValid = false;
            }
            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn hôm nay");
                isValid = false;
            }

            // Kiểm tra trùng mã sản phẩm (chỉ khi thêm mới)
            string ma = txtMaSP.Text.Trim();
            bool isDuplicate = products.Any(p => p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (!isEdit && isDuplicate)
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
                isValid = false;
            }

            return isValid;
        }

        // Hàm lấy sản phẩm đang được chọn trên DataGridView
        private Product GetSelectedProduct()
        {
            if (productSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return productSource.Current as Product;
        }

        // 1. Chức năng Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Product p = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value,
                NgayNhap = dtpNgayNhap.Value.Date,
                ConKinhDoanh = chkConKinhDoanh.Checked,
                DuongDanAnh = selectedImagePath
            };

            products.Add(p);
            ClearInput();
            UpdateStatus("Đã thêm sản phẩm mới");
        }

        // 2. Chọn dòng hiển thị lên Form
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = productSource.Current as Product;
            if (p == null) return;

            txtMaSP.Text = p.MaSP;
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.Text = p.LoaiSP;
            numDonGia.Value = p.DonGia;
            numSoLuong.Value = p.SoLuong;
            dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;
            selectedImagePath = p.DuongDanAnh;

            // Load ảnh nếu có
            if (!string.IsNullOrWhiteSpace(p.DuongDanAnh) && File.Exists(p.DuongDanAnh))
                picSanPham.Image = Image.FromFile(p.DuongDanAnh);
            else
                picSanPham.Image = null;
        }

        // 3. Chức năng Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;

            // Chuyển true để bỏ qua bước kiểm tra trùng mã SP đang sửa
            if (!ValidateInput(isEdit: true)) return;

            p.TenSP = txtTenSP.Text.Trim();
            p.LoaiSP = cboLoaiSP.Text;
            p.DonGia = numDonGia.Value;
            p.SoLuong = (int)numSoLuong.Value;
            p.NgayNhap = dtpNgayNhap.Value.Date;
            p.ConKinhDoanh = chkConKinhDoanh.Checked;
            p.DuongDanAnh = selectedImagePath;

            // Làm mới lại lưới hiển thị
            productSource.ResetBindings(false);
            UpdateStatus("Đã cập nhật sản phẩm");
        }

        // 4. Chức năng Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                products.Remove(p);
                ClearInput();
                UpdateStatus("Đã xóa sản phẩm");
            }
        }

        // 5. Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var result = products.Where(p => p.MaSP.ToLower().Contains(keyword) || p.TenSP.ToLower().Contains(keyword)).ToList();
            
            dgvProducts.DataSource = result;
            lblStatus.Text = $"Tìm thấy {result.Count} sản phẩm";
        }

        // 6. Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = productSource;
            ClearInput();
            UpdateStatus("Đã làm mới dữ liệu");
        }

        // 7. Chọn ảnh
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh sản phẩm";
                dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = dialog.FileName;
                    picSanPham.Image = Image.FromFile(selectedImagePath);
                    UpdateStatus("Đã chọn ảnh sản phẩm");
                }
            }
        }

        // Xem chi tiết ContextMenu
        private void cmsChiTiet_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;
            
            MessageBox.Show($"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\nTổng tiền: {p.ThanhTien:N0}", "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xử lý các Menu phụ trợ
        private void mnuFileExit_Click(object sender, EventArgs e) { Close(); }
        private void tsbSua_Click(object sender, EventArgs e) { btnSua_Click(sender, e); }
        private void tsbXoa_Click(object sender, EventArgs e) { btnXoa_Click(sender, e); }

        // Hàm xóa trắng Form
        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 1;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;
            txtTimKiem.Clear();
            picSanPham.Image = null;
            selectedImagePath = string.Empty;
            errorProvider1.Clear();
            txtMaSP.Focus();
        }

        // Hàm cập nhật thanh trạng thái
        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"{message} | Số sản phẩm: {products.Count}";
        }
    }
}