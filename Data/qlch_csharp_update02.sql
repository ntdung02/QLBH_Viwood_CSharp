/*Tạo cơ sở dữ liệu  CuaHangVIWOOD*/
CREATE DATABASE DB_QLCH_02
GO
USE DB_QLCH_02
GO
/*****************1. Tạo các bảng********************/

/*1. Tạo bảng nhân viên*/------------------
create table NhanVien
(
	 MaNV varchar (6) primary key,
	 HoTen nvarchar (100) NOT NULL,
	 GioiTinh nvarchar (10) NOT NULL,
	 SDT nvarchar (15) NOT NULL,
	 Email nvarchar (150) NOT NULL,
	 MaPB int Not null,
	 TaiKhoan varchar(20) NOT NULL,
	 MatKhau varchar (20) Not null,
)
go

/*2.Tạo bảng phòng ban */------------------
create table PhongBan
(
	 MaPB int identity (1,1) primary key,
	TenPB nvarchar (50) NOT NULL,
)
go

/*3. Tạo bảng nhóm*/----------------
create table Nhom
(
 MaNhom varchar (6) primary key,
 TenNhom nvarchar (100) NOT NULL,
)
go


/*4.Tạo bảng sản phẩm*/-------------
create table SanPham
(
MaSP varchar (6) primary key,
TenSanPham nvarchar(100) NOT NULL,
SoLuongTon int NOT NULL,
GiaNhap float NOT NULL,
GiaBan float NOT NULL,
TinhTrang nvarchar (100) NOT NULL,
MaNhom varchar (6)  NOT NULL,
MaNCC varchar (6)  NOT NULL,
)
go

/*5.Tạo bảng khách hàng*/----------------
create table KhachHang
(
MaKH varchar (6) primary key,
HoTenKH nvarchar(100) NOT NULL,
DiaChiKH nvarchar(100) NOT NULL,
SDTKH nvarchar(12) NOT NULL,
EmailKH nvarchar(50) NOT NULL,
GioiTinhKH nvarchar(10) NOT NULL,
)
go

/*6.Tạo bảng nhà cung cấp*/------------
create table NhaCungCap
(
MaNCC varchar (6) primary key,
TenNCC nvarchar(50) NOT NULL,
DiaChiNCC nvarchar(100) NOT NULL,
DienThoaiNCC varchar(12) NOT NULL,
EmailNCC nvarchar(100) NOT NULL,
)
go

/*7.Tạo bảng hóa đơn*/
create table HoaDon
(
	MaHoaDon varchar (6) primary key,
	NgayLap datetime constraint DF_NgayLap_tbHoaDon Default (getdate()),
	TongTien bigint NOT NULL,
	MaNV varchar (6) not null,
	MaDonDat varchar (6) not null ,
)
go
/*8.Tạo bảng chi tiết hóa đơn*/
create table CTHoaDon
(
	MaHoaDon varchar (6) not null,
	MaSP varchar (6)  NOT NULL ,
	SoLuong int not null,
	ThanhTien int not null,
)
go


/*9.Tạo bảng nhập hàng*/
create table NhapHang
(
	MaNhapHang varchar (6)  primary key,
	NgayLap datetime constraint DF_NgayLap_tbNhapHang Default (getdate()),
	MaNV varchar (6) NOT NULL,
	MaNCC varchar (6)  NOT NULL,
	TongTien int  not null ,
)
go

/*10.Tạo bảng chi tiết nhập hàng*/
create table CTNhapHang
(

	MaSP varchar (6)  NOT NULL,
	MaNhapHang varchar (6)   NOT NULL  ,
	SoLuong int not null,
	ThanhTien int not null,
)
go


/*11.Tạo bảng đơn đặt hàng*/
create table DonDatHang
(
MaDonDat  varchar (6)  primary key,
MaKH varchar (6) NOT NULL,
NgayLap datetime constraint DF_NgayLap_tbDonDatHang Default (getdate()),
TinhTrang nvarchar (30) NOT NULL,
MaNV varchar (6)   not null,
)
go

/*15.Tạo bảng chi tiết đơn đặt hàng*/
create table CTDonDatHang
(
MaDonDat varchar (6) not null  ,
MaSP varchar (6) not null   ,
SoLuongDat int NOT NULL,
)
go



/************2.Lệnh Alter*****************/


