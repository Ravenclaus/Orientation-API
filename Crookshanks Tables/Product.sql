USE [Crookshanks]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 4/24/2017 7:47:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](255) NOT NULL,
	[ProductPrice] [int] NOT NULL
) ON [PRIMARY]

GO

