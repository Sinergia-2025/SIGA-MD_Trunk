
-- Para usar como nombre de solapa en la nueva alerta de SiLIVE

UPDATE Parametros
   SET CategoriaParametro = 'Pedidos'
 WHERE IdParametro IN ('PEDIDOSPERMITEFECHAENTREGADISTINTAS', 'FACTURARPEDIDOSELECCIONADO', 'PREFACTURACONSUMEPEDIDOS')
;
