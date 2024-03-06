 
CREATE PROCEDURE InsertGuitare
    @NbrCordes INT,
    @AnneeDeSortie INT,
    @Libelle NVARCHAR(50),
	@Description NVARCHAR(500),
	@Prix DECIMAL(9,2)
AS
BEGIN
    INSERT INTO Guitares(NbrCordes, AnneeDeSortie, Libelle,Description,Prix)
    VALUES (@NbrCordes,@AnneeDeSortie, TRIM(@Libelle), TRIM(@Description), @Prix)
END

