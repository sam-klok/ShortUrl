USE [LifelongLearning]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShortenedUrls]') AND type in (N'U'))
DROP TABLE [dbo].[ShortenedUrls]
GO

CREATE TABLE [dbo].[ShortenedUrls](
	[Id] [varchar](7) NOT NULL PRIMARY KEY,
	[LongUrl] [varchar](8000) NOT NULL,
	[ShortUrl] [varchar](512) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[Hits] [int] DEFAULT ((0)) NOT NULL,
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [ShortUrl] ON [dbo].[ShortenedUrls]
(
	[ShortUrl] ASC
)
GO