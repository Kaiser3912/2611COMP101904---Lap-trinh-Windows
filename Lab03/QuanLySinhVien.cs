using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> _danhSachSinhVien;

        public QuanLySinhVien()
        {
            _danhSachSinhVien = new List<SinhVien>();
        }

        public List<SinhVien> LayDanhSach()
        {
            return _danhSachSinhVien;
        }

        public bool Them(SinhVien sv)
        {
            if (TimTheoMa(sv.MaSinhVien) != null)
            {
                return false; // Trung ma sinh vien
            }
            _danhSachSinhVien.Add(sv);
            return true;
        }

        public SinhVien TimTheoMa(string maSv)
        {
            return _danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien.Equals(maSv, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return _danhSachSinhVien
                .Where(sv => sv.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public bool SuaDiem(string maSv, double diemMoi)
        {
            var sv = TimTheoMa(maSv);
            if (sv == null) return false;

            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        public bool Xoa(string maSv)
        {
            var sv = TimTheoMa(maSv);
            if (sv == null) return false;

            return _danhSachSinhVien.Remove(sv);
        }

        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return _danhSachSinhVien.OrderByDescending(sv => sv.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return _danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= 5.0).ToList();
        }
    }
}