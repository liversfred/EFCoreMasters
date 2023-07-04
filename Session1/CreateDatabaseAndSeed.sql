IF DB_ID('Frederick.EFCoreMasters.Session01') IS NOT NULL
   RETURN

CREATE DATABASE [Frederick.EFCoreMasters.Session01]
GO

USE [Frederick.EFCoreMasters.Session01]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Create Shops Table */
CREATE TABLE [dbo].[Shops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/* Create Tags Table */
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/* Create Products Table */
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShopId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/* Create Reviews Table */
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ReviewerName] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[NumberOfStars] [tinyint] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/* Populate Shops Table */
INSERT [dbo].[Shops] ([Name]) VALUES (N'Shop A')
INSERT [dbo].[Shops] ([Name]) VALUES (N'Shop B')
INSERT [dbo].[Shops] ([Name]) VALUES (N'Shop C')
GO

/* Populate Tags Table */
INSERT [dbo].[Tags] ([Name]) VALUES (N'Tag A')
INSERT [dbo].[Tags] ([Name]) VALUES (N'Tag B')
INSERT [dbo].[Tags] ([Name]) VALUES (N'Tag C')
GO

/* Populate Products Table */
INSERT [dbo].[Products] ([Name], [ShopId]) VALUES (N'Product A', 1)
INSERT [dbo].[Products] ([Name], [ShopId]) VALUES (N'Product B', 2)
INSERT [dbo].[Products] ([Name], [ShopId]) VALUES (N'Product C', 3)
INSERT [dbo].[Products] ([Name], [ShopId]) VALUES (N'Product D', 1)
INSERT [dbo].[Products] ([Name], [ShopId]) VALUES (N'Product E', 2)
GO

/* Populate Reviews Table */
INSERT [dbo].[Reviews] ([ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (1, N'Review A', N'This is the comment from reviewer A', 3)
INSERT [dbo].[Reviews] ([ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (2, N'Review B', N'This is the comment from reviewer B', 4)
INSERT [dbo].[Reviews] ([ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (3, N'Review C', N'This is the comment from reviewer C', 5)
INSERT [dbo].[Reviews] ([ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (4, N'Review D', N'This is the comment from reviewer D', 2)
INSERT [dbo].[Reviews] ([ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (5, N'Review E', N'This is the comment from reviewer E', 1)
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Shops_ShopId] FOREIGN KEY([ShopId]) REFERENCES [dbo].[Shops] ([Id])
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Shops_ShopId]
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products_ProductId]
GO