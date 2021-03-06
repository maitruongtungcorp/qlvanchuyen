USE [QuanLyVanChuyen]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 03/05/2017 1:46:58 PM ******/
DROP TABLE [dbo].[NhanVien]
GO
/****** Object:  Table [dbo].[LyDoThatBai]    Script Date: 03/05/2017 1:46:58 PM ******/
DROP TABLE [dbo].[LyDoThatBai]
GO
/****** Object:  Table [dbo].[DonViTiepNhan]    Script Date: 03/05/2017 1:46:58 PM ******/
DROP TABLE [dbo].[DonViTiepNhan]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 03/05/2017 1:46:58 PM ******/
DROP TABLE [dbo].[Account]
GO
USE [master]
GO
/****** Object:  Database [QuanLyVanChuyen]    Script Date: 03/05/2017 1:46:58 PM ******/
DROP DATABASE [QuanLyVanChuyen]
GO
/****** Object:  Database [QuanLyVanChuyen]    Script Date: 03/05/2017 1:46:58 PM ******/
CREATE DATABASE [QuanLyVanChuyen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TN_QuanLyVanChuyen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TN_QuanLyVanChuyen.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TN_QuanLyVanChuyen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TN_QuanLyVanChuyen_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyVanChuyen] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyVanChuyen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyVanChuyen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyVanChuyen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyVanChuyen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyVanChuyen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyVanChuyen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyVanChuyen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyVanChuyen] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyVanChuyen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyVanChuyen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyVanChuyen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyVanChuyen] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyVanChuyen]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 03/05/2017 1:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DonViTiepNhan]    Script Date: 03/05/2017 1:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonViTiepNhan](
	[MaDonVi] [nvarchar](50) NOT NULL,
	[TenDonVi] [nvarchar](50) NULL,
	[NguoiDaiDien] [nvarchar](50) NULL,
	[DienThoai] [varbinary](15) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
 CONSTRAINT [PK_DonViTiepNhan] PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LyDoThatBai]    Script Date: 03/05/2017 1:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LyDoThatBai](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](500) NULL,
 CONSTRAINT [PK_LyDoThatBai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 03/05/2017 1:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](50) NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[Nhom] [nvarchar](50) NULL,
	[ThuocDonVi] [nvarchar](50) NULL,
	[DienThoai] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [QuanLyVanChuyen] SET  READ_WRITE 
GO
