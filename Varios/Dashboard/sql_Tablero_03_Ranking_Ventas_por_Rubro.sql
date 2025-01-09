
DECLARE @TotalDeVentas DECIMAL(12,2) = (
SELECT SUM(ImporteTotalNeto) AS TotalGeneral FROM
(SELECT TOP(10) R.NombreRubro 
      ,SUM(VP.ImporteTotal) AS ImporteTotalNeto
--      ,SUM(VP.Cantidad) AS Cantidad
--      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal
--      ,SUM(VP.Kilos) AS Kilos
  FROM Ventas V, VentasProductos VP, TiposComprobantes TC,
       Productos P, Rubros R
 WHERE V.IdSucursal = VP.IdSucursal
   AND V.IdTipoComprobante = VP.IdTipoComprobante
   AND V.Letra = VP.Letra
   AND V.CentroEmisor = VP.CentroEmisor
   AND V.NumeroComprobante = VP.NumeroComprobante
   AND V.IdTipoComprobante = TC.IdTipoComprobante
   AND VP.IdProducto = P.IdProducto
   AND P.IdRubro = R.IdRubro
   AND TC.AfectaCaja = 'True'
   AND TC.EsComercial = 'True'
   AND V.IdSucursal >= 1
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))	---'20200101 00:00:00'
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))					---'20201221 23:59:59'
 GROUP BY R.NombreRubro
 ORDER BY ImporteTotalNeto DESC
) AS TablaUno
);


SELECT TOP(10) R.NombreRubro 
      ,ROUND(SUM(VP.ImporteTotal)/@TotalDeVentas*100,2) AS ImporteTotalPorc
--      ,SUM(VP.Cantidad) AS Cantidad
--      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal
--      ,SUM(VP.Kilos) AS Kilos
  FROM Ventas V, VentasProductos VP, TiposComprobantes TC,
       Productos P, Rubros R
 WHERE V.IdSucursal = VP.IdSucursal
   AND V.IdTipoComprobante = VP.IdTipoComprobante
   AND V.Letra = VP.Letra
   AND V.CentroEmisor = VP.CentroEmisor
   AND V.NumeroComprobante = VP.NumeroComprobante
   AND V.IdTipoComprobante = TC.IdTipoComprobante
   AND VP.IdProducto = P.IdProducto
   AND P.IdRubro = R.IdRubro
   AND TC.AfectaCaja = 'True'
   AND TC.EsComercial = 'True'
   AND V.IdSucursal >= 1
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
 GROUP BY R.NombreRubro
 ORDER BY ImporteTotalPorc DESC
;
