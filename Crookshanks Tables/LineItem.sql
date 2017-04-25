USE [Crookshanks]
GO

/****** Object:  Table [dbo].[LineItem]    Script Date: 4/24/2017 7:45:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LineItem](
	[LineItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CartOrderId] [int] NOT NULL
) ON [PRIMARY]

GO

