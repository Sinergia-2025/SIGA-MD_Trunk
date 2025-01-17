--SISCAP Tiene Sucursales Asociadas

SELECT PS.IdProducto, PS.Stock, PS.StockInicial+Z.Suma2 AS Historico FROM ProductosSucursales PS,
(
SELECT IdProducto, SUM(Sumado) as Suma2 FROM
(
SELECT IdProducto, SUM(Cantidad) AS Sumado FROM MovimientosComprasProductos MCP
    WHERE MCP.IdSucursal IN (1, 2)
 GROUP BY IdProducto
UNION
SELECT IdProducto, SUM(Cantidad) AS Sumado FROM MovimientosVentasProductos MVP
    WHERE MVP.IdSucursal IN (1, 2)
 GROUP BY IdProducto
) a
 GROUP BY IdProducto
) Z
 WHERE PS.IdProducto = Z.IdProducto
    AND PS.IdSucursal = 1
    AND PS.Stock <> PS.StockInicial+Z.Suma2
GO


--SISCAP Tiene Sucursales Asociadas

--SELECT PS.IdSucursal, PS.IdProducto, PS.Stock, PS.StockInicial+Z.Suma2 AS Calculo FROM ProductosSucursales PS,
--(
--SELECT IdSucursal, IdProducto, SUM(Sumado) as Suma2 FROM
--(
--SELECT IdSucursal, IdProducto, SUM(Cantidad) AS Sumado FROM MovimientosComprasProductos
-- GROUP BY IdSucursal, IdProducto
--UNION
--SELECT IdSucursal, IdProducto, SUM(Cantidad) AS Sumado FROM MovimientosVentasProductos
-- GROUP BY IdSucursal, IdProducto
--) a
-- GROUP BY IdSucursal, IdProducto
--) Z
-- WHERE PS.IdSucursal = Z.IdSucursal
--    AND PS.IdProducto = Z.IdProducto
--GO



