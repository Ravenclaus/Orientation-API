USE [Crookshanks]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 4/24/2017 7:43:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NULL
) ON [PRIMARY]

GO

