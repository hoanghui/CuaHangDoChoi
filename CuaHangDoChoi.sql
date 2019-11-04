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

