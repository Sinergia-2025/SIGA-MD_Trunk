
-- NOTA: Anticipos y comprobantes sin saldo fueron borrados previamente.

SELECT * FROM CuentasCorrientes
 WHERE IdSucursal IN (1, 3)
   AND (Saldo = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
GO

SELECT * FROM CuentasCorrientesPagos
 WHERE IdSucursal IN (1, 3)
   AND (SaldoCuota = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
GO

------------------------------------------------------------------------

INSERT INTO CuentasCorrientes
      ([IdSucursal]
      ,IdTipoComprobante
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[ImporteTickets]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[ImporteRetenciones]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[IdUsuario]
      ,[IdEstadoComprobante]
      ,[IdCliente]
      ,[FechaActualizacion]
      ,[IdClienteCtaCte]
      ,[IdCategoria]
      ,[SaldoCtaCte]
      ,[IdAsiento]
      ,IdPlanCuenta
      ,[MetodoGrabacion]
      ,[IdFuncion]
      )
SELECT 3 AS [IdSucursal]
      ,CC.IdTipoComprobante
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[ImporteTickets]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[ImporteRetenciones]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[IdUsuario]
      ,[IdEstadoComprobante]
      ,[IdCliente]
      ,[FechaActualizacion]
      ,[IdClienteCtaCte]
      ,[IdCategoria]
      ,[SaldoCtaCte]
      ,[IdAsiento]
      ,CC.IdPlanCuenta
      ,[MetodoGrabacion]
      ,[IdFuncion]
  FROM CuentasCorrientes CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
     AND (TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
     AND CC.IdTipoComprobante NOT IN ('REPRESENTACION','REPRESENT-NC','REMITOTRANSP')
  WHERE CC.IdSucursal = 1
GO


--------------------
INSERT INTO CuentasCorrientesPagos
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteCuota]
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc])
SELECT 3 AS [IdSucursal]
      ,CC.IdTipoComprobante
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[CuotaNumero]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteCuota]
      ,[SaldoCuota]
      ,[IdFormasPago]
      ,[Observacion]
      ,[IdTipoComprobante2]
      ,[NumeroComprobante2]
      ,[CentroEmisor2]
      ,[CuotaNumero2]
      ,[Letra2]
      ,[DescuentoRecargo]
      ,[DescuentoRecargoPorc]
  FROM CuentasCorrientesPagos CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
     AND (TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
     AND CC.IdTipoComprobante NOT IN ('REPRESENTACION','REPRESENT-NC','REMITOTRANSP')
  WHERE CC.IdSucursal = 1
GO

----

DELETE CuentasCorrientesPagos
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM CuentasCorrientesPagos CC
	    WHERE CC.IdSucursal = 3
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante)
GO

DELETE CuentasCorrientes
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM CuentasCorrientes CC
	    WHERE CC.IdSucursal = 3
          AND CC.IdTipoComprobante = CuentasCorrientes.IdTipoComprobante
          AND CC.Letra = CuentasCorrientes.Letra
          AND CC.CentroEmisor = CuentasCorrientes.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientes.NumeroComprobante)
GO


UPDATE CuentasCorrientesPagos
  SET ImporteCuota = SaldoCuota
 WHERE IdSucursal IN (1, 3)
   AND SaldoCuota <> 0
GO

UPDATE CuentasCorrientes
  SET ImporteTotal = Saldo
 WHERE IdSucursal IN (1, 3)
   AND Saldo <> 0
GO



SELECT * FROM CuentasCorrientesPagos
 WHERE IdSucursal IN (1, 3)
   AND SaldoCuota = 0
GO

SELECT * FROM CuentasCorrientes
 WHERE IdSucursal IN (1, 3)
   AND Saldo = 0
GO

