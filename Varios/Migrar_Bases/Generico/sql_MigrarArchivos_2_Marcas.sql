
SELECT COUNT(*) FROM Marcas
GO

MERGE INTO Marcas AS P
     USING MO_SIGA.dbo.Marcas AS PT
        ON P.IdMarca = PT.IdMarca
 WHEN NOT MATCHED THEN
    INSERT (   IdMarca,    NombreMarca,    ComisionPorVenta)
    VALUES (PT.IdMarca, PT.NombreMarca, PT.ComisionPorVenta)
;

SELECT COUNT(*) FROM Marcas
GO

SELECT * FROM Marcas
GO
