
ALTER TABLE dbo.Retenciones ADD IdLocalidad int NULL
GO

UPDATE R
   SET IdLocalidad = C.IdLocalidad
  FROM Retenciones R
 INNER JOIN Clientes C ON C.IdCliente = R.IdCliente
 WHERE R.IdTipoImpuesto = 'RDREI'

ALTER TABLE dbo.Retenciones ADD CONSTRAINT FK_Retenciones_Localidades
    FOREIGN KEY (IdLocalidad) 
    REFERENCES dbo.Localidades (IdLocalidad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