/*1. Tạo ràng khóa ngoại của bảng nhân viên */
ALTER TABLE NhanVien
ADD CONSTRAINT fk_nv_mpb FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB);

/*2. Tạo ràng buộc khóa ngoại khóa ngoại của bảng Sản phẩm */
alter table SanPham
add constraint fk_MaNhom foreign key (MaNhom) references Nhom(MaNhom);
alter table SanPham
add constraint fk_sp_MaNCC foreign key (MaNCC) references NhaCungCap(MaNCC);

/*3. Tạo ràng buộc khóa ngoại của bảng hóa đơn */
alter table HoaDon
add constraint fk_hd_MaNV foreign key (MaNV) references NhanVien(MaNV);
alter table HoaDon
add constraint fk_hd_MaDonDat foreign key (MaDonDat) references DonDatHang(MaDonDat);

/*3. Tạo ràng buộc khóa ngoại của bảng chi tiết hóa đơn */
alter table CTHoaDon
add constraint fk_cthd_MaHoaDon foreign key (MaHoaDon) references HoaDon(MaHoaDon);
alter table CTHoaDon
add constraint fk_cthd_MaSP foreign key (MaSP) references SanPham(MaSP);


/*4. Tạo ràng buộc khóa ngoại của bảng nhập hàng */
alter table NhapHang
add constraint fk_nh_MaNV foreign key (MaNV) references NhanVien(MaNV);
alter table NhapHang
add constraint fk_nh_MaNCC foreign key (MaNCC) references NhaCungCap(MaNCC);

/*5. Tạo ràng buộc khóa ngoại của bảng chi tiết nhập hàng.*/
alter table CTNhapHang
add constraint fk_ctnh_MaNhapHang foreign key (MaNhapHang) references NhapHang(MaNhapHang);
alter table CTNhapHang
add constraint fk_ctnh_MaSP foreign key (MaSP) references SanPham(MaSP);

/*6. Tạo ràng buộc khóa ngoại của bảng đơn đặt hàng */
alter table DonDatHang
add constraint fk_ddh_MaKH foreign key (MaKH ) references KhachHang(MaKH );
alter table DonDatHang
add constraint fk_ddh_MaNV foreign key (MaNV) references NhanVien(MaNV);

/*7. Tạo ràng buộc khóa ngoại của bảng đơn đặt hàng */
alter table CTDonDatHang
add constraint fk_ctddh_MaDonDat foreign key (MaDonDat) references DonDatHang(MaDonDat);
alter table CTDonDatHang
add constraint fk_ctddh_MaSP foreign key (MaSP) references SanPham(MaSP);
-----------------------------------------------------------
alter table CTDonDatHang
add constraint pk_ctdonhang primary key (MaDonDat,MaSP)


alter table CTNhapHang
add constraint pk_ctnhaphang primary key (MaNhapHang,MaSP)


alter table CTHoaDon
add constraint pk_cthoadon primary key (MaHoaDon, MaSP)


/*TẠO FUNCITION VÀ TRIGGER*/
---------- AUTO EMPLOYEE ID----------------

CREATE FUNCTION func_nextid
(
    @lastuserID VARCHAR(6),
    @prefix VARCHAR(3),
    @size INT
)
RETURNS VARCHAR(6)
AS
BEGIN
    IF (@lastuserID = '')
        SET @lastuserID = @prefix + REPLICATE('0', @size - LEN(@prefix));
    
    DECLARE @num_nextuserID INT, @nextuserID VARCHAR(6);
    
    SET @lastuserID = LTRIM(RTRIM(@lastuserID));
    SET @num_nextuserID = CAST(REPLACE(@lastuserID, @prefix, '') AS INT) + 1;
    SET @size = @size - LEN(@prefix);
    SET @nextuserID = @prefix + RIGHT('0000' + CAST(@num_nextuserID AS VARCHAR(6)), @size);
    
    RETURN @nextuserID;
END;
GO
CREATE TRIGGER tr_nextspID ON [NhanVien]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaNV
    FROM [NhanVien]
    ORDER BY MaNV DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'NV', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [NhanVien]
    SET MaNV = @nextuserID
    WHERE MaNV = '';
END;
GO

--------- AUTO GROUP ID ---------------------
CREATE TRIGGER tr_nextnhomID ON [Nhom]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaNhom
    FROM [Nhom]
    ORDER BY MaNhom DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'gr', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [Nhom]
    SET MaNhom = @nextuserID
    WHERE MaNhom = '';
