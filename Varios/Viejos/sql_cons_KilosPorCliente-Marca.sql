SELECT 
    TipoDocCliente, NroDocCliente, NombreCliente,
    SUM(Marca1) AS Marca1, SUM(Marca2) AS Marca2, SUM(Marca3) AS Marca3,
    SUM(Marca1+Marca2+Marca3) AS Total
  FROM
( 
SELECT V.TipoDocCliente, V.NroDocCliente, C.NombreCliente,
 CASE P.IdMarca 	
      WHEN 6 Then SUM(VP.Kilos)
      ELSE 0 
 END Marca1,
 CASE P.IdMarca	
      WHEN 15 Then SUM(VP.Kilos)
      ELSE 0 
 END Marca2,
 CASE P.IdMarca 	
      WHEN 17 Then SUM(VP.Kilos)
      ELSE 0 
 END Marca3
 FROM VentasProductos VP
 INNER JOIN Ventas V ON VP.IdSucursal = V.IdSucursal
                    AND VP.IdTipoComprobante = V.IdTipoComprobante
                    AND VP.Letra = V.Letra
                    AND VP.CentroEmisor = V.CentroEmisor
                    AND VP.NumeroComprobante = V.NumeroComprobante
 INNER JOIN Clientes C ON V.TipoDocCliente = C.TipoDocumento AND V.NroDocCliente = C.NroDocumento
 INNER JOIN Productos P ON VP.IdProducto = P.IdProducto
 WHERE P.IdMarca in (6, 15, 17)
   AND V.IdSucursal = 1
   AND CONVERT(varchar(11), V.Fecha, 120) >= '2010-10-01'
   AND CONVERT(varchar(11), V.Fecha, 120) <= '2010-10-31'
 GROUP BY V.TipoDocCliente, V.NroDocCliente, C.NombreCliente, P.IdMarca
) Detalle
GROUP BY TipoDocCliente, NroDocCliente, NombreCliente
