
-- Unifica Numeracion de Comprobantes
UPDATE VentasNumeros
   SET IdTipoComprobanteRelacionado = 'eNDEBCHEQRECH'
 WHERE IdTipoComprobante = 'eNDEB'
GO
