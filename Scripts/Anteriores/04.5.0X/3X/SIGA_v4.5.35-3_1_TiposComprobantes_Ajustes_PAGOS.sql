
UPDATE TiposComprobantes
   SET EsRecibo = 'True'
 WHERE IdtipoComprobante IN ('PAGO','PAGOPROV')
GO
