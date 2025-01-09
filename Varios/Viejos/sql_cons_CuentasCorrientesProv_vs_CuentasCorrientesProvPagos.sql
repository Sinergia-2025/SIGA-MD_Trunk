
SELECT cc.IdSucursal, cc.TipoDocProveedor, cc.NroDocProveedor, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, 
       cc.NumeroComprobante, cc.fecha, cc.ImporteTotal, ccp.ImporteCuota
 FROM CuentasCorrientesProv cc,
(
SELECT IdSucursal, TipoDocProveedor, NroDocProveedor, IdTipoComprobante, Letra, CentroEmisor, 
       NumeroComprobante, sum(ImporteCuota) as ImporteCuota
 FROM CuentasCorrientesProvPagos
GROUP BY IdSucursal, TipoDocProveedor, NroDocProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) ccp
 WHERE cc.IdSucursal = ccp.IdSucursal
   AND cc.TipoDocProveedor = ccp.TipoDocProveedor
   AND cc.NroDocProveedor = ccp.NroDocProveedor
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
   AND cc.ImporteTotal <> ccp.ImporteCuota
--   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
GO


SELECT cc.IdSucursal, cc.TipoDocProveedor, cc.NroDocProveedor, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, 
       cc.NumeroComprobante, cc.fecha, cc.Saldo, ccp.SaldoCuota
 FROM CuentasCorrientesProv cc,
(
SELECT IdSucursal, TipoDocProveedor, NroDocProveedor, IdTipoComprobante, Letra, CentroEmisor, 
       NumeroComprobante, sum(SaldoCuota) as SaldoCuota
 FROM CuentasCorrientesProvPagos
GROUP BY IdSucursal, TipoDocProveedor, NroDocProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) ccp
 WHERE cc.IdSucursal = ccp.IdSucursal
   AND cc.TipoDocProveedor = ccp.TipoDocProveedor
   AND cc.NroDocProveedor = ccp.NroDocProveedor
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
   AND cc.Saldo <> ccp.SaldoCuota
--   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
GO
