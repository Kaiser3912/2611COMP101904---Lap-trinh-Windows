# BÁO CÁO THỰC HÀNH LAB 13

## Thông tin sinh viên

* **Họ và tên:** Kiều Gia Bảo
* **Lớp:** CNTT.A (Khóa 51)
* **Khoa:** Công nghệ Thông tin - Trường Đại học Sư phạm TP.HCM (HCMUE)
* **Học phần:** COMP1019 - Lập trình trên Windows
* **Tên bài thực hành:** Báo cáo sinh viên bằng LINQ

---

## 1. Mục Tiêu Bài Thực Hành

* Củng cố và thực hành kỹ năng xử lý, truy vấn dữ liệu bằng LINQ trong ngôn ngữ C#.
* Thiết kế Form báo cáo dữ liệu trực quan trên nền tảng WinForms.
* Sử dụng DataGridView để hiển thị kết quả lọc dữ liệu và thống kê.
* Áp dụng SaveFileDialog để tạo chức năng xuất dữ liệu báo cáo ra định dạng file text hoặc CSV.

## 2. Các Chức Năng Đã Triển Khai

* **Khởi tạo dữ liệu:** Tạo danh sách mẫu gồm 12 sinh viên thuộc 3 lớp khác nhau. Thuộc tính kết quả học tập được đóng gói tự động (trả về "Đạt" nếu điểm lớn hơn hoặc bằng 5, ngược lại là "Không đạt").
* **Lọc và Xem báo cáo:** Hỗ trợ người dùng lọc dữ liệu đồng thời theo Lớp, Kết quả học tập và Tìm kiếm theo từ khóa (Mã sinh viên hoặc Họ tên). Dữ liệu sau khi lọc được tự động sắp xếp giảm dần theo điểm trước khi hiển thị lên lưới.
* **Thống kê chuyên sâu:** Sử dụng hàm nhóm (`GroupBy`) trong LINQ để gom nhóm sinh viên theo từng lớp. Hiển thị báo cáo thống kê tổng số lượng sinh viên, số lượng đạt/không đạt và điểm trung bình chung của từng lớp.
* **Xuất file báo cáo:** Cho phép người dùng lưu toàn bộ dữ liệu đang hiển thị trên DataGridView ra file `.csv` hoặc `.txt`. Chức năng có kèm theo xử lý ngoại lệ và tự động loại bỏ lỗi dấu phẩy để không làm hỏng cấu trúc cột của file CSV.

## 3. Cấu Trúc Mã Nguồn

* `Models/SinhVien.cs`: Chứa định nghĩa lớp `SinhVien`, các thuộc tính dữ liệu và logic đánh giá kết quả.
* `Forms/FrmBaoCaoSinhVien.cs`: Chứa toàn bộ giao diện Form, logic bắt sự kiện từ người dùng và các câu lệnh truy vấn dữ liệu bằng LINQ.

---

## 4. Hình Ảnh Minh Họa Từng Chức Năng

### 4.1. Giao diện khởi tạo Form
<img width="959" height="478" alt="image" src="https://github.com/user-attachments/assets/c0066f54-4299-4edb-a206-ad07f9369741" />

### 4.2. Chức năng Lọc và Xem báo cáo
<img width="955" height="482" alt="image" src="https://github.com/user-attachments/assets/8271333d-8fbe-4c70-8a5e-5c4411ad100e" />
<img width="956" height="479" alt="image" src="https://github.com/user-attachments/assets/87ccffe4-f53c-4afa-a4ae-6139252736fc" />


### 4.3. Chức năng Thống kê chuyên sâu
<img width="959" height="478" alt="image" src="https://github.com/user-attachments/assets/c7a16b50-a856-4e5a-b868-cb873ed38cda" />


### 4.4. Chức năng Xuất file báo cáo
<img width="956" height="478" alt="image" src="https://github.com/user-attachments/assets/df31be4c-39ef-4f01-a78d-86fc58e042b1" />

### 4.5. Kết quả File xuất ra (CSV / TXT)
<img width="594" height="204" alt="image" src="https://github.com/user-attachments/assets/aad858d5-e4db-4484-91b2-7f47361db98f" />
