# TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH
## KHOA CÔNG NGHỆ THÔNG TIN
### BÁO CÁO KẾT QUẢ BÀI THỰC HÀNH LAB 10

**Học phần:** COMP1019 - Lập trình trên Windows  
**Chủ đề:** SQL Server, Thiết kế database, T-SQL và Kiểm thử ràng buộc dữ liệu  
**Cơ sở dữ liệu:** `EduManagerDB`  

---

### THÔNG TIN SINH VIÊN
* **Họ và tên:** Kiều Gia Bảo
* **Mã số sinh viên:** 51.01.104.128
* **Lớp sinh hoạt / Học phần:** CNTT.A (K51)
* **Giảng viên hướng dẫn:** Bộ môn Công nghệ Phần mềm
* **Môi trường thực nghiệm:**
  * Hệ điều hành: Windows 10 Pro 64-bit
  * Hệ quản trị CSDL: Microsoft SQL Server 2022 Developer Edition
  * Công cụ giao diện: SQL Server Management Studio (SSMS) v22

---

## 1. Mục tiêu bài thực hành
1. Khảo sát và thiết kế cơ sở dữ liệu quan hệ cho bài toán quản lý sinh viên và điểm học tập.
2. Cài đặt hoàn chỉnh Database `EduManagerDB` gồm 6 bảng, thiết lập các ràng buộc toàn vẹn khóa chính (`PRIMARY KEY`), khóa ngoại (`FOREIGN KEY`) và kiểm tra miền giá trị (`CHECK`) bằng ngôn ngữ T-SQL.
3. Tổ chức và thực hiện kịch bản nạp dữ liệu mẫu đảm bảo tính toàn vẹn quan hệ cha - con.
4. Xây dựng và thực thi các câu truy vấn trích xuất dữ liệu, tổng hợp thống kê theo yêu cầu (`SELECT`, `INNER JOIN`, `LEFT JOIN`, `GROUP BY`, `HAVING`, `UPDATE`, `DELETE`).
5. Kiểm thử tính toàn vẹn dữ liệu bằng cách cố tình chèn dữ liệu vi phạm ràng buộc và quan sát phản hồi từ SQL Server.

---

## 2. Thiết kế CSDL và Cài đặt Bảng (`01_CreateDatabase.sql`)

### 2.1. Danh sách bảng và mô hình thực thể
Cơ sở dữ liệu `EduManagerDB` gồm 6 bảng chuẩn hóa:

| Bảng | Khóa chính (PK) | Khóa ngoại (FK) | Ràng buộc kiểm tra (CHECK) | Chức năng nghiệp vụ |
| :--- | :--- | :--- | :--- | :--- |
| **KHOA** | `MaKhoa` | *(Không)* | *(Không)* | Lưu trữ danh mục khoa đào tạo. |
| **LOP** | `MaLop` | `MaKhoa` -> `KHOA(MaKhoa)` | *(Không)* | Lưu thông tin các lớp thuộc từng khoa. |
| **SINHVIEN** | `MaSV` | `MaLop` -> `LOP(MaLop)` | `GioiTinh IN (N'Nam', N'Nữ')` | Hồ sơ sinh viên theo từng lớp sinh hoạt. |
| **MONHOC** | `MaMH` | *(Không)* | `SoTinChi > 0` | Danh mục môn học và số tín chỉ tương ứng. |
| **KETQUA** | `(MaSV, MaMH)` | `MaSV` -> `SINHVIEN(MaSV)`,<br>`MaMH` -> `MONHOC(MaMH)` | `Diem BETWEEN 0 AND 10` | Điểm tổng kết môn học của sinh viên. |
| **TAIKHOAN** | `TenDangNhap` | *(Không)* | *(Không)* | Tài khoản đăng nhập hệ thống (`Admin`/`User`). |

### 2.2. Script khởi tạo T-SQL tiêu biểu
```sql
USE master;
GO
DROP DATABASE IF EXISTS EduManagerDB;
GO
CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

CREATE TABLE KHOA (
    MaKhoa VARCHAR(20) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) NULL
);

CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20) NOT NULL,
    CONSTRAINT FK_LOP_KHOA FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);

CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT CK_SINHVIEN_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

CREATE TABLE MONHOC (
    MaMH VARCHAR(20) PRIMARY KEY,
    TenMH NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL,
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);

CREATE TABLE KETQUA (
    MaSV VARCHAR(20) NOT NULL,
    MaMH VARCHAR(20) NOT NULL,
    Diem DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);

CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro VARCHAR(20) NOT NULL DEFAULT 'User',
    TrangThai BIT NOT NULL DEFAULT 1
);
GO
```

