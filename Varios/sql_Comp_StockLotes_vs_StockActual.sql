SELECT P.IdProducto AS Codigo
      ,P.NombreProducto AS Producto
      ,M.NombreMarca AS Marca
      ,R.NombreRubro AS Rubro
      ,PS.Stock
      ,Lotes.StockLote
 FROM ProductosSucursales PS
 LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto
 LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca
 LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro
 LEFT JOIN (SELECT PL.IdProducto, SUM(PL.CantidadActual) AS StockLote
              FROM ProductosLotes AS PL
             WHERE PL.IdSucursal = 1
          GROUP BY PL.IdProducto
            ) Lotes ON Lotes.IdProducto = PS.IdProducto

  WHERE PS.IdSucursal = 1
--    AND P.Activo = 'True'
--    AND P.AfectaStock = 'True'
--    AND PS.Stock <= 0
      AND PS.Stock<>Lotes.StockLote
 ORDER BY P.IdProducto
         ,P.NombreProducto
