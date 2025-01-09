SELECT SUBSTRING(CONVERT(varchar(11), V.Fecha, 120),3,5)
--	    ,MONTH(V.fecha)
      ,ROUND(SUM(V.ImporteTotal)/1000000,2) AS ImporteTotal 
  FROM Ventas V
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante 
 WHERE V.IdSucursal >= 1
   --AND V.Fecha >= '20200101 00:00:00'
   --AND V.Fecha <= '20201221 23:59:59'
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
   AND TC.AfectaCaja = 'True' 
   AND TC.EsComercial = 'True' 
  --GROUP BY MONTH(V.fecha)
  GROUP BY SUBSTRING(CONVERT(varchar(11), V.Fecha, 120),3,5)  
--ORDER BY 1
