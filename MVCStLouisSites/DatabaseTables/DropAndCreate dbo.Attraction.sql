USE [MVCStLouisSites]
GO

/****** Object: Table [dbo].[Attraction] Script Date: 6/9/2019 2:30:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Attraction];


GO
CREATE TABLE [dbo].[Attraction] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NULL,
    [Description]       NVARCHAR (MAX) NULL,
    [BackgroundImageId] INT            NOT NULL,
    [IconImageId]       INT            NOT NULL
);


