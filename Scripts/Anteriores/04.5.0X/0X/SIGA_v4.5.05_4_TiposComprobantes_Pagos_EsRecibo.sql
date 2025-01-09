
UPDATE TiposComprobantes
   SET EsRecibo = 'TRUE'
 WHERE IdTipoComprobante IN ('PAGO', 'PAGOPROV')
GO
