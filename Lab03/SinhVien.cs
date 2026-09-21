using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double _diemTrungBinh;
        public double DiemTrungBinh
        {
            get => _diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Diem trung binh phai trong khoang tu 0 den 10.");
                }
                _diemTrungBinh = value;
            }
        }

        public SinhVien() : base()
        {
            MaSinhVien = string.Empty;
            MaLop = string.Empty;
            _diemTrungBinh = 0;
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.5) return "Xuat sac";
            if (DiemTrungBinh >= 8.0) return "Gioi";
            if (DiemTrungBinh >= 6.5) return "Kha";
            if (DiemTrungBinh >= 5.0) return "Trung binh";
            return "Yeu";
        }

        public override string LayThongTin()
        {
            return $"Ma SV: {MaSinhVien,-8} | Ho ten: {HoTen,-20} | Lop: {MaLop,-8} | Ngay sinh: {NgaySinh:dd/MM/yyyy} | DTB: {DiemTrungBinh,4:F1} | Xep loai: {XepLoai()}";
        }
    }
}