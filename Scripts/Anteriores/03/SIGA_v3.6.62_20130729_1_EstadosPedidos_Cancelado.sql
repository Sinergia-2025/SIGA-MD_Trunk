
UPDATE EstadosPedidos
   SET Orden = (SELECT MAX(Orden) + 10 FROM EstadosPedidosProveedores)
 WHERE IdEstado = 'CANCELADO'
GO
