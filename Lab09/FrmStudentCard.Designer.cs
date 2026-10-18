namespace Lab09
{
    partial class FrmStudentCard
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudentCard));
            txtStudentId = new TextBox();
            txtFullName = new TextBox();
            cboClass = new ComboBox();
            cboFaculty = new ComboBox();
            txtCourse = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cboGender = new ComboBox();
            picAvatar = new PictureBox();
            pnlCardPreview = new Panel();
            btnChoosePhoto = new Button();
            btnPreviewPrint = new Button();
            btnPrint = new Button();
            btnClear = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();
            pnlInput = new Panel();
            lblId = new Label();
            lblName = new Label();
            lblClass = new Label();
            lblFaculty = new Label();
            lblCourse = new Label();
            lblBirth = new Label();
            lblGender = new Label();
            lblAvatar = new Label();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(120, 20);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(200, 27);
            txtStudentId.TabIndex = 1;
            txtStudentId.TextChanged += InputChanged;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(120, 55);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 27);
            txtFullName.TabIndex = 3;
            txtFullName.TextChanged += InputChanged;
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.Location = new Point(120, 90);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(200, 28);
            cboClass.TabIndex = 5;
            cboClass.SelectedIndexChanged += InputChanged;
            // 
            // cboFaculty
            // 
            cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFaculty.Location = new Point(120, 125);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(200, 28);
            cboFaculty.TabIndex = 7;
            cboFaculty.SelectedIndexChanged += InputChanged;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(120, 160);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(200, 27);
            txtCourse.TabIndex = 9;
            txtCourse.TextChanged += InputChanged;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(120, 195);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 27);
            dtpBirthDate.TabIndex = 11;
            dtpBirthDate.ValueChanged += InputChanged;
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Location = new Point(120, 230);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(200, 28);
            cboGender.TabIndex = 13;
            cboGender.SelectedIndexChanged += InputChanged;
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(120, 265);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(100, 130);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 15;
            picAvatar.TabStop = false;
            // 
            // pnlCardPreview
            // 
            pnlCardPreview.BackColor = Color.White;
            pnlCardPreview.Dock = DockStyle.Fill;
            pnlCardPreview.Location = new Point(360, 0);
            pnlCardPreview.Name = "pnlCardPreview";
            pnlCardPreview.Size = new Size(605, 553);
            pnlCardPreview.TabIndex = 0;
            pnlCardPreview.Paint += pnlCardPreview_Paint;
            // 
            // btnChoosePhoto
            // 
            btnChoosePhoto.Location = new Point(230, 365);
            btnChoosePhoto.Name = "btnChoosePhoto";
            btnChoosePhoto.Size = new Size(90, 30);
            btnChoosePhoto.TabIndex = 16;
            btnChoosePhoto.Text = "Chọn ảnh";
            btnChoosePhoto.Click += btnChoosePhoto_Click;
            // 
            // btnPreviewPrint
            // 
            btnPreviewPrint.Location = new Point(100, 420);
            btnPreviewPrint.Name = "btnPreviewPrint";
            btnPreviewPrint.Size = new Size(100, 35);
            btnPreviewPrint.TabIndex = 18;
            btnPreviewPrint.Text = "Xem trước";
            btnPreviewPrint.Click += btnPreviewPrint_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(210, 420);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(110, 35);
            btnPrint.TabIndex = 19;
            btnPrint.Text = "In thẻ";
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(10, 420);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 35);
            btnClear.TabIndex = 17;
            btnClear.Text = "Làm mới";
            btnClear.Click += btnClear_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // pnlInput
            // 
            pnlInput.Controls.Add(lblId);
            pnlInput.Controls.Add(txtStudentId);
            pnlInput.Controls.Add(lblName);
            pnlInput.Controls.Add(txtFullName);
            pnlInput.Controls.Add(lblClass);
            pnlInput.Controls.Add(cboClass);
            pnlInput.Controls.Add(lblFaculty);
            pnlInput.Controls.Add(cboFaculty);
            pnlInput.Controls.Add(lblCourse);
            pnlInput.Controls.Add(txtCourse);
            pnlInput.Controls.Add(lblBirth);
            pnlInput.Controls.Add(dtpBirthDate);
            pnlInput.Controls.Add(lblGender);
            pnlInput.Controls.Add(cboGender);
            pnlInput.Controls.Add(lblAvatar);
            pnlInput.Controls.Add(picAvatar);
            pnlInput.Controls.Add(btnChoosePhoto);
            pnlInput.Controls.Add(btnClear);
            pnlInput.Controls.Add(btnPreviewPrint);
            pnlInput.Controls.Add(btnPrint);
            pnlInput.Dock = DockStyle.Left;
            pnlInput.Location = new Point(0, 0);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(10);
            pnlInput.Size = new Size(360, 553);
            pnlInput.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.Location = new Point(10, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 25);
            lblId.TabIndex = 0;
            lblId.Text = "Mã sinh viên:";
            // 
            // lblName
            // 
            lblName.Location = new Point(10, 58);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Họ tên:";
            // 
            // lblClass
            // 
            lblClass.Location = new Point(10, 93);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(100, 25);
            lblClass.TabIndex = 4;
            lblClass.Text = "Lớp:";
            // 
            // lblFaculty
            // 
            lblFaculty.Location = new Point(10, 128);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(100, 25);
            lblFaculty.TabIndex = 6;
            lblFaculty.Text = "Khoa:";
            // 
            // lblCourse
            // 
            lblCourse.Location = new Point(10, 163);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(100, 25);
            lblCourse.TabIndex = 8;
            lblCourse.Text = "Khóa học:";
            // 
            // lblBirth
            // 
            lblBirth.Location = new Point(10, 198);
            lblBirth.Name = "lblBirth";
            lblBirth.Size = new Size(100, 25);
            lblBirth.TabIndex = 10;
            lblBirth.Text = "Ngày sinh:";
            // 
            // lblGender
            // 
            lblGender.Location = new Point(10, 233);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 25);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính:";
            // 
            // lblAvatar
            // 
            lblAvatar.Location = new Point(10, 265);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(100, 25);
            lblAvatar.TabIndex = 14;
            lblAvatar.Text = "Ảnh đại diện:";
            // 
            // FrmStudentCard
            // 
            ClientSize = new Size(965, 553);
            Controls.Add(pnlCardPreview);
            Controls.Add(pnlInput);
            Name = "FrmStudentCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thiết kế và in thẻ sinh viên";
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
        }

        // Khai báo các control
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.ComboBox cboFaculty;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlCardPreview;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.Button btnPreviewPrint;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private Panel pnlInput;
        private Label lblId;
        private Label lblName;
        private Label lblClass;
        private Label lblFaculty;
        private Label lblCourse;
        private Label lblBirth;
        private Label lblGender;
        private Label lblAvatar;
    }
}