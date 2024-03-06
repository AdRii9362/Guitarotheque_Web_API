CREATE TABLE [dbo].[MM_Guit_Marq_Access] (
    [Id_Guitares]    INT NOT NULL,
    [Id_Marques]     INT NOT NULL,
    [Id_Accessoires] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Guitares] ASC, [Id_Marques] ASC, [Id_Accessoires] ASC),
    FOREIGN KEY ([Id_Accessoires]) REFERENCES [dbo].[Accessoires] ([Id_Accessoires]),
    FOREIGN KEY ([Id_Guitares]) REFERENCES [dbo].[Guitares] ([Id_Guitares]),
    FOREIGN KEY ([Id_Marques]) REFERENCES [dbo].[Marques] ([Id_Marques])
);

