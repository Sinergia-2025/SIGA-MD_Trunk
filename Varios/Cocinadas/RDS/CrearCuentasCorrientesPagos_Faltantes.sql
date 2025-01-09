INSERT INTO [dbo].[CuentasCorrientesPagos]
           ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [CuotaNumero]
           ,[Fecha], [FechaVencimiento], [ImporteCuota], [SaldoCuota], [IdFormasPago], [Observacion]
           ,[IdTipoComprobante2], [Letra2], [CentroEmisor2], [NumeroComprobante2], [CuotaNumero2]
           ,[DescuentoRecargo], [DescuentoRecargoPorc], [ImporteCapital], [ImporteInteres]
           ,[FechaVencimiento2], [ImporteVencimiento2], [FechaVencimiento3], [ImporteVencimiento3]
           ,[CodigoDeBarra], [ReferenciaCuota], [IdEmbarcacion]
           ,[FechaVencimiento4], [ImporteVencimiento4], [FechaVencimiento5], [ImporteVencimiento5])
SELECT CC.IdSucursal, CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, 1
     , CC.Fecha, CC.Fecha + 30, CC.ImporteTotal, CC.Saldo, 1, 'SPC'
     , CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, 1
     , 0, 0, CC.ImporteTotal, 0
     , NULL, NULL, NULL, NULL
     , NULL, NULL, NULL
     , NULL, NULL, NULL, NULL
  FROM CuentasCorrientes CC
  LEFT JOIN CuentasCorrientesPagos CCP ON CCP.IdSucursal = CC.IdSucursal
                                AND CCP.IdTipoComprobante = CC.IdTipoComprobante
                                AND CCP.Letra = CC.Letra
                                AND CCP.CentroEmisor = CC.CentroEmisor
                                AND CCP.NumeroComprobante = CC.NumeroComprobante
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
 INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = CC.IdFormasPago
 --WHERE CC.IdCliente = 192
 WHERE CCP.IdSucursal IS NULL
   AND TC.EsRecibo = 0
 ORDER BY CC.Fecha DESC
