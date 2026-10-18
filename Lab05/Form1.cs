using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab05
{
    public partial class Form1 : Form
    {
        // Khai báo danh sách khóa học và học phí theo yêu cầu đề bài
        Dictionary<string, int> danhSachKhoaHoc = new Dictionary<string, int>()
        {
            {"C# WinForms cơ bản", 800000},
            {"SQL Server cơ bản", 700000},
            {"Web Frontend cơ bản", 750000},
            {"Lập trình Python cơ bản", 650000}
        };

        public Form1()
        {
            InitializeComponent();

            // Gán các sự kiện click cho các nút lệnh dựa trên tên biến của bạn
            this.btn_dangky.Click += new System.EventHandler(this.btn_dangky_Click);
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            this.num_sothang.ValueChanged += new System.EventHandler(this.num_sothang_ValueChanged);
            this.cbo_Nhanemail.CheckedChanged += new System.EventHandler(this.cbo_Nhanemail_CheckedChanged);
        }

        // 5.1. Khi Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp danh sách khóa học vào ComboBox
            foreach (var item in danhSachKhoaHoc.Keys)
            {
                cbo_khoahoc.Items.Add(item);
            }

            // Chọn mặc định khóa học đầu tiên, hình thức Online, số tháng 1
            if (cbo_khoahoc.Items.Count > 0)
            {
                cbo_khoahoc.SelectedIndex = 0;
            }
            rad_online.Checked = true;
            num_sothang.Value = 1;

            TinhTongTien();
        }

        // Hàm tính tổng học phí
        private void TinhTongTien()
        {
            if (cbo_khoahoc.SelectedIndex != -1)
            {
                string tenKhoaHoc = cbo_khoahoc.SelectedItem.ToString();
                int hocPhiMotThang = danhSachKhoaHoc[tenKhoaHoc];
                int soThang = (int)num_sothang.Value;
                int tongTien = hocPhiMotThang * soThang;

                // Hiển thị học phí 1 tháng và tổng tiền
                lbl_hocphi.Text = hocPhiMotThang.ToString("N0") + " VNĐ";
                lbl_tongtien.Text = tongTien.ToString("N0") + " VNĐ";
            }
        }

        // Tính lại học phí khi thay đổi khóa học
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        // Tính lại học phí khi thay đổi số tháng
        private void num_sothang_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        // 5.2. Nút Đăng ký
        private void btn_dangky_Click(object sender, EventArgs e)
        {
            // Kiểm tra họ tên không được rỗng
            if (string.IsNullOrWhiteSpace(txt_Hoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên học viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Hoten.Focus();
                return;
            }

            // Kiểm tra số điện thoại không được rỗng
            if (string.IsNullOrWhiteSpace(txt_SĐT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SĐT.Focus();
                return;
            }

            // Kiểm tra phải chọn khóa học
            if (cbo_khoahoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hinhThuc = rad_online.Checked ? "Online" : "Trực tiếp (Offline)";
            string nhanEmail = cbo_Nhanemail.Checked ? "Có" : "Không";
            string tenKhoaHoc = cbo_khoahoc.SelectedItem.ToString();
            int tongTien = danhSachKhoaHoc[tenKhoaHoc] * (int)num_sothang.Value;

            // Hiển thị phiếu đăng ký bằng MessageBox
            string thongTinPhieu = $"--- PHIẾU ĐĂNG KÝ ---\n" +
                                   $"Họ tên: {txt_Hoten.Text}\n" +
                                   $"Số điện thoại: {txt_SĐT.Text}\n" +
                                   $"Ngày sinh: {dtp_NgaySinh.Value.ToString("dd/MM/yyyy")}\n" +
                                   $"Khóa học: {tenKhoaHoc}\n" +
                                   $"Hình thức: {hinhThuc}\n" +
                                   $"Số tháng: {num_sothang.Value}\n" +
                                   $"Tổng tiền: {tongTien:N0} VNĐ\n" +
                                   $"Nhận email: {nhanEmail}";

            MessageBox.Show(thongTinPhieu, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 5.3. Nút Làm mới
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txt_Hoten.Clear();
            txt_SĐT.Clear();
            dtp_NgaySinh.Value = DateTime.Now;
            cbo_Nhanemail.Checked = false;

            if (cbo_khoahoc.Items.Count > 0) cbo_khoahoc.SelectedIndex = 0;
            rad_online.Checked = true;
            num_sothang.Value = 1;

            txt_Hoten.Focus();
        }

        // 5.4. Nút Thoát
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txt_Hoten_TextChanged(object sender, EventArgs e)
        {
            int doDai = txt_Hoten.Text.Length;
            lbl_Chucai.Text = $"{doDai}/50";
        }

        private void cbo_Nhanemail_CheckedChanged(object sender, EventArgs e)
        {
            if (cbo_Nhanemail.Checked)
                lbl_Thongbao.Text = "Sẽ nhận email thông báo";
            else
                lbl_Thongbao.Text = "Không nhận email thông báo";
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }

        private void lbl_Chucai_Click(object sender, EventArgs e)
        {

        }
    }
}