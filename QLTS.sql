USE [master]
GO
/****** Object:  Database [QLTS]    Script Date: 2021-01-11 10:17:03 PM ******/
CREATE DATABASE [QLTS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLTS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLTS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLTS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLTS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLTS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLTS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLTS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLTS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLTS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLTS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLTS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLTS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLTS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLTS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLTS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLTS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLTS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLTS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLTS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLTS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLTS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLTS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLTS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLTS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLTS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLTS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLTS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLTS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLTS] SET RECOVERY FULL 
GO
ALTER DATABASE [QLTS] SET  MULTI_USER 
GO
ALTER DATABASE [QLTS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLTS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLTS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLTS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLTS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLTS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLTS', N'ON'
GO
ALTER DATABASE [QLTS] SET QUERY_STORE = OFF
GO
USE [QLTS]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 2021-01-11 10:17:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[MSSV] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](200) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[MSSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phat]    Script Date: 2021-01-11 10:17:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phat](
	[MaPhat] [int] IDENTITY(1,1) NOT NULL,
	[MaTra] [int] NULL,
	[LyDoPhat] [nvarchar](150) NULL,
	[HTXuLy] [nvarchar](200) NULL,
	[MucPhat] [int] NULL,
 CONSTRAINT [PK_Phat] PRIMARY KEY CLUSTERED 
(
	[MaPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanlyTra]    Script Date: 2021-01-11 10:17:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanlyTra](
	[MaTra] [int] IDENTITY(1,1) NOT NULL,
	[MSSV] [nvarchar](50) NULL,
	[MaSach] [nvarchar](50) NULL,
	[NgayMuon] [date] NULL,
	[HanTra] [int] NULL,
	[NgayTra] [date] NULL,
	[TrangThai] [nvarchar](10) NULL,
 CONSTRAINT [PK_QuanlyTra] PRIMARY KEY CLUSTERED 
(
	[MaTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 2021-01-11 10:17:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nvarchar](50) NOT NULL,
	[TenSach] [nvarchar](200) NULL,
	[TacGia] [nvarchar](200) NULL,
	[TheLoai] [nvarchar](150) NULL,
	[NhaXuatBan] [nvarchar](100) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 2021-01-11 10:17:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800100', N'Nguyễn Ngọc Minh', CAST(N'2011-12-06' AS Date), N'Nam')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800101', N'Ngô Trọng Thành', CAST(N'2011-06-06' AS Date), N'Nam')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800102', N'Nguyễn Khánh Vân', CAST(N'2011-12-06' AS Date), N'Nữ')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800103', N'Trịnh Thị  Yến Nhi', CAST(N'2011-10-06' AS Date), N'Nữ')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800104', N'Trinh Thị Thương', CAST(N'2020-12-08' AS Date), N'Nam')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800105', N'Ngô Minh Tính', CAST(N'2000-02-13' AS Date), N'Nam')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800106', N'Trần Trọng Bình', CAST(N'2000-09-19' AS Date), N'Nam')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800107', N'Lý Cẩm Vân', CAST(N'2000-06-29' AS Date), N'Nữ')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800108', N'Trần Minh Bình', CAST(N'2000-02-17' AS Date), N'Nam')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800109', N'Trần Minh Thư', CAST(N'2000-03-18' AS Date), N'Nữ')
INSERT [dbo].[DocGia] ([MSSV], [HoTen], [NgaySinh], [GioiTinh]) VALUES (N'1800123', N'Trần Thị Yến Nhi', CAST(N'2020-12-08' AS Date), N'Nữ')
GO
SET IDENTITY_INSERT [dbo].[Phat] ON 

INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (1, 2, N'Quá Hạn', N'10%*2', 3)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (2, 3, N'Quá Hạn', N'10%*2', 3)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (3, 6, N'Làm Rách Sách', N'70%', 2)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (4, 9, N'Làm Mất Sách', N'100%', 1)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (5, 11, N'Quá Hạn', N'10% *5', 3)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (6, 12, N'Quá Hạn', N'10% *5', 3)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (7, 14, N'hhh', N'hhh', 3)
INSERT [dbo].[Phat] ([MaPhat], [MaTra], [LyDoPhat], [HTXuLy], [MucPhat]) VALUES (8, 16, N'Quas han', N'70%', 2)
SET IDENTITY_INSERT [dbo].[Phat] OFF
GO
SET IDENTITY_INSERT [dbo].[QuanlyTra] ON 

INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (1, N'1800616', N's0002', CAST(N'2020-01-01' AS Date), 10, CAST(N'2020-01-09' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (2, N'1800102', N's0004', CAST(N'2020-01-12' AS Date), 10, CAST(N'2020-01-24' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (3, N'1800103', N's0001', CAST(N'2020-02-12' AS Date), 10, CAST(N'2020-02-24' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (4, N'1800104', N's0017', CAST(N'2020-02-26' AS Date), 10, CAST(N'2021-03-05' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (5, N'1800105', N's0013', CAST(N'2020-03-06' AS Date), 10, CAST(N'2020-03-12' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (6, N'1800106', N's0018', CAST(N'2020-03-18' AS Date), 10, CAST(N'2020-03-25' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (7, N'1800107', N's0019', CAST(N'2020-04-02' AS Date), 10, CAST(N'2020-04-07' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (8, N'1800616', N's0003', CAST(N'2020-04-27' AS Date), 10, CAST(N'2020-05-05' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (9, N'1800100', N's0007', CAST(N'2020-05-11' AS Date), 10, CAST(N'2020-05-20' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (10, N'18001102', N's0009', CAST(N'2020-06-05' AS Date), 10, CAST(N'2020-06-14' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (11, N'1800104', N's0011', CAST(N'2020-06-24' AS Date), 10, CAST(N'2020-07-15' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (12, N'1800103', N's0014', CAST(N'2020-07-12' AS Date), 10, CAST(N'2020-07-25' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (13, N'1800105', N's0012', CAST(N'2020-08-12' AS Date), 10, CAST(N'2020-08-27' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (14, N'1800104', N's0014', CAST(N'2020-08-19' AS Date), 10, CAST(N'2020-12-29' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (15, N'1800101', N's0013', CAST(N'2020-10-14' AS Date), 10, CAST(N'2020-12-25' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (16, N'1800102', N's0018', CAST(N'2020-11-25' AS Date), 10, CAST(N'2021-01-05' AS Date), N'đã trả')
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (17, N'1800107', N's0006', CAST(N'2020-12-01' AS Date), 10, NULL, NULL)
INSERT [dbo].[QuanlyTra] ([MaTra], [MSSV], [MaSach], [NgayMuon], [HanTra], [NgayTra], [TrangThai]) VALUES (18, N'1800108', N's0014', CAST(N'2020-12-10' AS Date), 10, NULL, NULL)
SET IDENTITY_INSERT [dbo].[QuanlyTra] OFF
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0001', N'Mắt Biếc', N'Nguyễn Nhật Ánh', N'Tiểu Thuyết Ngôn Tình', N'NXB Trẻ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0002', N'Tôi thấy hoa vàng trên cỏ xanh', N'Nguyễn Nhật Ánh', N'Văn Học Việt Nam', N'NXB Trẻ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0003', N'Đắc Nhân Tâm', N'Dale Carnegie', N'Tự lực', N'NXB Tổng hợp TP.HCM')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0004', N'Tắt Đèn', N'Ngô Tất Tố', N'Văn Học Việt Nam', N'NXB Văn Học')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0005', N'Nhà Giả Kim', N'Paulo Coelho', N'Tiểu Thuyết', N'NXB Văn Học')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0006', N'Người Giàu Có Nhất Thành Babylon', N'George Samuel Clason', N'Tài chính cá nhân', N'NXB Tổng hợp TP.HCM')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0007', N'Cha Giàu Cha Nghèo', N'Sharon Lechter, Robert Kiyosaki', N'Tự Lực', N'NXB Tổng hợp TP.HCM')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0008', N'Lược Sử Loài Người', N'Yuval Harari', N'Văn Học
', N'NXB Tri Thức')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0009', N'Bất Phụ Như Lai Bất Phụ Khanh', N'Chương Xuân Di', N'Tiểu Thuyết Ngôn Tình', N'NXB Văn Học')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0010', N'Khéo Ăn Nó Sẽ Có Được Thiên Hạ', N'Trác Nhã
', N'Kỹ năng sống', N'NXB Văn Học
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0011', N'Bí Mật Phan Thiên Ân', N'Alan Phan', N'Tài chính cá nhân', N'NXB Thế Giới
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0012', N'Đời Ngắn Đừng Ngủ Dài', N'Robin Sharma', N'Tự Lực', N'NXB Trẻ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0013', N'Binh Pháp Tôn Tử', N'Tôn Vũ', N'Lịch Sử - Chính Trị', N'NXB Dân Trí')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0014', N'Nếu Tôi Biết Được Khi Còn 20', N'Tina Seelig', N'Tự Lực', N'NXB Trẻ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0015', N'Trên Đường Băng', N'Tony Buổi Sáng', N'Kỹ năng sống', N'NXB Trẻ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0016', N'Cà Phê Cùng Tony', N'Tony Buổi Sáng', N'Kỹ năng sống', N'NXB Trẻ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0017', N'Sức Mạnh Của Tĩnh Tâm', N'Hải Hoa', N'Kỹ năng sống', N'NXB Phụ Nữ
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0018', N'Quẳng gánh lo đi và vui sống', N'Dale Carnegie', N'Kỹ năng sống', N'NXB Tri Thức')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0019', N'Hạt Giống Tâm Hồn', N'Nhiều Tác Gia', N'Văn Học', N'NXB Tổng hợp TP.HCM')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0020', N'Thánh Kinh Dưỡng Da', N'Chizu Saeki', N'Làm Đẹp', N'NXB Thế Giới
')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan]) VALUES (N's0021', N'Hành trình về phương đông:', N'Dr. Blair T. Spalding', N'Văn Hóa - Tôn Giáo', N'NXB Dân Trí')
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TaiKhoan], [MatKhau], [Role]) VALUES (1, N'admin', N'123456', N'admin')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TaiKhoan], [MatKhau], [Role]) VALUES (2, N'tt', N'123456', N'thủ thư')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[Phat]  WITH CHECK ADD  CONSTRAINT [FK_Phat_QuanlyTra] FOREIGN KEY([MaTra])
REFERENCES [dbo].[QuanlyTra] ([MaTra])
GO
ALTER TABLE [dbo].[Phat] CHECK CONSTRAINT [FK_Phat_QuanlyTra]
GO
ALTER TABLE [dbo].[QuanlyTra]  WITH CHECK ADD  CONSTRAINT [FK_QuanlyTra_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[QuanlyTra] CHECK CONSTRAINT [FK_QuanlyTra_Sach]
GO
USE [master]
GO
ALTER DATABASE [QLTS] SET  READ_WRITE 
GO
