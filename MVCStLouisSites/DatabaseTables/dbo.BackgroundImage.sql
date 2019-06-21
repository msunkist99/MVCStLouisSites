CREATE TABLE [dbo].[BackgroundImage] (
    [Id]                          INT            IDENTITY (1, 1) NOT NULL,
    [BackgroundImageFileName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BackgroundImage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

