
UPDATE CuentasCorrientes 
   SET CuentasCorrientes.ImporteTotal = CCP.ImporteCuota
      ,CuentasCorrientes.Saldo = CCP.SaldoCuota
 FROM CuentasCorrientes CC
 INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = CC.IdTipoComprobante
                  AND TP.EsRecibo = 'False' AND TP.EsAnticipo = 'False'
 INNER JOIN CuentasCorrientesPagos CCP ON CC.IdSucursal = CC.IdSucursal
                                AND CCP.IdTipoComprobante = CC.IdTipoComprobante
                                AND CCP.Letra = CC.Letra
                                AND CCP.CentroEmisor = CC.CentroEmisor
                                AND CCP.NumeroComprobante = CC.NumeroComprobante
                                AND CCP.SaldoCuota <> CC.Saldo
                                AND ABS(CCP.SaldoCuota - CC.Saldo)<0.10
 --WHERE V.Direccion IS NULL
GO


--UPDATE CuentasCorrientesPagos 
--   SET CuentasCorrientesPagos.ImporteCuota = CC.ImporteTotal
--      ,CuentasCorrientesPagos.SaldoCuota = CC.Saldo
-- FROM CuentasCorrientesPagos CCP 
-- INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = CCP.IdTipoComprobante2
--                  AND TP.EsRecibo = 'False' AND TP.EsAnticipo = 'False'
-- INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal
--                                AND CC.IdTipoComprobante = CCP.IdTipoComprobante
--                                AND CC.Letra = CCP.Letra
--                                AND CC.CentroEmisor = CCP.CentroEmisor
--                                AND CC.NumeroComprobante = CCP.NumeroComprobante
--                                AND CC.Saldo <> CCP.SaldoCuota
-- --WHERE V.Direccion IS NULL
--GO
