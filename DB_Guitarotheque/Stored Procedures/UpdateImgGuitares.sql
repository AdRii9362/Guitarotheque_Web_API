CREATE PROCEDURE [dbo].[UpdateImgGuitares]
    @Id_Guitare INT,
    @UrlImage NVARCHAR(200)
AS
BEGIN
    UPDATE [Guitares]
    SET
        UrlImage = @UrlImage
    WHERE
        Id_Guitares = @Id_Guitare
END