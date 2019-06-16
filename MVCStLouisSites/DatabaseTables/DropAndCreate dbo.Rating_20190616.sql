USE [MVCStLouisSites]
GO

/****** Object: Table [dbo].[Rating] Script Date: 6/16/2019 5:45:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Rating];


GO
CREATE TABLE [dbo].[Rating] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Number]        INT            NOT NULL,
    [Comments]      NVARCHAR (MAX) NULL,
    [AttractionId]  INT            NOT NULL,
    [DateTimeStamp] DATETIME2 (7)  NOT NULL
);


