# BÁO CÁO THỰC HÀNH LAB 14
**Môn học:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** Entity Framework Core, WinForms, SQL Server, Mô hình ba lớp  
**Sinh viên thực hiện:** Kiều Gia Bảo  
**Lớp:** CNTT.A - Khóa 51 (Trường Đại học Sư phạm TP.HCM)  

---

## 1. Mục tiêu đã hoàn thành
- Thiết kế thành công giao diện với đầy đủ các control yêu cầu.
- Khởi tạo cơ sở dữ liệu và bảng `MONHOC` bằng script SQL.
- Cấu hình thành công `DbContext` và Entity ánh xạ bằng Entity Framework Core 8.x.
- Xây dựng mã nguồn tuân thủ triệt để mô hình 3 lớp: **GUI, BLL, DAL**.
- Hoàn thiện các chức năng CRUD và tích hợp Validation logic từ lớp BLL.

---

## 2. Giới thiệu chức năng (Minh họa)

### 2.1. Giao diện chính và Load dữ liệu
Khi vừa mở Form, hệ thống sẽ tự động load danh sách môn học từ cơ sở dữ liệu lên DataGridView.
<img width="597" height="736" alt="image" src="https://github.com/user-attachments/assets/4f240fac-3c3d-45c0-8238-f0e804fd911d" />

### 2.2. Thêm môn học
Người dùng nhập thông tin và nhấn "Thêm". Dữ liệu sẽ được kiểm tra hợp lệ, sau đó lưu xuống CSDL và cập nhật lại lưới hiển thị.
<img width="596" height="734" alt="image" src="https://github.com/user-attachments/assets/601351a8-afc7-450c-a2d2-0da05b17b3de" />

### 2.3. Cập nhật (Sửa) thông tin
Click chọn một dòng trên DataGridView, dữ liệu sẽ được đưa lên các ô nhập liệu. Người dùng sửa thông tin và nhấn "Sửa".
<img width="620" height="741" alt="image" src="https://github.com/user-attachments/assets/b1702856-d942-4d57-ae4f-eec588d1105e" />

### 2.4. Xóa môn học
Xác nhận xóa môn học đang được chọn thông qua một MessageBox an toàn.
<img width="595" height="739" alt="image" src="https://github.com/user-attachments/assets/65e81aee-02ac-4f62-b11c-0e5be5bd20ed" />

### 2.5. Tìm kiếm
Người dùng có thể tìm kiếm nhanh môn học theo Mã môn học hoặc Tên môn học.
<img width="602" height="736" alt="image" src="https://github.com/user-attachments/assets/af08186f-0d0a-40f8-8763-f9b6295b89c2" />


### 2.6. Validation và Xử lý lỗi
Hệ thống sẽ hiển thị thông báo thân thiện khi người dùng nhập sai quy tắc (ví dụ: để trống mã, trùng mã, số tín chỉ không hợp lệ).
<img width="596" height="733" alt="image" src="https://github.com/user-attachments/assets/40e5a082-652b-4d65-b07b-db019f9f6fac" />

---

## 3. Kịch bản kiểm thử (Test Cases)

| Test Case | Hành động / Input | Kết quả mong đợi (Output) | Trạng thái |
| :--- | :--- | :--- | :---: |
| **TC01: Thêm môn học hợp lệ** | Nhập đầy đủ thông tin đúng định dạng | Thêm thành công, hiển thị lên DataGridView | Pass |
| **TC02: Lỗi bỏ trống dữ liệu** | Để trống ô Mã hoặc Tên môn học | BLL chặn lại, báo lỗi "Không được rỗng" | Pass |
| **TC03: Lỗi trùng mã** | Nhập mã môn học đã tồn tại trong DB | BLL chặn lại, báo lỗi "Mã môn học đã tồn tại" | Pass |
| **TC04: Số tín chỉ sai** | Nhập số tín chỉ < 1 hoặc > 6 | BLL chặn lại, báo lỗi "Số tín chỉ phải từ 1 đến 6" | Pass |
| **TC05: Xóa môn học** | Chọn 1 môn và bấm Xóa | Hiển thị hộp thoại xác nhận. Nếu Yes -> Xóa thành công | Pass |
| **TC06: Tìm kiếm** | Nhập từ khóa vào ô Tìm kiếm | DataGridView lọc ra các môn chứa từ khóa ở Mã hoặc Tên | Pass |

---

## 4. Trả lời câu hỏi lý thuyết

**Câu 8: Vì sao không nên viết toàn bộ code CRUD trong sự kiện Button Click?**
> Viết gộp sẽ vi phạm nguyên tắc Đơn trách nhiệm (Single Responsibility). Giao diện bị gắn chặt với cơ sở dữ liệu khiến hệ thống khó bảo trì, khó tái sử dụng code và khó mở rộng sang các nền tảng khác (như Web hoặc Mobile).

**Câu 9: BLL và DAL khác nhau ở điểm nào?**
> - **DAL (Data Access Layer):** Chỉ chịu trách nhiệm kết nối và thực thi các câu lệnh tương tác trực tiếp với cơ sở dữ liệu (Insert, Update, Delete, Select).
> - **BLL (Business Logic Layer):** Chịu trách nhiệm kiểm tra tính hợp lệ của dữ liệu (Validation) và xử lý các quy tắc nghiệp vụ trước khi gọi các phương thức của DAL.

**Câu 10: Entity Framework khác ADO.NET ở điểm nào?**
> - **ADO.NET:** Hoạt động ở mức thấp, yêu cầu lập trình viên tự viết các câu lệnh SQL thuần, dễ sai sót cú pháp và bảo trì khó khăn.
> - **Entity Framework:** Là một công cụ ORM (Object-Relational Mapping), cho phép lập trình viên thao tác với dữ liệu dưới dạng các Đối tượng (Object) bằng ngôn ngữ C# (thông qua LINQ), giúp code ngắn gọn, trực quan, an toàn và dễ bảo trì hơn.

**Câu 11: Trong bài lab này, validation nào nên đặt ở BLL?**
> Tất cả validation bao gồm: Mã/Tên không được rỗng, Số tín chỉ từ 1-6. Đặc biệt, logic "Mã môn học đã tồn tại" bắt buộc phải ở BLL vì nó cần dùng hàm của DAL để truy xuất DB kiểm tra trước khi cho phép lưu mới.

---

## 5. Khó khăn gặp phải và hướng khắc phục

1. **Lỗi biên dịch DbContext:** 
   - **Vấn đề:** Trình biên dịch không nhận diện được lớp `DbContext` và phương thức mở rộng `UseSqlServer`. 
   - **Khắc phục:** Cài đặt các gói NuGet `Microsoft.EntityFrameworkCore` và `Microsoft.EntityFrameworkCore.SqlServer`.
2. **Xung đột phiên bản .NET và EF Core:** 
   - **Vấn đề:** Cài nhầm bản EF Core 10.x cho project đang chạy .NET 8, dẫn đến lỗi restore package. 
   - **Khắc phục:** Hạ cấp và cài đặt các gói EF Core ở phiên bản `8.0.x` (ví dụ `8.0.11`) để tương thích hoàn toàn.
3. **Lỗi kết nối CSDL (Error 40):** 
   - **Vấn đề:** Lỗi do chưa cấu hình đúng tên máy chủ SQL khi ứng dụng cố gắng kết nối. 
   - **Khắc phục:** Mở SQL Server Management Studio để lấy chính xác tên Server Name, sau đó cấu hình lại chuỗi kết nối trong file Context.
