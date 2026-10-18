# BÁO CÁO LAB 06: ỨNG DỤNG QUẢN LÝ SẢN PHẨM (PRODUCT MANAGER)

**Học phần:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** Windows Forms Nâng cao, DataGridView, Menu và ErrorProvider  
**Tên dự án:** ProductManager  

---

## 1. Giới thiệu
ProductManager là ứng dụng Windows Forms nâng cao dùng để quản lý danh sách sản phẩm của cửa hàng. Ứng dụng mô phỏng các nghiệp vụ chuẩn (CRUD) với dữ liệu được lưu trữ trong bộ nhớ (Memory/BindingList), kết hợp giao diện chuyên nghiệp thông qua việc sử dụng hệ thống thanh menu, thanh công cụ, thanh trạng thái và bảng lưới dữ liệu (DataGridView)[cite: 23].

## 2. Các chức năng chính
Chương trình bao gồm các tính năng quản lý cốt lõi:

*   **Quản lý danh sách (CRUD):**
    *   **Thêm sản phẩm:** Nhập thông tin, tự động kiểm tra tính hợp lệ (mã không trùng, giá > 0, số lượng >= 0, ngày không vượt quá hiện tại)[cite: 24].
    *   **Sửa sản phẩm:** Bấm chọn sản phẩm trên lưới, thông tin tự động điền lên Form để chỉnh sửa và cập nhật[cite: 24].
    *   **Xóa sản phẩm:** Chọn sản phẩm và xác nhận qua MessageBox an toàn trước khi xóa[cite: 24].
*   **Tìm kiếm & Làm mới:** Tìm kiếm linh hoạt theo Mã hoặc Tên sản phẩm (không phân biệt hoa/thường). Nút Làm mới giúp xóa trắng Form và khôi phục toàn bộ danh sách[cite: 24].
*   **Quản lý Hình ảnh:** Nhấn nút "Chọn ảnh" mở hộp thoại `OpenFileDialog` để tải ảnh sản phẩm lên `PictureBox`[cite: 23, 24].
*   **Thanh công cụ & Menu:** Hỗ trợ thao tác nhanh qua `MenuStrip` (Menu truyền thống), `ToolStrip` (Thanh công cụ biểu tượng) và `ContextMenuStrip` (Menu chuột phải ngay trên lưới dữ liệu)[cite: 23].
*   **Thanh trạng thái (StatusStrip):** Cập nhật liên tục (Real-time) trạng thái hành động vừa thực hiện và đếm tổng số lượng sản phẩm hiện có trong kho[cite: 24].

## 3. Kỹ thuật & Controls sử dụng
Dự án được tổ chức mã nguồn sạch, tách biệt các hàm xử lý (`ValidateInput`, `ClearInput`, `LoadProductToForm`) và áp dụng các kỹ thuật WinForms nâng cao[cite: 24]:

*   **DataGridView & BindingSource:** Thiết lập cấu hình lưới chuẩn (ReadOnly, FullRowSelect, MultiSelect = false) để hiển thị dữ liệu đồng bộ từ `Class Product`[cite: 24].
*   **ErrorProvider:** Bắt lỗi và hiển thị biểu tượng cảnh báo màu đỏ ngay bên cạnh ô nhập liệu bị sai mà không làm gián đoạn trải nghiệm bằng quá nhiều MessageBox[cite: 23, 24].
*   **Tương tác linh hoạt:** Bắt lỗi chống đứng chương trình khi người dùng nhấn Sửa/Xóa mà chưa chọn dòng[cite: 24].

---

## 4. Hình ảnh minh họa (Screenshots)

**1. Giao diện chính với DataGridView, ToolStrip và dữ liệu mẫu:**
<img width="983" height="647" alt="1" src="https://github.com/user-attachments/assets/23c7e2b5-c247-42c2-b667-25e9ef1628f5" />


**2. Chức năng Validation bằng ErrorProvider (Báo lỗi nhập liệu):**
<img width="986" height="646" alt="2" src="https://github.com/user-attachments/assets/8598a004-5fef-41d4-b652-dc5e6dd88dcb" />

**3. Thao tác bằng Menu chuột phải (ContextMenuStrip) trên lưới dữ liệu:**
<img width="986" height="646" alt="2" src="https://github.com/user-attachments/assets/c9415506-f229-4afb-98ec-40394d5d8171" />

**4. Chức năng Tìm kiếm, Chọn ảnh và Thanh trạng thái (StatusStrip):**
<img width="983" height="650" alt="4" src="https://github.com/user-attachments/assets/71579943-7c19-473d-bf41-f4432fced2dc" /> <img width="1196" height="626" alt="5" src="https://github.com/user-attachments/assets/47981ae6-3e08-4a67-bee9-7c77befe12c7" />


---

## 5. Hướng dẫn chạy chương trình
1. Clone repository này về máy.
2. Mở file `.sln` bằng Visual Studio.
3. Nhấn `F5` để chạy chương trình (Dữ liệu mẫu 3 sản phẩm sẽ tự động nạp khi khởi động Form)[cite: 24].
4. Sử dụng chuột trái để chọn dòng, chuột phải để mở menu thao tác nhanh, hoặc click trực tiếp trên thanh công cụ phía trên.
