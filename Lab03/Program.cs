using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab03_QuanLySinhVienOOP
{
    internal class Program
    {
        private static readonly QuanLySinhVien _quanLy = new QuanLySinhVien();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chon chuc nang: ");
                Console.WriteLine();

                switch (luaChon)
                {
                    case 1:
                        ChucNangThemSinhVien();
                        break;
                    case 2:
                        ChucNangXuatDanhSach(_quanLy.LayDanhSach(), "DANH SACH SINH VIEN");
                        break;
                    case 3:
                        ChucNangTimTheoMa();
                        break;
                    case 4:
                        ChucNangTimTheoTen();
                        break;
                    case 5:
                        ChucNangSuaDiem();
                        break;
                    case 6:
                        ChucNangXoaSinhVien();
                        break;
                    case 7:
                        ChucNangSapXep();
                        break;
                    case 8:
                        ChucNangLocDat();
                        break;
                    case 0:
                        Console.WriteLine("Cam on ban da su dung chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai tu 0 den 8.");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (luaChon != 0);
        }

        private static void HienThiMenu()
        {
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
        }

        private static void ChucNangThemSinhVien()
        {
            Console.WriteLine("--- THEM SINH VIEN MOI ---");
            string maSv;
            while (true)
            {
                maSv = NhapChuoi("Nhap ma sinh vien: ");
                if (_quanLy.TimTheoMa(maSv) != null)
                {
                    Console.WriteLine("Loi: Ma sinh vien da ton tai. Vui long nhap ma khac!");
                }
                else
                {
                    break;
                }
            }

            string hoTen = NhapChuoi("Nhap ho ten: ");
            DateTime ngaySinh = NhapNgayThang("Nhap ngay sinh (dd/MM/yyyy): ");
            string maLop = NhapChuoi("Nhap ma lop: ");
            double diemTb = NhapDiemTrungBinh("Nhap diem trung binh (0.0 - 10.0): ");

            SinhVien sv = new SinhVien(maSv, hoTen, ngaySinh, maLop, diemTb);
            if (_quanLy.Them(sv))
            {
                Console.WriteLine("=> Them sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine("=> Them that bai!");
            }
        }

        private static void ChucNangXuatDanhSach(List<SinhVien> danhSach, string tieuDe)
        {
            Console.WriteLine($"--- {tieuDe} ---");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach trong.");
                return;
            }

            foreach (var sv in danhSach)
            {
                Console.WriteLine(sv.LayThongTin());
            }
            Console.WriteLine($"Tong cong: {danhSach.Count} sinh vien.");
        }

        private static void ChucNangTimTheoMa()
        {
            Console.WriteLine("--- TIM SINH VIEN THEO MA ---");
            string ma = NhapChuoi("Nhap ma sinh vien can tim: ");
            var sv = _quanLy.TimTheoMa(ma);

            if (sv != null)
            {
                Console.WriteLine("Tim thay sinh vien:");
                Console.WriteLine(sv.LayThongTin());
            }
            else
            {
                Console.WriteLine($"Khong tim thay sinh vien co ma '{ma}'.");
            }
        }

        private static void ChucNangTimTheoTen()
        {
            Console.WriteLine("--- TIM SINH VIEN THEO TEN ---");
            string tuKhoa = NhapChuoi("Nhap tu khoa ho ten: ");
            var ketQua = _quanLy.TimTheoTen(tuKhoa);

            ChucNangXuatDanhSach(ketQua, $"KET QUA TIM KIEM THEO TU KHOA '{tuKhoa}'");
        }

        private static void ChucNangSuaDiem()
        {
            Console.WriteLine("--- SUA DIEM TRUNG BINH ---");
            string ma = NhapChuoi("Nhap ma sinh vien can sua diem: ");
            var sv = _quanLy.TimTheoMa(ma);

            if (sv == null)
            {
                Console.WriteLine($"Khong tim thay sinh vien co ma '{ma}'.");
                return;
            }

            Console.WriteLine($"Thong tin hien tai: {sv.LayThongTin()}");
            double diemMoi = NhapDiemTrungBinh("Nhap diem trung binh moi (0.0 - 10.0): ");
            _quanLy.SuaDiem(ma, diemMoi);
            Console.WriteLine("=> Cap nhat diem thanh cong!");
        }

        private static void ChucNangXoaSinhVien()
        {
            Console.WriteLine("--- XOA SINH VIEN ---");
            string ma = NhapChuoi("Nhap ma sinh vien can xoa: ");
            if (_quanLy.Xoa(ma))
            {
                Console.WriteLine($"=> Da xoa sinh vien co ma '{ma}' thanh cong.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay sinh vien co ma '{ma}' de xoa.");
            }
        }

        private static void ChucNangSapXep()
        {
            var dsSapXep = _quanLy.SapXepTheoDiemGiamDan();
            ChucNangXuatDanhSach(dsSapXep, "DANH SACH SAP XEP THEO DIEM GIAM DAN");
        }

        private static void ChucNangLocDat()
        {
            var dsDat = _quanLy.LocSinhVienDat();
            ChucNangXuatDanhSach(dsDat, "DANH SACH SINH VIEN DAT (DIEM >= 5.0)");
        }

        // ================= CAC HAM VALIDATION DU LIEU =================
        private static string NhapChuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine("Loi: Du lieu khong duoc de trong. Vui long nhap lai!");
            }
        }

        private static int NhapSoNguyen(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out int giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("Loi: Vui long nhap mot so nguyen hop le!");
            }
        }

        private static double NhapDiemTrungBinh(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                // Ho tro ca dau cham (.) va dau phay (,) khi nhap so thuc
                if (double.TryParse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double diem))
                {
                    if (diem >= 0.0 && diem <= 10.0)
                    {
                        return diem;
                    }
                    Console.WriteLine("Loi: Diem trung binh phai nam trong khoang tu 0 den 10!");
                }
                else
                {
                    Console.WriteLine("Loi: Gia tri nhap vao khong phai so hop le!");
                }
            }
        }

        private static DateTime NhapNgayThang(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh) ||
                    DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                {
                    return ngaySinh;
                }
                Console.WriteLine("Loi: Dinh dang ngay khong hop le (dinh dang chuan: dd/MM/yyyy, vi du: 15/08/2004)!");
            }
        }
    }
}