using Lab14.BLL;
using Lab14.Models;
using System;
using System.Windows.Forms;

namespace Lab14.GUI
{
    public partial class Form1 : Form
    {
        private MonHocBLL bll = new MonHocBLL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvMonHoc.DataSource = bll.GetAllMonHoc();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = 1;
            chkTrangThai.Checked = true;
            txtTimKiem.Clear();
            txtMaMonHoc.Focus();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var mh = new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text.Trim(),
                TenMonHoc = txtTenMonHoc.Text.Trim(),
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };

            string msg = bll.AddMonHoc(mh);
            MessageBox.Show(msg, "Thông báo");
            if (msg == "Thêm thành công!") LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mh = new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text.Trim(),
                TenMonHoc = txtTenMonHoc.Text.Trim(),
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };

            string msg = bll.UpdateMonHoc(mh);
            MessageBox.Show(msg, "Thông báo");
            if (msg == "Cập nhật thành công!") LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaMonHoc.Text.Trim();
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Cảnh báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string msg = bll.DeleteMonHoc(ma);
                MessageBox.Show(msg, "Thông báo");
                if (msg == "Xóa thành công!") btnLamMoi_Click(sender, e);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvMonHoc.DataSource = bll.SearchMonHoc(txtTimKiem.Text.Trim());
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];
                txtMaMonHoc.Text = row.Cells["MaMonHoc"].Value?.ToString();
                txtTenMonHoc.Text = row.Cells["TenMonHoc"].Value?.ToString();
                nudSoTinChi.Value = Convert.ToDecimal(row.Cells["SoTinChi"].Value);
                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            }
        }
    }
}