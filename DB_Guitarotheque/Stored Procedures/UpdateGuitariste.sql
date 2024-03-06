CREATE PROCEDURE [dbo].[UpdateGuitariste]
    @Id_Guitariste INT,
    @Nom NVARCHAR(50),
    @Prenom NVARCHAR(50),
    @DateNaiss DATE,
    @Guitares TGuitareId READONLY
AS
BEGIN
    DECLARE @Count INT = (SELECT COUNT(*) FROM @Guitares);

    BEGIN TRANSACTION UpdateGuitariste;

    IF @Count >= 0
    BEGIN
        BEGIN TRY
            -- Mettre à jour les informations du guitariste
            UPDATE [Guitaristes]
            SET
                Nom = @Nom,
                Prenom = @Prenom,
                DateNaiss = @DateNaiss
            WHERE
                Id_Guitaristes = @Id_Guitariste;

            -- Supprimer toutes les associations de guitares existantes pour ce guitariste
            DELETE FROM [MM_Guitariste_Guitare]
            WHERE
                Id_Guitaristes = @Id_Guitariste;

            -- Insérer les nouvelles associations de guitares pour ce guitariste
            INSERT INTO [MM_Guitariste_Guitare] (Id_Guitaristes, Id_Guitares)
            SELECT @Id_Guitariste, GuitareId
            FROM @Guitares;

            COMMIT TRANSACTION UpdateGuitariste;
        END TRY
        BEGIN CATCH
            DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
            DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
            DECLARE @ErrorState INT = ERROR_STATE();
            ROLLBACK TRANSACTION UpdateGuitariste;

            RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
            RETURN;
        END CATCH
    END
    ELSE
    BEGIN
        -- Aucune guitare à associer, annuler la transaction
        ROLLBACK TRANSACTION UpdateGuitariste;
    END
END