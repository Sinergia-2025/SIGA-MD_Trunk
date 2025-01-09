--declare @Fecha date = '2019-09-28'
----select * FROM MovimientosComprasProductos MCP
----join MovimientosCompras MC
----	on MCP.NumeroMovimiento = MC.NumeroMovimiento
----	where FechaMovimiento >= @Fecha
----	AND Usuario != 'Admin'
--	--AND Observacion != '** AJUSTE AUTOMATICO ***'

--select * from MovimientosVentasProductos MVP
--join MovimientosVentas MV
--	on MVP.NumeroMovimiento = MV.NumeroMovimiento
--	where FechaMovimiento >= @Fecha
--	--AND Usuario != 'Admin'
--	--AND Observacion = '** AJUSTE AUTOMATICO ***'
--	order by FechaMovimiento


declare @Fecha date = '2019-09-28'
SELECT M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto, SUM(A.Precio*A.Cantidad) AS ImporteNeto, SUM(A.Cantidad) as Cantidad
		 FROM
         ( SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + MCP.IdProducto,15) as IdProducto, Prod.NombreProducto, MCP.Precio, MCP.Cantidad
         FROM TiposMovimientos TM, Productos Prod, MovimientosComprasProductos MCP, MovimientosCompras MC
         LEFT OUTER JOIN TiposComprobantes TC ON MC.IdTipoComprobante = TC.IdTipoComprobante
         LEFT OUTER JOIN Sucursales S ON MC.IdSucursal2 = S.IdSucursal
         LEFT OUTER JOIN Proveedores P ON MC.IdProveedor = P.IdProveedor

         WHERE MC.IdTipoMovimiento = TM.IdTipoMovimiento
         AND MC.IdSucursal = MCP.IdSucursal
         AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
         AND MC.NumeroMovimiento = MCP.NumeroMovimiento
         AND MCP.IdProducto = Prod.IdProducto
         AND MC.FechaMovimiento > @Fecha
		 AND MC.Usuario != 'Admin'
		AND MC.Observacion != '** AJUSTE AUTOMATICO ***'
         UNION ALL

         SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + MVP.IdProducto,15) as IdProducto, Prod.NombreProducto, MVP.Precio,MVP.Cantidad
         FROM TiposMovimientos TM, Productos Prod, MovimientosVentasProductos MVP, Clientes C, MovimientosVentas MV
         LEFT OUTER JOIN TiposComprobantes TC ON MV.IdTipoComprobante = TC.IdTipoComprobante
         LEFT OUTER JOIN Sucursales S ON MV.IdSucursal = S.IdSucursal
         WHERE MV.IdTipoMovimiento = TM.IdTipoMovimiento
         AND MV.IdSucursal = MVP.IdSucursal
         AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento
         AND MV.NumeroMovimiento = MVP.NumeroMovimiento
         AND MV.IdCliente = C.IdCliente
         AND MVP.IdProducto = Prod.IdProducto
		AND MV.FechaMovimiento > @Fecha
		AND MV.Usuario != 'Admin'
		) A, Marcas M, Rubros R
         WHERE A.IdMarca = M.IdMarca
         AND A.IdRubro = R.IdRubro
         GROUP BY M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto
         ORDER BY M.NombreMarca, R.NombreRubro, A.NombreProducto
