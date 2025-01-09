SELECT P.IdProducto AS Codigo
      ,PS.IdSucursal
      ,P.NombreProducto AS Producto
      ,PS.Stock - (CASE WHEN Lotes.StockLote IS NULL THEN 0 ELSE Lotes.StockLote END) AS Generar
 FROM ProductosSucursales PS
 LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto
 LEFT JOIN (SELECT PL.IdSucursal, PL.IdProducto, SUM(PL.CantidadActual) AS StockLote
              FROM ProductosLotes AS PL
          GROUP BY PL.IdSucursal, PL.IdProducto
            ) Lotes ON Lotes.IdProducto = PS.IdProducto AND  Lotes.IdSucursal = PS.IdSucursal

  WHERE PS.IdProducto = 'HH472HH'
    AND PS.IdSucursal IN (SELECT ID FROM Sucursales WHERE SoyLaCentral = 'True' OR IdSucursalAsociada IS NULL)
--    AND P.Activo = 'True'
--    AND P.AfectaStock = 'True'
    AND PS.Stock > 0
--      AND PS.Stock>Lotes.StockLote

