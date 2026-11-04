namespace Lab12.Forms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnLuuTatCa;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMonHoc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cboLop = new ComboBox();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            dgvKetQua = new DataGridView();
            btnLuuTatCa = new Button();
            lblLop = new Label();
            lblMonHoc = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            SuspendLayout();
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(92, 15);
            cboLop.Margin = new Padding(3, 4, 3, 4);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(171, 28);
            cboLop.TabIndex = 0;
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(379, 16);
            cboMonHoc.Margin = new Padding(3, 4, 3, 4);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(171, 28);
            cboMonHoc.TabIndex = 1;
            // 
            // btnTaiDanhSach
            // 
            btnTaiDanhSach.Location = new Point(571, 15);
            btnTaiDanhSach.Margin = new Padding(3, 4, 3, 4);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(114, 33);
            btnTaiDanhSach.TabIndex = 2;
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.UseVisualStyleBackColor = true;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            // 
            // dgvKetQua
            // 
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Location = new Point(14, 67);
            dgvKetQua.Margin = new Padding(3, 4, 3, 4);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.RowHeadersWidth = 51;
            dgvKetQua.RowTemplate.Height = 25;
            dgvKetQua.Size = new Size(672, 467);
            dgvKetQua.TabIndex = 3;
            // 
            // btnLuuTatCa
            // 
            btnLuuTatCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuuTatCa.Location = new Point(571, 547);
            btnLuuTatCa.Margin = new Padding(3, 4, 3, 4);
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Size = new Size(114, 40);
            btnLuuTatCa.TabIndex = 4;
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.UseVisualStyleBackColor = true;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(14, 20);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(72, 20);
            lblLop.TabIndex = 5;
            lblLop.Text = "Chọn lớp:";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(271, 20);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(108, 20);
            lblMonHoc.TabIndex = 6;
            lblMonHoc.Text = "Chọn môn học:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 600);
            Controls.Add(lblMonHoc);
            Controls.Add(lblLop);
            Controls.Add(btnLuuTatCa);
            Controls.Add(dgvKetQua);
            Controls.Add(btnTaiDanhSach);
            Controls.Add(cboMonHoc);
            Controls.Add(cboLop);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Quản lý Kết quả Học tập";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}