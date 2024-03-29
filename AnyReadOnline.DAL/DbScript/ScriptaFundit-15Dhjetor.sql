USE [master]
GO
/****** Object:  Database [BookShopOnline]    Script Date: 12/15/2020 2:44:50 PM ******/
CREATE DATABASE [BookShopOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookShopOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookShopOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookShopOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookShopOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookShopOnline] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookShopOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookShopOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookShopOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookShopOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookShopOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookShopOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookShopOnline] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookShopOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookShopOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookShopOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookShopOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookShopOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookShopOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookShopOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookShopOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookShopOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookShopOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookShopOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookShopOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookShopOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookShopOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookShopOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookShopOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookShopOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookShopOnline] SET  MULTI_USER 
GO
ALTER DATABASE [BookShopOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookShopOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookShopOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookShopOnline] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookShopOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookShopOnline] SET QUERY_STORE = OFF
GO
USE [BookShopOnline]
GO
/****** Object:  User [granit.krasniqi]    Script Date: 12/15/2020 2:44:51 PM ******/
CREATE USER [granit.krasniqi] FOR LOGIN [granit.krasniqi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Addresse__091C2AFB1A7F37E5] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[AuthorImagePath] [varchar](max) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Authors__70DAFC14BFDE52C5] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthors]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthors](
	[AuthorID] [int] NOT NULL,
	[BookID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[GenreID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
	[PublishHouseID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Year] [datetime] NULL,
	[PublishPlace] [varchar](50) NULL,
	[ISBN] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PageNo] [int] NOT NULL,
	[Price] [decimal](5, 2) NOT NULL,
	[BookImagePath] [varchar](max) NOT NULL,
	[Weight] [decimal](4, 2) NOT NULL,
	[Length] [decimal](4, 2) NOT NULL,
	[Width] [decimal](4, 2) NOT NULL,
	[Height] [decimal](4, 2) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Books__3DE0C227C1CA2B40] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FIrstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Clients__E67E1A04A87CCB11] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Countrie__10D160BF46A74EF4] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [varchar](50) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__OrderDet__D3B9D30C0EDB9B73] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[ShippingAddressID] [int] NOT NULL,
	[ShippingOrderId] [int] NULL,
	[ShippingCompanyID] [int] NOT NULL,
	[ShippingFee] [int] NOT NULL,
	[ShippingDuration] [datetime] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Orders__C3905BAF85E9BB2F] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TransactionID] [varchar](250) NOT NULL,
	[BillingAdressID] [int] NOT NULL,
	[TotalFee] [decimal](3, 3) NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Payments__9B556A589C256834] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublishHouses]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishHouses](
	[PublishHouseID] [int] IDENTITY(1,1) NOT NULL,
	[PublishHouse] [varchar](50) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__PublishH__F12F04E3A8FA7382] PRIMARY KEY CLUSTERED 
