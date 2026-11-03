-- =======================================================
-- BÀI LAB 10 - COMP1019: LẬP TRÌNH TRÊN WINDOWS
-- FILE 03: TRUY VẤN DỮ LIỆU VÀ KIỂM THỬ RÀNG BUỘC
-- =======================================================

USE EduManagerDB;
GO

-- 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

-- 2. Liệt kê sinh viên kèm tên lớp và tên khoa
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
GO

-- 3. Tìm sinh viên theo một phần họ tên bằng LIKE
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;
GO

-- 4. Liệt kê sinh viên theo mã lớp CNTT01
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

-- 5. Cập nhật họ tên của sinh viên SV001
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An Updated'
WHERE MaSV = 'SV001';
GO

-- 6. Xóa sinh viên chưa có dữ liệu điểm (nếu có)
DELETE FROM SINHVIEN
WHERE MaSV = 'SV003' 
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV003');
GO

-- 7. Liệt kê điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
GO

-- 8. Tính điểm trung bình của từng sinh viên
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen;
GO

-- 9. Thống kê số sinh viên theo từng lớp
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop;
GO

-- 10. Liệt kê các lớp có từ 2 sinh viên trở lên
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;
GO

-- =======================================================
-- KIỂM THỬ RÀNG BUỘC (MỤC TIÊU: SQL SERVER PHẢI CHẶN VÀ BÁO LỖI)
-- =======================================================

-- 11. Test lỗi khóa ngoại: Thêm sinh viên vào lớp 'CNTT99' không tồn tại
-- (Kết quả mong đợi: Báo lỗi FOREIGN KEY constraint "FK_SINHVIEN_LOP")
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
GO

-- 12. Test lỗi CHECK điểm: Nhập điểm 12 (vượt quá 10)
-- (Kết quả mong đợi: Báo lỗi CHECK constraint "CK_KETQUA_Diem")
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV001', 'COMP1019', 12);
GO