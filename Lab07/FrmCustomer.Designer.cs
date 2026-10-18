namespace Lab07.Forms
{
    partial class FrmCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grbThongTin = new GroupBox();
            cboLoaiKH = new ComboBox();
            label4 = new Label();
            txtSDT = new TextBox();
            label3 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtMaKH = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvCustomers = new DataGridView();
            grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // grbThongTin
            // 
            grbThongTin.Controls.Add(cboLoaiKH);
            grbThongTin.Controls.Add(label4);
            grbThongTin.Controls.Add(txtSDT);
            grbThongTin.Controls.Add(label3);
            grbThongTin.Controls.Add(txtHoTen);
            grbThongTin.Controls.Add(label2);
            grbThongTin.Controls.Add(txtMaKH);
            grbThongTin.Controls.Add(label1);
            grbThongTin.Location = new Point(12, 12);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(320, 204);
            grbThongTin.TabIndex = 0;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin khách hàng";
            // 
            // cboLoaiKH
            // 
            cboLoaiKH.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiKH.Items.AddRange(new object[] { "Khách vãng lai", "Thành viên", "VIP" });
            cboLoaiKH.Location = new Point(100, 152);
            cboLoaiKH.Name = "cboLoaiKH";
            cboLoaiKH.Size = new Size(200, 28);
            cboLoaiKH.TabIndex = 0;
            // 
            // label4
            // 
            label4.Location = new Point(15, 155);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 1;
            label4.Text = "Loại KH:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(100, 112);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(200, 27);
            txtSDT.TabIndex = 2;
            // 
            // label3
            // 
            label3.Location = new Point(15, 115);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 3;
            label3.Text = "Số điện thoại:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(100, 72);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 27);
            txtHoTen.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new Point(15, 75);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 5;
            label2.Text = "Họ tên:";
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(100, 32);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(200, 27);
            txtMaKH.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(15, 35);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 7;
            label1.Text = "Mã KH:";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.Highlight;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(10, 232);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 35);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Chartreuse;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(91, 232);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 35);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(172, 232);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 35);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DarkOrange;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(253, 232);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(77, 35);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(350, 20);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên để tìm...";
            txtTimKiem.Size = new Size(350, 27);
            txtTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Location = new Point(710, 19);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(85, 30);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.ColumnHeadersHeight = 29;
            dgvCustomers.Location = new Point(350, 60);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(445, 536);
            dgvCustomers.TabIndex = 0;
            // 
            // FrmCustomer
            // 
            ClientSize = new Size(810, 608);
            Controls.Add(dgvCustomers);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grbThongTin);
            Name = "FrmCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khách hàng";
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label label1; private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label2; private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3; private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4; private System.Windows.Forms.ComboBox cboLoaiKH;
        private System.Windows.Forms.Button btnThem; private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa; private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem; private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}