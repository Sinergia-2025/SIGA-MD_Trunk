
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

DECLARE @IdSucOrigen INT = 2
DECLARE @IdSucDestino INT = 3
;

PRINT ''
PRINT '1. Elimino CuentasCorrientesProvPagos.'
;

DELETE SIGA_Separada.dbo.CuentasCorrientesProvPagos
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '2. Elimino CuentasCorrientesProvCheques.'
;
DELETE SIGA_Separada.dbo.CuentasCorrientesProvCheques
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '3. Elimino CuentasCorrientesProvRetenciones.'
;
DELETE SIGA_Separada.dbo.CuentasCorrientesProvRetenciones
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '4. Elimino CuentasCorrientesProv.'
;
DELETE SIGA_Separada.dbo.CuentasCorrientesProv
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '5. Inserto CuentasCorrientesProv.'
;
INSERT INTO SIGA_Separada.dbo.CuentasCorrientesProv
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
  FROM SIGA.dbo.CuentasCorrientesProv CCP
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE CCP.IdSucursal = @IdSucOrigen
    AND CCP.Saldo <> 0
;


PRINT ''
PRINT '6. Inserto CuentasCorrientesProvPagos.'
;
INSERT INTO SIGA_Separada.dbo.CuentasCorrientesProvPagos
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
  FROM SIGA.dbo.CuentasCorrientesProvPagos CCPP
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCPP.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE CCPP.IdSucursal = @IdSucOrigen
    AND CCPP.SaldoCuota <> 0
;


/* FALTA */ 

-- CuentasCorrientesProvCheques
-- CuentasCorrientesProvRetenciones
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
