
INSERT INTO TiposImpuestos
    (IdTipoImpuesto, NombreTipoImpuesto, Tipo, idCuentaDebe, idCuentaHaber)
 VALUES
    ('RSELL', 'Sellado No Fiscal', 'RETENCION', NULL, NULL)
GO

INSERT INTO Impuestos
     (IdTipoImpuesto, Alicuota, Activo)
  VALUES
     ('RSELL', 0, 'True')
GO


