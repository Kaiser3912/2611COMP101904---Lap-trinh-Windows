namespace Lab07.Forms
{
    partial class FrmProduct
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
            numSoLuong = new NumericUpDown();
            label5 = new Label();
            numDonGia = new NumericUpDown();
            label4 = new Label();
            cboLoaiSP = new ComboBox();
            label3 = new Label();
            txtTenSP = new TextBox();
            label2 = new Label();
            txtMaSP = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvProducts = new DataGridView();
            grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // grbThongTin
            // 
            grbThongTin.Controls.Add(numSoLuong);
            grbThongTin.Controls.Add(label5);
            grbThongTin.Controls.Add(numDonGia);
            grbThongTin.Controls.Add(label4);
            grbThongTin.Controls.Add(cboLoaiSP);
            grbThongTin.Controls.Add(label3);
            grbThongTin.Controls.Add(txtTenSP);
            grbThongTin.Controls.Add(label2);
            grbThongTin.Controls.Add(txtMaSP);
            grbThongTin.Controls.Add(label1);
            grbThongTin.Location = new Point(12, 12);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(320, 250);
            grbThongTin.TabIndex = 0;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin sản phẩm";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(90, 192);
            numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(210, 27);
            numSoLuong.TabIndex = 0;
            // 
            // label5
            // 
            label5.Location = new Point(15, 195);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 1;
            label5.Text = "Số lượng:";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(90, 152);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(210, 27);
            numDonGia.TabIndex = 2;
            // 
            // label4
            // 
            label4.Location = new Point(15, 155);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Đơn giá:";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Phụ kiện", "Khác" });
            cboLoaiSP.Location = new Point(90, 112);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(210, 28);
            cboLoaiSP.TabIndex = 4;
            // 
            // label3
            // 
            label3.Location = new Point(15, 115);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Loại SP:";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(90, 72);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(210, 27);
            txtTenSP.TabIndex = 6;
            // 
            // label2
            // 
            label2.Location = new Point(15, 75);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 7;
            label2.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(90, 32);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(210, 27);
            txtMaSP.TabIndex = 8;
            // 
            // label1
            // 
            label1.Location = new Point(15, 35);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 9;
            label1.Text = "Mã SP:";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.HotTrack;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(12, 280);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 35);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Chartreuse;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(93, 280);
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
            btnXoa.Location = new Point(174, 280);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 35);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Orange;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(255, 280);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(89, 35);
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
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Location = new Point(350, 60);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(445, 545);
            dgvProducts.TabIndex = 0;
            // 
            // FrmProduct
            // 
            ClientSize = new Size(812, 648);
            Controls.Add(dgvProducts);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grbThongTin);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Sản phẩm";
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label label1; private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label2; private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label3; private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label label4; private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label label5; private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThem; private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa; private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem; private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}