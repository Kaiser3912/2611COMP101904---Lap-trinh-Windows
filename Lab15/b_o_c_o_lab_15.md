# BÁO CÁO LAB 15: MVP, KIỂM THỬ VÀ BÀN GIAO ĐỒ ÁN

**Họ và tên sinh viên:** [Điền họ tên của bạn]  
**Mã sinh viên:** [Điền MSSV của bạn]  
**Môn học:** COMP1019  

---

## 1. Mục tiêu và Bài toán
- **Bài toán:** Quản lý Sinh viên.
- **Mục tiêu:** 
  - Áp dụng mô hình MVP (Model - View - Presenter) ở mức cơ bản cho module Quản lý Sinh viên.
  - Tách biệt hoàn toàn phần xử lý logic ra khỏi Form (Form chỉ gọi Presenter).
  - Lên kịch bản kiểm thử (Test Cases) và checklist bàn giao đồ án.

## 2. Kiến trúc MVP áp dụng
Dự án được chia thành các thư mục sau:
- **Models:** Chứa class `Student` đại diện cho thực thể dữ liệu.
- **Views:** Chứa interface `IStudentView` và `FrmStudent` (implements interface này).
- **Presenters:** Chứa `StudentPresenter` làm trung gian, xử lý các logic nghiệp vụ và cập nhật View.
- **Repositories:** Chứa `IStudentRepository` và `StudentRepository` để mô phỏng việc lưu trữ và truy xuất dữ liệu bằng `List<Student>`.

---

## 3. Demo Chức năng và Hình ảnh minh họa

### 3.1. Giao diện chính và Load danh sách
Khi vừa mở Form lên, chương trình sẽ tự động load dữ liệu mẫu thông qua Repository. Form hiển thị đầy đủ 3 TextBox (Mã, Tên, Điểm) và DataGridView.

![Giao diện chính - Load danh sách]([Chèn link/đường dẫn ảnh giao diện chính và lưới dữ liệu vào đây])

### 3.2. Chức năng Thêm sinh viên (Hợp lệ)
Nhập đầy đủ thông tin hợp lệ (Mã: SV03, Tên: Lê Văn C, Điểm: 9.0) và bấm nút Thêm. Dữ liệu mới được cập nhật ngay lên DataGridView.

![Thêm sinh viên thành công]([Chèn link/đường dẫn ảnh sau khi bấm nút thêm thành công vào đây])

### 3.3. Chức năng Tìm kiếm
Nhập một phần của Tên hoặc Mã sinh viên vào ô tìm kiếm và bấm nút Tìm kiếm. Lưới dữ liệu sẽ được lọc tương ứng.

![Tìm kiếm sinh viên]([Chèn link/đường dẫn ảnh kết quả tìm kiếm vào đây])

### 3.4. Chức năng Xóa dữ liệu
Chọn một sinh viên hoặc nhập mã sinh viên cần xóa và bấm nút Xóa. Dữ liệu sẽ biến mất khỏi DataGridView.

![Xóa sinh viên]([Chèn link/đường dẫn ảnh sau khi xóa thành công vào đây])

### 3.5. Kiểm tra tính hợp lệ của dữ liệu (Validation)
**Trường hợp 1: Dữ liệu rỗng**
Bỏ trống thông tin và bấm Thêm.
![Lỗi dữ liệu rỗng]([Chèn link/đường dẫn ảnh thông báo lỗi rỗng vào đây])

**Trường hợp 2: Trùng mã sinh viên**
Nhập mã sinh viên đã tồn tại (VD: SV01) và bấm Thêm.
![Lỗi trùng mã]([Chèn link/đường dẫn ảnh thông báo lỗi trùng mã vào đây])

**Trường hợp 3: Điểm sai kiểu dữ liệu**
Nhập điểm bằng chữ (VD: "Chín") hoặc số ngoài khoảng 0-10 và bấm Thêm.
![Lỗi sai kiểu điểm]([Chèn link/đường dẫn ảnh thông báo lỗi sai định dạng điểm vào đây])

---

## 4. Kịch bản kiểm thử (Test Cases)

| ID | Chức năng | Thao tác/Dữ liệu | Kết quả mong đợi | Tình trạng (Pass/Fail) |
|---|---|---|---|---|
| **TC01** | Load danh sách | Mở Form ứng dụng | Hiển thị dữ liệu mẫu (SV01, SV02) trên lưới dữ liệu. | Pass |
| **TC02** | Thêm hợp lệ | Nhập: `SV03`, `Lê Văn C`, `9.0` -> Bấm Thêm | Thông báo thành công, SV03 xuất hiện trên lưới. | Pass |
| **TC03** | Thêm trùng mã | Nhập `SV01` (đã có) -> Bấm Thêm | Thông báo lỗi "Mã sinh viên đã tồn tại!". | Pass |
| **TC04** | Thêm sai dữ liệu | Nhập điểm là `A` hoặc `11` -> Bấm Thêm | Thông báo lỗi yêu cầu nhập số thực từ 0 đến 10. | Pass |
| **TC05** | Xóa dữ liệu | Nhập mã `SV01` -> Bấm Xóa | Thông báo thành công, SV01 biến mất khỏi lưới. | Pass |
| **TC06** | Tìm kiếm | Nhập `A` vào ô tìm kiếm -> Bấm Tìm | Hiển thị các sinh viên có chứa chữ "A" trong tên/mã. | Pass |

---

## 5. Checklist bàn giao đồ án cuối kỳ

- [x] Tách mã nguồn theo đúng mô hình MVP (Models, Views, Presenters, Repositories).
- [x] Form xử lý nghiệp vụ thông qua interface View và gọi qua Presenter.
- [x] Không viết logic trực tiếp trong Form (Button Click).
- [x] Đã xử lý bắt lỗi đầy đủ: dữ liệu rỗng, trùng ID, sai kiểu dữ liệu.
- [x] Có File `README.txt` hướng dẫn cách chạy và cấu hình.
- [x] Source code đã Push lên Github kèm theo mô tả rõ ràng.
- [x] File test case có chứa ít nhất 5 trường hợp kiểm thử (như bảng trên).

---
*Ghi chú: Source code và README chi tiết đính kèm trong repository GitHub được nộp.*