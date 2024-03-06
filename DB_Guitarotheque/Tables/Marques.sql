CREATE TABLE [dbo].[Marques] (
    [Id_Marques]  INT            IDENTITY (1, 1) NOT NULL,
    [Nom]         NVARCHAR (50)  NOT NULL,
    [SiegeSocial] NVARCHAR (100) NULL,
    [Description] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id_Marques] ASC)
);

