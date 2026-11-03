USE QuanLyBanHangDB;
GO

-- 1. Phải xóa bảng con (KETQUA) tham chiếu đến SINHVIEN trước (nếu có)
IF OBJECT_ID('KETQUA', 'U') IS NOT NULL DROP TABLE KETQUA;

-- 2. Xóa tiếp SINHVIEN (bảng con tham chiếu đến LOP)
IF OBJECT_ID('SINHVIEN', 'U') IS NOT NULL DROP TABLE SINHVIEN;

-- 3. Cuối cùng mới xóa được LOP
IF OBJECT_ID('LOP', 'U') IS NOT NULL DROP TABLE LOP;
GO

-- Sau đó bạn tiến hành CREATE TABLE LOP và SINHVIEN lại như bình thường
CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO