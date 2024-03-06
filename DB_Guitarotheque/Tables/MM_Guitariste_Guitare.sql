CREATE TABLE [dbo].[MM_Guitariste_Guitare] (
    [Id_Guitares]    INT NOT NULL,
    [Id_Guitaristes] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Guitares] ASC, [Id_Guitaristes] ASC),
    FOREIGN KEY ([Id_Guitares]) REFERENCES [dbo].[Guitares] ([Id_Guitares]),
    FOREIGN KEY ([Id_Guitaristes]) REFERENCES [dbo].[Guitaristes] ([Id_Guitaristes])
);

