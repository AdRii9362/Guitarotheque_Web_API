CREATE TABLE [dbo].[MM_Guitariste_Groupe] (
    [Id_Guitaristes] INT NOT NULL,
    [Id_Groupes]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Guitaristes] ASC, [Id_Groupes] ASC),
    FOREIGN KEY ([Id_Groupes]) REFERENCES [dbo].[Groupes] ([Id_Groupes]),
    FOREIGN KEY ([Id_Guitaristes]) REFERENCES [dbo].[Guitaristes] ([Id_Guitaristes])
);

