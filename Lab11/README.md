# TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH
## KHOA CÔNG NGHỆ THÔNG TIN
### BÁO CÁO KẾT QUẢ BÀI THỰC HÀNH LAB 11

**Học phần:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** ADO.NET, SqlConnection, SqlCommand, DataGridView, CRUD  
**Cơ sở dữ liệu:** `EduManagerDB`  

---

### THÔNG TIN SINH VIÊN
* **Họ và tên:** Kiều Gia Bảo
* **Mã số sinh viên:** 51.01.104.128
* **Lớp sinh hoạt / Học phần:** CNTT.A (K51)
* **Giảng viên hướng dẫn:** Bộ môn Công nghệ Phần mềm
* **Công cụ sử dụng:** Visual Studio 2022 (WinForms C#), Microsoft SQL Server 2022, thư viện `Microsoft.Data.SqlClient`.

---

## 1. Mục tiêu bài thực hành
1. Kết nối thành công ứng dụng Windows Forms với cơ sở dữ liệu `EduManagerDB` trong SQL Server thông qua ADO.NET.
2. Hiển thị toàn bộ dữ liệu bảng `LOP` kết hợp đếm số lượng `SINHVIEN` lên `DataGridView`.
3. Xây dựng hoàn chỉnh các chức năng CRUD (Thêm, Sửa, Xóa) và Tìm kiếm bằng ngôn ngữ C#.
4. Ứng dụng `SqlParameter` cho toàn bộ câu lệnh T-SQL để bảo mật, chống tấn công SQL Injection.
5. Xử lý triệt để các bắt lỗi logic (Validation): Chặn bỏ trống, chặn trùng khóa chính (`MaLop`), chặn xóa lớp khi đang có sinh viên (ràng buộc khóa ngoại).

---

## 2. Thiết kế Cơ sở dữ liệu và Dữ liệu mẫu

Script SQL khởi tạo 2 bảng `LOP` và `SINHVIEN` kèm dữ liệu test cơ bản:

```sql
USE EduManagerDB;
GO

IF OBJECT_ID('SINHVIEN', 'U') IS NOT NULL DROP TABLE SINHVIEN;
IF OBJECT_ID('LOP', 'U') IS NOT NULL DROP TABLE LOP;
GO

CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

INSERT INTO LOP(MaLop, TenLop) VALUES
('CNTT01', N'Công nghệ thông tin 01'),
('CNTT02', N'Công nghệ thông tin 02'),
('SPTIN01', N'Sư phạm Tin học 01');

INSERT INTO SINHVIEN(MaSV, HoTen, MaLop) VALUES
('SV001', N'Nguyễn Văn An', 'CNTT01'),
('SV002', N'Trần Thị Bình', 'CNTT01');
GO
```

---

## 3. Cấu hình Chuỗi kết nối (Connection String)

Ứng dụng kết nối tới hệ quản trị CSDL qua chuỗi sau:
```csharp
private readonly string connectionString = 
    @"Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";
```
*Ghi chú: Tham số `TrustServerCertificate=True` được bổ sung để khắc phục lỗi chứng chỉ bảo mật khi kết nối với SQL Server 2022 qua gói thư viện Microsoft.Data.SqlClient mới nhất.*

---

## 4. Hiện thực các chức năng CRUD (C# WinForms)

### 4.1. Khởi chạy và Nạp dữ liệu (`Form_Load` & `Read`)
- Ứng dụng sử dụng câu lệnh `LEFT JOIN` với `COUNT` để đếm số lượng sinh viên hiện có trong từng lớp.
- Dữ liệu được đổ vào `DataTable` qua `SqlDataAdapter` và gán cho `DataGridView`.

<img width="727" height="547" alt="image" src="https://github.com/user-attachments/assets/e7b46241-6c5c-435d-85f7-199f918b7340" />

### 4.2. Thêm mới lớp học (`Create`)
- Trước khi thực thi lệnh `INSERT`, ứng dụng sẽ gọi hàm `IsMaLopExists()` để dùng lệnh `ExecuteScalar()` đếm xem `MaLop` đã tồn tại chưa.
- Lệnh T-SQL được truyền tham số qua `@ma` và `@ten`.

<img width="722" height="550" alt="image" src="https://github.com/user-attachments/assets/c29185be-0fbe-4cc5-ac9c-91df175090d5" />
<img width="719" height="552" alt="image" src="https://github.com/user-attachments/assets/01d45ced-a550-446b-917e-ba50c7c33588" />

### 4.3. Cập nhật tên lớp (`Update`)
- Khi người dùng click chuột vào lưới (`CellClick`), thông tin lớp học tự động đổ lên các TextBox. Ô Số lượng bị khóa (`ReadOnly`) do là dữ liệu phái sinh.
- Ứng dụng chỉ cho phép sửa Tên lớp, cập nhật xuống CSDL bằng lệnh `UPDATE`.

<img width="719" height="551" alt="image" src="https://github.com/user-attachments/assets/733e19ed-7ffd-4055-9b4e-79c17e40fca3" />

### 4.4. Xóa lớp học (`Delete`)
- Xử lý ràng buộc toàn vẹn: Ứng dụng truy vấn bảng `SINHVIEN` để kiểm tra lớp đang chọn có sinh viên hay không.
- Nếu `COUNT > 0`, ứng dụng hiển thị MessageBox chặn xóa để tránh lỗi xung đột `FOREIGN KEY` dưới SQL Server. Nếu không có sinh viên, tiến hành lệnh `DELETE`.

<img width="718" height="548" alt="image" src="https://github.com/user-attachments/assets/5d3a5d37-d4e0-47b3-91db-b4de9456bd65" />

### 4.5. Tìm kiếm (`Search`)
- Tìm kiếm linh hoạt theo cả Mã lớp hoặc Tên lớp bằng toán tử `LIKE`.
- Tham số truyền vào được bọc bằng ký tự đại diện `%` (VD: `cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");`).


---

## 5. Kết luận
- Đã hoàn thành toàn bộ yêu cầu của bài thực hành Lab 11.
- Xây dựng thành công ứng dụng WinForms thao tác trực tiếp với SQL Server qua mô hình ADO.NET ngắt kết nối (`SqlDataAdapter` & `DataTable`) và kết nối trực tiếp (`SqlCommand.ExecuteNonQuery`).
- Ứng dụng hoạt động ổn định, bảo mật trước rủi ro SQL Injection và kiểm soát chặt chẽ tính toàn vẹn dữ liệu từ tầng ứng dụng trước khi đẩy xuống tầng Database.
