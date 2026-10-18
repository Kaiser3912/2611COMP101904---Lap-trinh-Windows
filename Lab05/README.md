# BÁO CÁO LAB 05: ỨNG DỤNG ĐĂNG KÝ KHÓA HỌC (WINDOWS FORMS)

**Học phần:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** Windows Forms Cơ bản  
**Tên dự án:** CourseRegistrationApp  

---

## 1. Giới thiệu
CourseRegistrationApp là một ứng dụng Windows Forms cơ bản giúp thu thập thông tin và đăng ký khóa học cho học viên. Ứng dụng tập trung vào việc thiết kế giao diện trực quan, quản lý các sự kiện (Events) của người dùng và kiểm tra tính hợp lệ của dữ liệu đầu vào (Validation) trước khi xử lý.

## 2. Các chức năng chính
Chương trình bao gồm các tính năng sau:

*   **Khởi tạo dữ liệu (Form Load):** Tự động nạp danh sách 4 khóa học (C#, SQL Server, Web Frontend, Python), thiết lập mặc định hình thức học Online và thời gian học là 1 tháng.
*   **Tính tổng tiền tự động:** Học phí tự động cập nhật ngay lập tức (Real-time) mỗi khi người dùng thay đổi khóa học (Sự kiện `SelectedIndexChanged`) hoặc thay đổi số tháng đăng ký (Sự kiện `ValueChanged`).
*   **Đăng ký khóa học:** 
    *   Kiểm tra dữ liệu bắt buộc (Họ tên, Số điện thoại không được để trống).
    *   Tính toán tổng học phí (Học phí/tháng * Số tháng).
    *   Hiển thị thông báo (MessageBox) tổng hợp toàn bộ thông tin đăng ký của học viên.
*   **Làm mới form:** Xóa sạch các ô nhập liệu, đưa cấu hình lựa chọn về trạng thái mặc định ban đầu và đặt con trỏ chuột (Focus) trở lại ô Họ tên.
*   **Thoát an toàn:** Hiển thị hộp thoại xác nhận (Yes/No) để tránh việc người dùng vô tình đóng ứng dụng.

## 3. Kỹ thuật & Controls sử dụng
Giao diện được bố cục rõ ràng, chuẩn mực bằng cách áp dụng các Control tiêu chuẩn của WinForms:
*   **GroupBox:** Phân chia rành mạch vùng "Thông tin học viên" và "Thông tin khóa học".
*   **TextBox & Label:** Nhập họ tên, số điện thoại và hiển thị chữ.
*   **ComboBox:** Tạo danh sách đổ xuống để chọn khóa học.
*   **DateTimePicker:** Chọn ngày tháng năm sinh trực quan.
*   **RadioButton & CheckBox:** Lựa chọn hình thức học (chỉ được chọn 1) và tùy chọn nhận email thông báo.
*   **NumericUpDown:** Hỗ trợ tăng/giảm số tháng học an toàn (giới hạn từ 1 đến 12).
*   **Quy ước đặt tên (Naming Convention):** Mọi control đều được đặt tên chuẩn như `txtHoTen`, `cboKhoaHoc`, `radOnline`, `btnDangKy`... giúp mã nguồn dễ quản lý.

---

## 4. Hình ảnh minh họa (Screenshots)

**1. Giao diện chính của ứng dụng khi vừa khởi động:**
<img width="800" height="400" alt="1" src="https://github.com/user-attachments/assets/a916f7a2-074e-4896-a81c-69fc30ba21cb" />

**2. Bắt lỗi (Validation) khi để trống thông tin bắt buộc:**
<img width="800" height="400" alt="1" src="https://github.com/user-attachments/assets/86f27387-2c51-4bd2-90da-e311a252a800" />

**3. Phiếu thông tin khi nhấn nút "Đăng ký" thành công:**
<img width="800" height="400" alt="3" src="https://github.com/user-attachments/assets/eab76642-fa61-4156-9f1a-8ebe178186de" />

**4. Xác nhận khi nhấn nút "Thoát":**
<img width="800" height="400" alt="4" src="https://github.com/user-attachments/assets/7586a28f-e28c-4170-86a0-3c87cf19537f" />

---

## 5. Hướng dẫn chạy chương trình
1. Clone repository này về máy tính.
2. Mở file `.sln` bằng Visual Studio.
3. Nhấn `F5` hoặc nút `Start` để biên dịch và chạy ứng dụng.
4. Nhập thông tin, thay đổi khóa học/số tháng để xem tổng tiền tự động thay đổi, sau đó nhấn "Đăng ký".
