
UPDATE dbo.TiposComprobantes 
   SET CantidadCopias = 1
 WHERE EsElectronico = 'True'
GO
