
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'RECIBO'
 WHERE IdTipoComprobante = 'ANTICIPO'
GO
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'RECIBOPROV'
 WHERE IdTipoComprobante = 'ANTICIPOPROV'
GO

UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'ANTICIPO'
 WHERE IdTipoComprobante = 'RECIBO'
GO
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'ANTICIPOPROV'
 WHERE IdTipoComprobante = 'RECIBOPROV'
GO
