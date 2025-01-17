
-- NOTA: Los Anticipos _Habria que pasarlos como ADELANTO y ADELANTOPROV (este ultimo no existE).

--SELECT * FROM CuentasCorrientes
-- WHERE IdSucursal IN (1, 3)
--   AND (Saldo = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
--;

--SELECT * FROM CuentasCorrientesPagos
-- WHERE IdSucursal IN (1, 3)
--   AND (SaldoCuota = 0 OR IdTipoComprobante LIKE 'ANTICIP%')
--;

------------------------------------------------------------------------

DECLARE @IdSucOrigen INT = 5
DECLARE @IdSucDestino INT = 1
;

DECLARE @COTIZACION INT
SELECT @COTIZACION = MAX(NumeroComprobante) FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientes 
                                           WHERE IdSucursal=1 AND IdtipoComprobante='COTIZACION';

DECLARE @DEVCOTIZACION  INT
SELECT @DEVCOTIZACION  = MAX(NumeroComprobante) FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientes
                                           WHERE IdSucursal=1 AND IdtipoComprobante='DEV-COTIZACION';

DECLARE @PRESUP  INT
SELECT @PRESUP  = MAX(NumeroComprobante) FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientes
                                          WHERE IdSucursal=1 AND IdtipoComprobante='PRESUP';
PRINT ''
PRINT '6. Inserto CuentasCorrientes.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientes
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
           ,ImporteTarjetas
           ,ImporteTickets
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,TipoDocVendedor
           ,NroDocVendedor
           ,ImporteRetenciones
           ,IdCaja
           ,NumeroPlanilla
           ,NumeroMovimiento
           ,IdEstadoComprobante
           ,IdUsuario
           ,IdCliente
           ,FechaActualizacion
           ,IdClienteCtaCte
           ,IdCategoria
           ,SaldoCtaCte
           ,IdAsiento
           ,IdPlanCuenta
           ,MetodoGrabacion
           ,IdFuncion
           ,ImprimeSaldos
           ,IdCobrador
           ,IdEstadoCliente
           ,NumeroOrdenCompra
           ,Referencia
		  ,[IdSucursalVinculado]
		  ,[IdTipoComprobanteVinculado]
		  ,[LetraVinculado]
		  ,[CentroEmisorVinculado]
		  ,[NumeroComprobanteVinculado]
		  ,[CotizacionDolar]
		  ,[FechaTransferencia]
		  ,[FechaExportacion])
SELECT @IdSucDestino AS IdSucursal
           ,CC.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
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
           ,ImporteTarjetas
           ,ImporteTickets
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,TipoDocVendedor
           ,NroDocVendedor
           ,ImporteRetenciones
           ,NULL AS xxIdCaja	-- No se pasan los movimientos de Caja.
           ,NULL AS xxNumeroPlanilla
           ,NULL AS xxNumeroMovimiento
           ,IdEstadoComprobante
           ,IdUsuario
           ,IdCliente
           ,FechaActualizacion
           ,IdClienteCtaCte
           ,IdCategoria
           ,SaldoCtaCte
           ,IdAsiento
           ,CC.IdPlanCuenta
           ,MetodoGrabacion
           ,IdFuncion
           ,ImprimeSaldos
           ,IdCobrador
           ,IdEstadoCliente
           ,NumeroOrdenCompra
           ,Referencia
		  ,[IdSucursalVinculado]
		  ,[IdTipoComprobanteVinculado]
		  ,[LetraVinculado]
		  ,[CentroEmisorVinculado]
		  ,[NumeroComprobanteVinculado]
		  ,[CotizacionDolar]
		  ,[FechaTransferencia]
		  ,[FechaExportacion]
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientes CC
  WHERE CC.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP', 'AJUSTE-', 'AJUSTE+', 'NDEBCHEQRECH')
;

PRINT ''
PRINT '7. Inserto CuentasCorrientesPagos.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesPagos
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
           ,DescuentoRecargo
           ,DescuentoRecargoPorc
           ,ImporteCapital
           ,ImporteInteres)
