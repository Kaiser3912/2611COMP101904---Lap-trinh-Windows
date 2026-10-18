namespace Lab08
{
    partial class FrmPaint
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
            this.canvas = new Lab08.DrawSurface();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            System.Windows.Forms.Panel topPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Label lblMode = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblWidth = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();

            // topPanel
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 48;
            topPanel.BackColor = System.Drawing.Color.FromArgb(238, 247, 247);
            topPanel.Controls.Add(lblMode);
            topPanel.Controls.Add(this.cboMode);
            topPanel.Controls.Add(lblWidth);
            topPanel.Controls.Add(this.nudWidth);
            topPanel.Controls.Add(this.btnColor);
            topPanel.Controls.Add(this.btnUndo);
            topPanel.Controls.Add(this.btnClear);

            // lblMode
            lblMode.Text = "Mode";
            lblMode.Left = 15; lblMode.Top = 16; lblMode.AutoSize = true;

            // cboMode
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            this.cboMode.SelectedIndex = 0;
            this.cboMode.Width = 110; this.cboMode.Left = 70; this.cboMode.Top = 12;

            // lblWidth
            lblWidth.Text = "Width";
            lblWidth.Left = 200; lblWidth.Top = 16; lblWidth.AutoSize = true;

            // nudWidth
            this.nudWidth.Minimum = 1; this.nudWidth.Maximum = 20; this.nudWidth.Value = 3;
            this.nudWidth.Width = 60; this.nudWidth.Left = 250; this.nudWidth.Top = 12;

            // btnColor
            this.btnColor.Text = "Color";
            this.btnColor.Left = 330; this.btnColor.Top = 10; this.btnColor.Width = 80;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);

            // btnUndo
            this.btnUndo.Text = "Undo";
            this.btnUndo.Left = 430; this.btnUndo.Top = 10; this.btnUndo.Width = 80;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);

            // btnClear
            this.btnClear.Text = "Clear";
            this.btnClear.Left = 530; this.btnClear.Top = 10; this.btnClear.Width = 80;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // lblStatus
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Height = 26;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // canvas
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);

            // FrmPaint
            this.Text = "COMP1019 - Simple Paint";
            this.Width = 1000;
            this.Height = 650;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(topPanel);

            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);
        }

        // Khai báo các biến giao diện
        private Lab08.DrawSurface canvas;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}