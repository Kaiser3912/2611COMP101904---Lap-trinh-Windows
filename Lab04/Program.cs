using Lab04;
using System;
using System.Linq;
using System.Text;

namespace Lab04
{
    internal class Program
    {
        private static ProductService _dichvu = null!;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var repository = new Repository<Product>();
            _dichvu = new ProductService(repository);
            _dichvu.OnProductAdded += product =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[EVENT] Đã thêm thành công sản phẩm: {product.TenSP} (Mã: {product.MaSP})");
                Console.ResetColor();
            };

            _dichvu.OnProductRemoved += product =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[EVENT] Đã xóa thành công sản phẩm: {product.TenSP} (Mã: {product.MaSP})");
                Console.ResetColor();
            };

            // Thêm dữ liệu mẫu ban đầu để tiện kiểm thử
            SeedTestData();

            while (true)
            {
                ShowMenu();
                Console.Write("Chọn: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice?.Trim())
                    {
                        case "1":
                            HandleAddProduct();
                            break;
                        case "2":
                            HandleDisplayAll();
                            break;
                        case "3":
                            HandleFindById();
                            break;
                        case "4":
                            HandleSearchByName();
                            break;
                        case "5":
                            HandleFilterByPrice();
                            break;
                        case "6":
                            HandleRemoveProduct();
                            break;
                        case "7":
                            HandleCalculateTotalValue();
                            break;
                        case "0":
                            Console.WriteLine("Đã thoát chương trình. Tạm biệt!");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn từ 0 đến 7.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (DuplicateProductException ex)
                {
                    PrintError(ex.Message);
                }
                catch (ProductNotFoundException ex)
                {
                    PrintError(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    PrintError($"Lỗi tham số: {ex.Message}");
                }
                catch (Exception ex)
                {
                    PrintError($"Lỗi hệ thống không xác định: {ex.Message}");
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("===== QUẢN LÍ SẢN PHẨM =====");
            Console.WriteLine("1. Thêm sản phẩm ");
            Console.WriteLine("2. Xuất danh sách");
            Console.WriteLine("3. Tìm theo mã");
            Console.WriteLine("4. Tìm theo tên");
            Console.WriteLine("5. Lọc theo khoảng giá");
            Console.WriteLine("6. Xóa sản phẩm");
            Console.WriteLine("7. Tính tổng giá trị trong kho");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("============================");
        }

        private static void HandleAddProduct()
        {
            Console.WriteLine("\n--- THÊM SẢN PHẨM MỚI ---");
            Console.Write("Nhập mã sản phẩm: ");
            string maSP = Console.ReadLine() ?? string.Empty;

            Console.Write("Nhập tên sản phẩm: ");
            string tenSP = Console.ReadLine() ?? string.Empty;

            Console.Write("Nhập đơn giá: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                throw new ArgumentException("Đơn giá phải là số hợp lệ!");
            }

            Console.Write("Nhập số lượng: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                throw new ArgumentException("Số lượng phải là số nguyên hợp lệ!");
            }

            var product = new Product(maSP, tenSP, price, quantity);
            _dichvu.AddProduct(product);
        }

        private static void HandleDisplayAll()
        {
            Console.WriteLine("\n--- DANH SÁCH TOÀN BỘ SẢN PHẨM ---");
            var list = _dichvu.GetAllProducts();
            if (!list.Any())
            {
                Console.WriteLine("Danh sách hiện đang rỗng.");
                return;
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void HandleFindById()
        {
            Console.WriteLine("\n--- TÌM SẢN PHẨM THEO MÃ ---");
            Console.Write("Nhập mã sản phẩm cần tìm: ");
            string ma = Console.ReadLine() ?? string.Empty;

            var product = _dichvu.FindById(ma);
            if (product != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Tìm thấy sản phẩm:");
                Console.ResetColor();
                Console.WriteLine(product);
            }
            else
            {
                throw new ProductNotFoundException(ma);
            }
        }

        private static void HandleSearchByName()
        {
            Console.WriteLine("\n--- TÌM SẢN PHẨM THEO TÊN ---");
            Console.Write("Nhập từ khóa tên sản phẩm: ");
            string kw = Console.ReadLine() ?? string.Empty;

            var results = _dichvu.SearchByName(kw).ToList();
            if (!results.Any())
            {
                Console.WriteLine($"Không có sản phẩm nào chứa từ khóa '{kw}'.");
                return;
            }

            Console.WriteLine($"Tìm thấy {results.Count} sản phẩm phù hợp:");
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        private static void HandleFilterByPrice()
        {
            Console.WriteLine("\n--- LỌC THEO KHOẢNG GIÁ ---");
            Console.Write("Nhập giá nhỏ nhất: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice) || minPrice < 0)
            {
                throw new ArgumentException("Giá min phải là số không âm!");
            }

            Console.Write("Nhập giá lớn nhất: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice) || maxPrice < minPrice)
            {
                throw new ArgumentException("Giá max phải là số hợp lệ và lớn hơn hoặc bằng giá min!");
            }

            Func<Product, bool> priceFilter = p => p.Price >= minPrice && p.Price <= maxPrice;
            var filtered = _dichvu.Filter(priceFilter).ToList();

            if (!filtered.Any())
            {
                Console.WriteLine($"Không có sản phẩm nào trong tầm giá từ {minPrice:N0} đ đến {maxPrice:N0} đ.");
                return;
            }

            Console.WriteLine($"\nDanh sách sản phẩm trong tầm giá {minPrice:N0} đ - {maxPrice:N0} đ:");
            foreach (var item in filtered)
            {
                Console.WriteLine(item);
            }
        }

        private static void HandleRemoveProduct()
        {
            Console.WriteLine("\n--- XÓA SẢN PHẨM ---");
            Console.Write("Nhập mã sản phẩm cần xóa: ");
            string ma = Console.ReadLine() ?? string.Empty;

            _dichvu.RemoveProduct(ma);
        }

        private static void HandleCalculateTotalValue()
        {
            Console.WriteLine("\n--- TỔNG GIÁ TRỊ KHO HÀNG ---");
            decimal total = _dichvu.CalculateTotalInventoryValue();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tổng giá trị tất cả hàng hóa trong kho: {total:N0} VNĐ");
            Console.ResetColor();
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[LỖI] {message}");
            Console.ResetColor();
        }

        private static void SeedTestData()
        {
            try
            {
                _dichvu.AddProduct(new Product("SP01", "Bàn phím cơ", 1200000, 10));
                _dichvu.AddProduct(new Product("SP02", "Chuột không dây", 450000, 25));
                _dichvu.AddProduct(new Product("SP03", "Tai nghe Gaming", 850000, 15));
            }
            catch { }
        }
    }
}