SELECT @IdSucDestino AS IdSucursal
           ,CCP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
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
           ,DescuentoRecargo
           ,DescuentoRecargoPorc
           ,ImporteCapital
           ,ImporteInteres
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientesPagos CCP
  WHERE CCP.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP', 'AJUSTE-', 'AJUSTE+', 'NDEBCHEQRECH')
;

PRINT ''
PRINT '8. CuentasCorrientesCheques: NO SE PASA PORQUE NO HABRA DETALLE DE CAJA NI CHEQUES.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesCheques
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,NumeroCheque
           ,IdBancoCheque
           ,IdLocalidadCheque
           ,IdBancoSucursalCheque)
SELECT @IdSucDestino AS IdSucursal
           ,CCC.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
			,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
           ,NumeroCheque
           ,IdBancoCheque
           ,IdLocalidadCheque
           ,IdBancoSucursalCheque
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientesCheques CCC
  WHERE CCC.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP', 'AJUSTE-', 'AJUSTE+', 'NDEBCHEQRECH')
;


PRINT ''
PRINT '9. CuentasCorrientesRetenciones: NO SE PASA PORQUE NO HABRA DETALLE DE CAJA NI RETENCIONES.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesRetenciones
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdTipoImpuesto
           ,EmisorRetencion
           ,NumeroRetencion
           ,IdCliente)
SELECT @IdSucDestino AS IdSucursal
           ,CCR.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
           ,IdTipoImpuesto
           ,EmisorRetencion
           ,NumeroRetencion
           ,IdCliente
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientesRetenciones CCR
  WHERE CCR.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP', 'AJUSTE-', 'AJUSTE+', 'NDEBCHEQRECH')
;


PRINT ''
PRINT '10. CuentasCorrientesTarjetas: NO SE PASA PORQUE NO HABRA DETALLE DE CAJA NI TARJETAS.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.CuentasCorrientesTarjetas
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdTarjeta
           ,IdBanco
           ,Monto
           ,Cuotas
           ,NumeroCupon)
SELECT @IdSucDestino AS IdSucursal
           ,CCT.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
           ,IdTarjeta
           ,IdBanco
           ,Monto
           ,Cuotas
           ,NumeroCupon
  FROM SIGA_Distrib_Trinidad.dbo.CuentasCorrientesTarjetas CCT
  WHERE CCT.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP', 'AJUSTE-', 'AJUSTE+', 'NDEBCHEQRECH')
;

-----------------------------------------------------

--DELETE CuentasCorrientesPagos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM CuentasCorrientesPagos CC
--	    WHERE CC.IdSucursal = 3
--          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
--          AND CC.Letra = CuentasCorrientesPagos.Letra
--          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
--          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante)
--;

--DELETE CuentasCorrientes
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM CuentasCorrientes CC
--	    WHERE CC.IdSucursal = 3
--          AND CC.IdTipoComprobante = CuentasCorrientes.IdTipoComprobante
--          AND CC.Letra = CuentasCorrientes.Letra
--          AND CC.CentroEmisor = CuentasCorrientes.CentroEmisor
--          AND CC.NumeroComprobante = CuentasCorrientes.NumeroComprobante)
--;


--UPDATE CuentasCorrientesPagos
--  SET ImporteCuota = SaldoCuota
-- WHERE IdSucursal IN (1, 3)
--   AND SaldoCuota <> 0
--;

--UPDATE CuentasCorrientes
--  SET ImporteTotal = Saldo
-- WHERE IdSucursal IN (1, 3)
--   AND Saldo <> 0
--;



--SELECT * FROM CuentasCorrientesPagos
-- WHERE IdSucursal IN (1, 3)
--   AND SaldoCuota = 0
--;

--SELECT * FROM CuentasCorrientes
-- WHERE IdSucursal IN (1, 3)
--   AND Saldo = 0
--;

