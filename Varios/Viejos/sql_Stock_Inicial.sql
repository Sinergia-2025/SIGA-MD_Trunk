ALTER TABLE dbo.ProductosSucursales ADD
	StockInicial decimal(10, 2) NULL;

----------------------------------------------------

Update ProductosSucursales SET stock=0
  where stock is null;


Update ProductosSucursales SET
 StockInicial=Stock;


UPDATE ProductosSucursales 
 SET ProductosSucursales.StockInicial = ProductosSucursales.StockInicial
       + ( select sum(cantidad) from MovimientosComprasProductos b
            where ProductosSucursales.idproducto=b.idproducto
          )
 where ProductosSucursales.idsucursal=1
   AND EXISTS 
     ( SELECT * FROM MovimientosComprasProductos MCP
       WHERE MCP.idproducto=ProductosSucursales.idproducto
         AND MCP.idsucursal=1
     )
;

UPDATE ProductosSucursales
 SET ProductosSucursales.StockInicial = ProductosSucursales.StockInicial
      + ( select sum(cantidad) from MovimientosVentasProductos b
           where ProductosSucursales.idproducto=b.idproducto
         )
 where ProductosSucursales.idsucursal=1
   AND EXISTS 
     ( SELECT * FROM MovimientosVentasProductos MVP
       WHERE MVP.idproducto=ProductosSucursales.idproducto
         AND MVP.idsucursal=1
     )
;


----------------------------------------------------



select a.idproducto, a.StockInicial, a.Stock, b.Saldo, c.Saldo from
 ProductosSucursales a
LEFT JOIN  ( select idproducto, sum(cantidad) as Saldo from dbo.MovimientosComprasProductos
      where IdSucursal=1 group by idproducto) b ON b.IdProducto= a.IdProducto
LEFT JOIN ( select idproducto, sum(cantidad) as Saldo from dbo.MovimientosVentasProductos
      where IdSucursal=1 group by idproducto) c ON c.IdPRoducto = a.IdProducto
 
WHERE a.IdSucursal=1
 and (a.StockInicial<>0 or a.Stock<>0 or  b.Saldo<>0 or c.Saldo<>0)