END;
GO

--------- AUTO PRODUCT ID ---------------------
CREATE TRIGGER tr_nextsanphamID ON [SanPham]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaSP
    FROM [SanPham]
    ORDER BY MaSP DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'sp', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [SanPham]
    SET MaSP = @nextuserID
    WHERE MaSP = '';
END;
GO

--------- AUTO CUSTOMER ID ---------------------
CREATE TRIGGER tr_nextkhID ON [KhachHang]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaKH
    FROM [KhachHang]
    ORDER BY MaKH DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'KH', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [KhachHang]
    SET MaKH = @nextuserID
    WHERE MaKH = '';
END;
GO

--------- AUTO SUPPLIER ID ---------------------
CREATE TRIGGER tr_nextnccID ON [NhaCungCap]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaNCC
    FROM [NhaCungCap]
    ORDER BY MaNCC DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'CC', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [NhaCungCap]
    SET MaNCC = @nextuserID
    WHERE MaNCC = '';
END;
GO

--------- AUTO BILL ID ---------------------
CREATE TRIGGER tr_nexthdID ON [HoaDon]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaHoaDon
    FROM [HoaDon]
    ORDER BY MaHoaDon DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'HD', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [HoaDon]
    SET MaHoaDon = @nextuserID
    WHERE MaHoaDon = '';
END;
GO

--------- AUTO IMPORT ID ---------------------
CREATE TRIGGER tr_nextnhID ON [NhapHang]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaNhapHang
    FROM [NhapHang]
    ORDER BY MaNhapHang DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'NH', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [NhapHang]
    SET MaNhapHang= @nextuserID
    WHERE MaNhapHang = '';
END;
GO

--------- AUTO ORDER ID ---------------------
CREATE TRIGGER tr_nextddID ON [DonDatHang]
FOR INSERT
AS
BEGIN
    DECLARE @lastuserID VARCHAR(6), @nextuserID VARCHAR(6);

    SELECT TOP 1 @lastuserID = MaDonDat
    FROM [DonDatHang]
    ORDER BY MaDonDat DESC;

    SET @lastuserID = ISNULL(@lastuserID, ''); -- Chắc chắn rằng @lastuserID không null

    -- Tạo mã người dùng tiếp theo
    SET @nextuserID = dbo.func_nextid(@lastuserID, 'DD', 6);

    -- Cập nhật mã người dùng mới trong bảng
    UPDATE [DonDatHang]
    SET MaDonDat = @nextuserID
    WHERE MaDonDat = '';
END;
GO

/*************----------------INSERT DATA-----------------***************/

INSERT [dbo].[PHONGBAN]  VALUES ( N'Quản lý')
INSERT [dbo].[PHONGBAN]  VALUES ( N'Kho')
INSERT [dbo].[PHONGBAN]  VALUES ( N'Bán hàng')
GO


INSERT [dbo].[NHANVIEN]  VALUES ('', N'Nguyễn Thuy Dung',N'NỮ', N'0398874556',N'ThuyDung@gmail.com',1,'ThuyDungQL','dung@123456')
INSERT [dbo].[NHANVIEN]  VALUES ('', N'Lê Thị Hoa',N'NỮ', N'0398874123',N'LeHoa@gmail.com',2,'HoaHoaNV','Hoa@123') 
INSERT [dbo].[NHANVIEN]  VALUES ('', N'Lý Thị Thu',N'NỮ', N'0398874112',N'ThuThug@gmail.com',3,'LyThuNV','Thu@456')
INSERT [dbo].[NHANVIEN]  VALUES ('', N'Nguyễn Văn Tấn',  N'NAM', N'0398874113',N'TanNguyen@gmail.com',3,'TanNguyenNV','Tan@789')
INSERT [dbo].[NHANVIEN]  VALUES ('', N'Phan Văn Anh',  N'NAM', N'0398874114',N'PhanAnh@gmail.com',3,'PhanAnhNV','AnhPhan@159')
INSERT [dbo].[NHANVIEN]  VALUES ('', N'Trần Thị Thanh',  N'NỮ', N'0398874115',N'ThanhThanh@gmail.com',3,'ThanhTranNV','ThanhTran@753')
INSERT [dbo].[NHANVIEN]  VALUES ('', N'Võ Thị Bảo trân',  N'NỮ', N'0398874117',N'BaoTran@gmail.com',2, 'BaoTranNV','TranBao@486')
go

