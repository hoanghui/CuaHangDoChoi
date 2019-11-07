CREATE DATABASE CuaHangDoChoi
GO

USE CuaHangDoChoi
GO

---các bảng
--bảng tài khoản
CREATE TABLE TaiKhoan
(
	tenDangNhap VARCHAR(20) PRIMARY KEY,
	matKhau VARCHAR(20) NOT NULL,
	loaiTaiKhoan INT NOT NULL --1: tài khoản quản lý, 0: tài khoản nhân viên
)
GO

--bảng nhân viên 
CREATE TABLE NhanVien
(
	maNhanVien INT PRIMARY KEY,
	hoTen NVARCHAR(50) NOT NULL,
	CMND INT NOT NULL,
	ngaySinh DATETIME,
	gioiTinh VARCHAR(10),
	tenDangNhap VARCHAR(20),
	FOREIGN KEY (tenDangNhap) REFERENCES dbo.TaiKhoan (tenDangNhap)
)
GO

--bảng khách hàng
CREATE TABLE KhachHang
(
	maKhachHang INT PRIMARY KEY,
	hoTen NVARCHAR(50) NOT NULL,
	CMND INT NOT NULL,
	soDienThoai INT NOT NULL,
	ngaySinh DATETIME,
	gioiTinh VARCHAR(10),
	diaChi NVARCHAR(50)
)
GO

--bảng đồ chơi
CREATE TABLE SanPham
(
	maSanPham INT PRIMARY KEY,
	tenSanPham NVARCHAR(20) NOT NULL,
	xuatXu NVARCHAR(20),
	ngayNhap DATETIME,
	giaBan MONEY
)
GO

CREATE TABLE HoaDon   
(
	maHoaDon INT PRIMARY KEY,
	maKhachHang INT,
	maNhanVien INT,
	ngayTao DATETIME NOT NULL,
	FOREIGN KEY (maKhachHang) REFERENCES dbo.KhachHang (maKhachHang),
	FOREIGN KEY (maNhanVien) REFERENCES dbo.NhanVien (maNhanVien)
)
GO

CREATE TABLE ChiTietHoaDon
(
	maHoaDon INT,
	maSanPham INT,
	donGia FLOAT,
	soLuong INT,
	PRIMARY KEY (maHoaDon, maSanPham),
	FOREIGN KEY (maHoaDon) REFERENCES dbo.HoaDon (maHoaDon),
	FOREIGN KEY (maSanPham) REFERENCES dbo.SanPham (maSanPham)
)
GO

--Thêm dữ liệu vào bảng TaiKhoan --

INSERT INTO TaiKhoan( tenDangNhap, matKhau, loaiTaiKhoan) VALUES ('admin', 1, 1),
																 ('hoanghuy',1,0),
																 ('giahuy',1,0),
																 ('anhkhoa',1,0)
																 
--Thêm dữ liệu vào bảng NhanVien --
INSERT INTO NhanVien VALUES (111, N'Nguyễn Hoàng Huy', 321764933,'11/19/1999','Nam', 'hoanghuy')
INSERT INTO NhanVien VALUES (112, N'Nguyễn Gia Huy', 845156151,'10/06/1999','Nam', 'giahuy')
INSERT INTO NhanVien VALUES(113, N'Phan Anh Khoa', 465151551,'10/22/1999','Nam', 'anhkhoa')
INSERT INTO NhanVien VALUES(114, N'Trịnh Hoàng Yến', 846813565,'11/12/1999','Nu', 'admin')
INSERT INTO NhanVien VALUES(115, N'Nguyễn Thanh Tú', 123456789,'09/29/1999','Nam', 'admin')