CREATE PROCEDURE [dbo].[DeleteGuitariste]
    @id INT
AS
BEGIN
    -- Vérifier s'il existe des associations dans la table MM_Guitariste_Guitare
    IF EXISTS (SELECT 1 FROM MM_Guitariste_Guitare WHERE Id_Guitaristes = @id)
    BEGIN
        -- Supprimer les associations dans la table MM_Guitariste_Guitare
        DELETE FROM MM_Guitariste_Guitare WHERE Id_Guitaristes = @id;
    END

    -- Supprimer le guitariste dans la table Guitaristes
    DELETE FROM Guitaristes WHERE Id_Guitaristes = @id;
END