# BÁO CÁO LAB 04: QUẢN LÝ SẢN PHẨM (CONSOLE APP)

**Học phần:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** Exception, Delegate/Event, Func/Action và Generic trong C#

---

## 1. Giới thiệu
Đây là ứng dụng Console quản lý danh sách sản phẩm lưu trong bộ nhớ. Chương trình được thiết kế với kiến trúc phân lớp rõ ràng (tách biệt `Program`, `ProductService`, và `Repository<T>`) nhằm đảm bảo mã nguồn dễ đọc, dễ bảo trì và mở rộng[cite: 17, 18].

## 2. Các chức năng chính
Chương trình hỗ trợ menu điều khiển với các tính năng sau:

*   **Thêm sản phẩm:** Cho phép nhập mã, tên, đơn giá và số lượng[cite: 17]. Tự động kiểm tra giá trị âm và ngăn chặn nhập mã trùng lặp[cite: 17, 18].
*   **Xuất danh sách:** Hiển thị toàn bộ dữ liệu trong kho hoặc in thông báo phù hợp nếu danh sách đang rỗng[cite: 17].
*   **Tìm kiếm:** Hỗ trợ tìm kiếm chính xác theo mã sản phẩm hoặc tìm tương đối theo từ khóa có trong tên[cite: 18].
*   **Lọc theo khoảng giá:** Lọc và hiển thị danh sách các sản phẩm nằm trong khoảng giá thấp nhất và cao nhất do người dùng nhập[cite: 18].
*   **Xóa sản phẩm:** Xóa sản phẩm dựa trên mã. Phát thông báo xác nhận nếu xóa thành công, hoặc cảnh báo lỗi nếu mã không tồn tại[cite: 18].
*   **Tính tổng giá trị kho:** Tự động tính toán tổng tài sản dựa trên công thức (Đơn giá * Số lượng) của tất cả sản phẩm[cite: 18].

## 3. Kỹ thuật lập trình áp dụng
Dự án vận dụng các kiến thức nâng cao trong C# theo đúng yêu cầu đề bài:

*   **Generic Constraint:** Xây dựng kho lưu trữ chung `Repository<T>` với ràng buộc `where T : IEntity` để tái sử dụng mã cho các đối tượng khác nhau[cite: 17].
*   **Custom Exceptions:** Định nghĩa và xử lý ít nhất 2 exception tự tạo gồm `DuplicateProductException` (xử lý trùng mã) và `ProductNotFoundException` (xử lý tìm/xóa không thấy)[cite: 17]. Chương trình sử dụng khối `try-catch` để đảm bảo không bị dừng đột ngột khi người dùng nhập sai kiểu dữ liệu[cite: 18].
*   **Delegate & Event:** Sử dụng Event (hoặc Action) để kích hoạt cơ chế thông báo (Subscribe/Publish) ngay khi có sản phẩm được thêm mới hoặc xóa khỏi kho thành công[cite: 18].
*   **Func<T, bool>:** Ứng dụng `Func<Product, bool>` như một tham số truyền vào để linh hoạt lọc danh sách và tìm kiếm theo khoảng giá mà không cần viết lại nhiều vòng lặp[cite: 18].

---

## 4. Hình ảnh minh họa (Screenshots)

**Menu chính và chức năng Thêm sản phẩm (Xử lý lỗi nhập sai / trùng mã):**
<img width="805" height="518" alt="1" src="https://github.com/user-attachments/assets/d5db1b62-3c56-4afc-bfc3-e01734bbc3af" /> <img width="805" height="518" alt="2" src="https://github.com/user-attachments/assets/32cf806e-3260-4ca8-bb03-200c4d613faa" /> 


**Chức năng Xuất danh sách và Thông báo Event khi thêm thành công:**
<img width="805" height="518" alt="4" src="https://github.com/user-attachments/assets/78b93aa8-b1fe-4368-8125-27f0e7c8e151" /> <img width="805" height="518" alt="3" src="https://github.com/user-attachments/assets/2d46d95c-d1f9-470b-aedc-95154b4579ee" />

**Chức năng Tìm kiếm và Lọc theo khoảng giá (Sử dụng Func):**
<img width="805" height="518" alt="5" src="https://github.com/user-attachments/assets/d3a4d805-f42b-423c-8fa4-efe11e7d8a92" /> <img width="805" height="518" alt="9" src="https://github.com/user-attachments/assets/0c75c80b-53c7-44be-9d14-8f6dc1f2a7be" />


**Chức năng Xóa sản phẩm (Xử lý lỗi ProductNotFound) và Tính tổng giá trị kho:**
<img width="805" height="518" alt="6" src="https://github.com/user-attachments/assets/4dbe7b1e-0eef-416a-bd66-c34952a39c77" /> <img width="805" height="518" alt="7" src="https://github.com/user-attachments/assets/b2eeef64-0835-443c-9c84-c2fda0f29f84" /> <img width="805" height="518" alt="8" src="https://github.com/user-attachments/assets/9d24a1cc-d50f-4c87-8676-c555900741e3" />



---

## 5. Hướng dẫn chạy chương trình
1. Clone repository này về máy tính.
2. Mở file `.sln` bằng Visual Studio (phiên bản hỗ trợ C# .NET).
3. Nhấn `F5` hoặc nút `Start` để chạy ứng dụng dưới dạng Console.
4. Sử dụng các phím số từ `1` đến `7` để chọn chức năng và `0` để thoát chương trình[cite: 18].
