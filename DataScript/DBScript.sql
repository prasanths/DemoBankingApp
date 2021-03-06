/****** Object:  Table [dbo].[Account]    Script Date: 29-May-17 3:11:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[AccountStatusId] [int] NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
	[Currency] [nvarchar](3) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountStatus]    Script Date: 29-May-17 3:11:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [nvarchar](10) NOT NULL,
	[StatusName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_AccountStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 29-May-17 3:11:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Location] [nvarchar](50) NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 29-May-17 3:11:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](150) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 29-May-17 3:11:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 29-May-17 3:11:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeCode] [nvarchar](10) NOT NULL,
	[TypeName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [AccountNumber], [CustomerId], [BranchId], [AccountStatusId], [Balance], [Currency], [StartDate], [EndDate]) VALUES (2, 10000000, 1, 1, 1, CAST(400 AS Decimal(18, 0)), N'INR', CAST(N'2017-01-05T11:34:20.000' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountNumber], [CustomerId], [BranchId], [AccountStatusId], [Balance], [Currency], [StartDate], [EndDate]) VALUES (3, 10000001, 2, 1, 1, CAST(0 AS Decimal(18, 0)), N'INR', CAST(N'2017-04-09T09:30:23.000' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountNumber], [CustomerId], [BranchId], [AccountStatusId], [Balance], [Currency], [StartDate], [EndDate]) VALUES (5, 10000002, 3, 2, 1, CAST(250 AS Decimal(18, 0)), N'USD', CAST(N'2017-03-09T09:43:15.000' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountNumber], [CustomerId], [BranchId], [AccountStatusId], [Balance], [Currency], [StartDate], [EndDate]) VALUES (8, 10000003, 4, 1, 2, CAST(0 AS Decimal(18, 0)), N'GBP', CAST(N'2012-05-01T09:34:10.000' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountNumber], [CustomerId], [BranchId], [AccountStatusId], [Balance], [Currency], [StartDate], [EndDate]) VALUES (9, 10000004, 5, 2, 1, CAST(10 AS Decimal(18, 0)), N'EUR', CAST(N'2017-04-09T09:30:23.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[AccountStatus] ON 

INSERT [dbo].[AccountStatus] ([StatusId], [StatusCode], [StatusName]) VALUES (1, N'Active', N'Active')
INSERT [dbo].[AccountStatus] ([StatusId], [StatusCode], [StatusName]) VALUES (2, N'Dormant', N'Dormant')
INSERT [dbo].[AccountStatus] ([StatusId], [StatusCode], [StatusName]) VALUES (3, N'Closed', N'Closed')
SET IDENTITY_INSERT [dbo].[AccountStatus] OFF
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([BranchId], [Name], [Code], [Location]) VALUES (1, N'Lords Ville', N'5000', N'Lords Ville')
INSERT [dbo].[Branch] ([BranchId], [Name], [Code], [Location]) VALUES (2, N'Grandham Road', N'5001', N'Grandham')
SET IDENTITY_INSERT [dbo].[Branch] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address]) VALUES (1, N'David', N'Cooper', N'45 Chapel Lane, Lords Ville')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address]) VALUES (2, N'Jonathan', N'Hawk', N'36 Witney Road, Witney')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address]) VALUES (3, N'Steve', N'Robinson', N'87 Dudley Close, Hampshire')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address]) VALUES (4, N'John', N'Hopkins', N'46 Yardley Green Road, Birmingham')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address]) VALUES (5, N'Chris', N'Davis', N'31 Hunslow Close, London')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([TransactionId], [TransactionTypeId], [Amount], [TransactionDate], [AccountId]) VALUES (1, 1, CAST(200 AS Decimal(18, 0)), CAST(N'2017-05-29T00:39:28.403' AS DateTime), 5)
INSERT [dbo].[Transaction] ([TransactionId], [TransactionTypeId], [Amount], [TransactionDate], [AccountId]) VALUES (2, 1, CAST(100 AS Decimal(18, 0)), CAST(N'2017-05-29T00:42:32.257' AS DateTime), 5)
INSERT [dbo].[Transaction] ([TransactionId], [TransactionTypeId], [Amount], [TransactionDate], [AccountId]) VALUES (3, 2, CAST(50 AS Decimal(18, 0)), CAST(N'2017-05-29T00:45:12.383' AS DateTime), 5)
INSERT [dbo].[Transaction] ([TransactionId], [TransactionTypeId], [Amount], [TransactionDate], [AccountId]) VALUES (4, 2, CAST(100 AS Decimal(18, 0)), CAST(N'2017-05-29T00:53:03.377' AS DateTime), 2)
INSERT [dbo].[Transaction] ([TransactionId], [TransactionTypeId], [Amount], [TransactionDate], [AccountId]) VALUES (5, 2, CAST(100 AS Decimal(18, 0)), CAST(N'2017-05-29T03:02:01.510' AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[Transaction] OFF
SET IDENTITY_INSERT [dbo].[TransactionType] ON 

INSERT [dbo].[TransactionType] ([TypeId], [TypeCode], [TypeName]) VALUES (1, N'Deposit', N'Deposit')
INSERT [dbo].[TransactionType] ([TypeId], [TypeCode], [TypeName]) VALUES (2, N'Withdraw', N'Withdraw')
SET IDENTITY_INSERT [dbo].[TransactionType] OFF
/****** Object:  Index [UK_Account]    Script Date: 29-May-17 3:11:37 AM ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [UK_Account] UNIQUE NONCLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountStatus] FOREIGN KEY([AccountStatusId])
REFERENCES [dbo].[AccountStatus] ([StatusId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountStatus]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Branch] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([BranchId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Branch]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Customer]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Account]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_TransactionType] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionType] ([TypeId])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_TransactionType]
GO
