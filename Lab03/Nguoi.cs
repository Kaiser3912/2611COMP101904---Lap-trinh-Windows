using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi()
        {
            HoTen = string.Empty;
            NgaySinh = DateTime.MinValue;
        }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual string LayThongTin()
        {
            return $"Ho ten: {HoTen} | Ngay sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}