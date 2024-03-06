CREATE PROCEDURE [dbo].[GetAllGuitaristes]
    
AS
BEGIN
SELECT
        MAX(Id_Guitaristes) AS Id_Guitaristes,
        Nom,
        Prenom,
        DateNaiss
    FROM
        Guitaristes
    GROUP BY
        Nom,
        Prenom,
        DateNaiss;
END
