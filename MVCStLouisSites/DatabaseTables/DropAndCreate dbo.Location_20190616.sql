USE [MVCStLouisSites]
GO

/****** Object: Table [dbo].[Location] Script Date: 6/16/2019 5:44:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Location];


GO
CREATE TABLE [dbo].[Location] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [StreetAddress]  NVARCHAR (MAX) NULL,
    [City]           NVARCHAR (MAX) NULL,
    [State]          NVARCHAR (MAX) NULL,
    [Zip]            NVARCHAR (MAX) NULL,
    [County]         NVARCHAR (MAX) NULL,
    [NeighborhoodId] INT            NOT NULL,
    [GPS]            NVARCHAR (MAX) NULL,
    [AttractionId]   INT            NOT NULL
);


