USE [master]
GO
/****** Object:  Database [cuahangdoannhanh]    Script Date: 11/8/2024 2:59:45 PM ******/
CREATE DATABASE [cuahangdoannhanh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cuahangdoannhanh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\cuahangdoannhanh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cuahangdoannhanh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\cuahangdoannhanh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cuahangdoannhanh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cuahangdoannhanh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET ARITHABORT OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [cuahangdoannhanh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cuahangdoannhanh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cuahangdoannhanh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [cuahangdoannhanh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cuahangdoannhanh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cuahangdoannhanh] SET  MULTI_USER 
GO
ALTER DATABASE [cuahangdoannhanh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cuahangdoannhanh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cuahangdoannhanh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cuahangdoannhanh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [cuahangdoannhanh]
GO
/****** Object:  Table [dbo].[CHI_TIET_DON_HANG]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_DON_HANG](
	[MaDH] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DANH_MUC]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANH_MUC](
	[MaDM] [int] NOT NULL,
	[TenDM] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DON_HANG]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DON_HANG](
	[MaDH] [int] NOT NULL,
	[TenDH] [nvarchar](100) NULL,
	[Ngay_dat] [nvarchar](10) NOT NULL,
	[MaKH] [int] NULL,
	[Soluong] [int] NULL,
	[Ten_KH] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[Dia_chi] [nvarchar](200) NULL,
	[Email] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MaKH] [int] NOT NULL,
	[Ten_KH] [nvarchar](100) NULL,
	[SDT] [int] NOT NULL,
	[Email] [varchar](32) NULL,
	[Dia_chi] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUAN_TRI]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUAN_TRI](
	[Tai_khoan] [varchar](50) NOT NULL,
	[Mat_khau] [varchar](32) NOT NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Tai_khoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SAN_PHAM]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAN_PHAM](
	[MaSP] [int] NOT NULL,
	[TenSP] [nvarchar](100) NULL,
	[Gia] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Mota] [nvarchar](100) NOT NULL,
	[Hinhanh] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THANH_TOAN]    Script Date: 11/8/2024 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THANH_TOAN](
	[MaTT] [int] NOT NULL,
	[PhuongThuc] [nvarchar](100) NULL,
	[Trangthai] [tinyint] NOT NULL,
	[MaDH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHI_TIET_DON_HANG] ([MaDH], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 2, 2, 20000, 40000)
INSERT [dbo].[CHI_TIET_DON_HANG] ([MaDH], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 3, 1, 90000, 90000)
INSERT [dbo].[CHI_TIET_DON_HANG] ([MaDH], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 123, 2, 100000, 200000)
GO
INSERT [dbo].[DANH_MUC] ([MaDM], [TenDM]) VALUES (32123, N'thit ga nuong')
GO
INSERT [dbo].[DON_HANG] ([MaDH], [TenDH], [Ngay_dat], [MaKH], [Soluong], [Ten_KH], [SDT], [Dia_chi], [Email]) VALUES (1, NULL, N'2024-11-06', NULL, NULL, N'duong', 972471680, N'ha noi', NULL)
INSERT [dbo].[DON_HANG] ([MaDH], [TenDH], [Ngay_dat], [MaKH], [Soluong], [Ten_KH], [SDT], [Dia_chi], [Email]) VALUES (2, NULL, N'08-11-2024', NULL, NULL, N'duong2', 9123123, N'duong2', NULL)
GO
INSERT [dbo].[KHACH_HANG] ([MaKH], [Ten_KH], [SDT], [Email], [Dia_chi]) VALUES (123, N'duong', 91234567, N'vuanhduong251020042@gmail.com', N'ha noi')
GO
INSERT [dbo].[QUAN_TRI] ([Tai_khoan], [Mat_khau], [Trang_thai]) VALUES (N'duong', N'duong123', 1)
GO
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [Gia], [Soluong], [Mota], [Hinhanh]) VALUES (2, N'com rang', 20000, 200, N'com rang ngon', NULL)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [Gia], [Soluong], [Mota], [Hinhanh]) VALUES (3, N'thit bo kho', 90000, 300, N'thit bo wayuu', NULL)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [Gia], [Soluong], [Mota], [Hinhanh]) VALUES (123, N'thit ga nuong', 100000, 100, N'thit ga nuong lam tu thit ga ', NULL)
GO
/****** Object:  Index [UQ__KHACH_HA__CA1930A5E4BEEA7E]    Script Date: 11/8/2024 2:59:45 PM ******/
ALTER TABLE [dbo].[KHACH_HANG] ADD UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHI_TIET_DON_HANG]  WITH CHECK ADD FOREIGN KEY([MaDH])
REFERENCES [dbo].[DON_HANG] ([MaDH])
GO
ALTER TABLE [dbo].[CHI_TIET_DON_HANG]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[DON_HANG]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[THANH_TOAN]  WITH CHECK ADD FOREIGN KEY([MaDH])
REFERENCES [dbo].[DON_HANG] ([MaDH])
GO
USE [master]
GO
ALTER DATABASE [cuahangdoannhanh] SET  READ_WRITE 
GO
