USE [Crookshanks]
GO

/****** Object:  Table [dbo].[LineItem]    Script Date: 4/25/2017 6:12:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LineItem](
	[LineItemId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CartOrderId] [int] NOT NULL
) ON [PRIMARY]

GO