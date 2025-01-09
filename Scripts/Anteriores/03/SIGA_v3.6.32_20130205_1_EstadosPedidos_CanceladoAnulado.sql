

UPDATE PedidosEstados 
   SET idEstado = 'ANULADO'
 WHERE idEstado = 'CANCELADO'
GO

 
UPDATE EstadosPedidos
   SET idEstado = 'ANULADO'
 WHERE idEstado = 'CANCELADO'
GO
