namespace Form1.Forms
{
    partial class FrmBaoCaoSinhVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

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
            cboKetQua = new ComboBox();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            dgvBaoCao = new DataGridView();
            lblThongKe = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(55, 11);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(121, 28);
            cboLop.TabIndex = 0;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            // 
            // cboKetQua
            // 
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.FormattingEnabled = true;
            cboKetQua.Location = new Point(258, 10);
            cboKetQua.Name = "cboKetQua";
            cboKetQua.Size = new Size(121, 28);
            cboKetQua.TabIndex = 1;
            cboKetQua.SelectedIndexChanged += cboKetQua_SelectedIndexChanged;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(456, 11);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(150, 27);
            txtTuKhoa.TabIndex = 2;
            txtTuKhoa.TextChanged += txtTuKhoa_TextChanged;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Location = new Point(632, 12);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(100, 25);
            btnXemBaoCao.TabIndex = 3;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(738, 12);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(100, 25);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.Location = new Point(844, 12);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(100, 25);
            btnXuatFile.TabIndex = 5;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = true;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(12, 52);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.Size = new Size(932, 359);
            dgvBaoCao.TabIndex = 6;
            // 
            // lblThongKe
            // 
            lblThongKe.AutoSize = true;
            lblThongKe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblThongKe.Location = new Point(12, 414);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(78, 20);
            lblThongKe.TabIndex = 7;
            lblThongKe.Text = "Thống kê:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 8;
            label1.Text = "Lớp:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 15);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 9;
            label2.Text = "Kết quả:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(385, 15);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 10;
            label3.Text = "Từ khóa:";
            label3.Click += label3_Click;
            // 
            // FrmBaoCaoSinhVien
            // 
            ClientSize = new Size(956, 443);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblThongKe);
            Controls.Add(dgvBaoCao);
            Controls.Add(btnXuatFile);
            Controls.Add(btnThongKe);
            Controls.Add(btnXemBaoCao);
            Controls.Add(txtTuKhoa);
            Controls.Add(cboKetQua);
            Controls.Add(cboLop);
            Name = "FrmBaoCaoSinhVien";
            Text = "Báo cáo sinh viên";
            Load += FrmBaoCaoSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}