INSERT [dbo].[NHACUNGCAP]  VALUES ('', N'Nội Thất Mộc Việt',N'106/1N Đường Tân Hiệp 17, ấp Tân Thới 2, Hóc Môn, Tp. Hồ Chí Minh ',N'0162595188',N'noithatmocviet106@gmail.com')
INSERT [dbo].[NHACUNGCAP]  VALUES ('', N'Nội Thất Trúc Linh ',N'Số 51/97 Văn Cao, Q. Ba Đình, Hà Nội',N'0903232317',N'info@truclinh.vn')
INSERT [dbo].[NHACUNGCAP]  VALUES ('', N'Nội Thất Minh Tiến',N'Tầng 9, Tòa nhà Sở Công Thương, 163 Hai Bà Trưng, Phường 6, Quận 3, Tp. Hồ Chí  ',N'0139118383',N'minhtien@mtic.vn')
INSERT [dbo].[NHACUNGCAP]  VALUES ('', N'Nội Thất Đại Phát',N'Số 18, Đường Số 9, Tổ 74, Khu Phố 3, P. Trung Mỹ Tây, Q. 12, Tp. Hồ Chí Minh  ',N'0162576254',N'daiphat26@gmail.com')
INSERT [dbo].[NHACUNGCAP]  VALUES ('', N'Thiết Kế Nội Thất Nam Hà',N'TDP Đồi Cao, TT. Hợp Châu, H. Tam Đảo, Vĩnh Phúc',N'0972 239 368',N'noithatnamha.68@gmail.com')
GO

INSERT [dbo].[NHOM]  VALUES ('', N'Ngoại thất')
INSERT [dbo].[NHOM] VALUES ('',N'Nội thất phòng khách')
INSERT [dbo].[NHOM]  VALUES ('',N'Nội thất phòng ngủ')
INSERT [dbo].[NHOM]  VALUES ( '',N'Nội thất phòng bếp')
INSERT [dbo].[NHOM]  VALUES ('', N'Sàn gỗ')
INSERT [dbo].[NHOM] VALUES ('', N'Đồ trang trí')
GO

INSERT [dbo].[SANPHAM]  VALUES ('', N'Bàn ngoài trời YO',100,5000000,5300000,N'Còn hàng','gr0001','CC0001')
INSERT [dbo].[SANPHAM] VALUES ('', N'Ghế ngoài trời Angela Alu',120,25000000,26000000,N'Còn hàng','gr0001','CC0001')
INSERT [dbo].[SANPHAM]  VALUES ('', N'Ghế ngoài trời Tuka boc vải Samoa SQB',110,3500000,3900000,N'Còn hàng','gr0001','CC0001')
INSERT [dbo].[SANPHAM]   VALUES ('', N'Ghế xếp Lorette Lagoon blue 570146',60,1000000,1300000,N'Còn hàng','gr0001','CC0001')
INSERT [dbo].[SANPHAM]  VALUES ('', N'Bàn bên Stulle CB5209-P E P7L/P97W',70,1500000,1800000,N'Còn hàng','gr0001','CC0001')
go
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2011-03-01' AS Date), N'NV0002',N'CC0001','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2022-11-01' AS Date),N'NV0002',N'CC0001','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2022-12-15' AS Date),N'NV0002',N'CC0001','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien])  VALUES ('',CAST(N'2023-02-19' AS Date),N'NV0002',N'CC0001','')
INSERT [dbo].[NHAPHANG]  ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2023-04-07' AS Date),N'NV0002',N'CC0001','')
go
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0001',N'NH0001',100,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0002',N'NH0001',40,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0003',N'NH0002',110,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0004',N'NH0002',10,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0005',N'NH0003',70,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0002',N'NH0003',70,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0003',N'NH0004',100,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0004',N'NH0004',50,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])  VALUES (N'sp0001',N'NH0005',30,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0005',N'NH0005',50,'')
GO


INSERT [dbo].[SANPHAM]  VALUES ('', N'Bảng treo chìa khóa',60,300000,350000,N'Còn hàng',N'gr0006','CC0004')
INSERT [dbo].[SANPHAM]  VALUES ('', N'Bình Aline xanh XS 16x16x16 23102J',80,300000,350000,N'Còn hàng',N'gr0006','CC0004')
INSERT [dbo].[SANPHAM]  VALUES ('', N'Bình con bướm 60464K',70,400000,440000,N'Còn hàng',N'gr0006','CC0004')
INSERT [dbo].[SANPHAM]  VALUES ('', N'Bộ hai chân nến Orche 10x30 29078J',100,400000,480000,N'Còn hàng',N'gr0006','CC0004')
INSERT [dbo].[SANPHAM] VALUES ('', N'Chậu hoa rừng gỗ nâu vừa 16x16x14 22775',50,900000,990000,N'Còn hàng',N'gr0006','CC0004')
go
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2023-04-01' AS Date), N'NV0002',N'CC0004','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2023-05-13' AS Date), N'NV0002',N'CC0004','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2023-06-05' AS Date), N'NV0007',N'CC0004','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2023-06-02' AS Date), N'NV0007',N'CC0004','')
INSERT [dbo].[NHAPHANG] ([MaNhapHang],[NgayLap],[MaNV],[MaNCC],[TongTien]) VALUES ('',CAST(N'2023-07-24' AS Date), N'NV0007',N'CC0004','')
go
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0006',N'NH0006',80,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])VALUES (N'sp0007',N'NH0006',20,'')
INSERT [dbo].[CTNHAPHANG]  ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])VALUES (N'sp0008',N'NH0007',70,'')
INSERT [dbo].[CTNHAPHANG]  ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])VALUES (N'sp0005',N'NH0007',40,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0006',N'NH0008',50,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0008',N'NH0008',40,'')
INSERT [dbo].[CTNHAPHANG]([MaSP], [MaNhapHang], [SoLuong],[ThanhTien])VALUES (N'sp0010',N'NH0009',50,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0007',N'NH0009',50,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0006',N'NH0010',25,'')
INSERT [dbo].[CTNHAPHANG] ([MaSP], [MaNhapHang], [SoLuong],[ThanhTien]) VALUES (N'sp0009',N'NH0010',55,'')
GO

