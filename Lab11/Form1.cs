using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lab11
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            @"Data Source=.;Initial Catalog=QuanLyBanHangDB;Integrated Security=True;TrustServerCertificate=True";

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
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
                               FROM LOP l
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                               GROUP BY l.MaLop, l.TenLop
                               ORDER BY l.MaLop";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLop.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!");
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!");
                txtTenLop.Focus();
                return false;
            }
            return true;
        }

        private bool IsMaLopExists(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma", maLop);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Mã lớp đã tồn tại!");
                    return;
                }

                string sql = "INSERT INTO LOP(MaLop, TenLop) VALUES(@ma, @ten)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm lớp thành công!");
                        LoadData();
                        ClearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = "UPDATE LOP SET TenLop = @ten WHERE MaLop = @ma";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txtMaLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@ten", txtTenLop.Text.Trim());
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp cần sửa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!");
                return;
            }

            try
            {
                string sqlCheck = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@ma", ma);
                        conn.Open();
                        int soSinhVien = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (soSinhVien > 0)
                        {
                            MessageBox.Show("Không thể xóa lớp đang có sinh viên (Lỗi khóa ngoại)!");
                            return;
                        }
                    }

                    if (MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (SqlCommand cmdDel = new SqlCommand("DELETE FROM LOP WHERE MaLop = @ma", conn))
                        {
                            cmdDel.Parameters.AddWithValue("@ma", ma);
                            if (cmdDel.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Xóa thành công!");
                                LoadData();
                                ClearInput();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
                               FROM LOP l
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                               WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw
                               GROUP BY l.MaLop, l.TenLop
                               ORDER BY l.MaLop";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + txtTimKiem.Text.Trim() + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLop.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLop.Rows[e.RowIndex];
                txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value?.ToString();
            }
        }

        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            txtMaLop.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}