
CREATE DATABASE [QuanLyQuanCafeNew]

GO
USE [QuanLyQuanCafeNew]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[Food]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[UF_Report]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[UF_Report] (@idBill INT)  
RETURNS TABLE  
AS  
RETURN (SELECT f.name AS N'Tên món',CONCAT(FORMAT(f.price, 'N0', 'vi-VN'), ',00')  AS N'Đơn giá', bi.count AS N'SL',CONCAT(FORMAT(f.price*bi.count, 'N0', 'vi-VN'),',00') AS N'T.Tiền'
	FROM dbo.Food AS f,dbo.BillInfo AS bi
	WHERE bi.idBill= @idBill AND f.id= bi.idFood)
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
	[TimeCheckIn] [varchar](5) NOT NULL,
	[TimeCheckOut] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[report]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[report](
	[tenMon] [nvarchar](50) NULL,
	[donGia] [varchar](20) NULL,
	[SL] [int] NULL,
	[thanhTien] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'abc', N'xyz', N'0', 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'K9', N'RongK11', N'1', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff', N'staff', N'1', 0)
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1078, CAST(N'2023-04-28' AS Date), CAST(N'2023-04-28' AS Date), 7, 1, 0, 150000, N'15:20', N'15:40')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1079, CAST(N'2023-04-28' AS Date), CAST(N'2023-04-28' AS Date), 10, 1, 0, 75000, N'15:20', N'15:20')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1080, CAST(N'2023-04-28' AS Date), CAST(N'2023-04-28' AS Date), 3, 1, 10, 216000, N'16:18', N'16:19')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1081, CAST(N'2023-04-28' AS Date), CAST(N'2023-04-29' AS Date), 7, 1, 0, 120000, N'16:23', N'22:04')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1082, CAST(N'2023-04-28' AS Date), CAST(N'2023-05-30' AS Date), 2, 1, 50, 195000, N'16:23', N'09:51')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1083, CAST(N'2023-04-28' AS Date), CAST(N'2023-04-29' AS Date), 3, 1, 0, 120000, N'20:35', N'22:07')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1085, CAST(N'2023-04-30' AS Date), CAST(N'2023-06-08' AS Date), 3, 1, 50, 240000, N'09:22', N'10:32')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1086, CAST(N'2023-05-16' AS Date), CAST(N'2023-05-30' AS Date), 4, 1, 50, 60000, N'18:48', N'08:20')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1087, CAST(N'2023-05-16' AS Date), CAST(N'2023-05-30' AS Date), 5, 1, 0, 120000, N'18:48', N'08:19')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1088, CAST(N'2023-05-30' AS Date), CAST(N'2023-05-30' AS Date), 6, 1, 50, 619999.5, N'10:00', N'10:00')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (1089, CAST(N'2023-05-30' AS Date), CAST(N'2023-05-30' AS Date), 2, 1, 0, 150000, N'10:03', N'10:08')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2088, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 2, 1, 0, 1339999, N'10:33', N'17:42')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2089, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 3, 1, 50, 120000, N'20:31', N'20:32')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2090, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 2, 1, 0, 480000, N'20:58', N'20:58')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2091, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 8, 1, 50, 180000, N'21:16', N'21:16')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2092, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 8, 1, 50, 180000, N'21:16', N'21:16')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2093, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 2, 1, 50, 1239999, N'21:17', N'21:17')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2094, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 2, 1, 70, 87000, N'21:20', N'21:21')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2095, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 6, 1, 70, 66000, N'21:27', N'21:27')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2096, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 7, 1, 0, 240000, N'21:57', N'21:57')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2097, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 8, 1, 50, 180000, N'21:59', N'21:59')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2098, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 7, 1, 0, 135000, N'22:01', N'22:01')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2099, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 3, 1, 50, 163500, N'22:11', N'22:11')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2100, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-08' AS Date), 3, 1, 0, 135000, N'22:15', N'22:16')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2101, CAST(N'2023-06-09' AS Date), CAST(N'2023-06-09' AS Date), 3, 1, 50, 85000, N'10:55', N'10:55')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2102, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 2, 1, 50, 97500, N'00:04', N'00:20')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2103, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 8, 1, 0, 240000, N'00:25', N'00:25')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2104, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 9, 1, 50, 157500, N'07:39', N'07:42')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2105, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 1002, 1, 0, 360000, N'14:23', N'14:23')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2106, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 1003, 1, 0, 600000, N'14:24', N'14:24')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2107, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 1, 1, 0, 360000, N'14:24', N'14:24')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2108, CAST(N'2023-06-13' AS Date), NULL, 1002, 1, 0, NULL, N'15:17', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2109, CAST(N'2023-06-13' AS Date), NULL, 1, 1, 0, NULL, N'15:17', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2110, CAST(N'2023-06-13' AS Date), NULL, 1005, 1, 0, NULL, N'22:22', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2111, CAST(N'2023-06-13' AS Date), NULL, 3, 1, 0, NULL, N'22:22', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2112, CAST(N'2023-06-13' AS Date), NULL, 3, 1, 0, NULL, N'22:26', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2117, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 8, 1, 0, 600000, N'23:05', N'23:32')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2120, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), 4, 1, 0, 480000, N'23:33', N'23:53')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2122, CAST(N'2023-06-13' AS Date), CAST(N'2023-06-14' AS Date), 4, 1, 0, 120000, N'23:55', N'00:03')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2127, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 2, 1, 0, 360000, N'00:05', N'00:06')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2129, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 8, 1, 0, 240000, N'00:08', N'00:08')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2130, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 1005, 1, 50, 120000, N'01:08', N'01:08')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2131, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 1005, 1, 50, 157500, N'01:13', N'01:14')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2132, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 1005, 1, 50, 240000, N'01:15', N'01:15')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2133, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 1005, 1, 0, 240000, N'01:24', N'01:24')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2134, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 3, 1, 0, 120000, N'08:49', N'11:47')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2135, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 4, 1, 50, 60000, N'11:28', N'11:33')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2138, CAST(N'2023-06-14' AS Date), CAST(N'2023-06-14' AS Date), 3, 1, 0, 360000, N'11:47', N'12:11')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (2141, CAST(N'2023-06-14' AS Date), NULL, 1, 0, 0, NULL, N'12:21', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (3133, CAST(N'2023-06-14' AS Date), NULL, 4, 0, 0, NULL, N'15:56', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (3134, CAST(N'2023-06-14' AS Date), NULL, 2, 0, 0, NULL, N'22:25', NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice], [TimeCheckIn], [TimeCheckOut]) VALUES (3135, CAST(N'2023-06-14' AS Date), NULL, 5, 0, 0, NULL, N'23:42', NULL)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1114, 1078, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1115, 1079, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1116, 1078, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1117, 1078, 3, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1118, 1079, 3, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1119, 1080, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1120, 1081, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1121, 1082, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1122, 1083, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1124, 1082, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1125, 1085, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1126, 1086, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1127, 1087, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (2128, 1088, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (2129, 1088, 5, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (2132, 1089, 3, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (2133, 1089, 6, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3128, 1085, 3, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3129, 2088, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3130, 2088, 5, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3131, 2088, 2, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3132, 2089, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3133, 2090, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3135, 2091, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3136, 2092, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3137, 2093, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3138, 2093, 5, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3139, 2094, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3140, 2094, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3141, 2095, 2, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3142, 2095, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3143, 2096, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3144, 2097, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3145, 2098, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3146, 2098, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3147, 2099, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3148, 2099, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3149, 2099, 7, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3150, 2099, 3, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3151, 2100, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3152, 2100, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3153, 2101, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3154, 2101, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3155, 2102, 3, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3156, 2102, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3157, 2102, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3158, 2103, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3159, 2104, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3160, 2104, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3161, 2105, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3162, 2106, 1, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3163, 2107, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3164, 2110, 1, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3171, 2117, 1, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3174, 2120, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3176, 2122, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3180, 2127, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3182, 2129, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3183, 2130, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3184, 2131, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3185, 2131, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3186, 2132, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3187, 2133, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3188, 2134, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3189, 2135, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3190, 2138, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (4186, 3133, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (4187, 3134, 1, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (1, N'Mực một nắng nước sa tế', 1, 120000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (2, N'Nghêu hấp xả', 1, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (3, N'Dú dê nướng sữa', 2, 60000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (4, N'Heo rừng nướng muối ớt', 3, 75000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (5, N'Cơm chiên mushi', 4, 90000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (6, N'7Up', 5, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (7, N'Cafe', 5, 12000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (1005, N'trà sữa', 5, 120000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'Hải sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'Nông sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'Lâm sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'Sản sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'Nước')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO
INSERT [dbo].[report] ([tenMon], [donGia], [SL], [thanhTien]) VALUES (N'Mực một nắng nước sa tế', N'120.000,00', 3, N'360.000,00')
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn 0', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn 1', N'Có người')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Bàn 2', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Bàn 3', N'Có người')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Bàn 4', N'Đang được gộp với Bàn 3')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Bàn 5', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Bàn 6', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (8, N'Bàn 7', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn 8', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn 9', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1002, N'Bàn 10', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1003, N'Bàn 12', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1005, N'Bàn 13', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Kter') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (CONVERT([varchar](5),getdate(),(108))) FOR [TimeCheckIn]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Bàn chưa có tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[dbo_USPCheckFoodInBillInf]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[dbo_USPCheckFoodInBillInf]
@idFood INT, @idBill INT
AS
BEGIN
	SELECT*FROM dbo.BillInfo WHERE idFood=@idFood AND idBill= @idBill
    
