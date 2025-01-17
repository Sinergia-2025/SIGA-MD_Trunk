SELECT B.CodigoProveedor
      ,B.NombreProveedor
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
      ,CCP.IdProveedor
      ,CCP.IdTipoComprobante2
      ,CCP.Letra2
      ,CCP.CentroEmisor2
      ,CCP.NumeroComprobante2
      ,SUM(CCP.ImporteCuota) AS ImporteTotal
  FROM CuentasCorrientesProvPagos CCP
  WHERE CCP.Fecha <= '20141231 23:59:59'
  GROUP BY CCP.IdSucursal
      ,CCP.IdProveedor
      ,CCP.IdTipoComprobante2
      ,CCP.Letra2
      ,CCP.CentroEmisor2
      ,CCP.NumeroComprobante2
--      ,CC.Fecha
  HAVING SUM(CCP.ImporteCuota) <> 0
) A,
(
  SELECT P.CodigoProveedor
      ,P.NombreProveedor
      ,Cat.NombreCategoria
      ,CC.IdSucursal
      ,CC.IdProveedor
      ,CC.IdTipoComprobante
      ,CC.Letra
      ,CC.CentroEmisor
      ,CC.NumeroComprobante
      ,CONVERT(varchar(11), CC.Fecha, 103) AS FechaEmision
      FROM CuentasCorrientesProv CC 
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
  INNER JOIN Proveedores P ON P.IdProveedor = CC.IdProveedor 
  INNER JOIN CategoriasProveedores Cat ON P.IdCategoria = Cat.IdCategoria 
) B
WHERE A.IdSucursal = B.IdSucursal
  AND A.IdProveedor = B.IdProveedor
  AND A.IdTipoComprobante2 = B.IdTipoComprobante
  AND A.Letra2 = B.Letra
  AND A.CentroEmisor2 = B.CentroEmisor
  AND A.NumeroComprobante2 = B.NumeroComprobante
