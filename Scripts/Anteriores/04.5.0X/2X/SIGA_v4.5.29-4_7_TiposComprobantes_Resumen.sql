
UPDATE TiposComprobantes
   SET AfectaCaja = 'True'
      ,ActualizaCtaCte = 'True'
 WHERE IdTipoComprobante IN ('RES-BANCARIO','RES-TARJETA')
GO