INSERT INTO [dbo].[KHACHHANG]  VALUES ('', N'Lê Văn Mỹ', N'41 đường số 19, khu Phú Mỹ Hưng, P.Tân Phú, Q.7, TP.HCM', N'0838414567', N'LeVanMy@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG] VALUES ('', N'Phạm Việt Anh', N'1765A Đại Lộ Bình Dương, P.Hiệp An-Thủ Dầu 1, Tỉnh Bình Dương', N'0838414567', N'VietAnh@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Bùi Thị Quỳnh Anh', N'18 Lam Sơn, P.2, Q.Tân Bình, TP.HCM', N'0838414567', N'QunhAnh@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Vũ Đức Anh', N'G4-22/1 Nguyễn Thái Học, P.7, TP.Vũng Tàu', N'0838414567', N'ThaiHOc@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Phùng Linh Chi',  N'68 Hồ Xuân Hương, Q.Ngũ Hành Sơn.TP.Đà Nẵng', N'0838414567', N'LinhChi@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Dương Mỹ Dung', N'Đảo Hòn Tre, Vĩnh Nguyên, Nha Trang, tình Khánh Hòa', N'0838414567', N'MyDung@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Mạnh Duy', N'23 Lê Lợi, Q.1, TP.HCM', N'0838414567', N'ManhDuyy@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Phạm Phương Duy', N'Biên Hòa, Đồng Nai', N'0838414567', N'Phuongduy@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Thùy Dương', N'96 Võ Thị Sáu, P.Tân Định, Q.1, TP.HCM', N'0838414567', N'ThuyDuong@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Lưu Minh Hằng', N'25 Nguyễn Văn Linh, khu Phú Mỹ Hưng, Q.7, TP.HCM', N'0838414567', N'MinhHang@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Hữu Minh Hoàng', N'41 đường số 19, khu Phú Mỹ Hưng, P.Tân Phú, Q.7, TP.HCM', N'0838414567', N'MinhHoang@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Đức Huy',  N'92 Nguyễn Hữu Cảnh, P.22, Q.Bình Tân', N'0838414567', N'HuuCanh@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Vũ Đức Huy', N'P.Hòa Hải, Q.Ngũ Hành Sơn, TP.Đà Nẵng', N'0838414567', N'DucHuy@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Minh Khuê', N'23 Lê Lợi, Q.1,TP.HCM', N'0838414567', N'MinhKhue@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Nguyễn Phúc Lộc', N' đường số 2, Tăng Nhơn Phú B,TP.Thủ Đức', N'0838414567', N'PhucLoc@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Trịnh Xuân Minh', N'đường số 19, Tăng Nhơn Phú B,TP.Thủ Đức', N'0838414567', N'XuanTrinh@gmail.com', N'Nam')
INSERT INTO[dbo].[KHACHHANG]  VALUES ('', N'Hoàng Kim Ngân', N'120 Lê Văn Việt, TP.Thủ Đức', N'0838414567', N'KimNgan@gmail.com', N'Nam')


/******Hoa don - cthoadon- **/

INSERT [dbo].[DonDatHang]  VALUES ('',N'KH0001',CAST(N'2023-6-01' AS Date), N'Đang kiểm tra hàng','NV0003')
INSERT [dbo].[DonDatHang]  VALUES ('',N'KH0005',CAST(N'2023-5-07' AS Date), N'Đang chuẩn bị hàng','NV0004')
INSERT [dbo].[DonDatHang]  VALUES ('',N'KH0006',CAST(N'2023-4-14' AS Date), N'Đang chuẩn bị hàng','NV0005')
INSERT [dbo].[DonDatHang]  VALUES ('',N'KH0007',CAST(N'2023-3-21' AS Date), N'Đang kiểm tra hàng','NV0006')
INSERT [dbo].[DonDatHang]  VALUES ('',N'KH0008',CAST(N'2023-2-28' AS Date), N'Đang kiểm tra hàng','NV0005')
INSERT [dbo].[DonDatHang]  VALUES ('',N'KH0002',CAST(N'2023-1-05' AS Date), N'Đang chuẩn bị hàng','NV0003')
GO
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0001',N'sp0003',1)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0001',N'sp0002',2)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0002',N'sp0006',3)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0002',N'sp0004',4)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0003',N'sp0010',5)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0003',N'sp0006',5)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0004',N'sp0007',4)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0004',N'sp0003',3)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0005',N'sp0009',2)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0005',N'sp0010',1)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0006',N'sp0002',3)
INSERT [dbo].[CTDonDatHang] VALUES (N'DD0006',N'sp0008',4)
go

