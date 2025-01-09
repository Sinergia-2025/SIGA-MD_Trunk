SELECT 
    TipoDocCliente, NroDocCliente, NombreCliente,
    SUM(Mes1) AS Mes1, SUM(Mes2) AS Mes2, SUM(Mes3) AS Mes3,
    SUM(Mes4) AS Mes4, SUM(Mes5) AS Mes5, SUM(Mes6) AS Mes6, SUM(Mes7) AS Mes7,
    SUM(Mes8) AS Mes8, SUM(Mes9) AS Mes9, SUM(Mes10) AS Mes10,
    SUM(Mes11) AS Mes11, SUM(Mes12) AS Mes12,
    SUM(Mes1+Mes2+Mes3+Mes4+Mes5+Mes6+Mes7+Mes8+Mes9+Mes10+Mes11+Mes12) AS Total
  FROM
( 
SELECT V.TipoDocCliente, V.NroDocCliente, C.NombreCliente,
 CASE YEAR(fecha)*100+MONTH(fecha)
      WHEN 200901 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes1,
 CASE MONTH(V.Fecha)
      WHEN 2 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes2,
 CASE MONTH(V.Fecha)
      WHEN 3 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes3,
 CASE MONTH(V.Fecha)
      WHEN 4 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes4,
 CASE MONTH(V.Fecha)
      WHEN 5 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes5,
 CASE MONTH(V.Fecha)
      WHEN 6 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes6,
 CASE MONTH(V.Fecha)
      WHEN 7 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes7,
 CASE MONTH(V.Fecha)
      WHEN 8 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes8,
 CASE MONTH(V.Fecha)
      WHEN 9 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes9,
 CASE MONTH(V.Fecha)
      WHEN 10 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes10,
 CASE MONTH(V.Fecha)
      WHEN 11 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes11,
 CASE MONTH(V.Fecha)
      WHEN 12 Then SUM(VP.Kilos)
      ELSE 0 
 END Mes12
 FROM VentasProductos VP
 INNER JOIN Ventas V ON VP.IdSucursal = V.IdSucursal
                    AND VP.IdTipoComprobante = V.IdTipoComprobante
                    AND VP.Letra = V.Letra
                    AND VP.CentroEmisor = V.CentroEmisor
                    AND VP.NumeroComprobante = V.NumeroComprobante
 
 INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante
 INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago
 INNER JOIN Productos P ON VP.IdProducto = P.IdProducto
 INNER JOIN Marcas M ON P.IdMarca = M.IdMarca
 INNER JOIN Rubros R ON P.IdRubro = R.IdRubro
 INNER JOIN Clientes C ON V.TipoDocCliente = C.TipoDocumento AND V.NroDocCliente = C.NroDocumento
 INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica
 WHERE V.idsucursal = 1
   AND V.Kilos<>0
   AND TC.AfectaCaja = 'True'
   AND TC.EsComercial = 'True'
   
   AND YEAR(V.Fecha) = 2009
 GROUP BY V.TipoDocCliente, V.NroDocCliente, C.NombreCliente, V.Fecha
) Detalle
GROUP BY TipoDocCliente, NroDocCliente, NombreCliente
ORDER BY NombreCliente, TipoDocCliente, NroDocCliente

