using System;
using System.Text;

namespace QuanLyMangSoNguyen
{
    class Program
    {
        static int[]? arr = null;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ MẢNG SỐ NGUYÊN =====");
                Console.WriteLine("1. Nhập mảng");
                Console.WriteLine("2. Xuất mảng");
                Console.WriteLine("3. Tính tổng các phần tử");
                Console.WriteLine("4. Tìm giá trị lớn nhất và nhỏ nhất");
                Console.WriteLine("5. Đếm số chẵn, số lẻ");
                Console.WriteLine("6. Sắp xếp mảng tăng dần");
                Console.WriteLine("7. Tìm kiếm một giá trị");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Mời chọn chức năng (0-7): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        NhapMang();
                        break;
                    case "2":
                        XuatMang();
                        break;
                    case "3":
                        Tong();
                        break;
                    case "4":
                        TimMaxMin();
                        break;
                    case "5":
                        DemChanLe();
                        break;
                    case "6":
                        SapXepTangDan();
                        break;
                    case "7":
                        TimKiemGiaTri();
                        break;
                    case "0":
                        Console.WriteLine("Đã thoát chương trình");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }
            }
        }

        // Kiểm tra mảng 
        static bool KtraMangRong()
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Mảng chưa được nhập! Vui lòng chọn 1 chức năng ");
                return true;
            }
            return false;
        }

        // 1. Nhập mảng
        static void NhapMang()
        {
            int n;
            while (true)
            {
                Console.Write("Nhập số lượng phần tử của mảng (n > 0): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Số lượng phần tử không hợp lệ.");
            }

            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"arr[{i}] = ");
                    if (int.TryParse(Console.ReadLine(), out arr[i]))
                    {
                        break;
                    }
                    Console.WriteLine("Dữ liệu phải là số nguyên.");
                }
            }
            Console.WriteLine("Nhập mảng thành công!");
        }

        // 2. Xuất mảng
        static void XuatMang()
        {
            if (KtraMangRong()) return;

            Console.Write("Các phần tử trong mảng: ");
            for (int i = 0; i < arr!.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // 3. Tính tổng
        static void Tong()
        {
            if (KtraMangRong()) return;

            long tong = 0;
            foreach (int x in arr!)
            {
                tong += x;
            }
            Console.WriteLine($"Tổng các phần tử trong mảng = {tong}");
        }

        // 4. Tìm max, min
        static void TimMaxMin()
        {
            if (KtraMangRong()) return;

            int max = arr![0];
            int min = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }

            Console.WriteLine($"Giá trị lớn nhất (Max): {max}");
            Console.WriteLine($"Giá trị nhỏ nhất (Min): {min}");
        }

        // 5. Đếm số chẵn, số lẻ
        static void DemChanLe()
        {
            if (KtraMangRong()) return;

            int countChan = 0;
            int countLe = 0;

            foreach (int x in arr!)
            {
                if (x % 2 == 0)
                    countChan++;
                else
                    countLe++;
            }

            Console.WriteLine($"Số lượng số chẵn: {countChan}");
            Console.WriteLine($"Số lượng số lẻ: {countLe}");
        }

        // 6. Sắp xếp tăng dần
        static void SapXepTangDan()
        {
            if (KtraMangRong()) return;

            Array.Sort(arr!);
            Console.WriteLine("Mảng đã được sắp xếp tăng dần thành công!");
            XuatMang();
        }

        // 7. Tìm kiếm một giá trị
        static void TimKiemGiaTri()
        {
            if (KtraMangRong()) return;

            Console.Write("Nhập giá trị cần tìm: ");
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine("Giá trị tìm kiếm phải là số nguyên!");
                return;
            }

            bool timThay = false;
            Console.Write($"Giá trị {x} xuất hiện tại các vị trí (index): ");
            for (int i = 0; i < arr!.Length; i++)
            {
                if (arr[i] == x)
                {
                    Console.Write(i + " ");
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy trong mảng.");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}