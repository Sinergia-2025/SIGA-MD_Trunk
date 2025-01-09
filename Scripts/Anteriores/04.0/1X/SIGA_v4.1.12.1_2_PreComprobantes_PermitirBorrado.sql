
UPDATE TiposComprobantes
  SET PuedeSerBorrado = 'True'
 WHERE EsPreElectronico = 'True'
GO
