SELECT C.Fecha
      ,C.IdTipoComprobante
      ,TC.DescripcionAbrev 
      ,C.Letra 
      ,C.CentroEmisor 
      ,C.NumeroComprobante 
      ,C.TipoDocComprador 
      ,C.NroDocComprador 
      ,PV.NombreProveedor 
      ,C.TipoDocProveedor 
      ,C.NroDocProveedor 
      ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal 
     -- ,C.IdEstadoComprobante
      ,C.IdFormasPago
      ,VFP.DescripcionFormasPago as FormaDePago
      ,CP.IdProducto
      ,P.NombreProducto
      --,CP.NombreProducto
      ,M.NombreMarca
      ,R.NombreRubro
      ,CP.Cantidad
      ,CP.Precio
     -- ,CP.Costo
      ,CP.DescRecGeneral
      ,CP.DescuentoRecargo
      --,CP.PrecioLista
      ,CP.DescuentoRecargoPorc
      --,CP.DescuentoRecargoPorc2
      ,CP.DescuentoRecargoProducto
      ,C.DescuentoRecargoPorc AS DescuentoRecargoPorcGral
      ,CP.PrecioNeto
      --,CP.Utilidad
      --,CP.IdTipoImpuesto
      --,CP.AlicuotaImpuesto
     -- ,CP.ImporteImpuesto
      ,CP.ImporteTotal
      ,CP.ImporteTotalNeto
     --,CP.Kilos
     -- ,C.Usuario

 FROM ComprasProductos CP
 INNER JOIN Compras C ON C.IdSucursal = CP.IdSucursal 
			AND C.TipoDocProveedor = CP.TipoDocProveedor 
			AND C.NroDocProveedor = CP.NroDocProveedor 
			AND C.IdTipoComprobante = CP.IdTipoComprobante 
			AND C.Letra = CP.Letra 
			AND C.CentroEmisor = CP.CentroEmisor
			AND C.NumeroComprobante = CP.NumeroComprobante 
 INNER JOIN Proveedores PV ON C.TipoDocProveedor = PV.TipoDocProveedor AND C.NroDocProveedor = PV.NroDocProveedor 
 INNER JOIN TiposComprobantes TC ON C.IdTipoComprobante = TC.IdTipoComprobante 
 INNER JOIN Productos P ON P.IdProducto = CP.IdProducto 
 INNER JOIN Marcas M ON M.IdMarca = P.IdMarca
 INNER JOIN Rubros R ON R.IdRubro = P.IdRubro
 INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal 
 INNER JOIN VentasFormasPago VFP ON C.IdFormasPago = VFP.IdFormasPago 

  WHERE C.IdSucursal = 1
    AND C.Fecha >= '20110901 00:00:00'
    AND C.Fecha <= '20110930 23:59:59'

   --AND P.idproducto = '{0}'

	ORDER BY CONVERT(varchar(11), C.fecha, 120)
	,C.IdTipoComprobante
	,C.Letra
	,C.CentroEmisor
	,C.NumeroComprobante
	,P.NombreProducto
	,CP.IdProducto
