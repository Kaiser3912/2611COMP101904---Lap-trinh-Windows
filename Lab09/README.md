# BÁO CÁO LAB 09: THIẾT KẾ VÀ IN THẺ SINH VIÊN (WINFORMS)

**Học phần:** COMP1019 - Lập trình trên Windows[cite: 30]  
**Chủ đề:** Vẽ đồ họa GDI+ và In ấn trong WinForms[cite: 30]  
**Tên dự án:** StudentCardPrinter  

---

## 1. Giới thiệu
Đây là ứng dụng Windows Forms hỗ trợ việc thu thập thông tin, hiển thị bản xem trước (Preview) và in thẻ sinh viên[cite: 30]. Chương trình được thiết kế với giao diện chia làm 2 vùng rõ rệt: Vùng nhập liệu bên trái và Vùng xem trước thẻ bằng đồ họa GDI+ bên phải[cite: 30]. Dữ liệu được quản lý trực tiếp trên bộ nhớ (không cần cơ sở dữ liệu)[cite: 30].

## 2. Các chức năng chính
Chương trình đáp ứng đầy đủ các mã chức năng (F1 - F6) theo yêu cầu[cite: 31]:

*   **F1 - Chọn ảnh:** Sử dụng `OpenFileDialog` chỉ cho phép tải lên các định dạng ảnh hợp lệ (JPG, JPEG, PNG, BMP). Ảnh được hiển thị gọn gàng trên `PictureBox` (chế độ Zoom) mà không bị méo tỉ lệ hay khóa file gốc[cite: 31].
*   **F2 - Preview thẻ tự động:** Thẻ sinh viên được vẽ trực tiếp lên `Panel` bằng thư viện GDI+. Bất cứ khi nào người dùng thay đổi dữ liệu nhập vào, bản xem trước sẽ tự động vẽ lại (cập nhật theo thời gian thực)[cite: 30, 31].
*   **F3 - Kiểm tra dữ liệu (Validation):** Ngăn chặn việc xem trước bản in hoặc in thẻ nếu người dùng bỏ trống các thông tin bắt buộc gồm: Mã sinh viên, Họ tên và Ảnh đại diện[cite: 30, 31].
*   **F4 & F5 - Xem trước bản in và In thẻ:** Sử dụng `PrintPreviewDialog` để xem lại trang in và `PrintDocument` / `PrintDialog` để xuất lệnh in với thẻ sinh viên có đầy đủ tiêu đề, khung viền, thông tin và hình ảnh không bị méo[cite: 31].
*   **F6 - Làm mới:** Nút chức năng giúp xóa sạch mọi dữ liệu đã nhập, xóa ảnh và đưa Form về trạng thái mặc định ban đầu[cite: 31].

---

## 3. Hình ảnh minh họa (Screenshots)

**1. Ảnh chụp màn hình Form chính (Đã nhập thông tin và hiển thị Preview thẻ):**

<img width="962" height="587" alt="Screenshot 2026-10-18 235102" src="https://github.com/user-attachments/assets/2fb99126-1530-4863-9f1d-47e0930fdf38" />


**2. Ảnh chụp màn hình Xem trước bản in (Print Preview):**

<img width="920" height="425" alt="Screenshot 2026-10-18 235148" src="https://github.com/user-attachments/assets/1419e2d4-fd0f-49da-8f71-6581e52f025d" />


---

## 4. Danh sách 8 Test Case Tự Kiểm Thử
Dưới đây là 8 trường hợp kiểm thử (Test Cases) đã được chạy thử nghiệm để đảm bảo tính ổn định của ứng dụng[cite: 32]:

| STT | Tên Test Case | Kết quả mong đợi | Trạng thái |
|---|---|---|---|
| 1 | Bỏ trống Mã sinh viên và nhấn In | Hiển thị cảnh báo yêu cầu nhập mã SV. | PASS |
| 2 | Bỏ trống Họ tên và nhấn Xem trước in | Hiển thị cảnh báo yêu cầu nhập họ tên. | PASS |
| 3 | Chưa tải ảnh lên và nhấn In | Hiển thị cảnh báo yêu cầu chọn ảnh. | PASS |
| 4 | Tải lên file không phải định dạng ảnh | Không hiển thị file để chọn hoặc báo lỗi file không hợp lệ. | PASS |
| 5 | Tải ảnh dọc hoặc ảnh ngang có tỉ lệ lạ | Ảnh hiển thị trên thẻ tự động Zoom thu nhỏ lại, không bị méo. | PASS |
| 6 | Thay đổi tên hoặc khóa học khi đang vẽ | Vùng thẻ (Panel) tự động cập nhật ngay lập tức chữ vừa gõ. | PASS |
| 7 | Nhấn nút "Làm mới" | Toàn bộ TextBox bị xóa trắng, PictureBox mất ảnh, ngày sinh reset. | PASS |
| 8 | Nhập đầy đủ thông tin và in PDF | Thẻ xuất ra file in PDF rõ nét, đúng kích thước, không mất khung viền. | PASS |

---

## 5. Hướng dẫn chạy chương trình
1. Clone dự án về máy tính cá nhân.
2. Mở file `.sln` bằng Visual Studio.
3. Nhấn `F5` để chạy ứng dụng.
4. Nhập liệu bên trái, nhấn "Chọn ảnh" để tải ảnh cá nhân lên.
5. Quan sát thẻ sinh viên được vẽ tự động ở bên phải.
6. Nhấn "Xem trước in" để kiểm tra khổ giấy, sau đó nhấn "In" để xuất ra máy in hoặc lưu thành file PDF.
