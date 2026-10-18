namespace Lab07.Forms
{
    partial class FrmAbout
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
            lblAppName = new Label();
            lblVersion = new Label();
            lblAuthor = new Label();
            lblSchool = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppName.ForeColor = Color.DodgerBlue;
            lblAppName.Location = new Point(57, 22);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(442, 37);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "PHẦN MỀM QUẢN LÝ CỬA HÀNG";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 10F);
            lblVersion.Location = new Point(35, 70);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(118, 23);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Phiên bản: 1.0";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F);
            lblAuthor.Location = new Point(57, 109);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(436, 28);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Sinh viên thực hiện: Kiều Gia Bảo - 51.01.104.128";
            // 
            // lblSchool
            // 
            lblSchool.AutoSize = true;
            lblSchool.Font = new Font("Segoe UI", 10F);
            lblSchool.Location = new Point(57, 155);
            lblSchool.Name = "lblSchool";
            lblSchool.Size = new Size(393, 23);
            lblSchool.TabIndex = 3;
            lblSchool.Text = "Trường: Đại học Sư phạm Thành phố Hồ Chí Minh";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.Location = new Point(205, 244);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 40);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // FrmAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 336);
            Controls.Add(btnClose);
            Controls.Add(lblSchool);
            Controls.Add(lblAuthor);
            Controls.Add(lblVersion);
            Controls.Add(lblAppName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giới thiệu";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Button btnClose;
    }
}