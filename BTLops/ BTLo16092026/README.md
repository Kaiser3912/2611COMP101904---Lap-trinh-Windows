# Báo Cáo Bài Tập: Chương Trình Quản Lý Nhân Viên (C# Console)

Dự án này là chương trình Console C# quản lý nhân sự, được xây dựng nhằm áp dụng các kiến thức về Lập trình hướng đối tượng (OOP) bao gồm: **Class, Property, Constructor, Encapsulation, Kế thừa và Đa hình**. 

Dưới đây là mô tả chi tiết các yêu cầu đã được triển khai trong mã nguồn:

## 1. Lớp cơ sở `NhanVien`
Lớp cha lưu trữ các thông tin chung của mọi nhân viên:
* **Thuộc tính:** Triển khai đầy đủ `MaNV` (Mã nhân viên), `HoTen` (Họ tên), và `LuongCoBan` (Lương cơ bản). 
* **Tính đóng gói (Encapsulation):** `LuongCoBan` được kiểm tra điều kiện lớn hơn 0, ném ra ngoại lệ nếu nhận giá trị âm.
* **Constructor:** Khởi tạo đầy đủ 3 thông tin cơ bản trên.
* **Phương thức ảo (Virtual):** 
  * `virtual double TinhLuong()`: Mặc định trả về lương cơ bản.
  * `virtual void HienThiThongTin()`: Xuất thông tin chung của nhân viên.

## 2. Các lớp kế thừa
### 2.1. Lớp `NhanVienVanPhong`
* **Kế thừa:** Kế thừa từ lớp `NhanVien`.
* **Thuộc tính bổ sung:** `SoNgayLamViec` (áp dụng đóng gói để đảm bảo giá trị nằm trong khoảng hợp lệ 0–31).
* **Constructor:** Sử dụng từ khóa `base(...)` để gọi constructor của lớp cha.
* **Tính đa hình (Override):** 
  * Ghi đè `TinhLuong()` theo công thức: *Lương cơ bản + Số ngày làm việc × 200.000*.
  * Ghi đè `HienThiThongTin()` để hiển thị thông tin đặc thù.

### 2.2. Lớp `NhanVienKinhDoanh`
* **Kế thừa:** Kế thừa từ lớp `NhanVien`.
* **Thuộc tính bổ sung:** `DoanhSo` (áp dụng đóng gói đảm bảo giá trị ≥ 0).
* **Constructor:** Sử dụng từ khóa `base(...)` để kế thừa logic khởi tạo từ lớp cha.
* **Tính đa hình (Override):**
  * Ghi đè `TinhLuong()` theo công thức: *Lương cơ bản + 5% × Doanh số*.
  * Ghi đè `HienThiThongTin()` để xuất thông tin doanh số.

## 3. Lớp mở rộng (Bonus) - `NhanVienThoiVu`
* Kế thừa từ `NhanVien`, bổ sung `SoGioLam` và `LuongTheoGio` (có kiểm tra tính hợp lệ).
* Ghi đè `TinhLuong()` theo công thức: *Số giờ làm × Lương theo giờ*.
* Tích hợp thành công vào hệ thống mà **không làm thay đổi** thuật toán tìm nhân viên có lương cao nhất hay tính tổng lương chung của chương trình.

## 4. Chương trình chính (Menu)
Sử dụng cấu trúc dữ liệu `List<NhanVien>` để lưu trữ và quản lý đa hình danh sách nhân viên (cho phép nhập từ 5 nhân viên trở lên). Hệ thống Menu đáp ứng đúng các chức năng theo yêu cầu:

1. **Xuất danh sách nhân viên:** Duyệt danh sách và sử dụng đa hình gọi `HienThiThongTin()` của từng đối tượng tương ứng. Hoàn toàn không sử dụng lệnh `if/switch` để ép kiểu.
2. **Tìm nhân viên theo mã:** Trích xuất và hiển thị thông tin nhân viên có mã khớp với dữ liệu người dùng nhập.
3. **Tìm nhân viên có lương cao nhất:** Áp dụng phương thức đa hình `TinhLuong()` để tìm ra (các) nhân viên có mức thu nhập cao nhất trong công ty (bao gồm cả nhân viên thời vụ).
4. **Tính tổng lương công ty phải trả:** Duyệt qua danh sách và cộng dồn kết quả trả về từ `TinhLuong()`, áp dụng triệt để tính đa hình mà không cần rẽ nhánh kiểm tra loại nhân viên.
5. **Thoát chương trình.**
