
UPDATE PedidosEstadosProveedores
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE PedidosProductosProveedores
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE PedidosEstados
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE PedidosProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE Alquileres
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE AlquileresTarifasProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

--DELETE ProductosProveedores
-- WHERE IdProducto = '43456  613'
--GO

UPDATE ProductosProveedores
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProduccionProductosComponentes
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProduccionProductosComponentes
   SET IdProductoComponente = '43456-613'
 WHERE IdProductoComponente = '43456  613'
GO

UPDATE ProduccionProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProductosComponentes
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProductosComponentes
   SET IdProductoComponente = '43456-613'
 WHERE IdProductoComponente = '43456  613'
GO

UPDATE RecepcionNotasF
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE RecepcionNotas
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE HistorialPrecios
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE MovimientosComprasProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ComprasProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE MovimientosVentasProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE VentasProductosLotes
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE VentasProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE FichasProductos
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProductosNrosSerie
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProductosLotes
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

UPDATE ProductosNrosSerie
   SET IdProducto = '43456-613'
 WHERE IdProducto = '43456  613'
GO

DELETE ProductosSucursalesPrecios
 WHERE IdProducto = '43456  613'
GO

DELETE ProductosSucursales
 WHERE IdProducto = '43456  613'
GO

DELETE Productos
 WHERE IdProducto = '43456  613'
GO

UPDATE ProductosSucursales SET
  Stock = StockInicial
 WHERE IdProducto = '43456-613'
GO

UPDATE ProductosSucursales 
 SET ProductosSucursales.Stock = ProductosSucursales.Stock
       + ( SELECT SUM(cantidad) FROM MovimientosComprasProductos b
            WHERE ProductosSucursales.idproducto = b.idproducto
              AND B.idsucursal IN (1, 2)
          )
 WHERE ProductosSucursales.idsucursal = 1
   AND EXISTS 
     ( SELECT * FROM MovimientosComprasProductos MCP
       WHERE MCP.idproducto = ProductosSucursales.idproducto
         AND MCP.idsucursal IN (1, 2)
     )
   AND IdProducto = '43456-613'
GO


UPDATE ProductosSucursales
 SET ProductosSucursales.Stock = ProductosSucursales.Stock
      + ( SELECT sum(cantidad) from MovimientosVentasProductos b
           WHERE ProductosSucursales.idproducto=b.idproducto
             AND b.idsucursal IN (1, 2)
         )
 where ProductosSucursales.idsucursal=1
   AND EXISTS 
     ( SELECT * FROM MovimientosVentasProductos MVP
       WHERE MVP.idproducto=ProductosSucursales.idproducto
         AND MVP.idsucursal IN (1, 2)
     )
   AND IdProducto = '43456-613'
GO


SELECT * FROM Productos 
 WHERE IdProducto IN ('43456  613','43456-613')
GO
