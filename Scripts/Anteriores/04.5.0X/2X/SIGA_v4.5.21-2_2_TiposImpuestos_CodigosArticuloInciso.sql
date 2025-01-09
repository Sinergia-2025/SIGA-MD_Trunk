
ALTER TABLE TiposImpuestos ADD CodigoArticuloInciso varchar(5) null
GO

ALTER TABLE TiposImpuestos ADD ArticuloInciso varchar(5) null
GO

UPDATE TiposImpuestos 
  SET CodigoArticuloInciso = '29'
     ,ArticuloInciso = '3'
 WHERE IdTipoImpuesto = 'PIIBB'
GO

UPDATE TiposImpuestos 
  SET CodigoArticuloInciso = '11'
     ,ArticuloInciso = '2'
 WHERE IdTipoImpuesto = 'RIIBB'
GO
