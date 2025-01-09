SELECT TOP 10
  V.IdCliente, 
  C.CodigoCliente, 
  C.NombreCliente, 
  SUM(VP.ImporteTotalNeto) AS Importe
 FROM Ventas V 
 INNER JOIN Clientes C ON V.IdCliente = C.IdCliente 
 INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
 INNER JOIN VentasProductos VP ON v.IdSucursal = vp.IdSucursal 
      AND v.IdTipoComprobante = vp.IdTipoComprobante 
      AND v.Letra = vp.Letra 
      AND v.CentroEmisor = vp.CentroEmisor
      AND v.NumeroComprobante = vp.NumeroComprobante 
 INNER JOIN Productos P ON P.IdProducto = VP.IdProducto
  WHERE TC.AfectaCaja = 'True' 
    AND TC.EsComercial = 'True' 
   AND v.Fecha >= '20210509 00:00:00'
    AND v.Fecha <= '20211209 23:59:59'
 AND V.IdSucursal IN (1) GROUP BY V.IdCliente, C.CodigoCliente, C.NombreCliente 
 ORDER BY Importe desc 
