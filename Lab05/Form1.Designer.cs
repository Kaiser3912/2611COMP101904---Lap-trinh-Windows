namespace Lab05
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            grb_Thongtinhocvien = new GroupBox();
            lbl_Thongbao = new Label();
            cbo_Nhanemail = new CheckBox();
            lbl_Ngaysinh = new Label();
            dtp_NgaySinh = new DateTimePicker();
            txt_SĐT = new TextBox();
            lbl_sdt = new Label();
            lbl_Chucai = new Label();
            txt_Hoten = new TextBox();
            lbl_HoTen = new Label();
            grb_Khoahoc = new GroupBox();
            lbl_tongtien = new Label();
            lbl_hocphi = new Label();
            lbl_hocphithang = new Label();
            lbl_tongtien2 = new Label();
            num_sothang = new NumericUpDown();
            lbl_sothang = new Label();
            rad_offline = new RadioButton();
            rad_online = new RadioButton();
            lbl_hinhthuchoc = new Label();
            cbo_khoahoc = new ComboBox();
            lbl_khoahoc = new Label();
            panel1 = new Panel();
            btn_thoat = new Button();
            btn_lammoi = new Button();
            btn_dangky = new Button();
            grb_Thongtinhocvien.SuspendLayout();
            grb_Khoahoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_sothang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(230, 37);
            label1.Name = "label1";
            label1.Size = new Size(547, 46);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÍ KHÓA HỌC NGẮN HẠN";
            label1.Click += label1_Click;
            // 
            // grb_Thongtinhocvien
            // 
            grb_Thongtinhocvien.BackColor = SystemColors.GradientActiveCaption;
            grb_Thongtinhocvien.Controls.Add(lbl_Thongbao);
            grb_Thongtinhocvien.Controls.Add(cbo_Nhanemail);
            grb_Thongtinhocvien.Controls.Add(lbl_Ngaysinh);
            grb_Thongtinhocvien.Controls.Add(dtp_NgaySinh);
            grb_Thongtinhocvien.Controls.Add(txt_SĐT);
            grb_Thongtinhocvien.Controls.Add(lbl_sdt);
            grb_Thongtinhocvien.Controls.Add(lbl_Chucai);
            grb_Thongtinhocvien.Controls.Add(txt_Hoten);
            grb_Thongtinhocvien.Controls.Add(lbl_HoTen);
            grb_Thongtinhocvien.Font = new Font("Segoe UI", 12F);
            grb_Thongtinhocvien.Location = new Point(46, 113);
            grb_Thongtinhocvien.Name = "grb_Thongtinhocvien";
            grb_Thongtinhocvien.Size = new Size(467, 365);
            grb_Thongtinhocvien.TabIndex = 1;
            grb_Thongtinhocvien.TabStop = false;
            grb_Thongtinhocvien.Text = "Thông tin học viên";
            // 
            // lbl_Thongbao
            // 
            lbl_Thongbao.AutoSize = true;
            lbl_Thongbao.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Thongbao.Location = new Point(66, 270);
            lbl_Thongbao.Name = "lbl_Thongbao";
            lbl_Thongbao.Size = new Size(287, 28);
            lbl_Thongbao.TabIndex = 8;
            lbl_Thongbao.Text = "Không nhận email thông báo";
            lbl_Thongbao.Click += label6_Click;
            // 
            // cbo_Nhanemail
            // 
            cbo_Nhanemail.AutoSize = true;
            cbo_Nhanemail.Location = new Point(81, 209);
            cbo_Nhanemail.Name = "cbo_Nhanemail";
            cbo_Nhanemail.Size = new Size(230, 32);
            cbo_Nhanemail.TabIndex = 7;
            cbo_Nhanemail.Text = "Nhận email thông báo";
            cbo_Nhanemail.UseVisualStyleBackColor = true;
            // 
            // lbl_Ngaysinh
            // 
            lbl_Ngaysinh.AutoSize = true;
            lbl_Ngaysinh.Location = new Point(16, 145);
            lbl_Ngaysinh.Name = "lbl_Ngaysinh";
            lbl_Ngaysinh.Size = new Size(103, 28);
            lbl_Ngaysinh.TabIndex = 6;
            lbl_Ngaysinh.Text = "Ngày sinh:";
            lbl_Ngaysinh.Click += label4_Click;
            // 
            // dtp_NgaySinh
            // 
            dtp_NgaySinh.Format = DateTimePickerFormat.Short;
            dtp_NgaySinh.Location = new Point(121, 140);
            dtp_NgaySinh.Name = "dtp_NgaySinh";
            dtp_NgaySinh.Size = new Size(190, 34);
            dtp_NgaySinh.TabIndex = 5;
            // 
            // txt_SĐT
            // 
            txt_SĐT.Location = new Point(121, 91);
            txt_SĐT.Name = "txt_SĐT";
            txt_SĐT.Size = new Size(190, 34);
            txt_SĐT.TabIndex = 4;
            // 
            // lbl_sdt
            // 
            lbl_sdt.AutoSize = true;
            lbl_sdt.Location = new Point(16, 91);
            lbl_sdt.Name = "lbl_sdt";
            lbl_sdt.Size = new Size(51, 28);
            lbl_sdt.TabIndex = 3;
            lbl_sdt.Text = "SĐT:";
            // 
            // lbl_Chucai
            // 
            lbl_Chucai.AutoSize = true;
            lbl_Chucai.Location = new Point(331, 44);
            lbl_Chucai.Name = "lbl_Chucai";
            lbl_Chucai.Size = new Size(53, 28);
            lbl_Chucai.TabIndex = 2;
            lbl_Chucai.Text = "0/50";
            lbl_Chucai.Click += lbl_Chucai_Click;
            // 
            // txt_Hoten
            // 
            txt_Hoten.Location = new Point(121, 41);
            txt_Hoten.Name = "txt_Hoten";
            txt_Hoten.Size = new Size(190, 34);
            txt_Hoten.TabIndex = 1;
            txt_Hoten.TextChanged += txt_Hoten_TextChanged;
            // 
            // lbl_HoTen
            // 
            lbl_HoTen.AutoSize = true;
            lbl_HoTen.Location = new Point(16, 44);
            lbl_HoTen.Name = "lbl_HoTen";
            lbl_HoTen.Size = new Size(75, 28);
            lbl_HoTen.TabIndex = 0;
            lbl_HoTen.Text = "Họ tên:";
            // 
            // grb_Khoahoc
            // 
            grb_Khoahoc.BackColor = SystemColors.GradientActiveCaption;
            grb_Khoahoc.Controls.Add(lbl_tongtien);
            grb_Khoahoc.Controls.Add(lbl_hocphi);
            grb_Khoahoc.Controls.Add(lbl_hocphithang);
            grb_Khoahoc.Controls.Add(lbl_tongtien2);
            grb_Khoahoc.Controls.Add(num_sothang);
            grb_Khoahoc.Controls.Add(lbl_sothang);
            grb_Khoahoc.Controls.Add(rad_offline);
            grb_Khoahoc.Controls.Add(rad_online);
            grb_Khoahoc.Controls.Add(lbl_hinhthuchoc);
            grb_Khoahoc.Controls.Add(cbo_khoahoc);
            grb_Khoahoc.Controls.Add(lbl_khoahoc);
            grb_Khoahoc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grb_Khoahoc.Location = new Point(551, 113);
            grb_Khoahoc.Name = "grb_Khoahoc";
            grb_Khoahoc.Size = new Size(467, 365);
            grb_Khoahoc.TabIndex = 2;
            grb_Khoahoc.TabStop = false;
            grb_Khoahoc.Text = "Thông tin khóa học";
            // 
            // lbl_tongtien
            // 
            lbl_tongtien.AutoSize = true;
            lbl_tongtien.Location = new Point(188, 285);
            lbl_tongtien.Name = "lbl_tongtien";
            lbl_tongtien.Size = new Size(69, 28);
            lbl_tongtien.TabIndex = 10;
            lbl_tongtien.Text = "0 VNĐ";
            // 
            // lbl_hocphi
            // 
            lbl_hocphi.AutoSize = true;
            lbl_hocphi.Location = new Point(188, 222);
            lbl_hocphi.Name = "lbl_hocphi";
            lbl_hocphi.Size = new Size(69, 28);
            lbl_hocphi.TabIndex = 9;
            lbl_hocphi.Text = "0 VNĐ";
            // 
            // lbl_hocphithang
            // 
            lbl_hocphithang.AutoSize = true;
            lbl_hocphithang.Location = new Point(6, 222);
            lbl_hocphithang.Name = "lbl_hocphithang";
            lbl_hocphithang.Size = new Size(139, 28);
            lbl_hocphithang.TabIndex = 8;
            lbl_hocphithang.Text = "Học phí/tháng";
            // 
            // lbl_tongtien2
            // 
            lbl_tongtien2.AutoSize = true;
            lbl_tongtien2.Location = new Point(6, 285);
            lbl_tongtien2.Name = "lbl_tongtien2";
            lbl_tongtien2.Size = new Size(95, 28);
            lbl_tongtien2.TabIndex = 7;
            lbl_tongtien2.Text = "Tổng tiền";
            lbl_tongtien2.Click += label5_Click;
            // 
            // num_sothang
            // 
            num_sothang.Location = new Point(162, 143);
            num_sothang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            num_sothang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_sothang.Name = "num_sothang";
            num_sothang.Size = new Size(73, 34);
            num_sothang.TabIndex = 6;
            num_sothang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_sothang
            // 
            lbl_sothang.AutoSize = true;
            lbl_sothang.Location = new Point(6, 145);
            lbl_sothang.Name = "lbl_sothang";
            lbl_sothang.Size = new Size(91, 28);
            lbl_sothang.TabIndex = 5;
            lbl_sothang.Text = "Số tháng";
            // 
            // rad_offline
            // 
            rad_offline.AutoSize = true;
            rad_offline.Location = new Point(278, 93);
            rad_offline.Name = "rad_offline";
            rad_offline.Size = new Size(108, 32);
            rad_offline.TabIndex = 4;
            rad_offline.Text = "Trực tiếp";
            rad_offline.UseVisualStyleBackColor = true;
            rad_offline.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // rad_online
            // 
            rad_online.AutoSize = true;
            rad_online.Checked = true;
            rad_online.Location = new Point(162, 92);
            rad_online.Name = "rad_online";
            rad_online.Size = new Size(90, 32);
            rad_online.TabIndex = 3;
            rad_online.TabStop = true;
            rad_online.Text = "Online";
            rad_online.UseVisualStyleBackColor = true;
            // 
            // lbl_hinhthuchoc
            // 
            lbl_hinhthuchoc.AutoSize = true;
            lbl_hinhthuchoc.Location = new Point(6, 92);
            lbl_hinhthuchoc.Name = "lbl_hinhthuchoc";
            lbl_hinhthuchoc.Size = new Size(134, 28);
            lbl_hinhthuchoc.TabIndex = 2;
            lbl_hinhthuchoc.Text = "Hình thức học";
            // 
            // cbo_khoahoc
            // 
            cbo_khoahoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_khoahoc.FormattingEnabled = true;
            cbo_khoahoc.Location = new Point(162, 39);
            cbo_khoahoc.Name = "cbo_khoahoc";
            cbo_khoahoc.Size = new Size(197, 36);
            cbo_khoahoc.TabIndex = 1;
            cbo_khoahoc.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lbl_khoahoc
            // 
            lbl_khoahoc.AutoSize = true;
            lbl_khoahoc.Location = new Point(6, 42);
            lbl_khoahoc.Name = "lbl_khoahoc";
            lbl_khoahoc.Size = new Size(94, 28);
            lbl_khoahoc.TabIndex = 0;
            lbl_khoahoc.Text = "Khóa học";
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_thoat);
            panel1.Controls.Add(btn_lammoi);
            panel1.Controls.Add(btn_dangky);
            panel1.Location = new Point(168, 509);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 62);
            panel1.TabIndex = 3;
            // 
            // btn_thoat
            // 
            btn_thoat.BackColor = Color.Red;
            btn_thoat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_thoat.ForeColor = SystemColors.ButtonHighlight;
            btn_thoat.Location = new Point(555, 10);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(127, 45);
            btn_thoat.TabIndex = 2;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = false;
            // 
            // btn_lammoi
            // 
            btn_lammoi.BackColor = Color.Blue;
            btn_lammoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_lammoi.ForeColor = SystemColors.ButtonHighlight;
            btn_lammoi.Location = new Point(304, 10);
            btn_lammoi.Name = "btn_lammoi";
            btn_lammoi.Size = new Size(127, 45);
            btn_lammoi.TabIndex = 1;
            btn_lammoi.Text = "Làm mới";
            btn_lammoi.UseVisualStyleBackColor = false;
            // 
            // btn_dangky
            // 
            btn_dangky.BackColor = Color.Lime;
            btn_dangky.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_dangky.ForeColor = SystemColors.ButtonHighlight;
            btn_dangky.Location = new Point(62, 10);
            btn_dangky.Name = "btn_dangky";
            btn_dangky.Size = new Size(127, 45);
            btn_dangky.TabIndex = 0;
            btn_dangky.Text = "Đăng ký";
            btn_dangky.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1045, 589);
            Controls.Add(panel1);
            Controls.Add(grb_Khoahoc);
            Controls.Add(grb_Thongtinhocvien);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grb_Thongtinhocvien.ResumeLayout(false);
            grb_Thongtinhocvien.PerformLayout();
            grb_Khoahoc.ResumeLayout(false);
            grb_Khoahoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_sothang).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grb_Thongtinhocvien;
        private TextBox txt_Hoten;
        private Label lbl_HoTen;
        private Label lbl_Chucai;
        private Label lbl_Ngaysinh;
        private DateTimePicker dtp_NgaySinh;
        private TextBox txt_SĐT;
        private Label lbl_sdt;
        private CheckBox cbo_Nhanemail;
        private GroupBox grb_Khoahoc;
        private ComboBox cbo_khoahoc;
        private Label lbl_khoahoc;
        private RadioButton rad_offline;
        private RadioButton rad_online;
        private Label lbl_hinhthuchoc;
        private Label lbl_Thongbao;
        private Label lbl_sothang;
        private NumericUpDown num_sothang;
        private Label lbl_tongtien2;
        private Label lbl_tongtien;
        private Label lbl_hocphi;
        private Label lbl_hocphithang;
        private Panel panel1;
        private Button btn_thoat;
        private Button btn_lammoi;
        private Button btn_dangky;
    }
}
