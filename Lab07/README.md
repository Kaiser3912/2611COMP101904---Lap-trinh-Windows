# BÁO CÁO LAB 07: ỨNG DỤNG QUẢN LÝ CỬA HÀNG MINI (SHOP MANAGER MINI)

**Học phần:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** SDI, MDI và ứng dụng nhiều Form  
**Tên dự án:** ShopManagerMini[cite: 25]  

---

## 1. Giới thiệu
ShopManagerMini là ứng dụng Windows Forms minh họa cho kiến trúc phần mềm nhiều lớp và quản lý đa cửa sổ (MDI)[cite: 25]. Ứng dụng thực hiện các chức năng đăng nhập, phân quyền cơ bản và quản lý danh mục (sản phẩm, khách hàng) với dữ liệu được lưu trữ tạm thời trong bộ nhớ bằng `List<T>` hoặc `BindingList<T>`[cite: 25].

Dự án được tổ chức cấu trúc thư mục rõ ràng, tách biệt giữa các lớp dữ liệu (Models: `User.cs`, `Product.cs`, `Customer.cs`) và các lớp giao diện (Forms)[cite: 27].

## 2. Các chức năng chính
Chương trình bao gồm các tính năng cốt lõi sau:

*   **1. Đăng nhập hệ thống (FrmLogin):** 
    *   Hỗ trợ xác thực tài khoản dựa trên danh sách người dùng mẫu (Ví dụ: `admin`/`123` là Quản trị viên, `user`/`123` là Nhân viên)[cite: 26]. 
    *   Kiểm tra tính hợp lệ khi người dùng bỏ trống trường nhập liệu và hiển thị thông báo lỗi nếu nhập sai[cite: 26]. 
    *   Truyền thông tin người dùng và vai trò sang Form chính sau khi đăng nhập thành công[cite: 25, 26].
*   **2. Giao diện MDI Parent (FrmMain):** 
    *   Đóng vai trò là cửa sổ chứa (`IsMdiContainer = true`), đảm bảo các Form con (Sản phẩm, Khách hàng) chỉ được mở bên trong không gian của Form chính, không tạo thành cửa sổ rời[cite: 26].
    *   Xử lý logic để không mở trùng lặp Form con (nếu đang mở thì kích hoạt lại Form cũ)[cite: 25, 26].
    *   Tích hợp `MenuStrip` điều hướng và `StatusStrip` hiển thị thời gian, tên cùng vai trò của người dùng đang đăng nhập[cite: 26]. Có hộp thoại xác nhận khi thoát chương trình[cite: 26].
*   **3. Quản lý Sản phẩm (FrmProduct):** 
    *   Hiển thị danh sách sản phẩm qua `DataGridView`[cite: 26].
    *   Hỗ trợ đầy đủ thao tác Thêm, Sửa, Xóa, Tìm kiếm, Làm mới (CRUD trong bộ nhớ)[cite: 25, 26].
    *   Kiểm tra ràng buộc nghiêm ngặt: Không được thêm sản phẩm trùng mã, đơn giá và số lượng không được nhập số âm, yêu cầu xác nhận trước khi xóa[cite: 26].
*   **4. Quản lý Khách hàng (FrmCustomer):** 
    *   Quản lý thông tin khách hàng (Mã, Họ tên, SĐT, Loại khách hàng) với chức năng Thêm và hiển thị lên `DataGridView`[cite: 26].
*   **5. Giới thiệu (FrmAbout):** Màn hình hiển thị thông tin ứng dụng, tên và lớp của sinh viên[cite: 25].

---

## 3. Hình ảnh minh họa (Screenshots)

**1. Màn hình Đăng nhập (FrmLogin):**

<img width="651" height="367" alt="1" src="https://github.com/user-attachments/assets/22e9e215-79ef-4060-87b1-271b7638a26c" />

**2. Giao diện chính MDI (FrmMain) với Menu và StatusStrip:**
<img width="820" height="746" alt="2" src="https://github.com/user-attachments/assets/91958afc-c277-4cce-bd7e-6b66caa3e228" />


**3. Chức năng Quản lý Sản phẩm bên trong Form chính:**
<img width="808" height="417" alt="5" src="https://github.com/user-attachments/assets/92c392b5-6e49-4d26-ac6e-a0f97bf1f07c" />


**4. Bắt lỗi Validation (Không trùng mã, không âm) hoặc Hỏi xác nhận Xóa:**
<img width="836" height="475" alt="4" src="https://github.com/user-attachments/assets/3e181325-4bd2-469b-a6e3-b96f10225493" />
<img width="837" height="470" alt="6" src="https://github.com/user-attachments/assets/c960d94a-0add-4184-8931-14258992cd03" />

**5. Màn hình Quản lý Khách hàng / Giới thiệu:**
<img width="991" height="503" alt="7" src="https://github.com/user-attachments/assets/68e70ce5-4d77-499b-bc10-fc8c3c9db2dc" />


---

## 4. Hướng dẫn chạy chương trình
1. Clone dự án về máy tính.
2. Mở file `.sln` bằng Visual Studio.
3. Nhấn `F5` hoặc nút `Start` để chạy.
4. Đăng nhập với tài khoản:
   * **Username:** `admin` | **Password:** `123` (Quyền Quản trị viên)[cite: 26]
   * **Username:** `user` | **Password:** `123` (Quyền Nhân viên)[cite: 26]
5. Sử dụng thanh Menu phía trên để điều hướng mở các chức năng Quản lý Sản phẩm, Khách hàng hoặc Giới thiệu[cite: 26].
