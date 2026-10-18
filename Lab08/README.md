# BÁO CÁO LAB 08: ỨNG DỤNG SIMPLE PAINT (WINFORMS & GDI+)

**Học phần:** COMP1019 - Lập trình trên Windows[cite: 28]  
**Chủ đề:** Xây dựng ứng dụng Paint đơn giản bằng WinForms và GDI+[cite: 28]  

---

## 1. Giới thiệu
Simple Paint là một ứng dụng đồ họa 2D cơ bản trên nền tảng C# Windows Forms[cite: 28]. Ứng dụng mô phỏng lại các công cụ vẽ cơ bản, vận dụng thư viện đồ họa GDI+ (Graphics, Pen, Brush) và các sự kiện bắt chuột (`MouseDown`, `MouseMove`, `MouseUp`) để tạo ra trải nghiệm tương tác trực tiếp trên vùng vẽ (canvas)[cite: 28].

## 2. Các chức năng chính
Chương trình đáp ứng đầy đủ các yêu cầu chức năng sau:
*   **Chế độ vẽ đa dạng:** Hỗ trợ vẽ tự do (Pen), đường thẳng (Line), hình chữ nhật (Rectangle) và hình elip (Ellipse)[cite: 28].
*   **Tùy chỉnh nét vẽ:** Cho phép người dùng thay đổi màu sắc qua hộp thoại `ColorDialog` và tùy chỉnh độ dày của nét vẽ từ mức 1 đến 20 qua `NumericUpDown`[cite: 28].
*   **Quản lý thao tác (Undo/Clear):** Cung cấp nút `Undo` để hoàn tác xóa nét vẽ vừa thực hiện gần nhất và nút `Clear` để xóa sạch toàn bộ vùng vẽ[cite: 28].
*   **Thanh trạng thái:** Hiển thị tọa độ chuột hiện tại (`X`, `Y`) trực tiếp trên `Status Label` ở dưới cùng[cite: 28].
*   **Tính ổn định hiển thị:** Tất cả các nét vẽ được bảo toàn, không bị biến mất khi thu phóng cửa sổ (resize) hoặc khi Form bị che khuất rồi hiện lại[cite: 28, 29].

## 3. Kỹ thuật lập trình áp dụng
Ứng dụng tuân thủ các yêu cầu kỹ thuật nghiêm ngặt để đảm bảo hiệu suất:
*   **Vẽ qua sự kiện Paint:** Dữ liệu nét vẽ không được vẽ trực tiếp rồi bỏ qua trong `MouseMove`, mà được lưu trữ vào một danh sách các đối tượng (`List<DrawItem>`). Mọi thao tác cập nhật hình ảnh đều được gọi thông qua hàm `canvas.Invalidate()` để kích hoạt sự kiện `Paint` thực hiện vẽ lại một cách đồng bộ và ổn định[cite: 29].
*   **Quản lý tài nguyên bộ nhớ:** Các đối tượng đồ họa (như `Pen`, `Brush`, `Font`) đều được khởi tạo và giải phóng tài nguyên một cách triệt để thông qua lệnh `using` hoặc phương thức `Dispose`[cite: 29].
*   **Xử lý tọa độ linh hoạt:** Thuật toán vẽ hình khối (chữ nhật, elip) đã được tinh chỉnh để xử lý tốt trường hợp người dùng kéo rê chuột ngược hướng (từ dưới lên, từ phải qua trái)[cite: 29].

---

## 4. Hình ảnh minh họa (Screenshots)

**1. Giao diện chính và Demo vẽ 4 loại hình học (Pen, Line, Rectangle, Ellipse):**

<img width="982" height="638" alt="1" src="https://github.com/user-attachments/assets/038acca2-8203-49b9-b00f-d878550e63f8" />


**2. Demo thay đổi độ dày, đổi màu và theo dõi tọa độ chuột:**

<img width="983" height="642" alt="2" src="https://github.com/user-attachments/assets/38a15010-75bf-40bf-8518-a7ca600cf0d1" />


---

## 5. Hướng dẫn chạy chương trình
1. Clone repository này về máy tính.
2. Mở file solution (`.sln`) bằng phần mềm Visual Studio 2022/2026 (yêu cầu hỗ trợ Windows Forms .NET 8/10 hoặc .NET Framework)[cite: 28].
3. Nhấn `F5` hoặc chọn nút `Start` để khởi chạy ứng dụng.
4. Chọn công cụ trên thanh menu, chọn màu sắc, độ dày và kéo chuột trên vùng trắng (canvas) để vẽ.
