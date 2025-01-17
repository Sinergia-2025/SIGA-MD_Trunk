
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

DECLARE @IdSucOrigen INT = 2
DECLARE @IdSucDestino INT = 2
;

PRINT ''
PRINT '1. Elimino CuentasCorrientesPagos.'
;

DELETE SIGA_PA_Separada.dbo.CuentasCorrientesPagos
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '2. Elimino CuentasCorrientesCheques.'
;
DELETE SIGA_PA_Separada.dbo.CuentasCorrientesCheques
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '3. Elimino CuentasCorrientesRetenciones.'
;
DELETE SIGA_PA_Separada.dbo.CuentasCorrientesRetenciones
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '4. Elimino CuentasCorrientesTarjetas.'
;
DELETE SIGA_PA_Separada.dbo.CuentasCorrientesTarjetas
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '5. Elimino CuentasCorrientes.'
;
DELETE SIGA_PA_Separada.dbo.CuentasCorrientes
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '6. Inserto CuentasCorrientes.'
;
INSERT INTO SIGA_PA_Separada.dbo.CuentasCorrientes
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
           ,Referencia)
SELECT @IdSucDestino AS IdSucursal
           ,CC.IdTipoComprobante
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
  FROM SIGA_PA.dbo.CuentasCorrientes CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=1)
  WHERE CC.IdSucursal = @IdSucOrigen
    AND CC.Saldo <> 0
;


PRINT ''
PRINT '7. Inserto CuentasCorrientesPagos.'
;
INSERT INTO SIGA_PA_Separada.dbo.CuentasCorrientesPagos
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
           ,DescuentoRecargo
           ,DescuentoRecargoPorc
           ,ImporteCapital
           ,ImporteInteres
  FROM SIGA_PA.dbo.CuentasCorrientesPagos CCP
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=1)
  WHERE CCP.IdSucursal = @IdSucOrigen
    AND CCP.SaldoCuota <> 0
;

PRINT ''
PRINT '8. CuentasCorrientesCheques: NO SE PASA PORQUE NO HABRA DETALLE DE CAJA NI CHEQUES.'
;
--INSERT INTO SIGA_PA_Separada.dbo.CuentasCorrientesCheques
--           (IdSucursal
--           ,IdTipoComprobante
--           ,Letra
--           ,CentroEmisor
--           ,NumeroComprobante
--           ,NumeroCheque
--           ,IdBancoCheque
--           ,IdLocalidadCheque
--           ,IdBancoSucursalCheque)
--SELECT @IdSucDestino AS IdSucursal
--           ,CCC.IdTipoComprobante
--           ,Letra
--           ,CentroEmisor
--           ,NumeroComprobante
--           ,NumeroCheque
--           ,IdBancoCheque
--           ,IdLocalidadCheque
--           ,IdBancoSucursalCheque
--  FROM SIGA_PA.dbo.CuentasCorrientesCheques CCC
--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCC.IdTipoComprobante
--         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=1)
--  WHERE CCC.IdSucursal = @IdSucOrigen
--;


PRINT ''
PRINT '9. CuentasCorrientesRetenciones: NO SE PASA PORQUE NO HABRA DETALLE DE CAJA NI RETENCIONES.'
;
--INSERT INTO SIGA_PA_Separada.dbo.CuentasCorrientesRetenciones
--           (IdSucursal
--           ,IdTipoComprobante
--           ,Letra
--           ,CentroEmisor
--           ,NumeroComprobante
--           ,IdTipoImpuesto
--           ,EmisorRetencion
--           ,NumeroRetencion
--           ,IdCliente)
--SELECT @IdSucDestino AS IdSucursal
--           ,CCR.IdTipoComprobante
--           ,Letra
--           ,CentroEmisor
--           ,NumeroComprobante
--           ,IdTipoImpuesto
--           ,EmisorRetencion
--           ,NumeroRetencion
--           ,IdCliente
--  FROM SIGA_PA.dbo.CuentasCorrientesRetenciones CCR
--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCR.IdTipoComprobante
--         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=1)
--  WHERE CCR.IdSucursal = @IdSucOrigen
--;


PRINT ''
PRINT '10. CuentasCorrientesTarjetas: NO SE PASA PORQUE NO HABRA DETALLE DE CAJA NI TARJETAS.'
;
--INSERT INTO SIGA_PA_Separada.dbo.CuentasCorrientesTarjetas
--           (IdSucursal
--           ,IdTipoComprobante
--           ,Letra
--           ,CentroEmisor
--           ,NumeroComprobante
--           ,IdTarjeta
--           ,IdBanco
--           ,Monto
--           ,Cuotas
--           ,NumeroCupon)
--SELECT @IdSucDestino AS IdSucursal
--           ,CCT.IdTipoComprobante
--           ,Letra
--           ,CentroEmisor
--           ,NumeroComprobante
--           ,IdTarjeta
--           ,IdBanco
--           ,Monto
--           ,Cuotas
--           ,NumeroCupon
--  FROM SIGA_PA.dbo.CuentasCorrientesTarjetas CCT
--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCT.IdTipoComprobante
--         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=1)
--  WHERE CCT.IdSucursal = @IdSucOrigen
--;


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

