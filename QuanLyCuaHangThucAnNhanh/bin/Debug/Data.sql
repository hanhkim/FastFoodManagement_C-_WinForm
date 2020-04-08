create database QUAN_LY_CUA_HANG_THUC_AN_NHANH01
GO
USE QUAN_LY_CUA_HANG_THUC_AN_NHANH01
GO

--
CREATE TABLE DANGNHAP
(
	MANV int identity primary key,
	TENDANGNHAP NVARCHAR(50) NOT NULL,
	MATKHAU NVARCHAR(50) NOT NULL,
	TENNV NVARCHAR(50),
	CHUCVU INT DEFAULT 0,	-- 0 QUẢN LÝ; 1 NHÂN VIÊN
	
)
GO

create table NHANVIEN
(
	MANV INT NOT NULL,
	TENNV NVARCHAR(50) NOT NULL,	
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5), -- NAM/ NỮ
	CHUCVU INT DEFAULT 0, -- 0 QUAN LY
	DIACHI NVARCHAR(100),
	PRIMARY KEY (MANV)
)
GO
--
CREATE TABLE LOAISP
(
	MALOAISP CHAR(5),-- FL001; DL001;
	TENLOAISP NVARCHAR(50)
	CONSTRAINT PK_LOAISP
	PRIMARY KEY(MALOAISP)
)
GO
CREATE TABLE SANPHAM
(
	MASP CHAR(4) NOT NULL, -- F001 HOẶC D001 (F: FOOD; D: DRINK)
	TENSP NVARCHAR(50) NOT NULL,
	DONGIA INT DEFAULT 1000,
	MALOAISP	CHAR(5),-- FL001; DL001
	CONSTRAINT PK_SANPHAM
	PRIMARY KEY (MASP)
)
GO
--                                  
CREATE TABLE TABLEINFO
(
	MABAN CHAR(4),	--TRONG NHA: H; TANG: F, VIP: V + 001;
	VITRI NVARCHAR(20),
	TENBAN NVARCHAR(10),
	TINHTRANG NVARCHAR(10), -- TRỐNG; CÓ KHÁCH
	CONSTRAINT PK_TABLEINFO
	PRIMARY KEY (MABAN,VITRI)
)
GO
--
CREATE TABLE HOADON
(
	MAHOADON CHAR(5),
	CHECKIN DATETIME default getdate(),
	CHECKOUT DATETIME null,
	MABAN CHAR(4),
	VITRI NVARCHAR(20),
	TINHTRANG NVARCHAR(20), -- ĐÃ THANH TOÁN, CHƯA THANH TOÁN
	GIAMGIA int default 0
	CONSTRAINT PK_HOADON
	PRIMARY KEY (MAHOADON)
)
GO
--
CREATE TABLE THONGTINCHITIETHOADON
(
	MActHOADON CHAR(5),
	MAHOADON CHAR(5),
	MASP CHAR(4),
	SOLUONG INT,
	CONSTRAINT PK_THONGTINCHITIETHOADON
	PRIMARY KEY (MActHOADON)
)
GO
--
create table KHACHHANG
(
	MaKH int identity primary key,
	TenKH nvarchar(50),
	SDT char(11),
	MAHOADON char(5)
)


GO
insert DANGNHAP(TENDANGNHAP, MATKHAU, TENNV, CHUCVU)
VALUES ('admin','admin','Admin',0),
		('user','pass','User',1),
		('nguyenkhanhhoa','khanhhoaLK',N'Nguyễn Khánh Hòa',0),
		('chuminhduc','chuminhduc',N'Chu Minh Đức',1),
		('lethikimhanh','lethikimhanh',N'Lê Thị Kim Hạnh',0),
		('nguyenvanhoan','nguyenvanhoan',N'Nguyễn Văn Hoàn',0),
		('levanhung','levanhung',N'Lê Văn Hưng',1)
