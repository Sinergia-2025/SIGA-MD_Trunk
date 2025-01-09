
--SELECT MONTH(Fecha) AS MES
SELECT SUBSTRING(CONVERT(varchar(11), V.Fecha, 120),3,5) AS MES
   , E.NombreEmpleado AS Vendedor, ROUND(SUM(ComisionVendedor)/1000,2) AS SumaComisionVendedor
  FROM Ventas V
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.AfectaCaja = 'True' AND TC.EsComercial = 'True'
 INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado 
 WHERE V.IdSucursal >= 1
  AND V.ComisionVendedor <> 0
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
-- GROUP BY MONTH(Fecha), E.NombreEmpleado 
-- HAVING SUM(ComisionVendedor) > 0
 GROUP BY SUBSTRING(CONVERT(varchar(11), V.Fecha, 120),3,5), E.NombreEmpleado 
 ORDER BY 1
