using Lab12.DAL;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace Lab12.Forms
{
    public partial class Form1 : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.DataSource = ketQuaSource;
        }
        private void LoadComboBox()
        {
            cboLop.DataSource = ketQuaDAL.GetLop();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
        }
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";
            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.");
                return;
            }
            DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
            ketQuaSource.DataSource = table;
        }
        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                ketQuaSource.EndEdit();
                DataTable table = (DataTable)ketQuaSource.DataSource;
                ValidateData(table);
                string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";
                int count = ketQuaDAL.SaveAll(maMon, table);
                MessageBox.Show($"Đã lưu thành công {count} dòng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu dữ liệu: " + ex.Message);
            }
        }
        private void ValidateData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                string maSV = row["MaSV"].ToString() ?? "";
                string diemText = row["Diem"].ToString() ?? "";
                if (!double.TryParse(diemText, out double diem))
                    throw new Exception($"Điểm của sinh viên {maSV} không hợp lệ.");
                if (diem < 0 || diem > 10)
                    throw new Exception($"Điểm của sinh viên {maSV} phải từ 0 đến 10.");
            }
        }
    }
}