INSERT [dbo].[HOADON]  VALUES ('HD001',CAST(N'2023-5-10' AS Date),'',N'NV0003','DD0005')
INSERT [dbo].[HOADON]  VALUES ('HD002',CAST(N'2023-4-17' AS Date),'',N'NV0003','DD0001')
INSERT [dbo].[HOADON]  VALUES ('HD003',CAST(N'2023-3-24' AS Date),'',N'NV0004','DD0002')
INSERT [dbo].[HOADON]  VALUES ('HD004',CAST(N'2023-3-01' AS Date),'',N'NV0005','DD0003')
INSERT [dbo].[HOADON]  VALUES ('HD005',CAST(N'2023-1-08' AS Date),'',N'NV0007','DD0004')
go
INSERT [dbo].[CTHOADON] VALUES (N'HD0001','sp0001','','')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0001','sp0004','','')
INSERT [dbo].[CTHOADON]   VALUES (N'HD0002',N'sp0001',3,'')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0002',N'sp0004',4,'')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0003',N'sp0010',5,'')
INSERT [dbo].[CTHOADON]   VALUES (N'HD0003',N'sp0006',5,'')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0004',N'sp0007',4,'')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0004',N'sp0008',3,'')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0005',N'sp0009',2,'')
INSERT [dbo].[CTHOADON]  VALUES (N'HD0005',N'sp0010',1,'')
go

 -----VIEW

 ---ĐƠN ĐẶT HÀNG
	create view vw_DSDonDatHang
	as
	select MaDonDat, NgayLap, KhachHang.HoTenKH,NhanVien.HoTen, TinhTrang
	from (DonDatHang join NhanVien on DonDatHang.MaNV= NhanVien.MaNV) join KhachHang on DonDatHang.MaKH = KhachHang.MaKH


	create view vw_DSChiTietDonDatHang
	as
	select MaDonDat,SanPham.MaSP, TenSanPham,SoLuongDat 
	from CTDonDatHang join SanPham on CTDonDatHang.MaSP = SanPham.MaSP



