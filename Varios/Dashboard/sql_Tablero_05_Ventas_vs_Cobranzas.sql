SELECT V.Periodo, V.Ventas, C.Cobranzas
FROM
(
	SELECT SUBSTRING(CONVERT(varchar(11), Fecha, 120),3,5) AS Periodo, ROUND(SUM(ImporteTotal)/1000000,2) AS Ventas
	FROM Ventas
	 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = Ventas.IdTipoComprobante AND TC.AfectaCaja = 'True' AND TC.EsComercial = 'True'
	 WHERE IdSucursal >= 1
	   AND CONVERT(DATE, Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
       AND CONVERT(DATE, Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))		
	 GROUP BY SUBSTRING(CONVERT(varchar(11), Fecha, 120),3,5)
) V,
(
	SELECT SUBSTRING(CONVERT(varchar(11), Fecha, 120),3,5) AS Periodo, ROUND(SUM(ImporteTotal*-1)/1000000,2) AS Cobranzas
	FROM CuentasCorrientes
	 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CuentasCorrientes.IdTipoComprobante AND TC.EsRecibo = 'True'
	 WHERE IdSucursal >= 1
	   AND CONVERT(DATE, Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
       AND CONVERT(DATE, Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))		
	 GROUP BY SUBSTRING(CONVERT(varchar(11), Fecha, 120),3,5)
) C
 WHERE V.Periodo = C.Periodo
 ORDER BY 1
