DECLARE @vendedores VARCHAR(MAX)
SET @vendedores = ( 
SELECT QUOTENAME(E.NombreEmpleado) + ',' --AS Vendedor
  FROM Ventas V
INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.AfectaCaja = 'True' AND TC.EsComercial = 'True'
INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado 
 WHERE V.IdSucursal >= 1
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
 GROUP BY E.NombreEmpleado 
 HAVING SUM(V.ComisionVendedor) > 0
 ORDER BY 1
FOR XML PATH(''))

SET @vendedores = SUBSTRING(@vendedores, 0, LEN(@vendedores))

PRINT @vendedores

DECLARE @SQLString nvarchar(MAX);

set @SQLString = N'SELECT *
  FROM (SELECT SUBSTRING(CONVERT(varchar(11), V.Fecha, 120),3,5) AS MES, E.NombreEmpleado AS Vendedor, ROUND(SUM(V.ComisionVendedor)/1000,2) AS SumaComisionVendedor
  FROM Ventas V
INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.AfectaCaja = ''True'' AND TC.EsComercial = ''True''
INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado 
 WHERE V.IdSucursal >= 1
   AND CONVERT(DATE, V.Fecha, 120) >= DATEADD(YY,-1,(CAST(GETDATE()-DAY(GETDATE())+1 AS DATE)))
   AND CONVERT(DATE, V.Fecha, 120) <= CONVERT(DATE, GETDATE()-DAY(GETDATE()))				
 GROUP BY SUBSTRING(CONVERT(varchar(11), V.Fecha, 120),3,5), E.NombreEmpleado 
 HAVING SUM(V.ComisionVendedor) > 0
 ) a
 PIVOT (SUM(SumaComisionVendedor) FOR Vendedor IN (' + @vendedores + ')) AS a
 '
--PRINT @SQLString
EXECUTE sp_executesql @SQLString
