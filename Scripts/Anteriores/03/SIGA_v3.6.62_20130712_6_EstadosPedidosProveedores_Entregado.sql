
INSERT INTO EstadosPedidosProveedores
    (idEstado, IdTipoComprobante, IdTipoEstado, Orden)
 SELECT 'ENTREGADO', NULL, 'ENTREGADO', Orden FROM EstadosPedidosProveedores
  WHERE IdEstado = 'FINALIZADO'
GO

UPDATE EstadosPedidosProveedores 
   SET Orden = Orden + 1
 WHERE IdEstado = 'ENTREGADO'
GO

UPDATE EstadosPedidosProveedores 
   SET Orden = (SELECT MAX(Orden) + 10 FROM EstadosPedidosProveedores)
 WHERE IdEstado = 'CANCELADO'
GO
