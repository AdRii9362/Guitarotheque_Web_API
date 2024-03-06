
CREATE PROCEDURE UpdateMarque
    @Id_Marque INT,
    @Nom NVARCHAR(50),
	@SiegeSocial NVARCHAR(100),
	@Description NVARCHAR(500)
AS
BEGIN
    UPDATE [Marques]
    SET
        Nom = @Nom,
        SiegeSocial = @SiegeSocial,
        Description = @Description
		
    WHERE
        Id_Marques = @Id_Marque
END