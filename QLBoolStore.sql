CREATE DATABASE QLBOOKSTORE
USE QLBOOKSTORE
GO

ALTER DATABASE QLBOOKSTORE
COLLATE Vietnamese_CI_AS;

/***********/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[TACGIA](
    [MaTG] INT IDENTITY(1,1) ,
	[TenTG]  nvarchar(255) NOT NULL,
	[DiaChi] nvarchar(255) NULL,
	[TieuSu] text NULL,
	[DienThoai] int NULL,

 CONSTRAINT [PK_TACGIA] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[VIETSACH](
	[MaTG] INT not null,
	[Masach]  int not  NULL,
	[Vaitro] nvarchar(255) NULL,
	[Vitri] text null,

 CONSTRAINT [PK_VIETSACH] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC,
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[SACH](
    [Masach] INT IDENTITY(1,1) ,
	[Tensach] nvarchar(100) not NULL,
	[Giaban] money null,
	[Mota] text null,
	[Anhbia] nvarchar(150) NULL,
	[Ngaycapnhap] date null,
	[Soluongton] int null,
	[MaCD] int  null,
	[MaNXB] int NULL,

 CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
(
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[CHITIETDONHANG](
    [MaDonHang]int  not NULL,
	[MaSach] int not NULL,
	[Soluong] int null,
	[Dongia] money  null,
 CONSTRAINT [PK_CHITIETDONHANG] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[CHUDE](
	[MaCD] int IDENTITY(1,1) ,
	[TenChuDe] nvarchar(255) NULL,

 CONSTRAINT [PK_CHUDE] PRIMARY KEY CLUSTERED 
(
	[MaCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[NHAXUATBAN](
	[MaNXB] int IDENTITY(1,1) ,
	[TenNXB] nvarchar(100) NULL,
	[DiaChi] nvarchar(255) NULL,
	[DienThoai] int NULL,

 CONSTRAINT [PK_NHAXUATBAN] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********/
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] INT IDENTITY(1,1) ,
	[HoTen] nvarchar(255) NULL,
	[TaiKhoan] nvarchar(100) NOT NULL,
    [MatKhau] nvarchar(100) NOT null,
	[Email] nvarchar(100) null,
    [DiaChiKH] nvarchar(255) null,
    [DienThoaiKH] int null,
    [NgaySinh] date null,

 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO


CREATE TABLE [dbo].[DONDATHANG](
	[MaDonHang] INT IDENTITY(1,1) ,
	[Dathanhtoan] nvarchar(255) NULL,
	[Tinhtranggiaohang] nvarchar(100) NOT NULL,
    [Ngaydat] nvarchar(100) NOT null,
	[Ngaygiao] nvarchar(100) null,
    [MaKH] int not null,

 CONSTRAINT [PK_DONDATHANG] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
 

 CREATE TABLE ADMIN (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50),
    Password NVARCHAR(50),
    HoTen NVARCHAR(100)
);

/*************************/
ALTER TABLE dbo.VIETSACH
ADD CONSTRAINT FK_VIETSACH_TACGIA FOREIGN KEY (MaTG)
REFERENCES dbo.TACGIA (MaTG);

ALTER TABLE dbo.VIETSACH
ADD CONSTRAINT FK_VIETSACH_SACH FOREIGN KEY (Masach)
REFERENCES dbo.SACH (Masach);

/**********/


ALTER TABLE dbo.SACH
ADD CONSTRAINT FK_SACH_NHAXUATBAN FOREIGN KEY (MaNXB)
REFERENCES dbo.NHAXUATBAN (MaNXB);


ALTER TABLE dbo.SACH
ADD CONSTRAINT FK_SACH_CHUDE FOREIGN KEY (MaCD)
REFERENCES dbo.CHUDE (MaCD);

/****************/
ALTER TABLE dbo.CHITIETDONHANG
ADD CONSTRAINT FK_CHITIETDONHANG_SACH FOREIGN KEY (Masach)
REFERENCES dbo.SACH (Masach);




ALTER TABLE dbo.CHITIETDONHANG
ADD CONSTRAINT FK_CHITIETDONHANG_DONDATHANG FOREIGN KEY (MaDonHang)
REFERENCES dbo.DONDATHANG (MaDonHang);

/*************/

ALTER TABLE dbo.DONDATHANG
ADD CONSTRAINT FK_DONDATHANG_KHACHHANG FOREIGN KEY (MaKH)
REFERENCES dbo.KHACHHANG (MaKH);




/*************/

INSERT INTO ADMIN (Username, Password, HoTen) VALUES
('admin1', 'password1', 'admin1m'),
('admin2', 'password2', 'admin2'),
('admin3', 'password3', 'admin3');


INSERT INTO TACGIA (TenTG, DiaChi, TieuSu, DienThoai)
VALUES ('Nguyễn Nhật Ánh', 'Hà Nội', 'Sinh năm 1955, là một trong những nhà văn nổi tiếng của Việt Nam', 123456789),
       ('Trịnh Thanh Thủy', 'Hồ Chí Minh', 'Tác giả của loạt truyện Cô gái đến từ hôm qua', 987654321),
       ('Nguyễn Xuân Phúc', 'Đà Nẵng', 'Sáng tác loạt sách về lịch sử Việt Nam', 456123789);


 INSERT INTO CHUDE (TenChuDe)
VALUES ('Phiêu lưu'),
       ('Tình cảm'),
       ('Lịch sử');




INSERT INTO KHACHHANG (HoTen, TaiKhoan, MatKhau, Email, DiaChiKH, DienThoaiKH, NgaySinh)
VALUES ('Nguyễn Văn A', 'nguyenvana', '123456', 'nguyenvana@example.com', 'Hà Nội', 123456789, '1990-01-01'),
       ('Trần Thị B', 'tranthib', 'abcdef', 'tranthib@example.com', 'Hồ Chí Minh', 987654321, '1995-05-05'),
       ('Lê Văn C', 'levanc', 'xyz123', 'levanc@example.com', 'Đà Nẵng', 456123789, '1988-10-10');




	   INSERT INTO DONDATHANG (Dathanhtoan, Tinhtranggiaohang, Ngaydat, Ngaygiao, MaKH)
VALUES (N'Đã thanh toán', N'Chưa giao hàng', '2024-03-21', NULL, 1),
       (N'Chưa thanh toán', 'Đã giao hàng', '2024-03-20', '2024-03-25', 2),
       (N'Đã thanh toán', N'Đã giao hàng', '2024-03-19', '2024-03-24', 3);



	   INSERT INTO NHAXUATBAN (TenNXB, DiaChi, DienThoai)
VALUES ('Nhà Xuất Bản Kim Đồng', 'Hà Nội', 123456789),
       ('Nhà Xuất Bản Văn Học', 'Hồ Chí Minh', 987654321),
       ('Nhà Xuất Bản Đại Học Quốc Gia', 'Đà Nẵng', 456123789);



	   INSERT INTO SACH (Tensach, Giaban, Mota, Anhbia, Ngaycapnhap, Soluongton, MaCD, MaNXB)
VALUES (N'Chạy trốn tìm ánh sáng', 25000, N'Cuốn sách kể về cuộc phiêu lưu tìm kiếm ý nghĩa cuộc sống', 'anh_bia1.jpg', '2024-03-21', 100, 1, 1),
       (N'Cô gái đến từ hôm qua', 35000, N'Truyện kể về cuộc sống của một cô gái từ quá khứ', 'anh_bia2.jpg', '2024-03-21', 80, 2, 2),
       (N'Lịch sử Việt Nam', 45000, N'Sách tóm tắt lịch sử Việt Nam từ thời cổ đại đến hiện đại', 'anh_bia3.jpg', '2024-03-21', 120, 3, 3);


	INSERT INTO VIETSACH (MaTG,Masach, Vaitro, Vitri)
	VALUES (1,1, N'Tác giả chính', N'Tác giả chính'),
	 (2,2, N'Tác giả chính', N'Tác giả chính'),
	 (1,3, N'Tác giả chính', N'Tác giả chính');



ALTER DATABASE QLBOOKSTORE
COLLATE Vietnamese_CI_AS;
