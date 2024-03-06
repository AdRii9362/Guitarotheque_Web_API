CREATE PROCEDURE [dbo].[InsertGuitariste]
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@DateNaiss DATE,
	@Guitares TGuitareId READONLY
AS
BEGIN
	DECLARE @Count INT = (SELECT COUNT(*) FROM @Guitares);

	BEGIN TRANSACTION AddGuitariste;

	IF @Count > 0
	BEGIN
		BEGIN TRY
			DECLARE @GuitaristeId INT;
			-- J'insère mon guitariste dans la table Guitariste
			INSERT INTO Guitaristes(Nom, Prenom, DateNaiss) VALUES (@Nom, @Prenom, @DateNaiss);
			-- Je récupère l'id du guitariste qui a été généré (identity)
			SET @GuitaristeId = SCOPE_IDENTITY();

			-- J'insère les associations entre le guitariste et les guitares
			INSERT INTO MM_Guitariste_Guitare(Id_Guitaristes, Id_Guitares)
			SELECT @GuitaristeId, GuitareId
			FROM @Guitares;

			COMMIT TRANSACTION InsertGuitariste;
		END TRY
		BEGIN CATCH
			DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
			DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
			DECLARE @ErrorState INT = ERROR_STATE();
			ROLLBACK TRANSACTION AddGuitariste;

			RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
			RETURN;
		END CATCH
	END
	ELSE
	BEGIN
		-- Aucune guitare à associer, annuler la transaction
		ROLLBACK TRANSACTION AddGuitariste;
	END
END;