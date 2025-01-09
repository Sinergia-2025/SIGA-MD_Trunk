
-- Actualizo el Stock Inicial con el Stock (Final) de la base Anterior

UPDATE SIGA.dbo.ProductosSucursales 
   SET SIGA.dbo.ProductosSucursales.StockInicial = Final.Stock
  FROM SIGA.dbo.ProductosSucursales AS PS
 INNER JOIN SIGA_Anterior.dbo.ProductosSucursales AS Final ON Final.IdProducto = PS.IdProducto
                                                            AND Final.IdSucursal = 1
 WHERE PS.IdSucursal IN (1, 3)
GO
