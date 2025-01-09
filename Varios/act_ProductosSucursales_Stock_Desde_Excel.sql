
-- Actualizo El Stock con el Stock que se importo desde un Excel

UPDATE ProductosSucursales 
   SET ProductosSucursales.StockInicial = Stk.Stock
 FROM ProductosSucursales PS
 INNER JOIN ProductoStock Stk ON Stk.IdProducto = PS.IdProducto
-- WHERE V.Direccion IS NULL
GO
