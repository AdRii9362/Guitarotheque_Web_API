CREATE TABLE [dbo].[Accessoires] (
    [Id_Accessoires] INT             IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (500)  NOT NULL,
    [Libelle]        NVARCHAR (50)   NOT NULL,
    [Prix]           DECIMAL (15, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Accessoires] ASC)
);

