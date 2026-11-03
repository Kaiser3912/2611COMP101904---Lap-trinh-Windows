-- =======================================================
-- BÀI LAB 10 - COMP1019: LẬP TRÌNH TRÊN WINDOWS
-- FILE 01: TẠO DATABASE VÀ HỆ THỐNG BẢNG RÀNG BUỘC
-- =======================================================

USE master;
GO

-- 1. Xóa database cũ nếu đã tồn tại để tránh xung đột
DROP DATABASE IF EXISTS EduManagerDB;
GO

-- 2. Tạo database mới
CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- 3. Tạo bảng KHOA
CREATE TABLE KHOA (
    MaKhoa VARCHAR(20) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) NULL
);
GO

-- 4. Tạo bảng LOP (Tham chiếu đến KHOA)
CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20) NOT NULL,
    CONSTRAINT FK_LOP_KHOA 
        FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

-- 5. Tạo bảng SINHVIEN (Tham chiếu đến LOP, ràng buộc giới tính Nam/Nữ)
CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT CK_SINHVIEN_GioiTinh 
        CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP 
        FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- 6. Tạo bảng MONHOC (Ràng buộc số tín chỉ > 0)
CREATE TABLE MONHOC (
    MaMH VARCHAR(20) PRIMARY KEY,
    TenMH NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL,
    CONSTRAINT CK_MONHOC_SoTinChi 
        CHECK (SoTinChi > 0)
);
GO

-- 7. Tạo bảng KETQUA (Khóa chính kép, tham chiếu SINHVIEN và MONHOC, điểm 0 - 10)
CREATE TABLE KETQUA (
    MaSV VARCHAR(20) NOT NULL,
    MaMH VARCHAR(20) NOT NULL,
    Diem DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN 
        FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC 
        FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- 8. Tạo bảng TAIKHOAN (Tài khoản đăng nhập demo)
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro VARCHAR(20) NOT NULL DEFAULT 'User',
    TrangThai BIT NOT NULL DEFAULT 1
);
GO