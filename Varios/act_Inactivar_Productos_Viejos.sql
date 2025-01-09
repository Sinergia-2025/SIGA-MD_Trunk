
SELECT P.IdProducto, P.NombreProducto, P.IdMarca, M.NombreMarca, P.IdRubro, R.NombreRubro 
  FROM Productos P, Marcas M, Rubros R
 WHERE P.IdMarca = M.IdMarca
   AND P.IdRubro = R.IdRubro
--UPDATE Productos SET Activo = 'False'
   AND IdProducto NOT IN
(
SELECT DISTINCT MVP.IdProducto FROM MovimientosVentas MV, MovimientosVentasProductos MVP
   WHERE MV.IdSucursal = MVP.IdSucursal
     AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento
     AND MV.NumeroMovimiento = MVP.NumeroMovimiento
--     AND CONVERT(varchar(11), MV.FechaMovimiento, 120) >= '2009-11-01'

UNION

SELECT DISTINCT MCP.IdProducto FROM MovimientosCompras MC, MovimientosComprasProductos MCP
   WHERE MC.IdSucursal = MCP.IdSucursal
     AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
     AND MC.NumeroMovimiento = MCP.NumeroMovimiento
--     AND CONVERT(varchar(11), MC.FechaMovimiento, 120) >= '2009-11-01'

UNION

SELECT DISTINCT VP.IdProducto FROM Ventas v, VentasProductos VP
   WHERE V.IdSucursal = VP.IdSucursal
     AND V.IdTipoComprobante = VP.IdTipoComprobante
     AND V.Letra = VP.Letra
     AND V.CentroEmisor = VP.CentroEmisor
     AND V.NumeroComprobante = VP.NumeroComprobante
--     AND CONVERT(varchar(11), V.Fecha, 120) >= '2009-11-01'

--UNION

--SELECT DISTINCT FP.IdProducto FROM Fichas F, FichasProductos FP
--   WHERE F.IdSucursal = FP.IdSucursal
--     AND F.NroOperacion = FP.NroOperacion
--     AND F.TipoDocumento = FP.TipoDocumento
--     AND F.NroDocumento = FP.NroDocumento
----     AND CONVERT(varchar(11), F.FechaOperacion, 120) >= '2009-11-01'

)
--   AND IdProducto IN (SELECT IdProducto FROM Productos WHERE NombreProducto NOT LIKE '%/%')
