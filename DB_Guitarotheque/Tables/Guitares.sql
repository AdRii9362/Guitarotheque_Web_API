CREATE TABLE [dbo].[Guitares] (
    [Id_Guitares]   INT            IDENTITY (1, 1) NOT NULL,
    [NbrCordes]     INT            NOT NULL,
    [AnneeDeSortie] INT            NOT NULL,
    [Libelle]       NVARCHAR (50)  NOT NULL,
    [Description]   NVARCHAR (500) NOT NULL,
    [Prix]          DECIMAL (9, 2) NOT NULL,
    [UrlImage]      NVARCHAR (200) DEFAULT ('default.jpg') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Guitares] ASC)
);

