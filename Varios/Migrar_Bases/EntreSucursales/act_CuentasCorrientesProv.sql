
-- NOTA: Anticipos y comprobantes sin saldo fueron borrados previamente.

--SELECT * FROM CuentasCorrientesProv
-- WHERE IdSucursal IN (1, 3)
--   AND (Saldo = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
--;

--SELECT * FROM CuentasCorrientesProvPagos
-- WHERE IdSucursal IN (1, 3)
--   AND (SaldoCuota = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
--;

------------------------------------------------------------------------

DECLARE @IdSucOrigen INT = 5
DECLARE @IdSucDestino INT = 1
;

PRINT ''
PRINT '5. Inserto CuentasCorrientesProv.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesProv
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,FechaVencimiento
           ,ImporteTotal
           ,IdFormasPago
           ,Observacion
           ,Saldo
           ,CantidadCuotas
           ,ImportePesos
           ,ImporteDolares
           ,ImporteEuros
           ,ImporteCheques
           ,ImporteTransfBancaria
           ,ImporteTickets
           ,IdCuentaBancaria
           ,IdCaja
           ,NumeroPlanilla
           ,NumeroMovimiento
           ,ImporteRetenciones
           ,ImporteTarjetas
           ,IdEstadoComprobante
           ,IdUsuario
           ,IdProveedor
           ,FechaActualizacion
           ,IdAsiento
           ,IdPlanCuenta
           ,MetodoGrabacion
           ,IdFuncion
           ,ImprimeSaldos)
SELECT @IdSucDestino AS IdSucursal
           ,CCP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,FechaVencimiento
           ,Saldo AS xxImporteTotal
           ,IdFormasPago
           ,Observacion
           ,Saldo
           ,CantidadCuotas
           ,ImportePesos
           ,ImporteDolares
           ,ImporteEuros
           ,ImporteCheques
           ,ImporteTransfBancaria
           ,ImporteTickets
           ,IdCuentaBancaria
           ,NULL AS xxIdCaja
           ,NULL AS xxNumeroPlanilla
           ,NULL AS xxNumeroMovimiento
           ,ImporteRetenciones
           ,ImporteTarjetas
           ,IdEstadoComprobante
           ,IdUsuario
           ,IdProveedor
           ,FechaActualizacion
           ,IdAsiento
           ,CCP.IdPlanCuenta
           ,MetodoGrabacion
           ,IdFuncion
           ,ImprimeSaldos
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientesProv CCP
  WHERE CCP.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACIONCOM', 'COTIZACIONNCCOM', 'COTIZACIONNDCOM', 'FACTCOM', 'GASTO', 'IMPUESTO', 'NCREDCOM', 'NDEBCHEQRECHCOM', 'NDEBCOM', 'SALDOINICIOM2-')
;


PRINT ''
PRINT '6. Inserto CuentasCorrientesProvPagos.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesProvPagos
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,CuotaNumero
           ,Fecha
           ,FechaVencimiento
           ,ImporteCuota
           ,SaldoCuota
           ,IdFormasPago
           ,Observacion
           ,IdTipoComprobante2
           ,NumeroComprobante2
           ,CentroEmisor2
           ,CuotaNumero2
           ,Letra2
           ,IdProveedor
           ,DescuentoRecargo
           ,DescuentoRecargoPorc)
SELECT @IdSucDestino AS IdSucursal
           ,CCPP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,CuotaNumero
           ,Fecha
           ,FechaVencimiento
           ,SaldoCuota AS xxImporteCuota
           ,SaldoCuota
           ,IdFormasPago
           ,Observacion
           ,IdTipoComprobante2
           ,NumeroComprobante2
           ,CentroEmisor2
           ,CuotaNumero2
           ,Letra2
           ,IdProveedor
           ,DescuentoRecargo
           ,DescuentoRecargoPorc
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientesProvPagos CCPP
  WHERE CCPP.IdSucursal = @IdSucOrigen
    AND IdTipoComprobante IN ('COTIZACIONCOM', 'COTIZACIONNCCOM', 'COTIZACIONNDCOM', 'FACTCOM', 'GASTO', 'IMPUESTO', 'NCREDCOM', 'NDEBCHEQRECHCOM', 'NDEBCOM', 'SALDOINICIOM2-')
;

PRINT ''
PRINT '6. Inserto CuentasCorrientesProvCheques.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesProvCheques
		([IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[IdProveedor])
SELECT @IdSucDestino AS IdSucursal
		,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[IdProveedor]
FROM [SIGA_Distrib_Trinidad].[dbo].[CuentasCorrientesProvCheques] CCPC
	WHERE CCPC.IdSucursal = @IdSucOrigen
	AND IdTipoComprobante IN ('COTIZACIONCOM', 'COTIZACIONNCCOM', 'COTIZACIONNDCOM', 'FACTCOM', 'GASTO', 'IMPUESTO', 'NCREDCOM', 'NDEBCHEQRECHCOM', 'NDEBCOM', 'SALDOINICIOM2-')
;

PRINT ''
PRINT '6. Inserto CuentasCorrientesProvRetenciones.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesProvRetenciones
		([IdSucursal]
		,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdTipoImpuesto]
      ,[EmisorRetencion]
      ,[NumeroRetencion]
      ,[IdProveedor])
SELECT @IdSucDestino AS IdSucursal
		,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdTipoImpuesto]
      ,[EmisorRetencion]
      ,[NumeroRetencion]
      ,[IdProveedor]
 FROM [SIGA_Distrib_Trinidad].[dbo].CuentasCorrientesProvRetenciones CCPR
	WHERE CCPR.IdSucursal = @IdSucOrigen
	AND IdTipoComprobante IN ('COTIZACIONCOM', 'COTIZACIONNCCOM', 'COTIZACIONNDCOM', 'FACTCOM', 'GASTO', 'IMPUESTO', 'NCREDCOM', 'NDEBCHEQRECHCOM', 'NDEBCOM', 'SALDOINICIOM2-')
;

----

--DELETE CuentasCorrientesProvPagos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM CuentasCorrientesProvPagos CC
--	    WHERE CC.IdSucursal = 3
--          AND CC.IdProveedor = CuentasCorrientesProvPagos.IdProveedor
--          AND CC.IdTipoComprobante = CuentasCorrientesProvPagos.IdTipoComprobante
--          AND CC.Letra = CuentasCorrientesProvPagos.Letra
--          AND CC.CentroEmisor = CuentasCorrientesProvPagos.CentroEmisor
--          AND CC.NumeroComprobante = CuentasCorrientesProvPagos.NumeroComprobante)
--;

--DELETE CuentasCorrientesProv
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM CuentasCorrientesProv CC
--	    WHERE CC.IdSucursal = 3
--          AND CC.IdProveedor = CuentasCorrientesProv.IdProveedor
--          AND CC.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
--          AND CC.Letra = CuentasCorrientesProv.Letra
--          AND CC.CentroEmisor = CuentasCorrientesProv.CentroEmisor
--          AND CC.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante)
--;


--UPDATE CuentasCorrientesProvPagos
--  SET ImporteCuota = SaldoCuota
-- WHERE IdSucursal IN (1, 3)
--   AND SaldoCuota <> 0
--;

--UPDATE CuentasCorrientesProv
--  SET ImporteTotal = Saldo
-- WHERE IdSucursal IN (1, 3)
--   AND Saldo <> 0
--;
