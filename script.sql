USE [LatihanSoal]
GO
/****** Object:  Table [dbo].[TransaksiDetail]    Script Date: 24/03/2022 19:32:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransaksiDetail]') AND type in (N'U'))
DROP TABLE [dbo].[TransaksiDetail]
GO
/****** Object:  Table [dbo].[Transaksi]    Script Date: 24/03/2022 19:32:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transaksi]') AND type in (N'U'))
DROP TABLE [dbo].[Transaksi]
GO
/****** Object:  Table [dbo].[MsProduct]    Script Date: 24/03/2022 19:32:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MsProduct]') AND type in (N'U'))
DROP TABLE [dbo].[MsProduct]
GO
/****** Object:  Table [dbo].[MsPelanggan]    Script Date: 24/03/2022 19:32:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MsPelanggan]') AND type in (N'U'))
DROP TABLE [dbo].[MsPelanggan]
GO
/****** Object:  Table [dbo].[MsPelanggan]    Script Date: 24/03/2022 19:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsPelanggan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](150) NULL,
	[Alamat] [nvarchar](350) NULL,
	[NoTelp] [nvarchar](150) NULL,
 CONSTRAINT [PK_MsPelanggan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsProduct]    Script Date: 24/03/2022 19:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](150) NULL,
	[Harga] [numeric](18, 0) NULL,
	[Deskripsi] [nvarchar](350) NULL,
 CONSTRAINT [PK_MsProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaksi]    Script Date: 24/03/2022 19:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaksi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KodeTransaksi] [nvarchar](50) NULL,
	[Tanggal] [date] NULL,
	[PelangganId] [int] NULL,
	[Total] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Transaksi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransaksiDetail]    Script Date: 24/03/2022 19:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransaksiDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransaksiId] [int] NULL,
	[ProductId] [int] NULL,
	[Harga] [numeric](18, 0) NULL,
	[Jumlah] [int] NULL,
 CONSTRAINT [PK_TransaksiDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MsPelanggan] ON 

INSERT [dbo].[MsPelanggan] ([Id], [Nama], [Alamat], [NoTelp]) VALUES (5, N'aaa', N'aaa', N'234')
INSERT [dbo].[MsPelanggan] ([Id], [Nama], [Alamat], [NoTelp]) VALUES (6, N'xxx', N'xxx', N'111')
INSERT [dbo].[MsPelanggan] ([Id], [Nama], [Alamat], [NoTelp]) VALUES (8, N'xxxa', N'xxxa', N'1112')
INSERT [dbo].[MsPelanggan] ([Id], [Nama], [Alamat], [NoTelp]) VALUES (9, N'aaaa', N'aaaaaa', N'43434343')
INSERT [dbo].[MsPelanggan] ([Id], [Nama], [Alamat], [NoTelp]) VALUES (14, N'test', N'test', N'123456')
INSERT [dbo].[MsPelanggan] ([Id], [Nama], [Alamat], [NoTelp]) VALUES (16, N'ssss', N'sssssssss', N'3333333333')
SET IDENTITY_INSERT [dbo].[MsPelanggan] OFF
GO
SET IDENTITY_INSERT [dbo].[MsProduct] ON 

INSERT [dbo].[MsProduct] ([Id], [Nama], [Harga], [Deskripsi]) VALUES (1, N'produk1', CAST(1000 AS Numeric(18, 0)), N'ini produk 1')
INSERT [dbo].[MsProduct] ([Id], [Nama], [Harga], [Deskripsi]) VALUES (2, N'produk2 ok', CAST(2500 AS Numeric(18, 0)), N'ini produk 2 ok')
INSERT [dbo].[MsProduct] ([Id], [Nama], [Harga], [Deskripsi]) VALUES (3, N'produk3', CAST(3003 AS Numeric(18, 0)), N'ini produk 3')
INSERT [dbo].[MsProduct] ([Id], [Nama], [Harga], [Deskripsi]) VALUES (5, N'Produk5', CAST(1500 AS Numeric(18, 0)), N'Deskripsi5')
SET IDENTITY_INSERT [dbo].[MsProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaksi] ON 

INSERT [dbo].[Transaksi] ([Id], [KodeTransaksi], [Tanggal], [PelangganId], [Total]) VALUES (1, N'TR0001/0303/20', CAST(N'2022-03-03' AS Date), 9, CAST(3500 AS Numeric(18, 0)))
INSERT [dbo].[Transaksi] ([Id], [KodeTransaksi], [Tanggal], [PelangganId], [Total]) VALUES (2, N'TR0002/0303/20', CAST(N'2022-03-03' AS Date), 5, CAST(5503 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Transaksi] OFF
GO
SET IDENTITY_INSERT [dbo].[TransaksiDetail] ON 

INSERT [dbo].[TransaksiDetail] ([Id], [TransaksiId], [ProductId], [Harga], [Jumlah]) VALUES (1, 1, 1, CAST(1000 AS Numeric(18, 0)), 3)
INSERT [dbo].[TransaksiDetail] ([Id], [TransaksiId], [ProductId], [Harga], [Jumlah]) VALUES (2, 1, 2, CAST(2500 AS Numeric(18, 0)), 2)
INSERT [dbo].[TransaksiDetail] ([Id], [TransaksiId], [ProductId], [Harga], [Jumlah]) VALUES (3, 2, 2, CAST(2500 AS Numeric(18, 0)), 4)
INSERT [dbo].[TransaksiDetail] ([Id], [TransaksiId], [ProductId], [Harga], [Jumlah]) VALUES (4, 2, 3, CAST(3003 AS Numeric(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[TransaksiDetail] OFF
GO
