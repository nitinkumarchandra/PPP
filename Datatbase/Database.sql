USE [master]
GO
/****** Object:  Database [NitinPortal]    Script Date: 06-04-2023 10:39:44 ******/
CREATE DATABASE [NitinPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NitinPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NitinPortal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NitinPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NitinPortal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NitinPortal] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NitinPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NitinPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NitinPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NitinPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NitinPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NitinPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [NitinPortal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NitinPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NitinPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NitinPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NitinPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NitinPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NitinPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NitinPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NitinPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NitinPortal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NitinPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NitinPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NitinPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NitinPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NitinPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NitinPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NitinPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NitinPortal] SET RECOVERY FULL 
GO
ALTER DATABASE [NitinPortal] SET  MULTI_USER 
GO
ALTER DATABASE [NitinPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NitinPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NitinPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NitinPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NitinPortal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NitinPortal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NitinPortal', N'ON'
GO
ALTER DATABASE [NitinPortal] SET QUERY_STORE = ON
GO
ALTER DATABASE [NitinPortal] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NitinPortal]
GO
/****** Object:  Table [dbo].[City]    Script Date: 06-04-2023 10:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[City Id] [int] IDENTITY(1,1) NOT NULL,
	[City Name] [varchar](150) NULL,
	[State Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[City Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 06-04-2023 10:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Country Id] [int] IDENTITY(1,1) NOT NULL,
	[Country Name] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Country Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 06-04-2023 10:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Company Name] [varchar](max) NULL,
	[Country] [varchar](150) NULL,
	[State] [varchar](150) NULL,
	[City] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 06-04-2023 10:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Image Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Extension] [varchar](100) NULL,
	[File Path] [varchar](300) NULL,
	[File Size] [varchar](200) NULL,
	[File Type] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Image Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 06-04-2023 10:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[State Id] [int] IDENTITY(1,1) NOT NULL,
	[State Name] [varchar](150) NULL,
	[Country Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[State Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 06-04-2023 10:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Standard] [varchar](50) NULL,
	[Image  Path] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([State Id])
REFERENCES [dbo].[State] ([State Id])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([Country Id])
REFERENCES [dbo].[Country] ([Country Id])
GO
USE [master]
GO
ALTER DATABASE [NitinPortal] SET  READ_WRITE 
GO
