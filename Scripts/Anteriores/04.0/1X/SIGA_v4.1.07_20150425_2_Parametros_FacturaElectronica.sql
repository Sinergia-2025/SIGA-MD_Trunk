
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTELECTSOURCE', 'C=AR, O=RAZON SOCIAL, SERIALNUMBER=CUIT 33123456781, CN=NOMBRE PC', NULL, 'Origen')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTELECTDESTINATION', 'cn=wsaahomo,o=afip,c=ar,serialNumber=CUIT 33123456781', NULL, 'Destino')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTELECUNIQUEID', '1', NULL, 'Identificacion')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTELECSERVICE', 'wsfe', NULL, 'Servicio')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTELECTGENERATIONTIME', GETDATE(), NULL, 'Fecha Generacion')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTELECTEXPIRATIONTIME', GETDATE(), NULL, 'Fecha Expiracion')
GO

