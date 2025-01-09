
INSERT INTO Impuestos
           (IdTipoImpuesto,Alicuota,Activo,IdCuentaCompras,IdCuentaVentas)
        SELECT CI.IdTipoImpuesto, CI.Alicuota, 1, NULL, NULL
          FROM (SELECT DISTINCT IdTipoImpuesto, Alicuota FROM ComprasImpuestos) CI
          LEFT JOIN Impuestos I ON I.IdTipoImpuesto = CI.IdTipoImpuesto AND I.Alicuota = CI.Alicuota
         WHERE I.Alicuota IS NULL
GO

SELECT * FROM Impuestos
 WHERE IdTipoImpuesto = 'PIIBB'
GO
