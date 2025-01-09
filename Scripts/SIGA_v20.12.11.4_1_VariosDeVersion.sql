
UPDATE VentasProductos
   SET CantidadManual = Cantidad
     , Conversion = 1
 WHERE CantidadManual = 0

UPDATE VentasProductos
   SET CantidadManual = CantidadManual * -1
 WHERE Cantidad < 0
   AND CantidadManual > 0

UPDATE VP
   SET VP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM VentasProductos VP
 INNER JOIN Productos P ON P.IdProducto = VP.IdProducto
 WHERE ISNULL(VP.IdUnidadDeMedida, '') = ''


UPDATE PedidosProductos
   SET CantidadManual = Cantidad
     , Conversion = 1
 WHERE CantidadManual = 0

UPDATE PedidosProductos
   SET CantidadManual = CantidadManual * -1
 WHERE Cantidad < 0
   AND CantidadManual > 0

UPDATE VP
   SET VP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM PedidosProductos VP
 INNER JOIN Productos P ON P.IdProducto = VP.IdProducto
 WHERE ISNULL(VP.IdUnidadDeMedida, '') = ''
