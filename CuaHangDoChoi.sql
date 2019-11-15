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
	giaBan FLOAT,
	soLuong INT
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
																 ('giahuy',1,0),
																 ('anhkhoa',1,1)
INSERT INTO TaiKhoan( tenDangNhap, matKhau, loaiTaiKhoan) VALUES ('thanhtu',1,0),
																 ('hoangyen',1,0)
INSERT INTO TaiKhoan( tenDangNhap, matKhau, loaiTaiKhoan) VALUES ('thanhtung',1,0)
--Thêm dữ liệu vào bảng NhanVien --
INSERT INTO NhanVien VALUES (111, N'Nguyễn Hoàng Huy', 321764933,'11/19/1999','Nam', 'admin')
INSERT INTO NhanVien VALUES (112, N'Nguyễn Gia Huy', 845156151,'10/06/1999','Nam', 'giahuy')
INSERT INTO NhanVien VALUES(113, N'Phan Anh Khoa', 465151551,'10/22/1999','Nam', 'anhkhoa')
INSERT INTO NhanVien VALUES(114, N'Trịnh Hoàng Yến', 846813565,'11/12/1999','Nu', 'hoangyen')
INSERT INTO NhanVien VALUES(115, N'Nguyễn Thanh Tú', 123456789,'09/29/1999','Nam', 'thanhtu')
INSERT INTO NhanVien VALUES(116, N'Nguyễn Thanh Tùng', 415481561,'09/29/1999','Nam', 'thanhtung')
--Thêm dữ liệu vào bảng SanPham --
INSERT INTO SanPham VALUES (1001, N'Xe đẩy', 'China', '10/11/2018',200000,50)
INSERT INTO SanPham VALUES (1002, N'Búp bê', 'China', '01/11/2018',10000,20)
INSERT INTO SanPham VALUES (1003, N'Nón lá', 'Vietnam', '10/2/2018',50000,100)
INSERT INTO SanPham VALUES (1004, N'Xe điều khiển', 'Campuchia', '06/11/2018',200000,50)
INSERT INTO SanPham VALUES (1005, N'Máy bay', 'Vietnam', '10/2/2018',1000000,10)
INSERT INTO SanPham VALUES (1006, N'Kiếm Nhật', 'China', '10/8/2018',300000,50)
INSERT INTO SanPham VALUES (1007, N'Xẻng nhưạ', 'China', '10/3/2018',150000,50)
INSERT INTO SanPham VALUES (1008, N'Đồ chơi bác sĩ', 'Japan', '10/12/2018',200000,50)
INSERT INTO SanPham VALUES (1009, N'Xe đạp', 'Japan', '7/8/2018',3000000,10)
INSERT INTO SanPham VALUES (1010, N'Thuyền', 'Korea', '6/11/2018',1500000,30)

--Thêm dữ liệu vào bảng KhachHang --
INSERT INTO KhachHang VALUES (1, N'Dương Trần Tử Minh', 123456789, 0321665499, '1/1/1999','Nam',N'Quận 7')
INSERT INTO KhachHang VALUES (2, N'Đỗ Nguyên Thanh Tùng', 123456789, 0321665499, '1/11/1999','Nu',N'Quận Gò Vấp')
INSERT INTO KhachHang VALUES (3, N'Nguyễn Thị Triệu', 123456789, 0321665499, '9/1/1999','Nu',N'Quận Gò Vấp')
INSERT INTO KhachHang VALUES (4, N'Chị Dậu', 123456789, 0321665499, '8/1/1999','Nu',N'Quận 4')
INSERT INTO KhachHang VALUES (5, N'Sơn Tùng MTP', 123456789, 0321665499, '3/2/1999','Nam',N'Thái Bình')
INSERT INTO KhachHang VALUES (6, N'Nguyễn Quốc Huy', 123456789, 0321665499, '12/8/1999','Nam',N'Quận Bình Thạnh')
INSERT INTO KhachHang VALUES (7, N'Nguyễn Trấn Thành', 123456789, 0321665499, '11/6/1999','Nam',N'Quận 10')
INSERT INTO KhachHang VALUES (8, N'Noo Phước Thịnh', 123456789, 0321665499, '3/9/1999','Nu',N'Quận 9')
INSERT INTO KhachHang VALUES (9, N'Mỹ Tâm', 123456789, 0321665499, '11/4/1999','Nu',N'Quận 8')

--Thêm dữ liệu vào bảng hóa đơn--

INSERT INTO HoaDon VALUES (101,1,112,'11/10/2018')
INSERT INTO HoaDon VALUES (102,7,112,'8/1/2018')
INSERT INTO HoaDon VALUES (103,6,116,'9/1/2018')

-- Thêm dữ liệu vào bảng chi tiết hóa đơn --

INSERT INTO ChiTietHoaDon VALUES (101,1001,400000,2)
INSERT INTO ChiTietHoaDon VALUES (102,1002,20000,2)
INSERT INTO ChiTietHoaDon VALUES (102,1003,50000,1)

DELETE FROM dbo.NhanVien WHERE maNhanVien = '0'
DELETE FROM dbo.TaiKhoan WHERE tenDangNhap = 'r'		

-- sua --
--SELECT *
--FROM NhanVien 
--IF EXISTS (
--	SELECT maNhanVien
--	FROM NhanVien
--	WHERE maNhanVien = 111
--	)	
--	BEGIN
--		INSERT INTO TaiKhoan( tenDangNhap, matKhau, loaiTaiKhoan) VALUES ('kaka',1,1)
--		INSERT INTO NhanVien VALUES(119, N'newbie', 415481561,'09/29/1999','Nam', 'kaka')
--	END
--ELSE
--	BEGIN
--		UPDATE  dbo.NhanVien SET  hoTen = N'cc', gioiTinh = 'Nu' 
--		WHERE maNhanVien = 111
--	END


--DELETE FROM NhanVien

--INSERT INTO dbo.NhanVien VALUES(119,N'Minh hoàng Hahahaha',485156156,'11/11/1999', 'nam','hahaha')
--INSERT INTO dbo.TaiKhoan ( tenDangNhap, matKhau, loaiTaiKhoan) VALUES('hahaha',1,1)

--xóa bảng--
--DROP TABLE dbo.SanPham
--DROP TABLE dbo.ChiTietHoaDon	
