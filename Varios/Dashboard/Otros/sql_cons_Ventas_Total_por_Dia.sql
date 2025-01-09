SELECT CONVERT(varchar(11), V.fecha, 120) as Fecha 
	,SUM(V.SubTotal) as SubTotal 
	,SUM(V.TotalImpuestos) as TotalImpuestos 
  ,SUM(V.TotalImpuestoInterno) AS TotalImpuestoInterno
	,SUM(V.ImporteTotal) as ImporteTotal 
  ,0 AS Acumulado
	FROM Ventas V, TiposComprobantes TC 
 WHERE V.IdTipoComprobante = TC.IdTipoComprobante 
	AND V.IdSucursal = 1
	AND CONVERT(varchar(11), V.fecha, 120) >= '2021-11-01'
	AND CONVERT(varchar(11), V.fecha, 120) <= '2021-12-14'
   AND TC.AfectaCaja = 'True' 
   AND TC.EsComercial = 'True' 
	GROUP BY CONVERT(varchar(11), V.fecha, 120)
	ORDER BY CONVERT(varchar(11), V.fecha, 120)
