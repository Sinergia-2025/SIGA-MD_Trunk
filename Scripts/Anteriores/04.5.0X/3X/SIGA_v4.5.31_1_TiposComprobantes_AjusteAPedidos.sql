
-- PEDIDO, PEDIDOPDA, PEDIDOPROV

UPDATE TiposComprobantes
  SET CargaPrecioActual = 'True'
 WHERE LEFT(IdTipoComprobante,6) = 'PEDIDO'
GO
