USE [master]
GO
/****** Object:  Database [PandaMarketCMS]    Script Date: 3/1/2020 1:48:50 PM ******/
CREATE DATABASE [PandaMarketCMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PandaMarketCMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PandaMarketCMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PandaMarketCMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PandaMarketCMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PandaMarketCMS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PandaMarketCMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PandaMarketCMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PandaMarketCMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PandaMarketCMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PandaMarketCMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PandaMarketCMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET RECOVERY FULL 
GO
ALTER DATABASE [PandaMarketCMS] SET  MULTI_USER 
GO
ALTER DATABASE [PandaMarketCMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PandaMarketCMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PandaMarketCMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PandaMarketCMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PandaMarketCMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PandaMarketCMS', N'ON'
GO
ALTER DATABASE [PandaMarketCMS] SET QUERY_STORE = OFF
GO
USE [PandaMarketCMS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PandaMarketCMS]
GO
/****** Object:  Table [dbo].[About]    Script Date: 3/1/2020 1:48:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[id_About] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Title_one] [nvarchar](max) NULL,
	[Text_one] [nvarchar](max) NULL,
	[Title_two] [nvarchar](max) NULL,
	[Text_two] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminTbl]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminTbl](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](100) NULL,
 CONSTRAINT [PK_AdminTbl] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[id_companies] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Name_companies] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Is_delete] [tinyint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpinionAbout]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpinionAbout](
	[Id_OpinionAbout] [int] IDENTITY(1,1) NOT NULL,
	[Name_OpinionAbout] [nvarchar](max) NULL,
	[OpinionAbout] [nvarchar](max) NULL,
	[Is_delete] [tinyint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Customer_Address]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer_Address](
	[id_CAddress] [int] IDENTITY(1,1) NOT NULL,
	[id_Customer] [int] NOT NULL,
	[ID_Shahr] [int] NOT NULL,
	[C_AddressHint] [nvarchar](max) NOT NULL,
	[C_FullAddress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Customer_Address] PRIMARY KEY CLUSTERED 
(
	[id_CAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Customer_Main]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer_Main](
	[id_Customer] [int] IDENTITY(1,1) NOT NULL,
	[C_regDate] [datetime] NOT NULL,
	[C_Mobile] [nvarchar](max) NOT NULL,
	[C_FirstName] [nvarchar](max) NULL,
	[C_LastNAme] [nvarchar](max) NULL,
	[C_Description] [nvarchar](max) NULL,
	[C_ISActivate] [int] NULL,
	[C_ActivationToken] [int] NULL,
	[C_ActivateDate] [datetime] NULL,
	[C_Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Customer_Main] PRIMARY KEY CLUSTERED 
(
	[id_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Enum_Shahr]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Enum_Shahr](
	[ID_Shahr] [int] NULL,
	[Shahr_Name] [nvarchar](max) NULL,
	[Shahr_OstanConnection] [int] NULL,
	[Ostan_name] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product](
	[id_MProduct] [int] IDENTITY(1,1) NOT NULL,
	[IS_AVAILABEL] [tinyint] NOT NULL,
	[id_CreatedByAdmin] [int] NOT NULL,
	[id_DraftLevel] [int] NULL,
	[id_Type] [int] NOT NULL,
	[id_MainCategory] [int] NOT NULL,
	[id_SubCategory] [int] NOT NULL,
	[idMPC_WhichTomainPrice] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Seo_Description] [nvarchar](max) NOT NULL,
	[Seo_KeyWords] [nvarchar](max) NOT NULL,
	[IS_AD] [tinyint] NOT NULL,
	[Search_Gravity] [int] NOT NULL,
	[Is_IntheDraft] [tinyint] NOT NULL,
	[ISDELETE] [tinyint] NOT NULL,
 CONSTRAINT [PK_tbl_Product] PRIMARY KEY CLUSTERED 
(
	[id_MProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_ConnectorSCOK_Product]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_ConnectorSCOK_Product](
	[id_MProduct] [int] NOT NULL,
	[id_SCOK] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_connectorToMPC_SCOV]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_connectorToMPC_SCOV](
	[id_MPC] [int] NOT NULL,
	[id_SCOV] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_MainCategory]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_MainCategory](
	[id_MC] [int] IDENTITY(1,1) NOT NULL,
	[id_PT] [int] NOT NULL,
	[MCName] [nvarchar](max) NOT NULL,
	[ISDESABLED] [tinyint] NULL,
	[ISDelete] [tinyint] NULL,
	[DateDesabled] [datetime] NULL,
	[DateDeleted] [datetime] NULL,
 CONSTRAINT [PK_tbl_Product_MainCategory] PRIMARY KEY CLUSTERED 
(
	[id_MC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_MainStarTags]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_MainStarTags](
	[id_MainStarTag] [int] IDENTITY(1,1) NOT NULL,
	[MST_Description] [nvarchar](max) NOT NULL,
	[MST_Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Product_MainStarTags] PRIMARY KEY CLUSTERED 
(
	[id_MainStarTag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_OffType]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_OffType](
	[OffType] [int] IDENTITY(1,1) NOT NULL,
	[OffType_Description] [nvarchar](max) NOT NULL,
	[OffType_Symbol] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Product_OffType] PRIMARY KEY CLUSTERED 
(
	[OffType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_Opinion]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_Opinion](
	[id_Opinion] [int] IDENTITY(1,1) NOT NULL,
	[id_MProduct] [int] NOT NULL,
	[id_Customer] [int] NOT NULL,
	[id_AccByAdmin] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[DateAccepted] [datetime] NULL,
	[Is_Accepted] [tinyint] NOT NULL,
	[OpinionDescription] [nvarchar](max) NOT NULL,
	[Rate] [int] NOT NULL,
	[ISDELETE] [tinyint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_PastProductHistory]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_PastProductHistory](
	[id_PPH] [int] IDENTITY(1,1) NOT NULL,
	[id_MPC] [int] NOT NULL,
	[PriceXquantity] [int] NOT NULL,
	[PricePerquantity] [int] NOT NULL,
	[PriceOff] [int] NULL,
	[OffType] [int] NULL,
	[id_MainStarTag] [int] NOT NULL,
	[ChangedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Product_PastProductHistory] PRIMARY KEY CLUSTERED 
(
	[id_PPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_Pic]    Script Date: 3/1/2020 1:48:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_Pic](
	[PicID] [int] IDENTITY(1,1) NOT NULL,
	[id_MProduct] [int] NOT NULL,
	[BigPicAddress] [nvarchar](max) NOT NULL,
	[ThumbnailPicAddress] [nvarchar](max) NOT NULL,
	[ISDELETE] [tinyint] NULL,
	[alt] [nvarchar](max) NULL,
	[uploadPicName] [nvarchar](max) NULL,
	[Descriptions] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Product_Pic] PRIMARY KEY CLUSTERED 
(
	[PicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_ProductQuantityType]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_ProductQuantityType](
	[id_PQT] [int] IDENTITY(1,1) NOT NULL,
	[PQT_Description] [nvarchar](max) NULL,
	[PQT_Demansion] [nvarchar](10) NOT NULL,
	[PQT_Quantom] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Product_ProductQuantityType] PRIMARY KEY CLUSTERED 
(
	[id_PQT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_SubCategory]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_SubCategory](
	[id_SC] [int] IDENTITY(1,1) NOT NULL,
	[id_MC] [int] NOT NULL,
	[SCName] [nvarchar](max) NOT NULL,
	[ISDESABLED] [tinyint] NULL,
	[ISDelete] [tinyint] NULL,
	[DateDesabled] [datetime] NULL,
	[DateDeleted] [datetime] NULL,
 CONSTRAINT [PK_tbl_Product_SubCategory] PRIMARY KEY CLUSTERED 
(
	[id_SC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_SubCategoryOptionKey]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_SubCategoryOptionKey](
	[id_SCOK] [int] IDENTITY(1,1) NOT NULL,
	[id_SC] [int] NOT NULL,
	[SCOKName] [nvarchar](max) NOT NULL,
	[ISDESABLED] [tinyint] NULL,
	[ISDelete] [tinyint] NULL,
	[DateDesabled] [datetime] NULL,
	[DateDeleted] [datetime] NULL,
 CONSTRAINT [PK_tbl_Product_SubCategoryKey] PRIMARY KEY CLUSTERED 
(
	[id_SCOK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_SubCategoryOptionValue]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_SubCategoryOptionValue](
	[id_SCOV] [int] IDENTITY(1,1) NOT NULL,
	[id_SCOK] [int] NOT NULL,
	[SCOVValueName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Product_SubCategoryOptionValue] PRIMARY KEY CLUSTERED 
(
	[id_SCOV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_tagConnector]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_tagConnector](
	[id_MPC] [int] NOT NULL,
	[id_TE] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_TagEnums]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_TagEnums](
	[id_TE] [int] IDENTITY(1,1) NOT NULL,
	[TE_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Product_TagEnums] PRIMARY KEY CLUSTERED 
(
	[id_TE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_tblOptions]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_tblOptions](
	[id_MProduct] [int] NOT NULL,
	[KeyName] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product_Type]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product_Type](
	[id_PT] [int] IDENTITY(1,1) NOT NULL,
	[PTname] [nvarchar](max) NOT NULL,
	[ISDESABLED] [tinyint] NULL,
	[ISDelete] [tinyint] NULL,
	[DateDesabled] [datetime] NULL,
	[DateDeleted] [datetime] NULL,
 CONSTRAINT [PK_tbl_Product_Type] PRIMARY KEY CLUSTERED 
(
	[id_PT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tlb_Product_MainProductConnector]    Script Date: 3/1/2020 1:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Product_MainProductConnector](
	[id_MPC] [int] IDENTITY(1,1) NOT NULL,
	[id_MProduct] [int] NOT NULL,
	[PriceXquantity] [int] NOT NULL,
	[PricePerquantity] [int] NOT NULL,
	[PriceOff] [int] NULL,
	[OffType] [int] NULL,
	[id_MainStarTag] [int] NOT NULL,
	[ISDELETE] [tinyint] NULL,
	[OutOfStock] [tinyint] NULL,
	[id_PQT] [int] NULL,
	[DateToRelease] [datetime] NULL,
 CONSTRAINT [PK_tlb_Product_ConnectorToMainProductID] PRIMARY KEY CLUSTERED 
(
	[id_MPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminTbl] ON 

INSERT [dbo].[AdminTbl] ([AdminId], [AdminName]) VALUES (1, N'Niky')
SET IDENTITY_INSERT [dbo].[AdminTbl] OFF
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (100, N'بوشهر', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (101, N'اهرم', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (102, N'برازجان', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (103, N'تنگستان', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (104, N'خارک', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (105, N'خورموج', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (106, N'دشتستان', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (107, N'دشتی', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (108, N'دیر', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (109, N'دیلم', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (110, N'ریشهر', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (111, N'کنگان', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (112, N'گناوه', 7, N'بوشهر')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (113, N'تهران', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (114, N'آسارا', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (115, N'اسلامشهر', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (116, N'اشتهارد', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (117, N'بومهن', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (118, N'تجریش', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (119, N'دماوند', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (120, N'رباط کریم', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (121, N'رودهن', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (122, N'ری', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (123, N'شریف آباد', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (124, N'شهریار', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (125, N'طالقان', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (126, N'فشم', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (127, N'فیروزکوه', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (128, N'قدس', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (129, N'قرچک', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (130, N'لواسان', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (131, N'ملارد', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (132, N'نظرآباد', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (133, N'هشتگرد', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (134, N'ورامین', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (135, N'پاکدشت', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (136, N'چهاردانگه', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (137, N'کن', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (138, N'کهریزک', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (139, N'گلستان', 8, N'تهران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (140, N'خراسان جنوبی', 9, N'خراسان جنوبی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (141, N'بیرجند', 9, N'خراسان جنوبی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (142, N'سرپیشه', 9, N'خراسان جنوبی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (143, N'نهبندان', 9, N'خراسان جنوبی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (144, N'خراسان رضوی', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (145, N'بردسکن', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (146, N'تایباد', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (147, N'تربت جام', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (148, N'تربت حیدریه', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (149, N'خواف', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (150, N'درگز', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (151, N'سبزوار', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (152, N'سرخس', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (153, N'طرقبه', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (154, N'فردوس', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (155, N'فریمان', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (156, N'قائن', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (157, N'قوچان', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (158, N'مشهد', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (159, N'نیشابور', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (160, N'چناران', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (161, N'کاشمهر', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (162, N'کلات', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (163, N'گناباد', 10, N'خراسان رضوی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (164, N'خراسان شمالی', 11, N'خراسان شمالی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (165, N'آشخانه', 11, N'خراسان شمالی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (166, N'اسفراین', 11, N'خراسان شمالی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (167, N'بجنورد', 11, N'خراسان شمالی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (168, N'جاجرم', 11, N'خراسان شمالی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (169, N'شیروان', 11, N'خراسان شمالی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (170, N'خوزستان', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (171, N'آبادان', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (172, N'امیدیه', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (173, N'اندیمشک', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (174, N'اهواز', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (175, N'ایذه', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (176, N'ایرانشهر', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (177, N'باغ ملک', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (178, N'بندر ماهشهر', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (179, N'بندرامام خمینی', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (180, N'بهبهان', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (181, N'خرمشهر', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (182, N'دزفول', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (183, N'رامهرمز', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (184, N'سوسنگرد', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (185, N'شادگان', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (186, N'شوش', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (187, N'شوشتر', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (188, N'لالی', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (189, N'مسجدسلیمان', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (190, N'هندیجان', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (191, N'هویزه', 12, N'خوزستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (192, N'زنجان', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (193, N'اب بر', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (194, N'ابهر', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (195, N'ایجرود', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (196, N'خدابنده', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (197, N'خرمدره', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (198, N'زرین آباد', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (199, N'قیدار', 13, N'زنجان')
GO
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (200, N'ماهنشان', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (201, N'کارم', 13, N'زنجان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (202, N'سمنان', 14, N'سمنان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (203, N'ایوانکی', 14, N'سمنان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (204, N'بسطام', 14, N'سمنان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (205, N'دامغان', 14, N'سمنان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (206, N'شاهرود', 14, N'سمنان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (207, N'گرمسار', 14, N'سمنان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (208, N'سیستان و بلوچستان', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (209, N'ایرانشهر', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (210, N'خاش', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (211, N'راسک', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (212, N'زابل', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (213, N'زاهدان', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (214, N'سراوان', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (215, N'سرباز', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (216, N'میرجاوه', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (217, N'نیکشهر', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (218, N'چابهار', 15, N'سیستان و بلوچستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (219, N'فارس', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (220, N'آباده', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (221, N'اردکان', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (222, N'ارسنجان', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (223, N'استهبان', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (224, N'اقلید', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (225, N'جهرم', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (226, N'حاجی آباد', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (227, N'خرم بید', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (228, N'داراب', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (229, N'سوریان', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (230, N'سپیدان', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (231, N'شیراز', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (232, N'صفا شهر', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (233, N'فراشبند', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (234, N'فسا', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (235, N'فیروزآباد', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (236, N'قیروکارزین', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (237, N'لار', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (238, N'لامرد', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (239, N'مرودشت', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (240, N'ممسنی', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (241, N'مهر', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (242, N'نورآباد', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (243, N'نی ریز', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (244, N'کازرون', 16, N'فارس')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (245, N'قزوین', 17, N'قزوین')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (246, N'آبیک', 17, N'قزوین')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (247, N'بوئین زهرا', 17, N'قزوین')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (248, N'تاکستان', 17, N'قزوین')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (249, N'قم', 18, N'قم')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (250, N'لرستان', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (251, N'ازنا', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (252, N'الشتر', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (253, N'الیگودرز', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (254, N'بروجرد', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (255, N'خرم آباد', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (256, N'دزفول', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (257, N'دورود', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (258, N'ماهشهر', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (259, N'نورآباد', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (260, N'پلدختر', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (261, N'کوهدشت', 19, N'لرستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (262, N'مازندران', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (263, N'آمل', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (264, N'بابل', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (265, N'بابلسر', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (266, N'بلده', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (267, N'بهشهر', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (268, N'تنکابن', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (269, N'جویبار', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (270, N'رامسر', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (271, N'ساری', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (272, N'سواد کوه', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (273, N'فریدون کنار', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (274, N'قائم شهر', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (275, N'محمود آباد', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (276, N'نور', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (277, N'نوشهر', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (278, N'نکا', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (279, N'پل سفید', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (280, N'چالوس', 20, N'مازندران')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (281, N'مرکزی', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (282, N'آشتیان', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (283, N'اراک', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (284, N'تفرش', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (285, N'خمین', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (286, N'دلیجان', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (287, N'ساوه', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (288, N'سربند', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (289, N'شازند', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (290, N'محلات', 21, N'مرکزی')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (291, N'هرمزگان', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (292, N'ابوموسی', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (293, N'انگهران', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (294, N'بستک', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (295, N'بندر جاسک', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (296, N'بندر عباس', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (297, N'بندرلنگه', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (298, N'تنب بزرگ', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (299, N'حاجی آباد', 22, N'هرمزگان')
GO
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (300, N'دهبا رز', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (301, N'قشم', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (302, N'میناب', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (303, N'کیش', 22, N'هرمزگان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (304, N'همدان', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (305, N'اسدآباد', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (306, N'بهار', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (307, N'تویسرکان', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (308, N'رزن', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (309, N'ملایر', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (310, N'نهاوند', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (311, N'کبودراهنگ', 23, N'همدان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (312, N'چهارمحال و بختیاری', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (313, N'اردل', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (314, N'بروجن', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (315, N'سامان', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (316, N'شهرکرد', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (317, N'فارسان', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (318, N'لردگان', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (319, N'چلگرد', 24, N'چهارمحال و بختیاری')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (320, N'کردستان', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (321, N'بانه', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (322, N'بیجار', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (323, N'دیواندره', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (324, N'سقز', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (325, N'سنندج', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (326, N'قروه', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (327, N'مریوان', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (328, N'کامیاران', 25, N'کردستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (329, N'کرمان', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (330, N'بابک', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (331, N'بافت', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (332, N'بردسیر', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (333, N'بم', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (334, N'جیرفت', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (335, N'راور', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (336, N'رفسنجان', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (337, N'زرند', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (338, N'سیرجان', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (339, N'قصرشیرین', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (340, N'کهنوج', 26, N'کرمان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (341, N'کرمانشاه', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (342, N'اسلام آبا د غرب', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (343, N'جوانرود', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (344, N'سرپل ذهاب', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (345, N'سنقر', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (346, N'صحنه', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (347, N'هرسین', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (348, N'پاوه', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (349, N'کنگاور', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (350, N'گیلان غرب', 27, N'کرمانشاه')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (351, N'کهکلویه و بویراحمد', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (352, N'دنا', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (353, N'دهدشت', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (354, N'دوگنبدان', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (355, N'سی سخت', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (356, N'گچساران', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (357, N'یاسوج', 28, N'کهکلویه و بویراحمد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (358, N'گلستان', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (359, N'آزادشهر', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (360, N'آق قلا', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (361, N'بندر گز', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (362, N'ترکمن', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (363, N'رامیان', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (364, N'علی آباد کتول', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (365, N'مینودشت', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (366, N'کردکوی', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (367, N'کلاله', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (368, N'گرگان', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (369, N'گنبد کاووس', 29, N'گلستان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (370, N'گیلان', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (371, N'آستارا', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (372, N'آستانه اشرفیه', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (373, N'املش', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (374, N'بندر انزلی', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (375, N'تالش', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (376, N'خشکبیجار', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (377, N'خمام', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (378, N'رحیم آباد', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (379, N'رشت', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (380, N'رضوان شهر', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (381, N'رودبار', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (382, N'رودسر', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (383, N'سنگر', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (384, N'سیاهکل', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (385, N'شفت', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (386, N'صومعه سرا', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (387, N'فومن', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (388, N'لاهیجان', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (389, N'لشت نشا', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (390, N'لنگرود', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (391, N'ماسال', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (392, N'ماسوله', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (393, N'منجیل', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (394, N'هشتپر', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (395, N'چابکسر', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (396, N'کلاچای', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (397, N'کوچصفهان', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (398, N'کیاشهر', 30, N'گیلان')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (399, N'یزد', 31, N'یزد')
GO
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (400, N'ابرکوه', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (401, N'اردکان', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (402, N'اشکذر', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (403, N'بافق', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (404, N'تفت', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (405, N'طبس', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (406, N'مهریز', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (407, N'میبد', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (408, N'هرات', 31, N'یزد')
INSERT [dbo].[tbl_Enum_Shahr] ([ID_Shahr], [Shahr_Name], [Shahr_OstanConnection], [Ostan_name]) VALUES (409, N'*نامشخص*', 32, N'*نامشخص*')
SET IDENTITY_INSERT [dbo].[tbl_Product] ON 

INSERT [dbo].[tbl_Product] ([id_MProduct], [IS_AVAILABEL], [id_CreatedByAdmin], [id_DraftLevel], [id_Type], [id_MainCategory], [id_SubCategory], [idMPC_WhichTomainPrice], [Description], [DateCreated], [Title], [Seo_Description], [Seo_KeyWords], [IS_AD], [Search_Gravity], [Is_IntheDraft], [ISDELETE]) VALUES (4, 1, 1, NULL, 1, 1, 1, 1, N'خووبه', CAST(N'2020-02-20T12:01:11.300' AS DateTime), N'galaxy s8', N'galaxy s8', N'galaxy', 1, 100, 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_Product] OFF
SET IDENTITY_INSERT [dbo].[tbl_Product_MainCategory] ON 

INSERT [dbo].[tbl_Product_MainCategory] ([id_MC], [id_PT], [MCName], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (1, 1, N'گوشی موبایل', 0, 0, NULL, CAST(N'2020-02-28T13:54:14.540' AS DateTime))
INSERT [dbo].[tbl_Product_MainCategory] ([id_MC], [id_PT], [MCName], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (2, 1003, N'پارچه', 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Product_MainCategory] OFF
SET IDENTITY_INSERT [dbo].[tbl_Product_Pic] ON 

INSERT [dbo].[tbl_Product_Pic] ([PicID], [id_MProduct], [BigPicAddress], [ThumbnailPicAddress], [ISDELETE], [alt], [uploadPicName], [Descriptions]) VALUES (1, 4, N'/assets/download.jpg', N'/assets/download.jpg', 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Product_Pic] OFF
SET IDENTITY_INSERT [dbo].[tbl_Product_SubCategory] ON 

INSERT [dbo].[tbl_Product_SubCategory] ([id_SC], [id_MC], [SCName], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (1, 1, N'سامسونگ', 0, 0, NULL, CAST(N'2020-02-28T13:58:10.660' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Product_SubCategory] OFF
SET IDENTITY_INSERT [dbo].[tbl_Product_SubCategoryOptionValue] ON 

INSERT [dbo].[tbl_Product_SubCategoryOptionValue] ([id_SCOV], [id_SCOK], [SCOVValueName]) VALUES (1, 1, N'gold')
SET IDENTITY_INSERT [dbo].[tbl_Product_SubCategoryOptionValue] OFF
SET IDENTITY_INSERT [dbo].[tbl_Product_Type] ON 

INSERT [dbo].[tbl_Product_Type] ([id_PT], [PTname], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (1, N'وسایل دیجیتال', 0, 0, NULL, NULL)
INSERT [dbo].[tbl_Product_Type] ([id_PT], [PTname], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (2, N'خوراکی', 0, 0, NULL, NULL)
INSERT [dbo].[tbl_Product_Type] ([id_PT], [PTname], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (3, N'پوشاک', 0, 0, CAST(N'2020-02-20T12:01:11.300' AS DateTime), NULL)
INSERT [dbo].[tbl_Product_Type] ([id_PT], [PTname], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (4, N'دیگر', 0, 0, CAST(N'2020-02-20T08:01:10.823' AS DateTime), NULL)
INSERT [dbo].[tbl_Product_Type] ([id_PT], [PTname], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (1003, N'other', 0, 1, NULL, NULL)
INSERT [dbo].[tbl_Product_Type] ([id_PT], [PTname], [ISDESABLED], [ISDelete], [DateDesabled], [DateDeleted]) VALUES (1004, N'dfss', 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Product_Type] OFF
USE [master]
GO
ALTER DATABASE [PandaMarketCMS] SET  READ_WRITE 
GO
