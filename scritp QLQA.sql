USE [master]
GO
/****** Object:  Database [QLQuanAn]    Script Date: 12/26/2017 4:54:32 PM ******/
CREATE DATABASE [QLQuanAn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLQuanAn', FILENAME = N'F:\SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLQuanAn.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLQuanAn_log', FILENAME = N'F:\SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLQuanAn_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLQuanAn] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLQuanAn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLQuanAn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLQuanAn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLQuanAn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLQuanAn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLQuanAn] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLQuanAn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLQuanAn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLQuanAn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLQuanAn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLQuanAn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLQuanAn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLQuanAn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLQuanAn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLQuanAn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLQuanAn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLQuanAn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLQuanAn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLQuanAn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLQuanAn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLQuanAn] SET  MULTI_USER 
GO
ALTER DATABASE [QLQuanAn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLQuanAn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLQuanAn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLQuanAn] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLQuanAn]
GO
/****** Object:  Table [dbo].[BanAn]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAn](
	[maBA] [int] IDENTITY(1,1) NOT NULL,
	[tenBA] [nvarchar](100) NULL,
	[ghiChu] [nvarchar](100) NULL,
	[maCN] [int] NULL,
	[sucChua] [int] NULL,
	[tinhTrang] [int] NULL CONSTRAINT [DF_TinhTrang]  DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[maBA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiNhanh]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiNhanh](
	[maCN] [int] IDENTITY(1,1) NOT NULL,
	[tenCN] [nvarchar](100) NULL,
	[diaChi] [nvarchar](100) NULL,
	[dienThoai] [nvarchar](15) NULL,
	[tinhThanh] [nvarchar](100) NULL,
	[soLuongBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiPhiChiNhanh]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiPhiChiNhanh](
	[maCPCN] [int] IDENTITY(1,1) NOT NULL,
	[tenCPCN] [nvarchar](100) NULL,
	[giaTienCPCN] [decimal](18, 0) NULL,
	[maCN] [int] NULL,
	[ghiChu] [nvarchar](150) NULL,
	[loaiCPCN] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maCPCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[maMA] [int] NOT NULL,
	[maDonHang] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DangKyTheoDoi]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangKyTheoDoi](
	[email] [nvarchar](150) NOT NULL,
	[thoiGian] [datetime] NULL,
 CONSTRAINT [PK_DangKyTheoDoi] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucMonAn]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucMonAn](
	[maDM] [int] IDENTITY(1,1) NOT NULL,
	[tenDM] [nvarchar](100) NOT NULL,
	[ghiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[maDH] [int] IDENTITY(1,1) NOT NULL,
	[maTTDH] [int] NULL,
	[maBA] [int] NULL,
	[thoiGian] [datetime] NULL,
	[SDT] [nvarchar](15) NULL,
	[maCN] [int] NULL,
	[diaChi] [nvarchar](100) NULL,
	[giaTriDonHang] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[maDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[SDT] [nvarchar](15) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[diaChi] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL CONSTRAINT [DF_Email]  DEFAULT (N'Không')
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuMuaHang]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuMuaHang](
	[maKH] [nvarchar](15) NULL,
	[maDH] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuChiNhanh]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuChiNhanh](
	[maCN] [int] NOT NULL,
	[maMA] [int] NOT NULL,
	[ghiChu] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[maMA] [int] IDENTITY(1,1) NOT NULL,
	[tenMA] [nvarchar](100) NOT NULL,
	[danhMuc] [int] NULL,
	[donGia] [decimal](18, 0) NULL,
	[donViTinh] [nvarchar](15) NULL,
	[ghiChu] [nvarchar](100) NULL,
	[dem] [int] NULL CONSTRAINT [DF_MonAn_dem]  DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[maMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SoLuotTruyCap]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoLuotTruyCap](
	[dem] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinhTrangDonHang]    Script Date: 12/26/2017 4:54:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrangDonHang](
	[maTTDH] [int] IDENTITY(1,1) NOT NULL,
	[tenTTDH] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTTDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BanAn] ON 

INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1026, N'1', N'', 26, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1027, N'2', N'', 26, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1028, N'3', N'', 26, 6, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1029, N'4', N'', 26, 7, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1030, N'5', N'', 26, 8, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1031, N'6', N'', 26, 9, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1032, N'7', N'', 26, 10, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1033, N'8', N'', 26, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1034, N'gf', N'gf', NULL, NULL, NULL)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1035, N'1', N'0', 27, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1036, N'2', N'0', 27, 2, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1037, N'1', N'', 30, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1038, N'2', N'', 30, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1039, N'3', N'', 30, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1040, N'4', N'', 30, 6, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1041, N'5', N'', 30, 10, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1042, N'6', N'', 30, 58, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1043, N'7', N'', 30, 15, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1044, N'8', N'', 30, 19, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1045, N'9', N'', 30, 10, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1046, N'10', N'', 30, 5, 0)
INSERT [dbo].[BanAn] ([maBA], [tenBA], [ghiChu], [maCN], [sucChua], [tinhTrang]) VALUES (1047, N'11', NULL, 30, 15, 0)
SET IDENTITY_INSERT [dbo].[BanAn] OFF
SET IDENTITY_INSERT [dbo].[ChiNhanh] ON 

INSERT [dbo].[ChiNhanh] ([maCN], [tenCN], [diaChi], [dienThoai], [tinhThanh], [soLuongBan]) VALUES (26, N'Nguyễn Văn Cừ', N'235 Nguyuễn Văn Cừ, P4, Q5', N'01232589999', N'TP.H? Chí Minh', 8)
INSERT [dbo].[ChiNhanh] ([maCN], [tenCN], [diaChi], [dienThoai], [tinhThanh], [soLuongBan]) VALUES (27, N'Lê Văn Khương', N'0', N'0', N'0', 2)
INSERT [dbo].[ChiNhanh] ([maCN], [tenCN], [diaChi], [dienThoai], [tinhThanh], [soLuongBan]) VALUES (30, N'Nguyễn Hữu Cầu', N'123 Tô Ký', N'01232584541', N'TP.HCM', 10)
SET IDENTITY_INSERT [dbo].[ChiNhanh] OFF
SET IDENTITY_INSERT [dbo].[ChiPhiChiNhanh] ON 

INSERT [dbo].[ChiPhiChiNhanh] ([maCPCN], [tenCPCN], [giaTienCPCN], [maCN], [ghiChu], [loaiCPCN]) VALUES (1, N'Ti?n thuê nhà', CAST(2500000 AS Decimal(18, 0)), 26, NULL, N'Tháng')
INSERT [dbo].[ChiPhiChiNhanh] ([maCPCN], [tenCPCN], [giaTienCPCN], [maCN], [ghiChu], [loaiCPCN]) VALUES (2, N'Lương nhân viên', CAST(8000000 AS Decimal(18, 0)), 26, NULL, N'Tháng')
SET IDENTITY_INSERT [dbo].[ChiPhiChiNhanh] OFF
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (0, 4)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (0, 4)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (0, 4)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (0, 5)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (0, 5)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (0, 5)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (12, 6)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 8)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 8)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 9)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 10)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 10)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 11)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 11)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 119)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 119)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (12, 120)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (9, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (11, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 0)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 235)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 237)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 238)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 253)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 253)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 255)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (11, 255)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 256)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 257)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (11, 257)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (11, 258)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 258)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (12, 258)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (11, 259)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 259)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 259)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 260)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (11, 260)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 261)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 262)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 262)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (9, 262)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 263)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 6)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (12, 8)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 10)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (10, 11)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (12, 11)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 120)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 178)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 178)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (13, 178)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 197)
INSERT [dbo].[ChiTietDonHang] ([maMA], [maDonHang]) VALUES (8, 200)
INSERT [dbo].[DangKyTheoDoi] ([email], [thoiGian]) VALUES (N'MisoaK@gmail.com', CAST(N'2017-12-26 15:44:07.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DanhMucMonAn] ON 

INSERT [dbo].[DanhMucMonAn] ([maDM], [tenDM], [ghiChu]) VALUES (27, N'Món ăn', N'')
INSERT [dbo].[DanhMucMonAn] ([maDM], [tenDM], [ghiChu]) VALUES (28, N'Nước uống đông lạnh', N'')
INSERT [dbo].[DanhMucMonAn] ([maDM], [tenDM], [ghiChu]) VALUES (31, N'Gà', N'các món làm từ gà')
INSERT [dbo].[DanhMucMonAn] ([maDM], [tenDM], [ghiChu]) VALUES (32, N'Heo', N'các món từ heo')
SET IDENTITY_INSERT [dbo].[DanhMucMonAn] OFF
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (114, 7, NULL, CAST(N'2017-12-24 02:37:41.000' AS DateTime), N'0123456', 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (115, 7, NULL, CAST(N'2017-12-24 02:37:43.000' AS DateTime), N'0456789', 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (116, 5, 1033, CAST(N'2017-12-24 02:37:45.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (117, 5, 1026, CAST(N'2017-12-24 02:37:46.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (118, 5, 1031, CAST(N'2017-12-24 03:18:21.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (119, 6, NULL, CAST(N'2017-12-24 04:17:41.000' AS DateTime), N'26081997', 26, NULL, CAST(216000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (120, 4, NULL, CAST(N'2017-12-24 04:17:57.000' AS DateTime), N'16081997', 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (121, 5, 1032, CAST(N'2017-12-24 05:43:46.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (122, 5, 1030, CAST(N'2017-12-24 05:50:01.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (123, 5, 1031, CAST(N'2017-12-24 05:50:14.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (124, 5, 1032, CAST(N'2017-12-24 05:51:50.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (125, 8, 1028, CAST(N'2017-12-24 05:51:57.000' AS DateTime), N'123456', 26, N'ahaha', NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (126, 5, 1031, CAST(N'2017-12-24 05:53:42.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (127, 5, 1033, CAST(N'2017-12-24 05:53:52.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (128, 5, 1032, CAST(N'2017-12-24 05:56:47.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (129, 8, 1029, CAST(N'2017-12-24 05:57:00.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (130, 5, 1031, CAST(N'2017-12-24 16:43:35.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (131, 5, 1030, CAST(N'2017-12-24 16:43:37.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (132, 5, 1033, CAST(N'2017-12-24 16:43:39.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (133, 5, 1029, CAST(N'2017-12-24 16:43:41.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (134, 5, 1032, CAST(N'2017-12-24 17:34:51.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (135, 5, 1032, CAST(N'2017-12-24 17:44:49.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (136, 5, 1032, CAST(N'2017-12-24 17:48:06.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (137, 5, 1032, CAST(N'2017-12-24 17:56:17.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (138, 5, 1033, CAST(N'2017-12-24 17:56:55.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (139, 5, 1031, CAST(N'2017-12-24 18:02:54.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (140, 5, 1033, CAST(N'2017-12-24 18:03:11.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (141, 5, 1033, CAST(N'2017-12-24 18:04:02.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (142, 5, 1033, CAST(N'2017-12-24 18:04:09.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (143, 5, 1028, CAST(N'2017-12-24 18:04:10.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (144, 5, 1031, CAST(N'2017-12-24 18:04:12.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (145, 5, 1026, CAST(N'2017-12-24 18:04:13.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (146, 5, 1029, CAST(N'2017-12-24 18:04:14.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (147, 5, 1032, CAST(N'2017-12-24 18:04:17.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (148, 5, 1032, CAST(N'2017-12-24 18:04:18.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (149, 5, 1032, CAST(N'2017-12-24 18:04:19.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (150, 5, 1032, CAST(N'2017-12-24 18:04:20.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (151, 5, 1030, CAST(N'2017-12-24 18:04:21.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (152, 5, 1031, CAST(N'2017-12-24 18:05:42.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (153, 5, 1032, CAST(N'2017-12-24 18:07:36.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (154, 5, 1029, CAST(N'2017-12-24 18:07:39.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (155, 5, 1027, CAST(N'2017-12-24 18:07:45.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (156, 5, 1029, CAST(N'2017-12-24 18:08:56.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (157, 5, 1032, CAST(N'2017-12-24 18:08:58.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (158, 5, 1033, CAST(N'2017-12-24 18:09:06.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (159, 5, 1026, CAST(N'2017-12-24 18:09:07.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (160, 5, 1031, CAST(N'2017-12-24 18:15:45.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (161, 5, 1032, CAST(N'2017-12-24 18:15:47.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (162, 5, 1026, CAST(N'2017-12-24 18:16:01.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (163, 5, 1031, CAST(N'2017-12-24 18:17:26.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (164, 5, 1032, CAST(N'2017-12-24 18:17:29.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (165, 5, 1033, CAST(N'2017-12-24 18:17:32.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (166, 5, 1030, CAST(N'2017-12-24 18:22:56.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (167, 5, 1030, CAST(N'2017-12-24 18:26:55.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (168, 5, 1032, CAST(N'2017-12-24 18:34:23.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (169, 5, 1028, CAST(N'2017-12-24 18:34:26.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (170, 5, 1033, CAST(N'2017-12-24 18:34:34.000' AS DateTime), NULL, 26, NULL, CAST(99 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (171, 5, 1030, CAST(N'2017-12-24 18:36:32.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (172, 5, 1029, CAST(N'2017-12-24 18:36:35.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (173, 5, 1033, CAST(N'2017-12-24 18:36:39.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (174, 5, 1031, CAST(N'2017-12-24 18:38:38.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (175, 5, 1028, CAST(N'2017-12-24 18:38:47.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (176, 5, 1026, CAST(N'2017-12-24 18:38:50.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (177, 5, 1032, CAST(N'2017-12-24 18:39:31.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (178, 5, 1033, CAST(N'2017-12-24 18:44:09.000' AS DateTime), NULL, 26, NULL, CAST(416000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (179, 5, 1032, CAST(N'2017-12-24 18:44:35.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (180, 5, 1030, CAST(N'2017-12-24 19:40:24.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (181, 5, 1032, CAST(N'2017-12-24 19:43:04.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (182, 5, 1031, CAST(N'2017-12-24 19:46:11.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (183, 5, 1031, CAST(N'2017-12-24 19:48:49.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (184, 5, 1033, CAST(N'2017-12-24 19:48:56.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (185, 5, 1028, CAST(N'2017-12-24 19:48:58.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (186, 5, 1032, CAST(N'2017-12-24 19:49:00.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (187, 5, 1026, CAST(N'2017-12-24 19:49:01.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (188, 5, 1026, CAST(N'2017-12-24 19:50:05.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (189, 5, 1030, CAST(N'2017-12-24 19:50:14.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (190, 5, 1027, CAST(N'2017-12-24 19:50:15.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (191, 5, 1029, CAST(N'2017-12-24 19:50:16.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (192, 5, 1030, CAST(N'2017-12-24 19:50:17.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (193, 5, 1031, CAST(N'2017-12-24 19:50:19.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (194, 5, 1031, CAST(N'2017-12-24 19:53:00.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (195, 5, 1033, CAST(N'2017-12-24 19:53:35.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (196, 5, 1029, CAST(N'2017-12-24 19:54:08.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (197, 5, 1030, CAST(N'2017-12-24 20:01:55.000' AS DateTime), NULL, 26, NULL, CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (198, 5, 1031, CAST(N'2017-12-24 20:03:35.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (199, 5, 1031, CAST(N'2017-12-24 20:03:37.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (200, 5, NULL, CAST(N'2017-12-24 20:03:43.000' AS DateTime), NULL, 26, NULL, CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (201, 5, 1028, CAST(N'2017-12-24 20:11:56.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (202, 5, 1031, CAST(N'2017-12-24 20:12:32.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (203, 5, 1027, CAST(N'2017-12-24 20:15:36.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (204, 5, 1027, CAST(N'2017-12-24 20:16:56.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (205, 5, 1031, CAST(N'2017-12-24 20:18:44.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (206, 5, 1029, CAST(N'2017-12-24 20:18:49.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (207, 5, 1033, CAST(N'2017-12-24 20:20:32.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (208, 5, 1030, CAST(N'2017-12-24 20:24:23.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (209, 5, 1028, CAST(N'2017-12-24 20:24:43.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (210, 5, 1029, CAST(N'2017-12-24 20:24:52.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (211, 5, 1031, CAST(N'2017-12-24 20:28:08.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (212, 5, 1032, CAST(N'2017-12-24 20:32:12.000' AS DateTime), NULL, 26, NULL, NULL)
GO
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (213, 4, NULL, CAST(N'2017-12-24 20:35:30.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (214, 4, 1031, CAST(N'2017-12-24 20:50:59.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (215, 4, 1032, CAST(N'2017-12-24 21:02:10.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (216, 5, 1032, CAST(N'2017-12-24 21:03:26.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (217, 5, 1038, CAST(N'2017-12-25 03:49:15.000' AS DateTime), NULL, 30, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (218, 4, 1041, CAST(N'2017-12-25 03:49:36.000' AS DateTime), NULL, 30, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (219, 7, NULL, CAST(N'2017-12-25 05:06:54.000' AS DateTime), N'0123456', 27, N'123 Hàng Tôm', CAST(267976 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (220, 7, NULL, CAST(N'2017-12-25 05:08:16.000' AS DateTime), N'01258914360', 27, N'235 Nguyễn Thị Minh Khai', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (221, 9, NULL, CAST(N'2017-12-25 05:09:32.000' AS DateTime), N'', NULL, N'label4', CAST(14500 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (222, 7, NULL, CAST(N'2017-12-25 05:13:45.000' AS DateTime), N'01258914360', 27, N'235 Nguyễn Thị Minh Khai', CAST(323456 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (223, 7, NULL, CAST(N'2017-12-25 05:22:45.000' AS DateTime), N'01258914360', 30, N'235 Nguyễn Thị Minh Khai', CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (224, 7, NULL, CAST(N'2017-12-25 05:25:21.000' AS DateTime), N'0123456', 27, N'123 Hàng Tôm', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (225, 9, NULL, CAST(N'2017-12-25 05:26:08.000' AS DateTime), N'', NULL, N'123 Hàng Tôm', CAST(32000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (226, 9, NULL, CAST(N'2017-12-25 05:28:16.000' AS DateTime), N'', NULL, N'label4', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (227, 9, NULL, CAST(N'2017-12-25 05:29:10.000' AS DateTime), N'01258914360', 26, N'235 Nguyễn Thị Minh Khai', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (228, 9, NULL, CAST(N'2017-12-25 05:31:48.000' AS DateTime), N'0123456', 26, N'123 Hàng Tôm', CAST(14500 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (229, 9, NULL, CAST(N'2017-12-25 05:34:36.000' AS DateTime), N'', NULL, N'label4', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (230, 5, NULL, CAST(N'2017-12-25 05:34:47.000' AS DateTime), N'0456789', 27, N'456 Hàng Cá', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (231, 9, NULL, CAST(N'2017-12-25 05:37:27.000' AS DateTime), N'0456789', 26, N'456 Hàng Cá', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (232, 9, NULL, CAST(N'2017-12-25 05:40:22.000' AS DateTime), N'0123456', 26, N'123 Hàng Tôm', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (233, 9, NULL, CAST(N'2017-12-25 05:42:06.000' AS DateTime), N'', NULL, N'label4', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (234, 9, NULL, CAST(N'2017-12-25 05:42:30.000' AS DateTime), N'', NULL, N'label4', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (235, 9, NULL, CAST(N'2017-12-25 05:44:57.000' AS DateTime), N'0123456', 30, N'123 Hàng Tôm', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (236, 9, NULL, CAST(N'2017-12-25 19:17:44.000' AS DateTime), N'', NULL, N'label4', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (237, 4, 1030, CAST(N'2017-12-26 00:41:05.000' AS DateTime), NULL, 26, NULL, CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (238, 4, 1033, CAST(N'2017-12-26 00:41:53.000' AS DateTime), NULL, 26, NULL, CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (239, 5, 1033, CAST(N'2017-12-26 00:42:28.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (240, 5, 1033, CAST(N'2017-12-26 00:42:45.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (241, 5, 1033, CAST(N'2017-12-26 00:43:04.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (242, 5, 1032, CAST(N'2017-12-26 00:46:03.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (243, 4, 1033, CAST(N'2017-12-26 00:46:15.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (244, 5, 1032, CAST(N'2017-12-26 00:50:27.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (245, 5, 1031, CAST(N'2017-12-26 00:52:31.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (246, 5, 1030, CAST(N'2017-12-26 00:59:49.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (247, 5, 1033, CAST(N'2017-12-26 00:59:59.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (248, 5, 1029, CAST(N'2017-12-26 01:00:01.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (249, 5, 1026, CAST(N'2017-12-26 01:00:02.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (250, 5, 1030, CAST(N'2017-12-26 01:00:03.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (251, 5, 1028, CAST(N'2017-12-26 01:00:06.000' AS DateTime), NULL, 26, NULL, NULL)
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (252, 4, 1032, CAST(N'2017-12-26 01:00:23.000' AS DateTime), NULL, 26, NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (253, 4, 1042, CAST(N'2017-12-26 01:06:01.000' AS DateTime), NULL, 30, NULL, CAST(21000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (254, 8, NULL, CAST(N'2017-12-26 05:13:32.000' AS DateTime), N'01234568521', NULL, N'hóc môn', CAST(16000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (255, 8, NULL, CAST(N'2017-12-26 05:26:12.000' AS DateTime), N'0903050303', NULL, N'235 Nguy?n Van C?', CAST(19500 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (256, 8, NULL, CAST(N'2017-12-26 05:33:26.000' AS DateTime), N'', NULL, N'', CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (257, 8, NULL, CAST(N'2017-12-26 05:36:18.000' AS DateTime), N'', NULL, N'', CAST(19500 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (258, 8, NULL, CAST(N'2017-12-26 05:42:10.000' AS DateTime), N'0236812344', NULL, N'New ork', CAST(338020 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (259, 8, NULL, CAST(N'2017-12-26 05:43:28.000' AS DateTime), N'053131', NULL, N'fsdfdsdf', CAST(414500 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (260, 8, NULL, CAST(N'2017-12-26 05:44:47.000' AS DateTime), N'     021212', NULL, N'fsd', CAST(30500 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (261, 8, NULL, CAST(N'2017-12-26 05:49:29.000' AS DateTime), N' 433324324', 27, N'dsads', CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (262, 8, NULL, CAST(N'2017-12-26 05:52:52.000' AS DateTime), N'    43', 26, N'xzczxc', CAST(155456 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([maDH], [maTTDH], [maBA], [thoiGian], [SDT], [maCN], [diaChi], [giaTriDonHang]) VALUES (263, 8, NULL, CAST(N'2017-12-26 05:55:30.000' AS DateTime), N'    343432', NULL, N'dsadas', CAST(16000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[DonHang] OFF
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'0123456', N'Nguyễn Thị A', N'123 Hàng Tôm', N'abc@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'0456789', N'Nguyễn Văn Bitch', N'456 Hàng Cá', N'xyz@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'16081997', N'Sơn Tùng', N'235 Hắc Điếm', N'ahihi@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'26081997', N'Bà Tưng', N'852 Nguyễn Chí  Thanh', N'bt@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'01258914360', N'Hoàng Hiệp', N'235 Nguyễn Thị Minh Khai', N'thh123@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'123456', N'ahuyhuy', N'ahaha', N'da@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'01234568521', N'leo', N'hóc môn', N'anh@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'0903050303', N'Trần Hoàng Hiệp', N'235 Nguyễn Văn Cừ', N'ahuyhuy@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'', N'', N'', N'')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'0236812344', N'Leo Tino', N'New ork', N'andksja@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'053131', N'dagsds', N'fsdfdsdf', N'ddsaasd@fdafa.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'     021212', N'fsdfsdf', N'fsd', N'cvzxxcxz@dsad.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'02515646541', N'gfdgsdfdsfsdf', N'fdsfsd', N'asdsa@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'   32131231', N'gfdgf', N'gfdgfdg', N'dsadasds@ga.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N' 433324324', N'dsad', N'dsads', N'dsadsad@gasds.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'    43', N'cxzcxzc', N'xzczxc', N'desad@gmail.com')
INSERT [dbo].[KhachHang] ([SDT], [ten], [diaChi], [email]) VALUES (N'    343432', N'dsadas', N'dsadas', N'ddasdsa@gmi.com')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (26, 13, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (26, 12, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (26, 8, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (26, 10, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (27, 10, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (27, 13, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (30, 10, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (30, 13, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (30, 12, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (30, 8, N'')
INSERT [dbo].[MenuChiNhanh] ([maCN], [maMA], [ghiChu]) VALUES (27, 8, N'')
SET IDENTITY_INSERT [dbo].[MonAn] ON 

INSERT [dbo].[MonAn] ([maMA], [tenMA], [danhMuc], [donGia], [donViTinh], [ghiChu], [dem]) VALUES (8, N'Da heo chiên giòn', 32, CAST(16000 AS Decimal(18, 0)), N'lạng', N'đã chế biến', 2)
INSERT [dbo].[MonAn] ([maMA], [tenMA], [danhMuc], [donGia], [donViTinh], [ghiChu], [dem]) VALUES (9, N'ga ', 31, CAST(123456 AS Decimal(18, 0)), N'', N'', 0)
INSERT [dbo].[MonAn] ([maMA], [tenMA], [danhMuc], [donGia], [donViTinh], [ghiChu], [dem]) VALUES (10, N'lavie', 28, CAST(5000 AS Decimal(18, 0)), N'', N'', 1)
INSERT [dbo].[MonAn] ([maMA], [tenMA], [danhMuc], [donGia], [donViTinh], [ghiChu], [dem]) VALUES (11, N'ma', 27, CAST(14500 AS Decimal(18, 0)), N'', N'', 0)
INSERT [dbo].[MonAn] ([maMA], [tenMA], [danhMuc], [donGia], [donViTinh], [ghiChu], [dem]) VALUES (12, N'Gà xào tỏi ớt', 31, CAST(123520 AS Decimal(18, 0)), N'con', N'', 1)
INSERT [dbo].[MonAn] ([maMA], [tenMA], [danhMuc], [donGia], [donViTinh], [ghiChu], [dem]) VALUES (13, N'Gà chiên nước mắm', 31, CAST(200000 AS Decimal(18, 0)), N'con', N'', 8)
SET IDENTITY_INSERT [dbo].[MonAn] OFF
INSERT [dbo].[SoLuotTruyCap] ([dem]) VALUES (16)
SET IDENTITY_INSERT [dbo].[TinhTrangDonHang] ON 

INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (1, N'Đang mở tại bàn')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (2, N'Đang chế biến')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (3, N'Đã chế biến')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (4, N'Đã thanh toán')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (5, N'Đã hủy')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (6, N'Đang chờ chi nhánh nhận đơn mang về')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (7, N'Đang chờ chi nhánh nhận giao hàng tận nơi')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (8, N'Đang chờ duyệt')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (9, N'Đã duyệt')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (10, N'Không duyệt')
INSERT [dbo].[TinhTrangDonHang] ([maTTDH], [tenTTDH]) VALUES (11, N'Đổi đơn hàng')
SET IDENTITY_INSERT [dbo].[TinhTrangDonHang] OFF
ALTER TABLE [dbo].[BanAn]  WITH CHECK ADD  CONSTRAINT [FK_BanAn_ChiNhanh] FOREIGN KEY([maCN])
REFERENCES [dbo].[ChiNhanh] ([maCN])
GO
ALTER TABLE [dbo].[BanAn] CHECK CONSTRAINT [FK_BanAn_ChiNhanh]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_BanAn] FOREIGN KEY([maBA])
REFERENCES [dbo].[BanAn] ([maBA])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_BanAn]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_ChiNhanh] FOREIGN KEY([maCN])
REFERENCES [dbo].[ChiNhanh] ([maCN])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_ChiNhanh]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_TinhTrangDonHang] FOREIGN KEY([maTTDH])
REFERENCES [dbo].[TinhTrangDonHang] ([maTTDH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_TinhTrangDonHang]
GO
ALTER TABLE [dbo].[LichSuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_LichSuMuaHang_DonHang] FOREIGN KEY([maDH])
REFERENCES [dbo].[DonHang] ([maDH])
GO
ALTER TABLE [dbo].[LichSuMuaHang] CHECK CONSTRAINT [FK_LichSuMuaHang_DonHang]
GO
ALTER TABLE [dbo].[MenuChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_MenuChiNhanh_ChiNhanh] FOREIGN KEY([maCN])
REFERENCES [dbo].[ChiNhanh] ([maCN])
GO
ALTER TABLE [dbo].[MenuChiNhanh] CHECK CONSTRAINT [FK_MenuChiNhanh_ChiNhanh]
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_DanhMucMonAn] FOREIGN KEY([danhMuc])
REFERENCES [dbo].[DanhMucMonAn] ([maDM])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_DanhMucMonAn]
GO
USE [master]
GO
ALTER DATABASE [QLQuanAn] SET  READ_WRITE 
GO
