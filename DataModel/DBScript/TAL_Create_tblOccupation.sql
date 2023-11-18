USE [TAL]
GO

/****** Object:  Table [dbo].[tblOccupation]    Script Date: 15/11/2021 09:03:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblOccupation](
	[OccupationId] [int] IDENTITY(1,1) NOT NULL,
	[OccupationName] [varchar](50) NULL,
	[RatingId] [int] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_tblOccupation] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblOccupation] ADD  CONSTRAINT [DF_tblOccupation_CreatedBy]  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[tblOccupation] ADD  CONSTRAINT [DF_tblOccupation_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[tblOccupation]  WITH CHECK ADD  CONSTRAINT [FK_tblOccupation_tblRating] FOREIGN KEY([RatingId])
REFERENCES [dbo].[tblRating] ([RatingId])
GO

ALTER TABLE [dbo].[tblOccupation] CHECK CONSTRAINT [FK_tblOccupation_tblRating]
GO

