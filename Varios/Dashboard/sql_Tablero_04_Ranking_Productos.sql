
DECLARE @TotalDeVentas DECIMAL(12,2) = (
SELECT SUM(Importe) AS TotalGeneral FROM
(SELECT TOP(10)
	VP.NombreProducto,
 -- SUM(vp.Cantidad) AS Cantidad,
  SUM(VP.ImporteTotal) AS Importe
 FROM VentasProductos vp
 INNER JOIN Ventas v ON v.IdSucursal = vp.IdSucursal 
			AND v.IdTipoComprobante = vp.IdTipoComprobante 
			AND v.Letra = vp.Letra 
			AND v.CentroEmisor = vp.CentroEmisor
			AND v.NumeroComprobante = vp.NumeroComprobante 
 INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
  WHERE V.IdSucursal >= 1
    AND TC.AfectaCaja = 'True' 
    AND TC.EsComercial = 'True' 
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
 GROUP BY VP.NombreProducto
 ORDER BY Importe desc
) AS TablaUno
);


SELECT TOP(10) VP.NombreProducto
 --, SUM(vp.Cantidad) AS Cantidad,
      ,ROUND(SUM(VP.ImporteTotal)/@TotalDeVentas*100,2) AS ImporteTotalPorc
 FROM VentasProductos vp
 INNER JOIN Ventas v ON v.IdSucursal = vp.IdSucursal 
			AND v.IdTipoComprobante = vp.IdTipoComprobante 
			AND v.Letra = vp.Letra 
			AND v.CentroEmisor = vp.CentroEmisor
			AND v.NumeroComprobante = vp.NumeroComprobante 
 INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
  WHERE V.IdSucursal >= 1
    AND TC.AfectaCaja = 'True' 
    AND TC.EsComercial = 'True' 
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
 GROUP BY VP.NombreProducto
 ORDER BY ImporteTotalPorc desc