-- nhân viên--
insert NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, DIACHI)
values	(03,N'Nguyễn Khánh Hòa', '04/05/1997', 'Nam', 0, 'TP HCM'),
		(04,N'Chu Minh Đức', '02/09/1997', 'Nam', 1, 'TP HCM'),
		(05,N'Lê Thị Kim Hạnh', '7/05/1997', N'Nữ', 0, 'TP HCM'),
		(06,N'Nguyễn Văn Hoàn', '11/05/1997', 'Nam', 0, 'TP HCM'),
		(07,N'NLê Văn Hưng', '1/03/1997', 'Nam', 1, 'TP HCM')

-- bàn ăn --
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F001', N'Tầng một', N'Bàn 1', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F002', N'Tầng một', N'Bàn 2', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F003', N'Tầng một', N'Bàn 3', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F004', N'Tầng một', N'Bàn 4', N'Trống')

insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F005', N'Tầng hai', N'Bàn 1', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F006', N'Tầng hai', N'Bàn 2', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F007', N'Tầng hai', N'Bàn 3', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'F008', N'Tầng hai', N'Bàn 4', N'Trống')

insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'H001', N'Trong nhà', N'Bàn 1', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'H002', N'Trong nhà', N'Bàn 2', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'H003', N'Trong nhà', N'Bàn 3', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'H004', N'Trong nhà', N'Bàn 4', N'Trống')

insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'V001', N'Phòng Vip', N'Bàn 1', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'V002', N'Phòng Vip', N'Bàn 2', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'V003', N'Phòng Vip', N'Bàn 3', N'Trống')
insert into TABLEINFO (MABAN, VITRI, TENBAN, TINHTRANG) values( 'V004', N'Phòng Vip', N'Bàn 4', N'Trống')

-- loại sản phẩm --

insert into LOAISP (MALOAISP, TENLOAISP) values ('DL001', N'Nước có gas')
insert into LOAISP (MALOAISP, TENLOAISP) values ('DL002', N'Nước có cồn')
insert into LOAISP (MALOAISP, TENLOAISP) values ('DL003', N'Nước ép trái cây')

insert into LOAISP (MALOAISP, TENLOAISP) values ('FL001', N'Món gà')
insert into LOAISP (MALOAISP, TENLOAISP) values ('FL002', N'Pizza')
insert into LOAISP (MALOAISP, TENLOAISP) values ('FL003', N'Bánh Biscuit')
insert into LOAISP (MALOAISP, TENLOAISP) values ('FL004', N'Kem')
insert into LOAISP (MALOAISP, TENLOAISP) values ('FL005', N'Khoai Tây')
insert into LOAISP (MALOAISP, TENLOAISP) values ('FL006', N'Snack')

-- sản phẩm --
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D001', N'7 up',10000,'DL001')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D002', N'Coca Cola',10000,'DL001')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D003', N'Strong bowl',10000,'DL001')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D004', N'Sprite',10000,'DL001')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D005', N'String Dâu',10000,'DL001')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D006', N'Heineken',18000,'DL002')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D007', N'Rượu Vang Đỏ',170000,'DL002')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D008', N'Rượu Vang Trắng',79000,'DL002')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('D009', N'Rượu Vang Đà lạt',110000,'DL002')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F017', N'Dâu',18000,'DL003')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F018', N'Bơ',16000,'DL003')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F019', N'Dừa',18000,'DL003')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F020', N'Sam - Bô',18000,'DL003')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F010', N'Gà rán',35000,'FL001')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F011', N'Gà xốt me',35000,'FL001')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F012', N'Khô gà lá chanh',35000,'FL001')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F013', N'Pizza hải sản',49000,'FL002')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F014', N'Pizza xúc xích',60000,'FL002')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F015', N'Pizza thập cẩm',60000,'FL002')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F016', N'Pizza bò hầm',60000,'FL002')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F021', N'Biscuit Bơ',8000,'FL003')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F022', N'Biscuit Dâu',8000,'FL003')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F023', N'Bánh xu kem sữa',8000,'FL003')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F024', N'Khoai Tây Chiên',15000,'FL005')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F025', N'Khoai Tây lắc',15000,'FL005')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F026', N'Khoai Tây nướng',15000,'FL005')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F027', N'Snack bắp',6000,'FL006')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F028', N'Snack khoai tây',6000,'FL006')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F029', N'Snack phô mai',6000,'FL006')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F030', N'Snack mực',6000,'FL006')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F031', N'Snack cà chua',6000,'FL006')

insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F032', N'Kem đậu xanh',12000,'FL004')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F033', N'Kem xôi',16000,'FL004')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F034', N'Kem sầu riêng',18000,'FL004')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F035', N'Kem bốn mùa',16000,'FL004')
insert into SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values ('F036', N'Kem Dâu',16000,'FL004')


-- load table lên flp

--
--thông tin hóa đơn

	-- Proc cho nút thêm món ăn. bài 11
GO
create Proc USP_InsertBill
@maHD char(5), @MABAN char(4), @VITRI NVARCHAR(20)
as
begin
	declare  @tinhtrang nvarchar(20) =N'Chưa thanh toán'
	insert HOADON(MAHOADON, CHECKIN, CHECKOUT, MABAN, VITRI, TINHTRANG,GIAMGIA)
	VALUES (@maHD, GETDATE(), null, @MABAN,	@VITRI,	@tinhtrang,0)
END
GO

Create Proc USP_InsertBillInfo
@CTmaHD char(5), @MAHOADON char(5), @MASP char(4) , @SOLUONG int
as
begin
	DECLARE @IsExitBillInfo char(5)
	DECLARE @FoodCount int =1

	select 
			@IsExitBillInfo = MActHOADON, 
			@FoodCount = THONGTINCHITIETHOADON.SOLUONG 
			FROM THONGTINCHITIETHOADON 
			WHERE MAHOADON = @MAHOADON AND MASP = @MASP

	IF (@IsExitBillInfo is not null)
	BEGIN
		DECLARE @NEWCOUNT INT = @FoodCount + @SOLUONG
		
		IF(@NEWCOUNT >0)
			UPDATE THONGTINCHITIETHOADON SET SOLUONG = @FoodCount + @SOLUONG where MASP = @MASP
		ELSE
			DELETE THONGTINCHITIETHOADON WHERE MAHOADON = @MAHOADON AND MASP =@MASP
	
	END

	ELSE
	
	BEGIN
		insert THONGTINCHITIETHOADON
			(MActHOADON,
	MAHOADON ,
	MASP ,
	SOLUONG)
		VALUES 
		(@CTmaHD, @MAHOADON, @MASP, @SOLUONG)
	END
	
END
GO




----------------
-- trigger
------------------ cập nhật trạng thái cho bàn ăn. CÓ NGƯỜI hay TRỐNG

create trigger UTG_UpdateTHONGTINCHITIETHOADON
on THONGTINCHITIETHOADON for insert, update
as
begin
	DECLARE @MAHD CHAR(5)
	SELECT @MAHD = MAHOADON FROM inserted
	DECLARE @MABAN CHAR(4)
	DECLARE @VITRI NVARCHAR(20)
	SELECT @MABAN = MABAN, @VITRI=VITRI  FROM HOADON WHERE MAHOADON = @MAHD AND CHECKOUT is null

	UPDATE TABLEINFO SET TINHTRANG = N'Có người' where @MABAN = MABAN and @VITRI=VITRI
END
GO
----
create TRIGGER UTG_UPDATEHOADON
ON HOADON FOR UPDATE
AS
BEGIN
	DECLARE @MAHD CHAR(5)
	SELECT @MAHD = MAHOADON FROM inserted
	DECLARE @MABAN CHAR(4)
	DECLARE @VITRI NVARCHAR(20)
	SELECT @MABAN = MABAN, @VITRI = VITRI FROM HOADON WHERE MAHOADON= @MAHD

	DECLARE @COUNT INT =0
	SELECT @COUNT = COUNT(*) FROM HOADON WHERE MABAN=@MABAN AND VITRI=@VITRI AND CHECKOUT is null

	if(@COUNT = 0)
	UPDATE TABLEINFO SET TINHTRANG =N'Trống' where @MABAN=MABAN and @VITRI=VITRI
END
GO
--nãy m chưa tạo csdl. thì mình quét server rồi tạo database ròi mà.

GO
create proc USP_loadTable
as select * from TABLEINFO
exec dbo.USP_loadTable
GO
