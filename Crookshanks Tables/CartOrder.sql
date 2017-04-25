USE [Crookshanks]
GO

/****** Object:  Table [dbo].[CartOrder]    Script Date: 4/24/2017 7:40:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CartOrder](
	[CartOrderId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL
) ON [PRIMARY]

GO

