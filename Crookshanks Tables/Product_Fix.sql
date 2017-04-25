USE [Crookshanks]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 4/25/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](255) NOT NULL,
	[ProductPrice] [int] NOT NULL
) ON [PRIMARY]

GO

