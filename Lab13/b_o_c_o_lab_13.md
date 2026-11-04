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

> **Hướng dẫn:** Để chèn ảnh, bạn hãy copy file ảnh vào cùng thư mục với file Markdown này, sau đó điền tên file ảnh vào bên trong dấu ngoặc đơn `()` ở dưới mỗi mục.

### 4.1. Giao diện khởi tạo Form
*(Mô tả: Ảnh chụp toàn bộ giao diện chương trình khi vừa chạy lên, ComboBox đã load đủ danh sách lớp, DataGridView hiển thị danh sách sinh viên ban đầu.)*

![Giao diện khởi tạo]()

### 4.2. Chức năng Lọc và Xem báo cáo
*(Mô tả: Ảnh chụp màn hình khi đã chọn một Lớp cụ thể, chọn Kết quả "Đạt" (hoặc "Không đạt"), nhập Từ khóa tìm kiếm. Lưới DataGridView lúc này chỉ hiển thị các sinh viên khớp với điều kiện tìm kiếm.)*

![Chức năng Lọc và Xem báo cáo]()

### 4.3. Chức năng Thống kê chuyên sâu
*(Mô tả: Ảnh chụp màn hình sau khi bấm nút "Thống kê". Lưới DataGridView thay đổi hiển thị thành bảng gom nhóm gồm: Tên Lớp, Số Lượng, Số Đạt, Số Không Đạt và Điểm Trung Bình.)*

![Chức năng Thống kê theo lớp]()

### 4.4. Chức năng Xuất file báo cáo
*(Mô tả: Ảnh chụp màn hình hộp thoại lưu file (SaveFileDialog) đang hiện lên để chọn nơi lưu, hoặc hộp thoại MessageBox thông báo "Xuất file thành công".)*

![Chức năng Xuất file báo cáo]()

### 4.5. Kết quả File xuất ra (CSV / TXT)
*(Mô tả: Mở file .csv hoặc .txt vừa xuất ra bằng Notepad hoặc Excel và chụp lại nội dung bên trong để chứng minh file xuất đúng cấu trúc.)*

![Nội dung file báo cáo]()