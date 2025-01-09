
ALTER TABLE TiposImpuestos ADD AplicativoAfip varchar(20) null
GO

UPDATE TiposImpuestos 
   SET AplicativoAfip = 'SICORE' 
 WHERE IdTipoImpuesto = 'RGANA' OR IdTipoImpuesto = 'RIVA'
GO

UPDATE TiposImpuestos 
   SET AplicativoAfip = 'SIPRIB' 
 WHERE IdTipoImpuesto = 'RIIBB' 
GO
