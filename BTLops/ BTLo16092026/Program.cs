using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HumanResources
{
    public class NhanVien
    {
        private string _maNV;
        private string _hoTen;
        private double _luongCoBan;

        public string MaNV
        {
            get => _maNV;
            set => _maNV = value;
        }

        public string HoTen
        {
            get => _hoTen;
            set => _hoTen = value;
        }

        public double LuongCoBan
        {
            get => _luongCoBan;
            set
            {
                if (value <= 0)
                    throw new Exception("Lương cơ bản không được âm.");
                _luongCoBan = value;
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã: {MaNV,-6} | Họ Tên: {HoTen,-18} | Lương: {TinhLuong(),11:N0} VNĐ");
        }
    }

    // LOP NHAN VIEN VAN PHONG
    public class NhanVienVanPhong : NhanVien
    {
        private int _soNgayLamViec;

        public int SoNgayLamViec
        {
            get => _soNgayLamViec;
            set
            {
                if (value < 0)
                    throw new Exception("Số ngày làm việc không được âm.");
                _soNgayLamViec = value;
            }
        }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (SoNgayLamViec * 200_000);
        }
        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã: {MaNV}");
            Console.WriteLine($"Họ Tên: {HoTen}");
            Console.WriteLine($"Lương: {TinhLuong(),11:N0} VNĐ");
            Console.WriteLine($"Số Ngày Làm Việc: {SoNgayLamViec}");
        }
    }

    // LOP NHAN VIEN KINH DOANH
    public class NhanVienKinhDoanh : NhanVien
    {
        private double _doanhSo;

        public double DoanhSo
        {
            get => _doanhSo;
            set
            {
                if (value < 0)
                    throw new Exception("Doanh số không được âm.");
                _doanhSo = value;
            }
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double doanhSo, double luongTheoGio)
            : base(maNV, hoTen, luongTheoGio)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (0.05 * DoanhSo);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã: {MaNV}");
            Console.WriteLine($"Họ Tên: {HoTen}");
            Console.WriteLine($"Lương: {TinhLuong(),11:N0} VNĐ");
            Console.WriteLine($"Doanh Số: {DoanhSo:N0}");
        }
    }

    // LOP NHAN VIEN THOI VU
    public class NhanVienThoiVu : NhanVien
    {
        private double _soGioLam;
        private double _luongTheoGio;

        public double SoGioLam
        {
            get => _soGioLam;
            set => _soGioLam = value >= 0 ? value : 0;
        }

        public double LuongTheoGio
        {
            get => _luongTheoGio;
            set => _luongTheoGio = value >= 0 ? value : 0;
        }

        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 1)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã: {MaNV}");
            Console.WriteLine($"Họ Tên: {HoTen}");
            Console.WriteLine($"Lương: {TinhLuong(),11:N0} VNĐ");
            Console.WriteLine($"Số Giờ Làm: {SoGioLam,4:F1}");
        }
    }

    // CHUONG TRINH
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<NhanVien> danhSach = new List<NhanVien>();

            while (true)
            {
                Console.WriteLine("\n==============MENU==============");
                Console.WriteLine("1. Xuất danh sách nhân viên");
                Console.WriteLine("2. Tìm nhân viên theo mã");
                Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("4. Tính tổng lương công ty phải trả");
                Console.WriteLine("5. Thêm nhân viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-5): ");

                string luaChon = Console.ReadLine();
                Console.WriteLine();

                switch (luaChon)
                {
                    case "1":
                        XuatDanhSachNhanVien(danhSach);
                        break;
                    case "2":
                        TimNhanVienTheoMa(danhSach);
                        break;
                    case "3":
                        TimNhanVienLuongCaoNhat(danhSach);
                        break;
                    case "4":
                        TinhTongLuong(danhSach);
                        break;
                    case "5":
                        ThemNhanVien(danhSach);
                        break;
                    case "0":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        static void KhoiTaoDuLieuMau(List<NhanVien> danhSach)
        {
            danhSach.Add(new NhanVienVanPhong("NV001", "Nguyen Van A", 5000000, 20));
            danhSach.Add(new NhanVienVanPhong("NV002", "Tran Thi B", 6000000, 22));
            danhSach.Add(new NhanVienKinhDoanh("NV003", "Le Van C", 160, 50000));
            danhSach.Add(new NhanVienKinhDoanh("NV004", "Pham Thi D", 180, 60000));
            danhSach.Add(new NhanVienThoiVu("NV005", "Hoang Van E", 100, 70000));
        }

        static void XuatDanhSachNhanVien(List<NhanVien> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên trống.");
                return;
            }

            var nhomNhanVien = danhSach.GroupBy(nv => nv.GetType());

            foreach (var nhom in nhomNhanVien)
            {
                string tenLoai = nhom.Key.Name switch
                {
                    nameof(NhanVienVanPhong) => "NhanVien Văn Phòng",
                    nameof(NhanVienKinhDoanh) => "NhanVien Kinh Doanh",
                    nameof(NhanVienThoiVu) => "NhanVien Thời Vụ",
                    _ => nhom.Key.Name
                };

                Console.WriteLine($"[{tenLoai}]");

                var danhSachTrongNhom = nhom.ToList();
                for (int i = 0; i < danhSachTrongNhom.Count; i++)
                {
                    danhSachTrongNhom[i].HienThiThongTin();

                    if (i < danhSachTrongNhom.Count - 1)
                    {
                        Console.WriteLine("-----------------------------");
                    }
                }
                Console.WriteLine();
            }
        }

        static void TimNhanVienTheoMa(List<NhanVien> danhSach)
        {
            Console.Write("Nhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine()?.Trim();

            NhanVien nv = danhSach.FirstOrDefault(x => x.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (nv != null)
            {
                Console.WriteLine("------Thông tin nhân viên ------");
                nv.HienThiThongTin();
            }
            else
            {
                Console.WriteLine($"Không tìm thấy nhân viên có mã {ma}.");
            }
        }

        static void TimNhanVienLuongCaoNhat(List<NhanVien> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên trống.");
                return;
            }
            double maxLuong = danhSach.Max(x => x.TinhLuong());
            var nhanViensLuongCaoNhat = danhSach.Where(x => Math.Abs(x.TinhLuong() - maxLuong) < 0.001).ToList();
            Console.WriteLine("------Nhân viên có lương cao nhất ------");
            for (int i = 0; i < nhanViensLuongCaoNhat.Count; i++)
            {
                nhanViensLuongCaoNhat[i].HienThiThongTin();
                if (i < nhanViensLuongCaoNhat.Count - 1)
                    Console.WriteLine("-----------------------------");
            }
        }

        static void TinhTongLuong(List<NhanVien> danhSach)
        {
            double tong = 0;
            foreach (var nv in danhSach)
            {
                tong += nv.TinhLuong();
            }
            Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0} VNĐ");
        }

        static void ThemNhanVien(List<NhanVien> danhSach)
        {
            Console.WriteLine("Chọn loại nhân viên cần thêm:");
            Console.WriteLine("1. Nhân viên văn phòng");
            Console.WriteLine("2. Nhân viên kinh doanh");
            Console.WriteLine("3. Nhân viên thời vụ");
            Console.Write("Lựa chọn (1-3): ");
            string luaChon = Console.ReadLine();

            Console.Write("Nhập mã nhân viên: ");
            string ma = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            string hoTen = Console.ReadLine();

            try
            {
                switch (luaChon)
                {
                    case "1":
                        CultureInfo viVn = new CultureInfo("vi-VN");
                        Console.Write("Nhập lương cơ bản: ");
                        string input = Console.ReadLine();
                        double luongCoBan = double.Parse(input, NumberStyles.AllowThousands | NumberStyles.Float, viVn);
                        Console.Write("Nhập số ngày làm việc: (0-31) ");
                        int soNgayLamViec = int.Parse(Console.ReadLine());
                        danhSach.Add(new NhanVienVanPhong(ma, hoTen, luongCoBan, soNgayLamViec));
                        break;
                    case "2":
                        Console.Write("Nhập số giờ làm: ");
                        double soGioLamKD = double.Parse(Console.ReadLine());
                        Console.Write("Nhập lương theo giờ: ");
                        double luongTheoGioKD = double.Parse(Console.ReadLine());
                        danhSach.Add(new NhanVienKinhDoanh(ma, hoTen, soGioLamKD, luongTheoGioKD));
                        break;
                    case "3":
                        Console.Write("Nhập số giờ làm: ");
                        double soGioLamTV = double.Parse(Console.ReadLine());
                        Console.Write("Nhập lương theo giờ: ");
                        double luongTheoGioTV = double.Parse(Console.ReadLine());
                        danhSach.Add(new NhanVienThoiVu(ma, hoTen, soGioLamTV, luongTheoGioTV));
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}