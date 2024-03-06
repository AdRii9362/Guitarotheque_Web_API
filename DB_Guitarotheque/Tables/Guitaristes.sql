CREATE TABLE [dbo].[Guitaristes] (
    [Id_Guitaristes] INT           IDENTITY (1, 1) NOT NULL,
    [Nom]            NVARCHAR (50) NOT NULL,
    [Prenom]         NVARCHAR (50) NOT NULL,
    [DateNaiss]      DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id_Guitaristes] ASC)
);

