
SELECT cc.IdSucursal, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.fecha,
       cc.ImporteTotal, ccp.ImporteCuota
 FROM CuentasCorrientes cc,
(
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(ImporteCuota) as ImporteCuota
 FROM CuentasCorrientesPagos
GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) ccp
 WHERE cc.IdSucursal = ccp.IdSucursal
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
   AND cc.ImporteTotal <> ccp.ImporteCuota
--   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
GO


SELECT cc.IdSucursal, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.fecha,
       cc.Saldo, ccp.SaldoCuota
 FROM CuentasCorrientes cc,
(
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(SaldoCuota) as SaldoCuota
 FROM CuentasCorrientesPagos
GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) ccp
 WHERE cc.IdSucursal = ccp.IdSucursal
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
   AND cc.Saldo <> ccp.SaldoCuota
--   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
GO
