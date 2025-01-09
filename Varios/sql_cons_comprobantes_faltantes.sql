
SELECT * FROM CuentasCorrientes A
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.EsRecibo = 'False'
  WHERE (A.IdEstadoComprobante IS NULL OR A.IdEstadoComprobante<>'ANULADO')
    AND NOT EXISTS 
     ( SELECT * FROM CuentasCorrientesPagos B
       WHERE B.IdSucursal = A.IdSucursal
         AND B.IdTipoComprobante = A.IdTipoComprobante
         AND B.Letra = A.Letra
         AND B.CentroEmisor = A.CentroEmisor
         AND B.NumeroComprobante = A.NumeroComprobante
     )
GO

SELECT * FROM CuentasCorrientesProv A
  WHERE IdTipoComprobante NOT IN ('PAGO','PAGOPROV')
    AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante<>'ANULADO')
    AND NOT EXISTS 
     ( SELECT * FROM CuentasCorrientesProvPagos B
       WHERE B.IdSucursal = A.IdSucursal
         AND B.IdTipoComprobante = A.IdTipoComprobante
         AND B.Letra = A.Letra
         AND B.CentroEmisor = A.CentroEmisor
         AND B.NumeroComprobante = A.NumeroComprobante
         AND B.IdProveedor = A.IdProveedor
     )
GO
