
CREATE PROCEDURE [dbo].[UpdateAccessoire]
    @Id_Accessoire INT,
    @Description NVARCHAR(500),
    @Libelle NVARCHAR(50),
    @Prix DECIMAL(15,2)
AS
BEGIN
    UPDATE [Accessoires]
    SET
        Description = @Description,
        Libelle = @Libelle,
        Prix = @Prix
    WHERE
        Id_Accessoires = @Id_Accessoire
END