### 2.3. Minh chứng hệ thống
<img width="417" height="468" alt="image" src="https://github.com/user-attachments/assets/09fa1420-3eb7-4871-8037-55d4ae411c7e" />

---

## 3. Nạp Dữ liệu mẫu (`02_InsertSampleData.sql`)

Dữ liệu được nạp theo đúng nguyên tắc phân cấp cha trước - con sau:
1. `KHOA`: 2 bản ghi (`FIT`, `MATH`).
2. `LOP`: 3 bản ghi (`CNTT01`, `CNTT02`, `SPTIN01`).
3. `SINHVIEN`: 6 bản ghi (`SV001` đến `SV006`).
4. `MONHOC`: 4 bản ghi (`COMP1019`, `COMP1017`, `COMP1020`, `COMP1044`).
5. `KETQUA`: 8 bản ghi điểm hợp lệ (thang điểm từ 0 đến 10).
6. `TAIKHOAN`: 2 tài khoản phân quyền (`admin`, `gv01`).

---

## 4. Kết quả Thực thi Truy vấn T-SQL (`03_Queries.sql`)

### Truy vấn 1: Liệt kê toàn bộ hồ sơ sinh viên
```sql
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
```
<img width="450" height="147" alt="image" src="https://github.com/user-attachments/assets/80e27085-7fd0-40f4-b743-532b5d7edbbb" />

### Truy vấn 2: Danh sách sinh viên kết hợp Tên lớp và Tên khoa (`INNER JOIN`)
```sql
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
```
<img width="544" height="143" alt="image" src="https://github.com/user-attachments/assets/4d84aff1-34ed-462e-9a40-1241d44da227" />

### Truy vấn 7: Liệt kê điểm thi của từng sinh viên theo môn học
```sql
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
```
<img width="491" height="186" alt="image" src="https://github.com/user-attachments/assets/7b4045c4-44ac-4213-b1f0-e74c7101b34f" />

### Truy vấn 8: Thống kê điểm trung bình của từng sinh viên

```sql
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen;
```
<img width="343" height="148" alt="image" src="https://github.com/user-attachments/assets/a982a7cb-c3ba-4a26-b8d6-18f743cf94c2" />

### Truy vấn 10: Thống kê các lớp có số lượng sinh viên >= 2 (`HAVING`)
```sql
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;
```
<img width="336" height="87" alt="image" src="https://github.com/user-attachments/assets/1b9f0ea6-0ccb-45d6-afd6-1b41c483304a" />


---

## 5. Kiểm thử Ràng buộc Toàn vẹn Dữ liệu

Mục đích kiểm thử: Đảm bảo SQL Server chủ động ngăn chặn các thao tác vi phạm quy tắc toàn vẹn đã thiết lập.

### 5.1. Kiểm thử vi phạm Khóa ngoại (Câu 11)
* **Thao tác:** Thêm sinh viên thuộc mã lớp `'CNTT99'` (lớp không tồn tại trong danh mục `LOP`).
```sql
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
```
* **Kết quả thực tế:** Hệ thống từ chối ghi dữ liệu và trả về lỗi `FK_SINHVIEN_LOP`.

### 5.2. Kiểm thử vi phạm Ràng buộc CHECK điểm (Câu 12)
* **Thao tác:** Nhập điểm môn học bằng 12 (vi phạm điều kiện từ 0 đến 10).
```sql
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV001', 'COMP1019', 12);
```
* **Kết quả thực tế:** Hệ thống chặn và trả về thông báo lỗi `CK_KETQUA_Diem`.


<img width="1212" height="126" alt="image" src="https://github.com/user-attachments/assets/431937ac-9433-45bc-b492-523956dbdcfe" />

<img width="1107" height="139" alt="image" src="https://github.com/user-attachments/assets/6d1c3269-e69e-4b02-bc8e-52527aed5793" />

---

## 6. Đánh giá và Kết luận
1. Đã thiết kế và triển khai thành công CSDL `EduManagerDB` chuẩn hóa theo đúng yêu cầu đề tài.
2. Các ràng buộc toàn vẹn thực thể (`PK`), toàn vẹn tham chiếu (`FK`) và toàn vẹn miền giá trị (`CHECK`) hoạt động ổn định và chính xác.
3. Kịch bản truy vấn giải quyết đầy đủ các yêu cầu nghiệp vụ từ cơ bản đến thống kê gom nhóm.
4. Xử lý triệt để các vấn đề kỹ thuật phát sinh trong quá trình thiết lập (cấu hình bảo mật kết nối SSMS, phân quyền quản trị tài khoản và đồng bộ bộ nhớ đệm IntelliSense).
