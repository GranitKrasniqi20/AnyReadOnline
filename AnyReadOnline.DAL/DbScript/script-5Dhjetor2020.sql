USE [master]
GO
/****** Object:  Database [BookShopOnline]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  User [granit.krasniqi]    Script Date: 12/5/2020 9:14:04 AM ******/
CREATE USER [granit.krasniqi] FOR LOGIN [granit.krasniqi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Authors]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[InsBy] [int] NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Authors__70DAFC14BFDE52C5] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthors]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthors](
	[AuthorID] [int] NOT NULL,
	[BookID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[GenreID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
	[PublishHouseID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Year] [datetime] NULL,
	[PublishPlace] [varchar](50) NULL,
	[ISBN] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PageNo] [int] NOT NULL,
	[Price] [decimal](5, 2) NOT NULL,
	[BookCover] [varchar](max) NOT NULL,
	[Weight] [decimal](2, 2) NOT NULL,
	[Length] [decimal](2, 2) NOT NULL,
	[Width] [decimal](2, 2) NOT NULL,
	[Height] [decimal](2, 2) NOT NULL,
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
/****** Object:  Table [dbo].[Clients]    Script Date: 12/5/2020 9:14:04 AM ******/
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
	[Password] [varchar](250) NOT NULL,
	[InsDate] [datetime] NOT NULL,
	[UpdBy] [int] NULL,
	[UpdDate] [datetime] NULL,
	[UpdNo] [int] NULL,
 CONSTRAINT [PK__Clients__E67E1A04A87CCB11] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[Genres]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[Languages]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[Payments]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[PublishHouses]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[ShippingCompanies]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 12/5/2020 9:14:04 AM ******/
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
 CONSTRAINT [PK__Users__1788CCAC7233A407] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (7, N'g1', 1, CAST(N'2001-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2001-01-01T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (19, N'g2', 9, CAST(N'2020-12-02T09:49:15.397' AS DateTime), 1, CAST(N'2020-12-02T09:49:15.397' AS DateTime), 1)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (22, N'lk', 1, CAST(N'2020-12-02T10:32:33.097' AS DateTime), 1, CAST(N'2020-12-02T10:46:58.787' AS DateTime), 2)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (31, N'n', 1, CAST(N'2020-12-02T11:47:59.743' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Genres] ([GenreID], [Genre], [InsBy], [InsDate], [UpdBy], [UpdDate], [UpdNo]) VALUES (38, N'wdwd', 1, CAST(N'2020-12-04T20:46:56.347' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Genres] OFF
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
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK__Authors__InsBy__4222D4EF] FOREIGN KEY([InsBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK__Authors__InsBy__4222D4EF]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK__Authors__UpdBy__4316F928] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK__Authors__UpdBy__4316F928]
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
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK__Clients__UpdBy__4AB81AF0] FOREIGN KEY([UpdBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK__Clients__UpdBy__4AB81AF0]
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
/****** Object:  StoredProcedure [dbo].[usp_DeleteAuthor]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteAuthor]
	@authorID int
as

begin try

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
/****** Object:  StoredProcedure [dbo].[usp_DeleteGenre]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_DeleteLanguage]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_DeletePublishHouse]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetAllAuthor]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetAllGenre]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetAllLanguage]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetAllPublishHouse]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetByIDAuthor]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetByIDGenre]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetByIDLanguage]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetByIDPublishHouse]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertAuthor]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertAuthor]
	@firstName varchar(50),
	@lastName varchar(50),
	@insBy int

	--@authorID int out

as
--exec usp_Insertauthor

begin try

insert into dbo.Authors
(
	Name,
	LastName,
	InsBy,
	InsDate
)
values
(
	@firstName,
	@lastName,
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
/****** Object:  StoredProcedure [dbo].[usp_InsertGenre]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertLanguage]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertPublishHouse]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_UpdateAuthor]    Script Date: 12/5/2020 9:14:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateAuthor]
	@authorID int,
	@firstName varchar(50),
	@lastName varchar(50),
	@updBy int=null
as

begin try

update Authors

set	
	Name = @firstName,
	LastName = @lastName,
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
/****** Object:  StoredProcedure [dbo].[usp_UpdateGenre]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_UpdateLanguage]    Script Date: 12/5/2020 9:14:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_UpdatePublishHouse]    Script Date: 12/5/2020 9:14:04 AM ******/
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
USE [master]
GO
ALTER DATABASE [BookShopOnline] SET  READ_WRITE 
GO
