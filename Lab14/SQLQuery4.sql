CREATE DATABASE Lab14;
GO
USE Lab14;
GO
CREATE TABLE MONHOC (
    MaMonHoc nvarchar(10) PRIMARY KEY,
    TenMonHoc nvarchar(100) NOT NULL,
    SoTinChi int CHECK (SoTinChi >= 1 AND SoTinChi <= 6),
    TrangThai bit DEFAULT 1
);
GO
INSERT INTO MONHOC VALUES ('COMP1019', N'Lập trình trên Windows', 3, 1);