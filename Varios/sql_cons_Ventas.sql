SELECT CONVERT(varchar(11), V.Fecha, 120) AS Fecha
	,V.IdTipoComprobante
	,TC.DescripcionAbrev 
	,V.Letra 
	,V.CentroEmisor 
	,V.NumeroComprobante 
	,V.TipoDocVendedor 
	,V.NroDocVendedor 
    ,E.NombreEmpleado as NombreVendedor
	,C.NombreCliente 
	,C.IdLocalidad
	,L.NombreLocalidad
	,P.NombreProvincia
	,V.TipoDocCliente 
	,V.NroDocCliente 
	,V.DescuentoRecargoPorc 
	,V.DescuentoRecargo 
	,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal 
   ,V.IdEstadoComprobante
   ,V.IdFormasPago
   ,VFP.DescripcionFormasPago as FormaDePago
   ,V.Usuario
	,V.SubTotal
	,V.TotalImpuestos
	,V.ImporteTotal
  ,V.Utilidad
  ,V.SubTotal-V.Utilidad AS Costo
	FROM Ventas V
	 LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal 
	 LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor 
	 LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante 
	 LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago 
	 LEFT JOIN Clientes C ON V.TipoDocCliente=C.TipoDocumento AND V.NroDocCliente=C.NroDocumento 
     INNER JOIN Empleados E ON V.TipoDocVendedor = E.TipoDocEmpleado AND V.NroDocVendedor = E.NroDocEmpleado 
     INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad
     INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia  
  WHERE V.IdSucursal= 1
	  AND V.Fecha >= '20130101 00:00:00'
	  AND V.Fecha <= '20131221 23:59:59'
	ORDER BY V.fecha
