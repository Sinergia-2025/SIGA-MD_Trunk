
SELECT DATEPART(year, Fecha) AS Anio, DATEPART(month, Fecha) AS Mes
      ,SUM(SubTotal) AS T_SubTotal, SUM(ImporteTotal) AS T_Total
  FROM VENTAS V
 WHERE IdTipoComprobante<> 'REMITOTRANSP' AND IdTipoComprobante<> 'ENTREGAMERCAD'
--   AND V.Fecha >= '20171001 00:00:00'
--   AND V.Fecha <= '20171031 23:59:59'
 GROUP BY DATEPART(year, Fecha),DATEPART(month, Fecha)
 ORDER BY 1 DESC, 2 DESC
 
 
 