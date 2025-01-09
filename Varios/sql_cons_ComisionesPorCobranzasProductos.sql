
SELECT CC.TipoDocVendedor, CC.NroDocVendedor, E.NombreEmpleado as NombreVendedor, E.ComisionPorVenta

	--Recibo
	 , CC.IdSucursal 
	 , CC.IdTipoComprobante
	 , CC.Letra
	 , CC.CentroEmisor
	 , CC.NumeroComprobante
	 , CC.Fecha
	 , CC.IdCliente
	 , CC.IdUsuario

	--Comprobante Aplicado
	 , CC2.IdSucursal 
	 , CC2.IdTipoComprobante
	 , CC2.Letra
	 , CC2.CentroEmisor
	 , CC2.NumeroComprobante
	 , CC2.Fecha

	--Productos
	 , VP.IdProducto
	 , VP.NombreProducto	--Pudo cambiar la descripcion
	 , VP.Cantidad
	 , VP.PrecioNeto
	 , VP.ImporteTotalNeto
	 
	 , M.NombreMarca
	 , M.ComisionPorVenta
	 
	 , R.NombreRubro
	 , R.ComisionPorVenta

  FROM CuentasCorrientes CC 

 --Mira los comprobantes tipo recibo.
 INNER JOIN TiposComprobantes TC on TC.IdTipoComprobante = CC.IdTipoComprobante AND TC.EsRecibo = 'True'

 --Vendedor
 INNER JOIN Empleados E on E.TipoDocEmpleado = CC.TipoDocVendedor AND E.NroDocEmpleado = CC.NroDocVendedor

 --Obtiene los comprobantes que se pagaron
 INNER JOIN CuentasCorrientesPagos CCP on ccp.IdSucursal = CC.IdSucursal 
								AND ccp.IdTipoComprobante = CC.IdTipoComprobante
								AND ccp.Letra = CC.Letra
								AND ccp.CentroEmisor = CC.CentroEmisor
								AND ccp.NumeroComprobante = CC.NumeroComprobante

 --Controla el saldo de dichos comprobantes
 INNER JOIN CuentasCorrientes CC2 on CC2.IdSucursal = ccp.IdSucursal
								AND CC2.IdTipoComprobante = ccp.IdTipoComprobante2
								AND CC2.Letra = ccp.Letra2
								AND CC2.CentroEmisor = ccp.CentroEmisor2
								AND CC2.NumeroComprobante = ccp.NumeroComprobante2
								AND CC2.Saldo = 0

 INNER JOIN VentasProductos  VP on VP.IdSucursal = CC2.IdSucursal
								AND VP.IdTipoComprobante = CC2.IdTipoComprobante
								AND VP.Letra = CC2.Letra
								AND VP.CentroEmisor = CC2.CentroEmisor
								AND VP.NumeroComprobante = CC2.NumeroComprobante

 INNER JOIN Productos P on P.IdProducto = VP.IdProducto
 INNER JOIN Marcas M on M.IdMarca = P.IdMarca
 INNER JOIN Rubros R on R.IdRubro = P.IdRubro

 WHERE CC.Fecha >= '20150801 00:00:00'
   AND CC.Fecha <= '20150930 23:59:59'
GO