(
	[PublishHouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](30) NULL,
	[InsBy] [int] NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Roles__8AFACE3AD53D0EDB] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingCompanies]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingCompanies](
	[ShippingCompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Shipping__DADC8F9A15D88657] PRIMARY KEY CLUSTERED 
(
	[ShippingCompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[InsBy] [int] NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
	[CountryID] [int] NULL,
	[Address] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[City] [varchar](50) NULL,
 CONSTRAINT [PK__Users__1788CCAC7233A407] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (1, N'Walter', N'Isaacson', N'~/Content/img/walter_isaacson.jpg', 1, CAST(N'2020-12-15T13:49:26.480' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (2, N'Dale', N'Carnegie', N'~/Content/img/dale_carnegie.jpg', 1, CAST(N'2020-12-15T13:49:26.483' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (3, N'George', N'R. R. Martin', N'~/Content/img/george_rr_martin.jpg', 1, CAST(N'2020-12-15T13:49:26.487' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (4, N'Kelly', N'M. Kapic', N'~/Content/img/kelly_kapic.jpg', 1, CAST(N'2020-12-15T13:49:26.487' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (5, N'Ismail', N'Kadare', N'~/Content/img/ismail_kadare.jpg', 1, CAST(N'2020-12-15T13:49:26.487' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (6, N'Naim', N'Frasheri', N'~/Content/img/naim_frasheri.jpg', 1, CAST(N'2020-12-15T13:49:26.487' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (7, N'Leke', N'Matrenga', N'~/Content/img/default_profile.jpg', 1, CAST(N'2020-12-15T13:49:26.487' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [AuthorImagePath], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (8, N'Sabri', N'Hamiti', N'~/Content/img/sabri_hamiti.jpg', 1, CAST(N'2020-12-15T13:49:26.487' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [GenreID], [LanguageID], [PublishHouseID], [AuthorID], [Title], [Description], [Year], [PublishPlace], [ISBN], [Quantity], [PageNo], [Price], [BookImagePath], [Weight], [Length], [Width], [Height], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (1, 1, 2, 3, 4, N'Steve Jobs', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis tortor a ligula vehicula, eget porta nisi convallis', CAST(N'1905-07-05T00:00:00.000' AS DateTime), N'USA', N'1234567890123', 20, 230, CAST(29.99 AS Decimal(5, 2)), N'~/Content/img/bio_steve_jobs.jpg', CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), 1, CAST(N'2020-12-15T13:53:48.450' AS DateTime), 1, CAST(N'2020-12-15T13:53:48.450' AS DateTime), 1)
INSERT [dbo].[Books] ([BookID], [GenreID], [LanguageID], [PublishHouseID], [AuthorID], [Title], [Description], [Year], [PublishPlace], [ISBN], [Quantity], [PageNo], [Price], [BookImagePath], [Weight], [Length], [Width], [Height], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (2, 4, 3, 2, 1, N'A Promised Land', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis tortor a ligula vehicula, eget porta nisi convallis', CAST(N'1905-07-14T00:00:00.000' AS DateTime), N'USA', N'1234567890123', 20, 230, CAST(29.99 AS Decimal(5, 2)), N'~/Content/img/bio_obama.jpg', CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), 1, CAST(N'2020-12-15T13:53:48.453' AS DateTime), 1, CAST(N'2020-12-15T13:53:48.453' AS DateTime), 1)
INSERT [dbo].[Books] ([BookID], [GenreID], [LanguageID], [PublishHouseID], [AuthorID], [Title], [Description], [Year], [PublishPlace], [ISBN], [Quantity], [PageNo], [Price], [BookImagePath], [Weight], [Length], [Width], [Height], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (3, 5, 2, 1, 6, N'CODE', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis tortor a ligula vehicula, eget porta nisi convallis', CAST(N'1905-07-10T00:00:00.000' AS DateTime), N'England', N'1234567890123', 20, 230, CAST(29.99 AS Decimal(5, 2)), N'~/Content/img/cs_code.jpg', CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), 1, CAST(N'2020-12-15T13:53:48.457' AS DateTime), 1, CAST(N'2020-12-15T13:53:48.457' AS DateTime), 1)
INSERT [dbo].[Books] ([BookID], [GenreID], [LanguageID], [PublishHouseID], [AuthorID], [Title], [Description], [Year], [PublishPlace], [ISBN], [Quantity], [PageNo], [Price], [BookImagePath], [Weight], [Length], [Width], [Height], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (4, 6, 1, 2, 7, N'The 48 Laws of Power', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis tortor a ligula vehicula, eget porta nisi convallis', CAST(N'1905-07-10T00:00:00.000' AS DateTime), N'England', N'1234567890123', 20, 230, CAST(29.99 AS Decimal(5, 2)), N'~/Content/img/sd_48_laws_power.jpg', CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), 1, CAST(N'2020-12-15T13:53:48.457' AS DateTime), 1, CAST(N'2020-12-15T13:53:48.457' AS DateTime), 1)
INSERT [dbo].[Books] ([BookID], [GenreID], [LanguageID], [PublishHouseID], [AuthorID], [Title], [Description], [Year], [PublishPlace], [ISBN], [Quantity], [PageNo], [Price], [BookImagePath], [Weight], [Length], [Width], [Height], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (5, 7, 4, 4, 8, N'Leonardo Da Vinci', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis tortor a ligula vehicula, eget porta nisi convallis', CAST(N'1905-07-10T00:00:00.000' AS DateTime), N'England', N'1234567890123', 20, 230, CAST(29.99 AS Decimal(5, 2)), N'~/Content/img/bio_leonardo_davinci.jpg', CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), 1, CAST(N'2020-12-15T13:53:48.457' AS DateTime), 1, CAST(N'2020-12-15T13:53:48.457' AS DateTime), 1)
INSERT [dbo].[Books] ([BookID], [GenreID], [LanguageID], [PublishHouseID], [AuthorID], [Title], [Description], [Year], [PublishPlace], [ISBN], [Quantity], [PageNo], [Price], [BookImagePath], [Weight], [Length], [Width], [Height], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (8, 3, 2, 1, 2, N'Learning SQL', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis tortor a ligula vehicula, eget porta nisi convallis', CAST(N'1905-07-10T00:00:00.000' AS DateTime), N'Ireland', N'1234567890123', 20, 230, CAST(29.99 AS Decimal(5, 2)), N'~/Content/img/cs_learning_sql.jpg', CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), CAST(19.20 AS Decimal(4, 2)), 1, CAST(N'2020-12-15T13:54:57.800' AS DateTime), 1, CAST(N'2020-12-15T13:54:57.800' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (1, N'Biography', 1, CAST(N'2020-12-15T13:49:56.970' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (2, N'History', 1, CAST(N'2020-12-15T13:49:56.973' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (3, N'Psychology', 1, CAST(N'2020-12-15T13:49:56.973' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (4, N'Computer Science', 1, CAST(N'2020-12-15T13:49:56.973' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (5, N'Finance', 1, CAST(N'2020-12-15T13:49:56.973' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (6, N'Self-Development', 1, CAST(N'2020-12-15T13:49:56.973' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (7, N'Thriller', 1, CAST(N'2020-12-15T13:49:56.983' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Genres] OFF
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([LanguageID], [Language], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (1, N'English', 1, CAST(N'2020-12-15T13:50:28.683' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Languages] ([LanguageID], [Language], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (2, N'Albanian', 1, CAST(N'2020-12-15T13:50:28.690' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Languages] ([LanguageID], [Language], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (3, N'Bosnian', 1, CAST(N'2020-12-15T13:50:28.690' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Languages] ([LanguageID], [Language], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (4, N'Turkish', 1, CAST(N'2020-12-15T13:50:28.690' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Languages] OFF
SET IDENTITY_INSERT [dbo].[PublishHouses] ON 

INSERT [dbo].[PublishHouses] ([PublishHouseID], [PublishHouse], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (1, N'Dukagjini SHPK', 1, CAST(N'2020-12-15T13:50:50.683' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[PublishHouses] ([PublishHouseID], [PublishHouse], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (2, N'ADA SHPK', 1, CAST(N'2020-12-15T13:50:50.683' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[PublishHouses] ([PublishHouseID], [PublishHouse], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (3, N'Albas SHPK', 1, CAST(N'2020-12-15T13:50:50.683' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[PublishHouses] ([PublishHouseID], [PublishHouse], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (4, N'KOHA SHPK', 1, CAST(N'2020-12-15T13:50:50.683' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PublishHouses] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [Role], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (1, N'Admin', NULL, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [RoleId], [Username], [Password], [Name], [LastName], [Email], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo], [CountryID], [Address], [PostalCode], [PhoneNumber], [City]) VALUES (1, 1, N'granit.k', N'123', N'Granit', N'Krasniqi', N'granit.krasniqi1@riinvest.net', NULL, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [RoleId], [Username], [Password], [Name], [LastName], [Email], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo], [CountryID], [Address], [PostalCode], [PhoneNumber], [City]) VALUES (2, 1, N'endrit.p', N'123', N'Endrit', N'Tmava', N'endrit.tmava@riinvest.net', NULL, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [RoleId], [Username], [Password], [Name], [LastName], [Email], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo], [CountryID], [Address], [PostalCode], [PhoneNumber], [City]) VALUES (3, 1, N'beis.p', N'123', N'Beis', N'Presheva', N'beis.presheva@riinvest.net', NULL, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK__Addresses__Clien__3E52440B] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK__Addresses__Clien__3E52440B]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK__Addresses__Count__3F466844] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK__Addresses__Count__3F466844]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK__Addresses__InsBy__403A8C7D] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK__Addresses__InsBy__403A8C7D]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK__Addresses__UpdBy__412EB0B6] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK__Addresses__UpdBy__412EB0B6]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_Authors_InsBy] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_Authors_InsBy]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_Authors_UpdBy] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_Authors_UpdBy]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK__BookAutho__Autho__440B1D61] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK__BookAutho__Autho__440B1D61]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK__BookAutho__BookI__44FF419A] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK__BookAutho__BookI__44FF419A]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__GenreID__45F365D3] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__GenreID__45F365D3]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__InsBy__46E78A0C] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__InsBy__46E78A0C]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__Language__47DBAE45] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__Language__47DBAE45]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__PublishHo__48CFD27E] FOREIGN KEY([PublishHouseID])
REFERENCES [dbo].[PublishHouses] ([PublishHouseID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__PublishHo__48CFD27E]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__UpdBy__49C3F6B7] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__UpdBy__49C3F6B7]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Author]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK__Countries__InsBy__4BAC3F29] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK__Countries__InsBy__4BAC3F29]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK__Countries__UpdBy__4CA06362] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK__Countries__UpdBy__4CA06362]
GO
ALTER TABLE [dbo].[Genres]  WITH CHECK ADD  CONSTRAINT [FK_Genres_InsBy] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Genres] CHECK CONSTRAINT [FK_Genres_InsBy]
GO
ALTER TABLE [dbo].[Genres]  WITH CHECK ADD  CONSTRAINT [FK_Genres_UpdBy] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Genres] CHECK CONSTRAINT [FK_Genres_UpdBy]
GO
ALTER TABLE [dbo].[Languages]  WITH CHECK ADD  CONSTRAINT [FK__Languages__InsBy__4F7CD00D] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Languages] CHECK CONSTRAINT [FK__Languages__InsBy__4F7CD00D]
GO
ALTER TABLE [dbo].[Languages]  WITH CHECK ADD  CONSTRAINT [FK__Languages__UpdBy__5070F446] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Languages] CHECK CONSTRAINT [FK__Languages__UpdBy__5070F446]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__BookI__5165187F] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__BookI__5165187F]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__InsBy__52593CB8] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__InsBy__52593CB8]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__534D60F1] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Order__534D60F1]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__UpdBy__5441852A] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__UpdBy__5441852A]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__ClientID__5535A963] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__ClientID__5535A963]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__Shipping__5629CD9C] FOREIGN KEY([ShippingAddressID])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__Shipping__5629CD9C]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__Shipping__571DF1D5] FOREIGN KEY([ShippingCompanyID])
REFERENCES [dbo].[ShippingCompanies] ([ShippingCompanyID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__Shipping__571DF1D5]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__UpdBy__5812160E] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__UpdBy__5812160E]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__Billin__59063A47] FOREIGN KEY([BillingAdressID])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__Billin__59063A47]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__OrderI__59FA5E80] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__OrderI__59FA5E80]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__UpdBy__5AEE82B9] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__UpdBy__5AEE82B9]
GO
ALTER TABLE [dbo].[PublishHouses]  WITH CHECK ADD  CONSTRAINT [FK__PublishHo__InsBy__5BE2A6F2] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PublishHouses] CHECK CONSTRAINT [FK__PublishHo__InsBy__5BE2A6F2]
GO
ALTER TABLE [dbo].[PublishHouses]  WITH CHECK ADD  CONSTRAINT [FK__PublishHo__UpdBy__5CD6CB2B] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PublishHouses] CHECK CONSTRAINT [FK__PublishHo__UpdBy__5CD6CB2B]
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [FK__Roles__InsBy__5DCAEF64] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [FK__Roles__InsBy__5DCAEF64]
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [FK__Roles__UpdBy__5EBF139D] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [FK__Roles__UpdBy__5EBF139D]
GO
ALTER TABLE [dbo].[ShippingCompanies]  WITH CHECK ADD  CONSTRAINT [FK__ShippingC__InsBy__5FB337D6] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ShippingCompanies] CHECK CONSTRAINT [FK__ShippingC__InsBy__5FB337D6]
GO
ALTER TABLE [dbo].[ShippingCompanies]  WITH CHECK ADD  CONSTRAINT [FK__ShippingC__UpdBy__60A75C0F] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ShippingCompanies] CHECK CONSTRAINT [FK__ShippingC__UpdBy__60A75C0F]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__InsBy__619B8048] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__InsBy__619B8048]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleId__628FA481] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleId__628FA481]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UpdBy] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UpdBy]
GO
/****** Object:  StoredProcedure [dbo].[usp_ClientRegister]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_ClientRegister]
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(50),
@Gender bit,
@PhoneNumber varchar(50)



as
BEGIN

insert into Clients
(
FIrstName,
LastName,
Email,
Gender,
PhoneNo,
InsDate
)
Values(
@FirstName,
@LastName,
@Email,
@Gender,
@PhoneNumber,
GETDATE()
);




end

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAddress]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteAddress]
	@AddressID int
as

begin
	delete from dbo.Addresses
	where AddressId=@AddressID;
end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAuthor]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteAuthor]
	@authorID int
as

begin try

delete from Books
where Books.AuthorID=@authorID;

delete from Authors
where AuthorID=@authorID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteBook]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteBook]
	@bookID int

as 

begin try

	delete from Books
	where dbo.Books.BookID = @bookID;

end try 

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteClient]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteClient]
	@ClientID int
as

begin
	
	delete from dbo.Clients
	where ClientID=@ClientID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteClientByEmail]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteClientByEmail]
	@email varchar(50)
as

begin
	
	delete from dbo.Clients
	where Email=@email;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCountry]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteCountry]
	@countryID int
as

begin
	delete from Countries
	where CountryID=@countryID;
end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteGenre]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteGenre]
	@genreID int
as

begin try

delete from Genres
where GenreID=@genreID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteLanguage]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteLanguage]
	@languageID int
as

begin try

delete from Languages
where LanguageID=@languageID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_DeletePublishHouse]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeletePublishHouse]
	@publishHouseID int
as

begin try

delete from PublishHouses
where PublishHouseID=@publishHouseID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUser]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteUser]
	@UserID int
as

begin
	
	delete from dbo.Users
	where UserID=@UserID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUserByEmail]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteUserByEmail]
	@email varchar(50)
as

begin
	
	delete from dbo.Users
	where Email=@email;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAddressById]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAddressById]
	@AddressID int
as

begin 
	
	select * from dbo.Addresses
	where AddressId=@AddressID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllAddresses]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllAddresses]
as

begin 
	
	select * from dbo.Addresses

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllAuthor]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetAllAuthor]
as

begin try

select * from dbo.Authors as a;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllBook]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetAllBook]

as

begin try

	select b.BookID, g.GenreID, g.Genre, l.LanguageId, l.Language, ph.PublishHouseId, ph.PublishHouse, a.AuthorId, a.Name, a.LastName, a.AuthorImagePath,
	b.Title, b.Description, Year, b.PublishPlace, b.ISBN, b.Quantity, b.PageNo, b.Price, b.BookImagePath, b.Weight, b.Length, b.Width, b.Height,
	b.InsBy, b.InsDate, b.UpdBy, b.UpdDate, b.UpdNo

	from dbo.Books b
		join dbo.Genres g on b.GenreID=g.GenreID
		join dbo.Languages l on b.LanguageID=l.LanguageID
		join dbo.PublishHouses ph on b.PublishHouseID=ph.PublishHouseID
		join dbo.Authors a on b.AuthorID=a.AuthorID
		
end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllClients]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllClients]
as

begin
	
	select * from dbo.Clients;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllCountries]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllCountries]
as

begin 
	select * from dbo.Countries;
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllGenre]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetAllGenre]
as

begin try

select * from dbo.Genres as g;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllLanguage]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetAllLanguage]

as

begin try

select * from dbo.Languages as l;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllPublishHouse]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllPublishHouse]
as

begin try

select * from dbo.PublishHouses as p;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllRoles]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllRoles]
as

begin
	select * from dbo.Roles
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllUsers]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllUsers]
as

begin
	
	select * from dbo.Users;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetByIDAuthor]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetByIDAuthor]
	@authorID int
as


begin try

select * from Authors
where AuthorID=@authorID;

end try 

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetByIDBook]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetByIDBook]
	@bookID int

as

begin try

	select b.BookID, g.GenreID, g.Genre, l.LanguageId, l.Language, ph.PublishHouseId, ph.PublishHouse, a.AuthorId, a.Name, a.LastName, a.AuthorImagePath,
	b.Title, b.Description, b.Year, b.PublishPlace, b.ISBN, b.Quantity, b.PageNo, b.Price, b.BookImagePath, b.Weight, b.Length, b.Width, b.Height,
	b.InsBy, b.InsDate, b.UpdBy, b.UpdDate, b.UpdNo

	from dbo.Books b
		join dbo.Genres g on b.GenreID=g.GenreID
		join dbo.Languages l on b.LanguageID=l.LanguageID
		join dbo.PublishHouses ph on b.PublishHouseID=ph.PublishHouseID
		join dbo.Authors a on b.AuthorID=a.AuthorID
	where b.BookID=@bookID

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch



GO
/****** Object:  StoredProcedure [dbo].[usp_GetByIDGenre]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetByIDGenre]
	@genreID int
as


begin try

select * from Genres
where GenreID=@genreID;

end try 

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetByIDLanguage]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetByIDLanguage]
	@languageID int
as


begin try

select * from Languages
where LanguageID=@languageID;

end try 

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetByIDPublishHouse]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetByIDPublishHouse]
	@publishHouseID int
as


begin try

select * from PublishHouses
where PublishHouseID=@publishHouseID;

end try 

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_GetClientByEmail]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetClientByEmail]
	@email varchar(50)
as

begin 
	
	select * from dbo.Clients
	where Email=@email;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetClientById]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetClientById]
	@ClientID int
as

begin 
	
	select * from dbo.Clients
	where ClientID=@ClientID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCountryByID]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetCountryByID]
	@countryID int
as

begin 
	select * from Countries
	where CountryID=@countryID;
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetRoleByID]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetRoleByID]
	@roleID int
as

begin
	select * from dbo.Roles
	where RoleID=@roleID;
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTop4EarliestAuthors]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetTop4EarliestAuthors]
as

begin

	select top(4) *
	from Authors
	order by AuthorID asc

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTop4EarliestBooks]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetTop4EarliestBooks]
as

begin

	select top(4) b.BookID, g.GenreID, g.Genre, l.LanguageId, l.Language, ph.PublishHouseId, ph.PublishHouse, a.AuthorId, a.Name, a.LastName, a.AuthorImagePath,
	b.Title, b.Description, b.Year, b.PublishPlace, b.ISBN, b.Quantity, b.PageNo, b.Price, b.BookImagePath, b.Weight, b.Length, b.Width, b.Height,
	b.InsBy, b.InsDate, b.UpdBy, b.UpdDate, b.UpdNo

	from dbo.Books b
		join dbo.Genres g on b.GenreID=g.GenreID
		join dbo.Languages l on b.LanguageID=l.LanguageID
		join dbo.PublishHouses ph on b.PublishHouseID=ph.PublishHouseID
		join dbo.Authors a on b.AuthorID=a.AuthorID

	order by b.BookID asc

end

exec usp_GetTop4EarliestBooks
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTop4LatestAuthors]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetTop4LatestAuthors]
as

begin

	select top(4) *
	from Authors
	order by AuthorID desc

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTop4LatestBooks]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetTop4LatestBooks]
as

begin

	select top(4) b.BookID, g.GenreID, g.Genre, l.LanguageId, l.Language, ph.PublishHouseId, ph.PublishHouse, a.AuthorId, a.Name, a.LastName, a.AuthorImagePath,
	b.Title, b.Description, b.Year, b.PublishPlace, b.ISBN, b.Quantity, b.PageNo, b.Price, b.BookImagePath, b.Weight, b.Length, b.Width, b.Height,
	b.InsBy, b.InsDate, b.UpdBy, b.UpdDate, b.UpdNo

	from dbo.Books b
		join dbo.Genres g on b.GenreID=g.GenreID
		join dbo.Languages l on b.LanguageID=l.LanguageID
		join dbo.PublishHouses ph on b.PublishHouseID=ph.PublishHouseID
		join dbo.Authors a on b.AuthorID=a.AuthorID

	order by b.BookID desc

end

exec usp_GetTop4LatestBooks
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserByEmail]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetUserByEmail]
	@email varchar(50)
as

begin 
	
	select * from dbo.Users
	where Email=@email;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserById]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetUserById]
	@UserID varchar(50)
as

begin 
	
	select * from dbo.Users
	where UserID=@UserID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertAddress]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertAddress]
	@clientID int,
	@Name varchar(50),
	@LastName varchar(50),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@PhoneNo varchar(50),
	@PostalCode varchar(50),
	@City varchar(50),
	@CountryID int,
	@InsBy int

as
	BEGIN

	insert into dbo.Addresses (ClientID, Name, LastName, Address1, Address2, PhoneNo, PostalCode, City, CountryID, InsBy, InsDate)
	values(@clientID, @Name, @LastName, @Address1, @Address2, @PhoneNo, @PostalCode, @City, @CountryID, @InsBy, GETDATE());




	end
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertAuthor]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertAuthor]
	@firstName varchar(50),
	@lastName varchar(50),
	@authorImagePath varchar(max),
	@insBy int

	--@authorID int out

as
--exec usp_Insertauthor

begin try

insert into dbo.Authors
(
	Name,
	LastName,
	AuthorImagePath,
	InsBy,
	InsDate
)
values
(
	@firstName,
	@lastName,
	@authorImagePath,
	@insBy,
	getdate()

);

--SCOPE IDENTITY
--set @authorID=scope_identity();

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertBook]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertBook]
	@genreID int,
	@languageID int,
	@publishHouseID int,
	@authorID int,
	@title varchar(50),
	@description varchar(max),
	@publishYear datetime,
	@publishPlace varchar(50),
	@ISBN varchar(50),
	@quantity int,
	@pageNumber int,
	@bookImagePath varchar(max),
	@price decimal(5,2),
	@weight decimal(4,2),
	@length decimal(4,2),
	@width decimal(4,2),
	@height decimal(4,2),
	@insBy int

	--@bookID int out

as
--exec usp_InsertBook 

begin try

insert into dbo.Books
(
	GenreID, LanguageID, PublishHouseID, AuthorID, Title, Description, Year, PublishPlace, ISBN, Quantity, PageNo, BookImagePath, Price,
	Weight, Length, Width, Height, InsBy, InsDate
)
values
( 
	@genreID, @languageID, @publishHouseID, @authorID, @title, @description, @publishYear, @publishPlace, @ISBN, @quantity, @pageNumber, @bookImagePath, @price,
	@weight, @length, @width, @height, @insBy, getdate()
);

--SCOPE IDENTITY
--set @bookID=scope_identity();

end try

begin catch

declare @ErrorMsg nvarchar(max)

set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCountry]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCountry]
	@country varchar(50),
	@insBy int
as

begin
	insert into dbo.Countries
(
	Country,
	InsBy,
	InsDate
)
values
(
	@country,
	@insBy,
	getdate()
);

end
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGenre]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertGenre]
	@genreName varchar(50),
	@insBy int

	--@genreID int out

as
--exec usp_InsertGenre 'g2', 1

begin try

insert into dbo.Genres
(
	Genre,
	InsBy,
	InsDate
)
values
(
	@genreName,
	@insBy,
	getdate()

);

--SCOPE IDENTITY
--set @genreID=scope_identity();

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertLanguage]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertLanguage]
	@languageName varchar(50),
	@insBy int

	--@languageID int out

as
--exec usp_InsertLanguage 'g2', 9

begin try

insert into dbo.Languages
(
	Language,
	InsBy,
	InsDate
)
values
(
	@languageName,
	@insBy,
	getdate()

);

--SCOPE IDENTITY
--set @languageID=scope_identity();

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPublishHouse]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertPublishHouse]
	@publishHouseName varchar(50),
	@insBy int

	--@publishHouseID int out

as
--exec usp_InsertPublishHouse 'g2', 1

begin try

insert into dbo.PublishHouses
(
	PublishHouse,
	InsBy,
	InsDate
)
values
(
	@publishHouseName,
	@insBy,
	getdate()

);

--SCOPE IDENTITY
--set @publishHouseNameID=scope_identity();

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_RegisterUser]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_RegisterUser]
@Username varchar(50),
@Name varchar(50),
@LastName varchar(50),
@Email varchar(50),
@InsBy int,
@RoleId int,
@CountryID int,
@Address varchar(50),
@PostalCode varchar(50),
@City varchar(50),
@PhoneNumber varchar(50)



as begin


insert into Users(
Username,
Name,
LastName,
Email,
InsBy,
InsDate,
RoleId,
CountryID,
Address,
PostalCode,
City,
PhoneNumber

)

values(
@Username,
@Name,
@LastName,
@Email,
@InsBy,
GETDATE(),
@RoleId,
@CountryID ,
@Address,
@PostalCode,
@City,
@PhoneNumber

)


end
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateAddress]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateAddress]
	@AddressID int,
	@clientID int,
	@Name varchar(50),
	@LastName varchar(50),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@PhoneNo varchar(50),
	@PostalCode varchar(50),
	@City varchar(50),
	@CountryID int,
	@updby int = null,
	@updno int = null

as

begin

	select @updno=UpdNo+1 from Addresses where AddressId=@AddressID;

	update dbo.Addresses

	set
		ClientID=@clientID,
		Name=@Name,
		LastName=@LastName,
		Address1=@Address1,
		Address2=@Address2,
		PhoneNo=@PhoneNo,
		PostalCode=@PostalCode,
		City=@City,
		CountryID=@CountryID,
		UpdBy=@updby,
		UpdDate=GETDATE()

	where AddressId=@AddressID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateAuthor]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateAuthor]
	@authorID int,
	@firstName varchar(50),
	@lastName varchar(50),
	@authorImagePath varchar(max),
	@updBy int=null
as

begin try

update Authors

set	
	Name = @firstName,
	LastName = @lastName,
	AuthorImagePath=@authorImagePath,
	UpdBy = @updBy,
	UpdDate = getdate(),
    UpdNo = isnull(UpdNo,0)+1  

where AuthorID=@authorID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateBook]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateBook]
	@bookID int,
	@genreID int,
	@languageID int,
	@publishHouseID int,
	@authorID int,
	@title varchar(50),
	@description varchar(max),
	@publishYear datetime,
	@publishPlace varchar(50),
	@iSBN varchar(50),
	@quantity int,
	@pageNumber int,
	@bookImagePath varchar(max),
	@price decimal(5,2),
	@weight decimal(4,2),
	@length decimal(4,2),
	@width decimal(4,2),
	@height decimal(4,2),
	@updBy int

as

begin try
		
		update Books

		set
			GenreID=@genreID,
			LanguageID=@languageID ,
			PublishHouseID=@publishHouseID,
			AuthorID=@authorID,
			Title=@title,
			Description=@description,
			Year=@publishYear,
			PublishPlace=@publishPlace,
			ISBN=@iSBN,
			Quantity=@quantity,
			PageNo=@pageNumber,
			BookImagePath=@bookImagePath,
			Price=@price,
			Weight=@weight,
			Length=@length,
			Width=@width,
			Height=@height,
			UpdBy = @updBy,
			UpdDate = getdate(),
			UpdNo = isnull(UpdNo,0)+1  

		where Books.BookID=@bookID;

end try 

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateClient]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateClient]
	@firstname varchar(50),
	@lastname varchar(50),
	@email varchar(50),
	@gender bit,
	@PhoneNumber varchar(50),
	@updno int = null

as

begin

	select @updno=UpdNo+1 from Clients where Email=@email

	update dbo.Clients

	set
		FIrstName=@firstname,
		LastName=@lastname,
		Gender=@gender,
		PhoneNo=@PhoneNumber,
		UpdDate=GETDATE()

	where Email=@email;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCountry]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateCountry]
	@countryID int,
	@country varchar(50),
	@updby int = null,
	@updno int = null

as

begin

	select @updno=UpdNo+1 from Countries where CountryID=@countryID

	update dbo.Countries

	set
		Country=@country,
		UpdBy=@updby,
		UpdDate=GETDATE()

	where CountryID=@countryID;

end
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateGenre]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateGenre]
	@genreID int,
	@genreName varchar(50),
	@updBy int=null
as

begin try

update Genres

set	
	Genre=@genreName,
	UpdBy = @updBy,
	UpdDate = getdate(),
    UpdNo = isnull(UpdNo,0)+1  

where GenreID=@genreID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateLanguage]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateLanguage]
	@languageID int,
	@languageName varchar(50),
	@updBy int=null
as

begin try

update Languages

set	
	Language=@languageName,
	UpdBy = @updBy,
	UpdDate = getdate(),
    UpdNo = isnull(UpdNo,0)+1  

where LanguageID=@languageID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePublishHouse]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdatePublishHouse]
	@publishHouseID int,
	@publishHouseName varchar(50),
	@updBy int=null
as

begin try

update PublishHouses

set	
	PublishHouse=@publishHouseName,
	UpdBy = @updBy,
	UpdDate = getdate(),
    UpdNo = isnull(UpdNo,0)+1  

where PublishHouseID=@publishHouseID;

end try

begin catch

declare @ErrorMsg nvarchar(max)
set @ErrorMsg=error_message();

raiserror (@ErrorMsg,16,1)
return -1;

end catch
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateUser]    Script Date: 12/15/2020 2:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateUser]
	@email varchar(50),
	@name varchar(50),
	@lastname varchar(50),
	@updby int = null,
	@updno int = null

as

begin

	select @updno=UpdNo+1 from Users where Email=@email

	update dbo.Users

	set
		Name=@name,
		LastName=@lastname,
		UpdBy=@updby,
		UpdDate=GETDATE()

	where Email=@email;

end
GO
USE [master]
GO
ALTER DATABASE [BookShopOnline] SET  READ_WRITE 
GO
