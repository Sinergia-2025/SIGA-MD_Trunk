select * from SIGA.dbo.CuentasCorrientesProvPagos CCP2
 where exists
(
SELECT IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor, COUNT(idsucursal)
  FROM SIGA.dbo.CuentasCorrientesProv CCP
       WHERE CCP2.IdTipoComprobante = CCP.IdTipoComprobante
         AND CCP2.Letra = CCP.Letra
         AND CCP2.CentroEmisor = CCP.CentroEmisor
         AND CCP2.NumeroComprobante = CCP.NumeroComprobante
         AND CCP2.IdProveedor = CCP.IdProveedor
  group by IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
  having COUNT(idsucursal)>1
)
order by IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
