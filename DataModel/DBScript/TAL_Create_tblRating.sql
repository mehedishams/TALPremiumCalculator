USE [TAL]
GO

/****** Object:  Table [dbo].[tblRating]    Script Date: 15/11/2021 09:04:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblRating](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[RatingName] [varchar](50) NULL,
	[Factor] [decimal](3, 2) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_tblRating] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblRating] ADD  CONSTRAINT [DF_tblRating_CreatedBy]  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[tblRating] ADD  CONSTRAINT [DF_tblRating_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

