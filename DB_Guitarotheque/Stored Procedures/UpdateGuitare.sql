
CREATE PROCEDURE UpdateGuitare
    @Id_Guitare INT,
    @NbrCordes INT,
    @AnneeDeSortie INT,
    @Libelle NVARCHAR(50),
	@Description NVARCHAR(2000),
	@Prix DECIMAL(9,2)
AS
BEGIN
    UPDATE [Guitares]
    SET
        NbrCordes = @NbrCordes,
        AnneeDeSortie = @AnneeDeSortie,
        Libelle = @Libelle,
		Description = @Description,
		Prix = @Prix
    WHERE
        Id_Guitares = @Id_Guitare
END