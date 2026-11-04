# Báo cáo Lab 12: Quản lý Kết quả Học tập (WinForms)

## 📌 Giới thiệu dự án

Đây là dự án WinForms minh họa các kỹ thuật thao tác với cơ sở dữ liệu SQL Server sử dụng ADO.NET. Trọng tâm của bài Lab 12 là việc áp dụng **Data Binding**, gọi **Stored Procedure** và sử dụng **SqlTransaction** để đảm bảo tính toàn vẹn dữ liệu khi lưu hàng loạt.

## 🛠 Công nghệ sử dụng

* **Ngôn ngữ:** C#

* **Framework:** .NET Windows Forms

* **Cơ sở dữ liệu:** Microsoft SQL Server

* **Thư viện:** `Microsoft.Data.SqlClient` (Truy cập CSDL), `System.Data` (DataTable)

* **Kiến trúc:** Phân lớp cơ bản (Forms và DAL)

## 📂 Cấu trúc thư mục

Dự án được chia thành các thư mục rõ ràng để dễ quản lý:

```
Lab12/
├── Database/
│   └── QLSinhVienLab12.sql      # Script tạo CSDL, bảng, dữ liệu mẫu và Stored Procedures
├── DAL/
│   ├── Database.cs              # Chứa biến static lưu ConnectionString
│   └── KetQuaDAL.cs             # Lớp xử lý truy xuất CSDL (Select, SaveAll)
├── Forms/
│   ├── Form1.cs                 # Giao diện và logic xử lý các sự kiện click, validation
│   └── Form1.Designer.cs        # Code tự sinh của phần thiết kế giao diện
└── Program.cs                   # Điểm khởi chạy ứng dụng

```

## 🚀 Các tính năng đã triển khai và Ảnh minh họa

**1. Data Binding cho ComboBox:**

* Tải danh sách Lớp (`sp_Lop_GetAll`) và Môn học (`sp_MonHoc_GetAll`) ngay khi Form vừa load.

<img width="697" height="634" alt="image" src="https://github.com/user-attachments/assets/548aeff6-02ad-4d43-a656-94437b08d035" />


**2. Hiển thị danh sách kết quả học tập:**

* Sử dụng Stored Procedure `sp_KetQua_GetByLopMon` có áp dụng `LEFT JOIN`.

* Hiển thị tất cả sinh viên trong lớp, bao gồm cả những sinh viên đã có điểm và chưa có điểm.

* Dữ liệu được Binding lên `DataGridView` thông qua `BindingSource`.

<img width="702" height="637" alt="image" src="https://github.com/user-attachments/assets/1bc2952a-ebfb-4095-a161-f79173607f32" />

**3. Xác thực dữ liệu (Validation):**

* Kiểm tra điểm không được rỗng, phải là giá trị số hợp lệ.

* Kiểm tra điểm số phải nằm trong khoảng từ `0` đến `10`. Nếu sai sẽ chặn lưu và báo lỗi.

<img width="701" height="640" alt="image" src="https://github.com/user-attachments/assets/7d7fe43f-cf12-43fe-b99a-c2171eb3aaf6" />


**4. Lưu dữ liệu an toàn với Transaction:**

* Cập nhật nhiều dòng dữ liệu điểm cùng một lúc (chỉnh sửa trực tiếp trên GridView).

* Dùng `SqlTransaction` để tự động **Commit** nếu toàn bộ danh sách sinh viên hợp lệ.

* Tự động **Rollback** toàn bộ thao tác nếu có bất kỳ một sinh viên nào bị lỗi dữ liệu hoặc lỗi kết nối.

<img width="697" height="635" alt="image" src="https://github.com/user-attachments/assets/9884aed6-c6a4-4056-9722-529e5550c5a8" />


## ⚙️ Hướng dẫn cài đặt và chạy thử

1. **Thiết lập Cơ sở dữ liệu:**

   * Mở SQL Server Management Studio (SSMS).

   * Chạy toàn bộ script trong file `Database/QLSinhVienLab12.sql` để tạo database `QLSinhVienLab12`.

2. **Thiết lập Project:**

   * Mở file Solution/Project bằng Visual Studio.

   * Mở **NuGet Package Manager** và cài đặt gói `Microsoft.Data.SqlClient` (nếu chưa có).

   * Kiểm tra và cấu hình lại `ConnectionString` trong file `DAL/Database.cs` cho phù hợp với tên server của máy bạn.

3. **Khởi chạy:**

   * Nhấn `F5` hoặc nút **Start** để chạy ứng dụng.

## 🐛 Các vấn đề đã gặp và Khắc phục

* **Lỗi CS0246 (Không tìm thấy Form/Thư viện):** Đã khắc phục bằng cách đồng bộ lại `namespace`, bổ sung `using System.Windows.Forms;` và cập nhật tham chiếu đúng tại `Program.cs`.

* **Lỗi Missing SqlClient:** Đã xử lý bằng cách cài đặt gói `Microsoft.Data.SqlClient` qua NuGet.

* **Lỗi lưu dữ liệu trên lưới không ghi nhận:** Đã xử lý bằng cách thêm lệnh `ketQuaSource.EndEdit();` ngay trước khi lấy DataTable ra để lưu, giúp đồng bộ các ô đang được người dùng gõ dở trên lưới.
