
-- NOTA: Anticipos y comprobantes sin saldo fueron borrados previamente.

SELECT * FROM CuentasCorrientesProv
 WHERE IdSucursal IN (1, 3)
   AND (Saldo = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
GO

SELECT * FROM CuentasCorrientesProvPagos
 WHERE IdSucursal IN (1, 3)
   AND (SaldoCuota = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
GO

------------------------------------------------------------------------

INSERT INTO CuentasCorrientesProv
           ([IdSucursal]
           ,[IdTipoComprobante]
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
           ,[ImporteTransfBancaria]
           ,[ImporteTickets]
           ,[IdCuentaBancaria]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[ImporteRetenciones]
           ,[ImporteTarjetas]
           ,[IdEstadoComprobante]
           ,[IdUsuario]
           ,[IdProveedor]
           ,[FechaActualizacion]
           ,[IdAsiento]
           ,[IdPlanCuenta])
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
      ,[ImporteTransfBancaria]
      ,[ImporteTickets]
      ,[IdCuentaBancaria]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[ImporteRetenciones]
      ,[ImporteTarjetas]
      ,[IdEstadoComprobante]
      ,[IdUsuario]
      ,[IdProveedor]
      ,[FechaActualizacion]
      ,[IdAsiento]
      ,CC.IdPlanCuenta
  FROM CuentasCorrientesProv CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
                                 AND TC.GrabaLibro=0
  WHERE CC.IdSucursal = 1
GO


--------------------
INSERT INTO CuentasCorrientesProvPagos
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
           ,[IdProveedor]
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
      ,[IdProveedor]
      ,[DescuentoRecargo]
      ,[DescuentoRecargoPorc]
  FROM CuentasCorrientesProvPagos CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
                                 AND TC.GrabaLibro=0
  WHERE CC.IdSucursal = 1
GO

----

DELETE CuentasCorrientesProvPagos
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM CuentasCorrientesProvPagos CC
	    WHERE CC.IdSucursal = 3
          AND CC.IdProveedor = CuentasCorrientesProvPagos.IdProveedor
          AND CC.IdTipoComprobante = CuentasCorrientesProvPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesProvPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesProvPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesProvPagos.NumeroComprobante)
GO

DELETE CuentasCorrientesProv
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM CuentasCorrientesProv CC
	    WHERE CC.IdSucursal = 3
          AND CC.IdProveedor = CuentasCorrientesProv.IdProveedor
          AND CC.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesProv.Letra
          AND CC.CentroEmisor = CuentasCorrientesProv.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante)
GO


UPDATE CuentasCorrientesProvPagos
  SET ImporteCuota = SaldoCuota
 WHERE IdSucursal IN (1, 3)
   AND SaldoCuota <> 0
GO

UPDATE CuentasCorrientesProv
  SET ImporteTotal = Saldo
 WHERE IdSucursal IN (1, 3)
   AND Saldo <> 0
GO
