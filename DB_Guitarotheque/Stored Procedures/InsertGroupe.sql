 
CREATE PROCEDURE [dbo].[InsertGroupe]
    @Nom NVARCHAR (50),
    @AnneeCreation INT,
    @Genre NVARCHAR(50)
AS
BEGIN
    INSERT INTO Groupes (Nom, AnneeCreation, Genre)
    VALUES (TRIM(@Nom), @AnneeCreation,TRIM(@Genre))
END