 
CREATE PROCEDURE InsertAccessoire
    @Description NVARCHAR(500),
    @Libelle NVARCHAR(50),
    @Prix DECIMAL(15,2)
AS
BEGIN
    INSERT INTO Accessoires (Description, Libelle, Prix)
    VALUES (TRIM(@Description), TRIM(@Libelle), @Prix)
END

