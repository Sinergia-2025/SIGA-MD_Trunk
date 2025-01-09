
PRINT '1. Si tiene activo el parametro PRE-FActura Consume pedido lo aplico en TIposComprobantes'
;
IF EXISTS (SELECT 1 FROM Parametros WHERE IdParametro = 'PREFACTURACONSUMEPEDIDOS' AND ValorParametro = 'True')
  UPDATE TiposComprobantes SET ConsumePedidos = 'True' WHERE IdTipoComprobante = 'ePRE-FACT'
;

PRINT '2. Actualizo a TRUE Parametro: FacturarPedidoSeleccionado'
;
UPDATE Parametros
   SET ValorParametro = 'True'
 WHERE IdParametro = 'FACTURARPEDIDOSELECCIONADO'
;
