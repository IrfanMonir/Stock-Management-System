USE [master]
GO
/****** Object:  Database [StockSystemDB]    Script Date: 3/21/2019 11:19:30 AM ******/
CREATE DATABASE [StockSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockSystemDB', FILENAME = N'E:\BITM\Project\Stock Management System\Database\StockSystemDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockSystemDB_log', FILENAME = N'E:\BITM\Project\Stock Management System\Database\StockSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [StockSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockSystemDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CompanyTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ReorderLevel] [int] NOT NULL,
 CONSTRAINT [PK_ItemTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockIn]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[AvailableQuantity] [int] NULL,
 CONSTRAINT [PK_StockInTable_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[StockOutQuantity] [int] NOT NULL,
 CONSTRAINT [PK_StockOutTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[DateView]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DateView]
as
SELECT        I.Name AS Item, C.Name AS Company, SO.StockOutQuantity as SaleQuantity
FROM            dbo.Company AS C FULL  JOIN
                         dbo.Item AS I ON C.Id = I.CompanyId  FULL JOIN

                         dbo.StockOut AS SO ON SO.ItemId = I.Id
						 WHERE Type = 'Sell' AND (Date <= '2019-03-20' AND Date >= '2019-03-19' )  
GO
/****** Object:  View [dbo].[GetAllItemView]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetAllItemView]
AS 
SELECT
I.Id as ItemId,
I.CategoryId,
I.CompanyId,
I.Name as ItemName,
I.ReorderLevel,
C.Name as CompanyName
FROM
Item as I INNER JOIN Company as C

ON C.Id = I.CompanyId
GO
/****** Object:  View [dbo].[GetAllItemView1]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetAllItemView1]
AS 
SELECT
I.Id as ItemId,
I.CategoryId,
I.CompanyId,
I.Name as ItemName,
I.ReorderLevel,
C.Name as CompanyName
FROM
Item as I INNER JOIN Company as C

ON C.Id = I.CompanyId
GO
/****** Object:  View [dbo].[GetSummaryByCategory]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetSummaryByCategory] 
as
SELECT        
I.Name AS Item,
 C.Name AS Company,

 
  SI.AvailableQuantity,
   I.ReorderLevel
FROM  
Company AS C FULL  JOIN  Item AS I ON C.Id = I.CompanyId 
FULL  JOIN Category AS Cg ON I.CategoryId = Cg.Id
FULL JOIN StockIN as SI on SI.ItemId = I.Id
GO
/****** Object:  View [dbo].[IsNullView]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[IsNullView]
as
SELECT 
Item.Id as ItemId,
AvailableQuantity
FROM StockIn FULL JOIN Item on Item.Id = StockIn.ItemId
WHERE AvailableQuantity IS NULL
GO
/****** Object:  View [dbo].[SummaryView]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SummaryView]
AS
SELECT        I.Name AS Item, C.Name AS Company, SI.AvailableQuantity, I.ReorderLevel
FROM            dbo.Company AS C FULL OUTER JOIN
                         dbo.Item AS I ON C.Id = I.CompanyId FULL OUTER JOIN
                         dbo.StockIn AS SI ON I.Id = SI.ItemId

GO
/****** Object:  View [dbo].[SummaryViewByCategory]    Script Date: 3/21/2019 11:19:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SummaryViewByCategory] 
as
SELECT        
I.Name AS Item,
 C.Name AS Company,
 Cg.Name as Category,
 
  SI.AvailableQuantity,
   I.ReorderLevel
FROM  
Company AS C FULL  JOIN  Item AS I ON C.Id = I.CompanyId 
FULL  JOIN Category AS Cg ON I.CategoryId = Cg.Id
FULL JOIN StockIN as SI on SI.ItemId = I.Id
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Cosmetic ')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Electronics')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Kichen Item')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Plastic Item')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Stationary')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Name]) VALUES (5, N'Nova')
INSERT [dbo].[Company] ([Id], [Name]) VALUES (3, N'RFL')
INSERT [dbo].[Company] ([Id], [Name]) VALUES (1, N'Unilever')
INSERT [dbo].[Company] ([Id], [Name]) VALUES (4, N'Walton')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (1, 1, 1, N'Face Wash', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (3, 2, 3, N'Board', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (4, 2, 4, N'Refregerator', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (5, 2, 4, N'Oven', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (6, 2, 4, N'Iron', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (7, 1, 1, N'Perfume', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (8, 1, 1, N'Lipstick', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (9, 3, 5, N'Phone', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (12, 3, 5, N'Stove', 5)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (2021, 1, 1, N'Siram', 0)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (2026, 2, 3, N'Balti', 0)
INSERT [dbo].[Item] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLevel]) VALUES (2027, 4, 3, N'Hanger', 5)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[StockIn] ON 

INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (28, 8, 1)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (35, 3, 100)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (36, 4, 0)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (37, 5, 0)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (38, 6, 0)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (39, 7, 0)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (40, 9, 100)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (49, 7, 100)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (51, 12, 100)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (52, 1, 0)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (58, 2021, 0)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (59, 2026, 110)
INSERT [dbo].[StockIn] ([Id], [ItemId], [AvailableQuantity]) VALUES (60, 2027, 222)
SET IDENTITY_INSERT [dbo].[StockIn] OFF
SET IDENTITY_INSERT [dbo].[StockOut] ON 

INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1, 1, CAST(0x713F0B00 AS Date), N'Sell', 10)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (3, 9, CAST(0x703F0B00 AS Date), N'Sell', 5)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (4, 9, CAST(0x703F0B00 AS Date), N'Sell', 5)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (5, 9, CAST(0x703F0B00 AS Date), N'Sell', 5)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (6, 7, CAST(0x703F0B00 AS Date), N'Sell', 10)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1002, 2027, CAST(0x703F0B00 AS Date), N'Sell', 100)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1003, 3, CAST(0x703F0B00 AS Date), N'Sell', 10)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1004, 3, CAST(0x703F0B00 AS Date), N'Sell', 2)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1005, 2027, CAST(0x703F0B00 AS Date), N'Sell', 100)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1006, 3, CAST(0x703F0B00 AS Date), N'Sell', 10)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1007, 3, CAST(0x703F0B00 AS Date), N'Sell', 2)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1008, 2027, CAST(0x703F0B00 AS Date), N'Sell', 100)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1009, 3, CAST(0x703F0B00 AS Date), N'Sell', 10)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1010, 3, CAST(0x703F0B00 AS Date), N'Sell', 2)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1011, 2027, CAST(0x703F0B00 AS Date), N'Sell', 100)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1012, 9, CAST(0x713F0B00 AS Date), N'Damage', 2)
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Type], [StockOutQuantity]) VALUES (1013, 9, CAST(0x713F0B00 AS Date), N'Lost', 2)
SET IDENTITY_INSERT [dbo].[StockOut] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UniqueKey_Category_Name]    Script Date: 3/21/2019 11:19:31 AM ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [UniqueKey_Category_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UniqueKey_Company_Name]    Script Date: 3/21/2019 11:19:31 AM ******/
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [UniqueKey_Company_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_ItemTable_CategoryTable] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_ItemTable_CategoryTable]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_ItemTable_CompanyTable] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_ItemTable_CompanyTable]
GO
ALTER TABLE [dbo].[StockIn]  WITH CHECK ADD  CONSTRAINT [FK_StockInTable_ItemTable] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockIn] CHECK CONSTRAINT [FK_StockInTable_ItemTable]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOutTable_ItemTable] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOutTable_ItemTable]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "I"
            Begin Extent = 
               Top = 3
               Left = 429
               Bottom = 133
               Right = 599
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SI"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 215
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SummaryView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SummaryView'
GO
USE [master]
GO
ALTER DATABASE [StockSystemDB] SET  READ_WRITE 
GO