---NHẬP HÀNG
	create view vw_DSNhapHang
	as
	select NhapHang.MaNhapHang, NhanVien.HoTen, TenNCC ,NgayLap, TongTien
	from  ((NhapHang inner join NhanVien on NhapHang.MaNV= NhanVien.MaNV) inner join NhaCungCap on NhapHang.MaNCC = NhaCungCap.MaNCC) 	 



	create view vw_DSCTNhapHang
	as
	select MaNhapHang, SanPham.MaSP, TenSanPham, SoLuong , ThanhTien
	from CTNhapHang join SanPham on CTNhapHang.MaSP = SanPham.MaSP
		
	
--- HOÁ ĐƠN
	create view vw_DSHoaDon
	as
	select MaHoaDon,HoaDon.NgayLap, TongTien ,NhanVien.HoTen,DonDatHang.MaDonDat, HoTenKH
	from  ((HoaDon inner join NhanVien on HoaDon.MaNV= NhanVien.MaNV) inner join DonDatHang 
			on HoaDon.MaDonDat = DonDatHang.MaDonDat)  inner join KhachHang on KhachHang.MaKH = DonDatHang.MaKH

	create view vw_DSCTHoaDon
	as
	select MaHoaDon,CTDonDatHang.MaSP,SanPham.TenSanPham,  CTDonDatHang.SoLuongDat, ThanhTien
	from  CT

-- Tạo trigger kiểm tra ràng buộc ngoài table

	CREATE TRIGGER tg_AutoUpdateThanhTien
	ON CTNhapHang
	AFTER INSERT, update
	AS
	BEGIN
		UPDATE CTNhapHang
		SET ThanhTien = CTNhapHang.SoLuong * GiaNhap
		FROM SanPham INNER JOIN CTNhapHang  ON SanPham.MaSP = CTNhapHang.MaSP 
	END;



--- Cập nhật giá trị Tổng tiền trong bảng NhapHang
	create trigger tg_AutoUpdateTongTien1111
	on CTNhapHang
	after insert, update
	as
		UPDATE NhapHang
		SET NhapHang.TongTien = ctt. TongTien1
		FROM NhapHang JOIN (
						SELECT CTNhapHang.MaNhapHang, SUM(ThanhTien) AS TongTien1
						FROM NhapHang inner JOIN CTNhapHang  ON NhapHang.MaNhapHang = CTNhapHang.MaNhapHang
						GROUP BY CTNhapHang.MaNhapHang
						) ctt ON NhapHang.MaNhapHang = ctt.MaNhapHang





		-- Cập nhật sản phẩm trong CTHoaDon sau khi thêm hoá đơn
		create trigger tg_GiatrichoSanPhamvaSoLuongTrongCTHoaDon 
			on HoaDon
			after insert, update
			as

					INSERT INTO CTHoaDon ( MaHoaDon, MaSP, SoLuong, ThanhTien) 
					SELECT MaHoaDon, CTDonDatHang.MaSP, CTDonDatHang.SoLuongDat, CTDonDatHang.SoLuongDat* SanPham.GiaBan
					FROM ((inserted join CTDonDatHang on CTDonDatHang.MaDonDat = inserted.MaDonDat)
						join SanPham on SanPham.MaSP = CTDonDatHang.MaSP) 
					where CTDonDatHang.MaDonDat = inserted.MaDonDat

			
					UPDATE HoaDon
					SET TongTien = TongTien1
					FROM HoaDon JOIN (
						SELECT HoaDon.MaHoaDon, sum(ThanhTien) as TongTien1
						FROM HoaDon join CTHoaDon on HoaDon.MaHoaDon = CTHoaDon.MaHoaDon
						GROUP BY HoaDon.MaHoaDon
						) ctt ON HoaDon.MaHoaDon = ctt.MaHoaDon

			


--Cập nhật số lượng tồn khi mặt hàng đc bán ra

	create trigger tg_CapNhatSLTon
on CTDonDatHang
for insert, update
as
	update SanPham
	set SoLuongTon=SoLuongTon-inserted.SoLuongDat
	from SanPham join inserted on SanPham.MaSP=inserted.MaSP

	drop trigger tg_CapNhatSLTon 


--Cập nhật số lượng tồn khi mặt hàng đc nhập

	create trigger tg_CapNhatSLTonNhap
on CTNhapHang
for insert, update
as
	update SanPham
	set SoLuongTon=SoLuongTon+ inserted.SoLuong
	from SanPham join inserted on SanPham.MaSP=inserted.MaSP