

SELECT cc.IdSucursal, p.CodigoProveedor, p.NombreProveedor, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.fecha,
       cc.Saldo, ccp.SaldoCuota, cc.IdProveedor
 FROM CuentasCorrientesProv cc, Proveedores P,
(
SELECT IdSucursal, IdProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(SaldoCuota) as SaldoCuota
 FROM CuentasCorrientesProvPagos
GROUP BY IdSucursal, IdProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) ccp
 WHERE cc.IdSucursal = ccp.IdSucursal
   AND cc.IdProveedor = ccp.IdProveedor
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
   and cc.IdProveedor = p.IdProveedor
   AND cc.Saldo <> ccp.SaldoCuota
--   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
   AND cc.IdTipoComprobante NOT IN ('PAGO','PAGOPROV')

GO

--SELECT cc.IdSucursal, cc.IdProveedor, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.fecha,
--       cc.ImporteTotal, ccp.ImporteCuota
-- FROM CuentasCorrientesProv cc,
--(
--SELECT IdSucursal, IdProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(ImporteCuota) as ImporteCuota
-- FROM CuentasCorrientesProvPagos
--GROUP BY IdSucursal, IdProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
--) ccp
-- WHERE cc.IdSucursal = ccp.IdSucursal
--   AND cc.IdProveedor = ccp.IdProveedor
--   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
--   AND cc.Letra = ccp.Letra
--   AND cc.CentroEmisor = ccp.CentroEmisor
--   AND cc.NumeroComprobante = ccp.NumeroComprobante
--   AND cc.ImporteTotal <> ccp.ImporteCuota
----   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
--   AND cc.IdTipoComprobante NOT IN ('PAGO','PAGOPROV')
--GO
