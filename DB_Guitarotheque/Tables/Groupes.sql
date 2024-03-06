CREATE TABLE [dbo].[Groupes] (
    [Id_Groupes]    INT           IDENTITY (1, 1) NOT NULL,
    [Nom]           NVARCHAR (50) NOT NULL,
    [AnneeCreation] INT           NULL,
    [Genre]         NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_Groupes] ASC),
    UNIQUE NONCLUSTERED ([Nom] ASC)
);

