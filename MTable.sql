/*Create database [MTable]*/
USE [MTable]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 14/03/2023 10:53:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Information]    Script Date: 14/03/2023 10:53:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Information](
	[ID] [int] NOT NULL,
	[FullName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](5000) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_Information] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 14/03/2023 10:53:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserOrder] [int] NULL,
	[TimeOrder] [varchar](50) NULL,
	[DateOrder] [date] NULL,
	[NoteUser] [varchar](5000) NULL,
	[EmployeeCF] [int] NULL,
	[DateCF] [datetime] NULL,
	[Status] [int] NULL,
	[NoteEmployee] [varchar](5000) NULL,
	[TableId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 14/03/2023 10:53:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Infor] [varchar](5000) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (1, N'sa', N'123', 0, 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (2, N'user1', N'123', 1, 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (3, N'user2', N'123', 1, 0)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (4, N'user3', N'123', 1, 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (5, N'user4', N'123', 1, 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (6, N'chi', N'123', 1, 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [Status]) VALUES (7, N'hoang', N'123', 1, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (1, N'admin', N'admin@gmail.com', N'Ha Noi', N'123')
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (2, N'Nguyen Duc Nam', N'nam@gmail.com', N'Ha Noi', N'098223443')
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (3, N'Vu Duc Hai', N'12345', N'Ho Chi Minh', N'hai@gmail.com')
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (4, N'Vu Trong Phung', N'phung@gmail.com', N'Hai Phong', N'09855446')
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (5, N'Duc', N'duc@gmail.com', N'Tay Ho', N'0345933322')
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (6, N'Vu Kim Chi', N'chi@gmail.com', N'Duc Giang', N'09833221')
INSERT [dbo].[Information] ([ID], [FullName], [Email], [Address], [Phone]) VALUES (7, N'Ngo Tung Son', N'son@gmail.com', N'Ngoc Lam', N'0345933322')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (3, 2, N'15:00', CAST(N'2023-03-12' AS Date), N'A Nam dat ban ', NULL, NULL, 1, NULL, 1)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (6, 3, N'16:00', CAST(N'2023-03-12' AS Date), N'Em hai dat ban 2 lan 2', NULL, CAST(N'2023-03-12T15:19:27.470' AS DateTime), 2, N'Da goi dien xac nhan', 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (7, 2, N'16:00', CAST(N'2023-03-17' AS Date), N'A dat ban 5 nhe em', NULL, CAST(N'2023-03-12T15:30:39.297' AS DateTime), 2, N'Ko nghe dien thoai', 5)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (8, 2, N'19:00', CAST(N'2023-03-12' AS Date), N'hihi', NULL, CAST(N'2023-03-12T21:59:30.183' AS DateTime), 3, N'Khong nghe may', 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (9, 3, N'17:00', CAST(N'2023-03-13' AS Date), N'Party1', NULL, CAST(N'2023-03-12T22:58:23.693' AS DateTime), 3, N'ko dat', 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (10, 3, N'16:00', CAST(N'2023-03-13' AS Date), N'Party2', NULL, NULL, 1, NULL, 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (11, 2, N'15:00', CAST(N'2023-03-13' AS Date), N'To chuc sinh nhat', NULL, CAST(N'2023-03-12T22:19:19.200' AS DateTime), 3, N'Goi dien khong nghe may', 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (12, 3, N'16:00', CAST(N'2023-03-13' AS Date), N'party nho', NULL, NULL, 1, NULL, 3)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (13, 3, N'15:00', CAST(N'2023-03-10' AS Date), N'party nho', NULL, NULL, 1, NULL, 3)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (14, 4, N'16:00', CAST(N'2023-03-14' AS Date), N'Abc', NULL, NULL, 1, NULL, 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (15, 2, N'15:00', CAST(N'2023-03-13' AS Date), N'Abc', NULL, NULL, 1, NULL, 2)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (17, 2, N'15:00', CAST(N'2023-03-11' AS Date), N'goi dien cho minh', NULL, NULL, 1, NULL, 1)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (18, 2, N'15:00', CAST(N'2023-03-11' AS Date), N'A Nam dat ban ', NULL, NULL, 1, NULL, 5)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (19, 4, N'16:00', CAST(N'2023-03-12' AS Date), N'A Nam dat ban ', NULL, NULL, 1, NULL, 1)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (29, 6, N'16:00', CAST(N'2023-03-14' AS Date), N'chi dat ban', NULL, CAST(N'2023-03-14T20:44:24.873' AS DateTime), 2, N'da xac nhan tu nhan vien', 1)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (31, 2, N'15:00', CAST(N'2023-03-17' AS Date), N'a dat cho em gai', NULL, NULL, 1, NULL, 5)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (32, 2, N'15:00', CAST(N'2023-03-14' AS Date), N'Dat ban', NULL, NULL, 1, NULL, 1)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (33, 7, N'17:00', CAST(N'2023-03-17' AS Date), N'TSon dat ban', NULL, CAST(N'2023-03-14T22:30:48.683' AS DateTime), 2, N'Da goi xac nhan cho khach', 5)
INSERT [dbo].[Order] ([ID], [UserOrder], [TimeOrder], [DateOrder], [NoteUser], [EmployeeCF], [DateCF], [Status], [NoteEmployee], [TableId]) VALUES (34, 7, N'15:00', CAST(N'2023-03-15' AS Date), N'Dat de lien hoan', NULL, NULL, 1, NULL, 2)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([ID], [Name], [Infor]) VALUES (1, N'Ban 1', NULL)
INSERT [dbo].[Table] ([ID], [Name], [Infor]) VALUES (2, N'Ban 2', NULL)
INSERT [dbo].[Table] ([ID], [Name], [Infor]) VALUES (3, N'Ban 3', NULL)
INSERT [dbo].[Table] ([ID], [Name], [Infor]) VALUES (4, N'Ban 4', NULL)
INSERT [dbo].[Table] ([ID], [Name], [Infor]) VALUES (5, N'Ban 5', NULL)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
ALTER TABLE [dbo].[Information]  WITH CHECK ADD  CONSTRAINT [FK_Information_Account] FOREIGN KEY([ID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Information] CHECK CONSTRAINT [FK_Information_Account]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account] FOREIGN KEY([UserOrder])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account1] FOREIGN KEY([EmployeeCF])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table]
GO
