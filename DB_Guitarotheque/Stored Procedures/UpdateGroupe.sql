
CREATE PROCEDURE [dbo].[UpdateGroupe]
    @Id_Groupe INT,
    @Nom NVARCHAR (50),
    @AnneeCreation INT,
    @Genre NVARCHAR(50)
AS
BEGIN
    UPDATE [Groupes]
    SET
        Nom = @Nom,
        AnneeCreation = @AnneeCreation,
        Genre = @Genre
    WHERE
        Id_Groupes = @Id_Groupe
END