
--SELECT c.CodigoCliente, cc.IdSucursal, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.fecha,
--       cc.Saldo, ccp.SaldoCuota, c.NombreCliente
-- FROM CuentasCorrientes cc, Clientes C,
--		(
--		SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(SaldoCuota) as SaldoCuota
--		 FROM CuentasCorrientesPagos
--		GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
--		) ccp,
--	TiposComprobantes TC
-- WHERE cc.IdSucursal = ccp.IdSucursal
--   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
--   AND cc.Letra = ccp.Letra
--   AND cc.CentroEmisor = ccp.CentroEmisor
--   AND cc.NumeroComprobante = ccp.NumeroComprobante
--   and cc.IdCliente = c.IdCliente
--   and cc.IdTipoComprobante = TC.IdTipoComprobante
--   AND cc.Saldo <> ccp.SaldoCuota
----   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
----   AND cc.IdTipoComprobante NOT IN ('RECIBO','RECIBOCYO','RECIBOPUB')
----   AND TC.EsRecibo = 'False'
--   AND cc.IdSucursal = 1
--   ORDER BY 1,2,3,4,5,6
--GO


SELECT c.CodigoCliente, cc.IdSucursal, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.fecha,
       cc.ImporteTotal, ccp.SumaCuota, c.NombreCliente
 FROM CuentasCorrientes cc, Clientes C,
		(
		SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(ImporteCuota) as SumaCuota
		 FROM CuentasCorrientesPagos
		GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
		) ccp,
	TiposComprobantes TC
 WHERE cc.IdSucursal = ccp.IdSucursal
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
   and cc.IdCliente = c.IdCliente
   and cc.IdTipoComprobante = TC.IdTipoComprobante
   --AND cc.ImporteTotal <> ccp.SumaCuota --- Incluye Los Recibos con Anticipos
   AND cc.ImporteTotal <> ccp.SumaCuota	---Casos raros
   AND ccp.SumaCuota > 0
   
--   AND ROUND(cc.ImporteTotal,1) <> ROUND(ccp.ImporteCuota,1)
--   AND cc.IdTipoComprobante NOT IN ('MINUTA','MINUTACYO','MINUTAPROV','RECIBO','RECIBOCYO','RECIBOPROV','RECIBOPUB')
--   AND TC.EsRecibo = 'False'
   AND cc.IdSucursal = 1
   ORDER BY 1,2,3,4,5,6
GO
