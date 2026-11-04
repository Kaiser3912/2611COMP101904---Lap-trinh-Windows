
using Lab14.DAL;
using Lab14.Models;
using System.Collections.Generic;

namespace Lab14.BLL
{
    public class MonHocBLL
    {
        private MonHocDAL dal = new MonHocDAL();

        public List<MonHoc> GetAllMonHoc() => dal.GetAll();

        public string AddMonHoc(MonHoc monHoc)
        {
            if (string.IsNullOrWhiteSpace(monHoc.MaMonHoc)) return "Mã môn học không được rỗng.";
            if (string.IsNullOrWhiteSpace(monHoc.TenMonHoc)) return "Tên môn học không được rỗng.";
            if (monHoc.SoTinChi < 1 || monHoc.SoTinChi > 6) return "Số tín chỉ phải từ 1 đến 6.";

            if (dal.GetById(monHoc.MaMonHoc) != null) return "Mã môn học đã tồn tại.";

            return dal.Insert(monHoc) ? "Thêm thành công!" : "Lỗi khi lưu vào cơ sở dữ liệu.";
        }

        public string UpdateMonHoc(MonHoc monHoc)
        {
            if (string.IsNullOrWhiteSpace(monHoc.MaMonHoc)) return "Mã môn học không được rỗng.";
            if (string.IsNullOrWhiteSpace(monHoc.TenMonHoc)) return "Tên môn học không được rỗng.";
            if (monHoc.SoTinChi < 1 || monHoc.SoTinChi > 6) return "Số tín chỉ phải từ 1 đến 6.";

            if (dal.GetById(monHoc.MaMonHoc) == null) return "Môn học không tồn tại.";

            return dal.Update(monHoc) ? "Cập nhật thành công!" : "Cập nhật thất bại.";
        }

        public string DeleteMonHoc(string maMonHoc)
        {
            if (dal.GetById(maMonHoc) == null) return "Môn học không tồn tại để xóa.";
            return dal.Delete(maMonHoc) ? "Xóa thành công!" : "Xóa thất bại.";
        }

        public List<MonHoc> SearchMonHoc(string keyword) => dal.Search(keyword);
    }
}