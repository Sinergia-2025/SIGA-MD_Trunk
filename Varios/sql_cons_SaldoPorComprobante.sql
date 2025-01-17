SELECT B.CodigoCliente
      ,B.NombreCliente
      ,B.NombreCategoria
      ,A.IdSucursal
      ,A.IdTipoComprobante2
      ,A.Letra2
      ,A.CentroEmisor2
      ,A.NumeroComprobante2
      ,B.FechaEmision
      ,A.ImporteTotal
FROM
(      
SELECT CCP.IdSucursal
      ,CCP.IdTipoComprobante2
      ,CCP.Letra2
      ,CCP.CentroEmisor2
      ,CCP.NumeroComprobante2
      ,SUM(CCP.ImporteCuota) AS ImporteTotal
  FROM CuentasCorrientesPagos CCP
  WHERE CCP.Fecha <= '20141231 23:59:59'
  GROUP BY CCP.IdSucursal
      ,CCP.IdTipoComprobante2
      ,CCP.Letra2
      ,CCP.CentroEmisor2
      ,CCP.NumeroComprobante2
--      ,CC.Fecha
  HAVING SUM(CCP.ImporteCuota) <> 0
) A,
(
  SELECT C.CodigoCliente
      ,C.NombreCliente
      ,Cat.NombreCategoria
      ,CC.IdSucursal
      ,CC.IdTipoComprobante
      ,CC.Letra
      ,CC.CentroEmisor
      ,CC.NumeroComprobante
      ,CONVERT(varchar(11), CC.Fecha, 103) AS FechaEmision
      FROM CuentasCorrientes CC 
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente 
  INNER JOIN Categorias Cat ON C.IdCategoria = Cat.IdCategoria 
) B
WHERE A.IdSucursal = B.IdSucursal
  AND A.IdTipoComprobante2 = B.IdTipoComprobante
  AND A.Letra2 = B.Letra
  AND A.CentroEmisor2 = B.CentroEmisor
  AND A.NumeroComprobante2 = B.NumeroComprobante
