USE [Crookshanks]
GO

/****** Object:  Table [dbo].[CartOrder]    Script Date: 4/25/2017 6:05:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CartOrder](
	[CartOrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL
) ON [PRIMARY]

GO

