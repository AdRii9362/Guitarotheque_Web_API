 
CREATE PROCEDURE InsertMarque
    @Nom NVARCHAR(50),
	@SiegeSocial NVARCHAR(100),
	@Description NVARCHAR(500)

AS
BEGIN
    INSERT INTO Marques(Nom,SiegeSocial,Description)
    VALUES (TRIM(@Nom), TRIM(@SiegeSocial),TRIM(@Description))
END

