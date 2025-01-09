UPDATE SIGA.dbo.ProductosSucursales
   SET StockInicial = PSo.Stock
      ,Stock = PSd.Stock + PSo.Stock
  FROM SIGA_Monotributo.dbo.ProductosSucursales PSo
 INNER JOIN SIGA.dbo.ProductosSucursales PSd ON PSd.IdSucursal = PSo.IdSucursal
                                            AND PSd.IdProducto = PSo.IdProducto
