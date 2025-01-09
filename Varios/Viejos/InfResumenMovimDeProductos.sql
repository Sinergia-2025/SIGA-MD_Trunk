SELECT M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto, SUM(A.Precio*A.Cantidad) AS ImporteNeto, SUM(A.Cantidad) as Cantidad
FROM
(
SELECT 
    Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + MCP.IdProducto,15) as IdProducto, Prod.NombreProducto, MCP.Precio, MCP.Cantidad
 FROM TiposMovimientos TM, Productos Prod, MovimientosComprasProductos MCP, MovimientosCompras MC 
 LEFT OUTER JOIN TiposComprobantes TC ON MC.IdTipoComprobante = TC.IdTipoComprobante 
 LEFT OUTER JOIN Sucursales S ON MC.IdSucursal2 = S.IdSucursal 

  WHERE MC.IdTipoMovimiento = TM.IdTipoMovimiento 
    AND MC.IdSucursal = MCP.IdSucursal 
    AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento 
    AND MC.NumeroMovimiento = MCP.NumeroMovimiento 
    AND MCP.IdProducto = Prod.IdProducto 
    AND MC.IdSucursal = 1
    AND CONVERT(varchar(11), MC.FechaMovimiento, 120) >= '2010-07-01'
    AND CONVERT(varchar(11), MC.FechaMovimiento, 120) <= '2010-07-31'

UNION ALL

SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + MVP.IdProducto,15) as IdProducto, Prod.NombreProducto, MVP.Precio,MVP.Cantidad

 FROM TiposMovimientos TM, Productos Prod, MovimientosVentasProductos MVP, MovimientosVentas MV 
 LEFT OUTER JOIN TiposComprobantes TC ON MV.IdTipoComprobante = TC.IdTipoComprobante 

  WHERE MV.IdTipoMovimiento = TM.IdTipoMovimiento 
    AND MV.IdSucursal = MVP.IdSucursal 
    AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento 
    AND MV.NumeroMovimiento = MVP.NumeroMovimiento 
    AND MVP.IdProducto = Prod.IdProducto 
    AND MV.IdSucursal = 1
    AND CONVERT(varchar(11), MV.FechaMovimiento, 120) >= '2010-07-01'
    AND CONVERT(varchar(11), MV.FechaMovimiento, 120) <= '2010-07-31'
) A, Marcas M, Rubros R
 WHERE A.IdMarca = M.IdMarca
  AND A.IdRubro = R.IdRubro
 GROUP BY M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto
 ORDER BY M.NombreMarca, R.NombreRubro, A.NombreProducto
  
