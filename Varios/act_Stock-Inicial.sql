
--El stock inicial podria tener valor.


PRINT ''
PRINT '1. Calculo Stock Inicial con el Valor que tiene ahora + (mas) las Compras.'
GO
UPDATE ProductosSucursales 
 SET ProductosSucursales.StockInicial = ProductosSucursales.StockInicial + 
        ( SELECT SUM(cantidad) FROM MovimientosComprasProductos b
            WHERE ProductosSucursales.idproducto = b.idproducto
          )
 WHERE ProductosSucursales.idsucursal = 1
   AND EXISTS 
     ( SELECT * FROM MovimientosComprasProductos MCP
       WHERE MCP.idproducto = ProductosSucursales.idproducto
         AND MCP.idsucursal IN (1, 2)
     )
GO

PRINT ''
PRINT '2. Calculo Stock Inicial con el Valor que tiene ahora - (menos) las Ventas. '
--Nota: El campo Cantidad ya tiene el simbolo negativo si es venta.
GO
UPDATE ProductosSucursales
 SET ProductosSucursales.StockInicial = ProductosSucursales.StockInicial + 
      ( SELECT sum(cantidad) from MovimientosVentasProductos b
           WHERE ProductosSucursales.idproducto=b.idproducto
         )
 where ProductosSucursales.idsucursal=1
   AND EXISTS 
     ( SELECT * FROM MovimientosVentasProductos MVP
       WHERE MVP.idproducto=ProductosSucursales.idproducto
         AND MVP.idsucursal IN (1, 2)
     )
GO

PRINT ''
PRINT '3. Calculo Stock Inicial con el Valor que tiene el Stock Actual - (menos) el valor Calculado para que quede la diferencia.'
GO
UPDATE ProductosSucursales
   SET ProductosSucursales.StockInicial = ProductosSucursales.Stock - ProductosSucursales.StockInicial
 WHERE ProductosSucursales.idsucursal=1
GO


PRINT ''
PRINT '4. Copio el Valor de la Sucursal 1 a la 2.'
GO
UPDATE ProductosSucursales 
 SET ProductosSucursales.StockInicial = 
        ( SELECT StockInicial FROM ProductosSucursales b
            WHERE ProductosSucursales.idproducto = b.idproducto
              AND B.idsucursal = 1
          )
 WHERE ProductosSucursales.idsucursal = 2
GO

/* -------------- */

PRINT ''
PRINT '5. Dejo en cero los productos de Servicios.'
GO
UPDATE ProductosSucursales SET 
   StockInicial = 0
   , Stock = 0
 WHERE EXISTS 
     ( SELECT * FROM Productos P
        WHERE P.idproducto=ProductosSucursales.idproducto
          AND P.AfectaStock = 'False'
     )
GO