END
GO
/****** Object:  StoredProcedure [dbo].[UPR_UpdateBillInfo]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UPR_UpdateBillInfo]
		@idBill INT , @idFood INT , @count INT
		AS
		BEGIN
			DECLARE @existID INT = 0
			DECLARE @countOld INT = 0
			SELECT @existID= COUNT(*) FROM dbo.BillInfo AS a WHERE a.idBill=@idBill AND a.idFood= @idFood
			IF @existID >0 
			BEGIN
				SELECT @countOld= a.count FROM dbo.BillInfo AS a WHERE a.idBill=@idBill AND a.idFood= @idFood
				UPDATE dbo.BillInfo SET count =  @countOld+@count WHERE idBill=@idBill AND idFood= @idFood
			END
			ELSE
			BEGIN
				INSERT INTO dbo.BillInfo(idBill,idFood,count)
				VALUES(   @idBill, @idFood, @count  )
		    END				
		END

GO
/****** Object:  StoredProcedure [dbo].[USP_AddTable]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_AddTable]
@tableName NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.TableFood
	(
	    name,
	    status
	)
	VALUES
	(   @tableName, -- name - nvarchar(100)
	    N'Trống'  -- status - nvarchar(100)
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_CombineTable]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_CombineTable]
@idTable1 INT, @idTable2 INT
AS BEGIN
	DECLARE @idFirsrBill INT-- = 1023
	DECLARE @idSeconrdBill INT --=1022

	SELECT @idFirsrBill = dbo.Bill.id  FROM dbo.Bill WHERE idTable = @idTable1 AND status=0
	SELECT @idSeconrdBill = dbo.Bill.id  FROM dbo.Bill WHERE idTable = @idTable2 AND status=0
	IF(@idSeconrdBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill( DateCheckIn, DateCheckOut, idTable, status, discount)
		VALUES  (   GETDATE(),NULL, @idTable2, 0,0  )
		SELECT @idSeconrdBill= MAX(id) FROM dbo.Bill
    END
	IF(@idFirsrBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill ( DateCheckIn, DateCheckOut, idTable, status, discount )
		VALUES (   GETDATE(), NULL,  @idTable1, 0, 0  )
		SELECT @idFirsrBill= MAX(id) FROM dbo.Bill
    END

	-- BẮT ĐẦU XỬ LÝ
	SELECT idBill,idFood,count INTO tem000 FROM dbo.BillInfo WHERE idBill= @idFirsrBill
	UPDATE dbo.tem000 SET idBill=@idSeconrdBill
	SELECT * FROM dbo.tem000 
	DELETE dbo.BillInfo WHERE idBill = @idFirsrBill
	DECLARE @tenBan2 NVARCHAR(100)
	DECLARE @tenBan1 NVARCHAR(100)
	SELECT @tenBan1= CONCAT(N'Đang được gộp với ',name) FROM tableFood WHERE id=@idTable1
	SELECT @tenBan2 =CONCAT(N'Đang được gộp với ',name) FROM tableFood WHERE id=@idTable2
	PRINT @tenBan1
	PRINT @tenBan2
	UPDATE dbo.TableFood SET status= @tenBan2 WHERE id= @idTable1 OR status=@tenban1
	--UPDATE dbo.Bill SET status =1 WHERE id = @idFirsrBill

	--KỊCH HAY BẮT ĐẦU
	DECLARE tempCursor CURSOR FOR SELECT *  FROM dbo.tem000 
		
	OPEN tempCursor
	
	DECLARE @idBill INT	
	DECLARE @idFood INT
	DECLARE @count INT
	
	FETCH NEXT FROM tempCursor INTO @idBill, @idFood, @count

	WHILE @@FETCH_STATUS = 0
	
	BEGIN
		EXEC dbo.UPR_UpdateBillInfo  @idBill =@idBill ,@idFood = @idFood, @count = @count  
		FETCH NEXT FROM tempCursor INTO @idBill, @idFood, @count
	END
	CLOSE tempCursor
	DEALLOCATE tempCursor
	DROP TABLE dbo.tem000
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteTable]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DeleteTable]
@idTable INT
AS 
BEGIN	
	DELETE dbo.Bill WHERE idTable=@idTable
	DELETE dbo.TableFood WHERE id = @idTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_EditTable]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_EditTable]
@tableName NVARCHAR(100), @statusTable NVARCHAR(100), @idTable INT
AS
BEGIN
	UPDATE dbo.TableFood SET name=@tableName,status= @statusTable WHERE id= @idTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDataForBieuDo]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetDataForBieuDo]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT idTable,name, SUM(totalPrice) AS totalFinal,@checkIn AS 'DateCheckIn',@checkOut AS 'DateCheckOut'
	FROM dbo.Bill, dbo.tableFood WHERE Bill.idTable=tableFood.id AND Bill.status=1 AND DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut
	GROUP BY idTable,name			
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name, b.DateCheckIn, b.TimeCheckIn, b.TimeCheckOut ,CONCAT(FORMAT(b.totalPrice, 'N0', 'vi-VN'), ',00 VNĐ') AS totalPrice, CONCAT(b.discount,'%') AS disCount, b.id	
	FROM dbo.Bill b, dbo.TableFood t 
	WHERE t.id = b.idTable AND b.status=1 AND DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut

END

SELECT SUM(totalPrice),SUM(totalPrice/(1-(discount*0.01))) FROM dbo.Bill
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
@checkIn date, @checkOut date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT t.name, b.DateCheckIn, b.TimeCheckIn, b.TimeCheckOut ,CONCAT(FORMAT(b.totalPrice, 'N0', 'vi-VN'), ',00 VNĐ') AS totalPrice, CONCAT(b.discount,'%') AS disCount, b.id	
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1 AND t.id = b.idTable)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListFoodByBill]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[USP_GetListFoodByBill]
 @idBill INT
 AS
 BEGIN
	 SELECT f.name AS N'Tên món',CONCAT(FORMAT(f.price, 'N0', 'vi-VN'), ',00')  AS N'Đơn giá', bi.count AS N'SL',CONCAT(FORMAT(f.price*bi.count, 'N0', 'vi-VN'),',00') AS N'T.Tiền'
	FROM dbo.Food AS f,dbo.BillInfo AS bi
	WHERE bi.idBill= @idBill AND f.id= bi.idFood
 END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListFoodByBill2]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[USP_GetListFoodByBill2]
 @idBill INT
 AS
 BEGIN
	 SELECT f.name AS N'foodName',CONCAT(FORMAT(f.price, 'N0', 'vi-VN'), ',00')  AS N'unitPrice', bi.count AS N'count',CONCAT(FORMAT(f.price*bi.count, 'N0', 'vi-VN'),',00') AS N'totalPrice'
	FROM dbo.Food AS f,dbo.BillInfo AS bi
	WHERE bi.idBill= @idBill AND f.id= bi.idFood
 END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNumBillByDate]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetNumBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetResultReport]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetResultReport]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT SUM(totalPrice) AS totalFinal,SUM(totalPrice/(1-discount*0.01)) AS total,SUM(totalPrice/(1-discount*0.01))-SUM(totalPrice) AS totalDiscount ,@checkIn AS dateCheckIn,@checkOut AS dateCheckOut
	FROM dbo.Bill		
	WHERE status=1 AND DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut

END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.TableFood
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
			  discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0 , -- status - int
			  0
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood AND idBill = @idBill
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertFood]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertFood]
@name NVARCHAR(100), @idCategory NVARCHAR(100), @price FLOAT
AS
BEGIN
	INSERT INTO dbo.Food
	(
	    name,
	    idCategory,
	    price
	)
	VALUES
	(   @name, -- name - nvarchar(100)
	    @idCategory,   -- idCategory - int
	    @price  -- price - float
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_Login]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Payment]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Payment]
@idBill INT, @discount INT,@totalPrice FLOAT , @tableName NVARCHAR(100)
AS
BEGIN
	SELECT id INTO Temp FROM tableFood WHERE status=CONCAT(N'Đang được gộp với ',@tableName)
	
	UPDATE dbo.Bill SET TimeCheckOut = CONVERT(varchar(5), GETDATE(), 108) ,dateCheckOut = GETDATE(), status = 1, discount = @discount, totalPrice =  @totalPrice  WHERE id = @idBill 

	DECLARE tempCursor CURSOR FOR SELECT *  FROM dbo.Temp 
	--con trỏ để sửa những bàn được gộp quay về trạng thái ban đầu	
	OPEN tempCursor
	
	DECLARE @idTable INT	
	
	FETCH NEXT FROM tempCursor INTO @idTable

	WHILE @@FETCH_STATUS = 0
	
	BEGIN
		DELETE  bill WHERE idTable= @idTable AND status =0
		UPDATE tableFood SET status = N'Trống'WHERE id=@idTable
		FETCH NEXT FROM tempCursor INTO @idTable
	END
	CLOSE tempCursor
	DEALLOCATE tempCursor
	
	DROP TABLE Temp
END
GO
/****** Object:  StoredProcedure [dbo].[USP_PoolTable]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_PoolTable]
@idTable1 INT, @idTable2 INT
AS BEGIN
	DECLARE @idFirsrBill INT-- = 1023
	DECLARE @idSeconrdBill INT --=1022
	PRINT @idFirsrBill
	SELECT @idFirsrBill = dbo.Bill.id  FROM dbo.Bill WHERE idTable = @idTable1 AND status=0
	SELECT @idSeconrdBill = dbo.Bill.id  FROM dbo.Bill WHERE idTable = @idTable2 AND status=0
	PRINT @idFirsrBill
	PRINT @idSeconrdBill
	IF(@idSeconrdBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill
		(
		    DateCheckIn,
		    DateCheckOut,
		    idTable,
		    status,
		    discount
		)
		VALUES
		(   GETDATE(), -- DateCheckIn - date
		    NULL, -- DateCheckOut - date
		    @idTable2,-- idTable - int
		    0,         -- status - int
		    0          -- discount - int
		    )
		SELECT @idSeconrdBill= MAX(id) FROM dbo.Bill
    END
	IF(@idFirsrBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill
		(
		    DateCheckIn,
		    DateCheckOut,
		    idTable,
		    status,
		    discount
		)
		VALUES
		(   GETDATE(), -- DateCheckIn - date
		    NULL, -- DateCheckOut - date
		    @idTable1,-- idTable - int
		    0,         -- status - int
		    0          -- discount - int
		    )
		SELECT @idFirsrBill= MAX(id) FROM dbo.Bill
    END
	PRINT @idFirsrBill
	PRINT @idSeconrdBill
	-- BẮT ĐẦU XỬ LÝ
	SELECT idBill,idFood,count INTO tem000 FROM dbo.BillInfo WHERE idBill= @idFirsrBill
	UPDATE dbo.tem000 SET idBill=@idSeconrdBill
	SELECT * FROM dbo.tem000 
	DELETE dbo.BillInfo WHERE idBill = @idFirsrBill
	UPDATE dbo.TableFood SET status= N'Trống' WHERE id= @idTable1
	UPDATE dbo.Bill SET status =1 WHERE id = @idFirsrBill
	PRINT @idFirsrBill
	PRINT @idSeconrdBill
	--KỊCH HAY BẮT ĐẦU
	DECLARE tempCursor CURSOR FOR SELECT *  FROM dbo.tem000 
	
	PRINT @idFirsrBill
	PRINT @idSeconrdBill
	
	OPEN tempCursor
	
	DECLARE @idBill INT	
	DECLARE @idFood INT
	DECLARE @count INT
	
	FETCH NEXT FROM tempCursor INTO @idBill, @idFood, @count

	WHILE @@FETCH_STATUS = 0
	
	BEGIN
		EXEC dbo.UPR_UpdateBillInfo  @idBill =@idBill ,@idFood = @idFood, @count = @count  
		FETCH NEXT FROM tempCursor INTO @idBill, @idFood, @count
	END
	CLOSE tempCursor
	DEALLOCATE tempCursor
	DROP TABLE dbo.tem000


END
GO
/****** Object:  StoredProcedure [dbo].[USP_Report]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Report]
    @idBill INT
AS
BEGIN
    DELETE dbo.report

    INSERT INTO dbo.report (tenMon, donGia, SL, thanhTien)
    SELECT f.name AS N'tenMon', CONCAT(FORMAT(f.price, 'N0', 'vi-VN'), ',00') AS N'donGia', bi.count AS N'SL', CONCAT(FORMAT(f.price * bi.count, 'N0', 'vi-VN'), ',00') AS N'tTien'
    FROM dbo.Food AS f, dbo.BillInfo AS bi
    WHERE bi.idBill = @idBill AND f.id = bi.idFood;
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SwichTable]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwichTable]
@idtable1 INT, @idTable2 INT
AS BEGIN
	DECLARE @idFirsrBill int
	DECLARE @idSeconrdBill INT
	DECLARE @status1 NVARCHAR(100)
	DECLARE @status2 NVARCHAR(100)

	SELECT @status1=status FROM dbo.TableFood WHERE id = @idtable1
	SELECT @status2=status FROM dbo.TableFood WHERE id = @idtable2
    SELECT @idFirsrBill = id FROM dbo.Bill WHERE idTable= @idtable1 AND status=0
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable= @idTable2 AND status=0

	
	IF(@idFirsrBill IS NULL) 
	BEGIN
		INSERT INTO dbo.Bill(DateCheckIn,DateCheckOut,idTable,status,discount)
		VALUES(GETDATE(),NULL,@idtable1,0,0 )
			SELECT @idFirsrBill = MAX(id) FROM dbo.Bill WHERE idTable = @idtable1 AND status=0
	END
	IF(@idSeconrdBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill(DateCheckIn,DateCheckOut,idTable,status,discount)
		VALUES
		(GETDATE(), NULL, @idtable2, 0, 0 )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idtable2 AND status=0
	END

	

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	UPDATE dbo.BillInfo SET idBill= @idSeconrdBill WHERE idBill= @idFirsrBill
	UPDATE dbo.BillInfo SET idBill=@idFirsrBill WHERE id IN (SELECT * FROM dbo.IDBillInfoTable)
	DROP TABLE dbo.IDBillInfoTable
	IF (@status1=N'Có người')
	BEGIN
		IF (@status2=N'Trống')
		BEGIN
			UPDATE dbo.TableFood SET status = N'Trống' WHERE id=@idtable1
			UPDATE dbo.TableFood SET status = N'Có người' WHERE id=@idtable2
			DELETE dbo.Bill WHERE id=@idFirsrBill
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateFood]    Script Date: 6/15/2023 12:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateFood]
@name NVARCHAR(100), @idCategory NVARCHAR(100), @price FLOAT,@id INT
AS
BEGIN
	UPDATE dbo.Food SET name=@name, idCategory=@idCategory, price=@price WHERE id = @id
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafeNew] SET  READ_WRITE 
GO
