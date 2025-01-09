
DECLARE @Suc1 int = 1
DECLARE @Suc2 int = ISNULL((SELECT IdSucursalAsociada FROM Sucursales WHERE Id = @suc1), @Suc1)

PRINT @Suc1 
PRINT @Suc2

/* Actualiza el Stock Actual */


UPDATE ProductosSucursales 
   SET --StockInicial = 0   ---- NO toco STock inicial porque podria tener valor de una depuracion de movimientos.
    Stock = StockInicial		---0
 WHERE IdSucursal IN (@Suc1, @Suc2)
;

UPDATE ProductosSucursales 
   SET ProductosSucursales.Stock = ProductosSucursales.Stock
      + ( SELECT SUM(cantidad) FROM MovimientosComprasProductos b
            WHERE ProductosSucursales.idproducto = b.idproducto
              AND B.idsucursal IN (@Suc1, @Suc2)
          )
 WHERE ProductosSucursales.idsucursal = @Suc1
   AND EXISTS 
     ( SELECT * FROM MovimientosComprasProductos MCP
       WHERE MCP.idproducto = ProductosSucursales.idproducto
         AND MCP.idsucursal IN (@Suc1, @Suc2)
     )
;

UPDATE ProductosSucursales
   SET ProductosSucursales.Stock = ProductosSucursales.Stock
      + ( SELECT sum(cantidad) from MovimientosVentasProductos b
           WHERE ProductosSucursales.idproducto=b.idproducto
             AND b.idsucursal IN (@Suc1, @Suc2)
         )
 where ProductosSucursales.idsucursal = @Suc1
   AND EXISTS 
     ( SELECT * FROM MovimientosVentasProductos MVP
       WHERE MVP.idproducto=ProductosSucursales.idproducto
         AND MVP.idsucursal IN (@Suc1, @Suc2)
     )
;

UPDATE ProductosSucursales 
 SET ProductosSucursales.Stock = 
        ( SELECT Stock FROM ProductosSucursales b
            WHERE ProductosSucursales.idproducto = b.idproducto
              AND B.idsucursal = @Suc1
          )
 WHERE ProductosSucursales.idsucursal = @Suc2
;


-- No hace falta filtrar sucursal porque nunca deberian tener stock por ser servicios.
UPDATE ProductosSucursales 
   SET StockInicial = 0
     , Stock = 0
  WHERE EXISTS 
     ( SELECT * FROM Productos P
        WHERE P.idproducto=ProductosSucursales.idproducto
          AND P.AfectaStock = 'False'
     )
;
