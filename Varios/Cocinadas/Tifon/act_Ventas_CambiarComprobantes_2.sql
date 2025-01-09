
/* -------- SETEO LOS VALORES ACTUAL Y FUTURO -------- */

DECLARE @IdTipoComprobanteOrigen as varchar(10) = 'FACT-CYO';
DECLARE @CentroEmisorOrigen as int = 2;
DECLARE @LetraOrigen as varchar(1) = 'A';

DECLARE @IdTipoComprobanteDestino as varchar(10) = 'FACT-CYO';	--No cambia
DECLARE @CentroEmisorDestino as int = 2;						--No cambia
DECLARE @LetraDestino as varchar(1) = 'M';

--DECLARE @DiasDiferencia as int = DATEDIFF(day, '2018-03-05', '2019-01-11');
DECLARE @FechaDestino as Datetime = '2019-01-11 09:001';
DECLARE @NumeroOrigen as int = 1538;
DECLARE @NumeroDiferencia as int = 1-1538;


/* -------- GENERO VENTAS -------- */

PRINT ''
PRINT 'Ventas: Inserto con Nueva Clave Primaria.'
;
INSERT INTO Ventas
           (IdSucursal
      ,IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,TipoDocVendedor
      ,NroDocVendedor
      ,SubTotal
      ,DescuentoRecargo
      ,ImporteTotal
      ,IdCategoriaFiscal
      ,IdFormasPago
      ,Observacion
      ,ImporteBruto
      ,DescuentoRecargoPorc
      ,IdEstadoComprobante
      ,IdTipoComprobanteFact
      ,LetraFact
      ,CentroEmisorFact
      ,NumeroComprobanteFact
      ,IdCaja
      ,NumeroPlanilla
      ,NumeroMovimiento
      ,ImportePesos
      ,ImporteTickets
      ,ImporteTarjetas
      ,ImporteCheques
      ,Kilos
      ,Bultos
      ,ValorDeclarado
      ,IdTransportista
      ,NumeroLote
      ,TotalImpuestos
      ,CantidadInvocados
      ,CantidadLotes
      ,Usuario
      ,FechaAlta
      ,CAE
      ,CAEVencimiento
      ,Utilidad
      ,FechaTransmisionAFIP
      ,CotizacionDolar
      ,ComisionVendedor
      ,FechaImpresion
      ,IdAsiento
      ,MercDespachada
      ,ImporteTransfBancaria
      ,IdCuentaBancaria
      ,IdActividad
      ,IdProvincia
      ,FechaEnvio
      ,NumeroReparto
      ,FechaRendicion
      ,IdCliente
      ,IdProveedor
      ,FechaActualizacion
      ,Direccion
      ,IdLocalidad
      ,IdCategoria
      ,CodigoErrorAfip
      ,IdPlanCuenta
      ,TotalImpuestoInterno
      ,MetodoGrabacion
      ,IdFuncion
      ,SaldoActualCtaCte
      ,NumeroOrdenCompra
      ,IdCobrador
      ,IdMoneda
      ,IdClienteVinculado)
SELECT IdSucursal
      ,@IdTipoComprobanteDestino AS XXIdTipoComprobanteDestino
      ,@LetraDestino AS XXLetra
      ,@CentroEmisorDestino AS XXCentroEmisor
      ,NumeroComprobante + @NumeroDiferencia
      ,@FechaDestino as XXFecha
      ,TipoDocVendedor
      ,NroDocVendedor
      ,SubTotal
      ,DescuentoRecargo
      ,ImporteTotal
      ,IdCategoriaFiscal
      ,IdFormasPago
      ,Observacion
      ,ImporteBruto
      ,DescuentoRecargoPorc
      ,IdEstadoComprobante
      ,IdTipoComprobanteFact
      ,LetraFact
      ,CentroEmisorFact
      ,NumeroComprobanteFact
      ,IdCaja
      ,NumeroPlanilla
      ,NumeroMovimiento
      ,ImportePesos
      ,ImporteTickets
      ,ImporteTarjetas
      ,ImporteCheques
      ,Kilos
      ,Bultos
      ,ValorDeclarado
      ,IdTransportista
      ,NumeroLote
      ,TotalImpuestos
      ,CantidadInvocados
      ,CantidadLotes
      ,Usuario
      ,FechaAlta
      ,CAE
      ,CAEVencimiento
      ,Utilidad
      ,FechaTransmisionAFIP
      ,CotizacionDolar
      ,ComisionVendedor
      ,FechaImpresion
      ,IdAsiento
      ,MercDespachada
      ,ImporteTransfBancaria
      ,IdCuentaBancaria
      ,IdActividad
      ,IdProvincia
      ,FechaEnvio
      ,NumeroReparto
      ,FechaRendicion
      ,IdCliente
      ,IdProveedor
      ,FechaActualizacion
      ,Direccion
      ,IdLocalidad
      ,IdCategoria
      ,CodigoErrorAfip
      ,IdPlanCuenta
      ,TotalImpuestoInterno
      ,MetodoGrabacion
      ,IdFuncion
      ,SaldoActualCtaCte
      ,NumeroOrdenCompra
      ,IdCobrador
      ,IdMoneda
      ,IdClienteVinculado
    FROM Ventas
   WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
      AND Letra = @LetraOrigen
      AND CentroEmisor = @CentroEmisorOrigen
      AND NumeroComprobante >= @NumeroOrigen
     --AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
;
   
/* -------- ACTUALIZO LAS TABLAS RELACIONADAS CON EL NUEVO EMISOR -------- */

PRINT ''
PRINT 'VentasCheques: Actualizo a Emisor Nuevo.'
;

UPDATE VentasCheques
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasCheques.IdSucursal
         AND V.IdTipoComprobante = VentasCheques.IdTipoComprobante
         AND V.Letra = VentasCheques.Letra
         AND V.CentroEmisor = VentasCheques.CentroEmisor
         AND V.NumeroComprobante = VentasCheques.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasChequesRechazado: Actualizo a Emisor Nuevo.'
;
UPDATE VentasChequesRechazados
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasChequesRechazados.IdSucursal
         AND V.IdTipoComprobante = VentasChequesRechazados.IdTipoComprobante
         AND V.Letra = VentasChequesRechazados.Letra
         AND V.CentroEmisor = VentasChequesRechazados.CentroEmisor
         AND V.NumeroComprobante = VentasChequesRechazados.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasImpuestos: Actualizo a Emisor Nuevo.'
;
UPDATE VentasImpuestos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasImpuestos.IdSucursal
         AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
         AND V.Letra = VentasImpuestos.Letra
         AND V.CentroEmisor = VentasImpuestos.CentroEmisor
         AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasObservaciones: Actualizo a Emisor Nuevo.'
;
UPDATE VentasObservaciones
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasObservaciones.IdSucursal
         AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
         AND V.Letra = VentasObservaciones.Letra
         AND V.CentroEmisor = VentasObservaciones.CentroEmisor
         AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasProductos: Actualizo a Emisor Nuevo.'
;
UPDATE VentasProductos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductos.IdSucursal
         AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
         AND V.Letra = VentasProductos.Letra
         AND V.CentroEmisor = VentasProductos.CentroEmisor
         AND V.NumeroComprobante = VentasProductos.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasProductosLotes: Actualizo a Emisor Nuevo.'
;
UPDATE VentasProductosLotes
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductosLotes.IdSucursal
         AND V.IdTipoComprobante = VentasProductosLotes.IdTipoComprobante
         AND V.Letra = VentasProductosLotes.Letra
         AND V.CentroEmisor = VentasProductosLotes.CentroEmisor
         AND V.NumeroComprobante = VentasProductosLotes.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'Ventas: Actualizo a Emisor Nuevo los Invocados.'
;
UPDATE Ventas
   SET IdTipoComprobanteFact = @IdTipoComprobanteDestino
      ,LetraFact = @LetraDestino
      ,CentroEmisorFact = @CentroEmisorDestino
      ,NumeroComprobanteFact = NumeroComprobanteFact + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = Ventas.IdSucursal
         AND V.IdTipoComprobante = Ventas.IdTipoComprobanteFact
         AND V.Letra = Ventas.LetraFact
         AND V.CentroEmisor = Ventas.CentroEmisorFact
         AND V.NumeroComprobante = Ventas.NumeroComprobanteFact
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;


PRINT ''
PRINT 'Cargos: Actualizo a Emisor Nuevo.'
;
UPDATE Cargos
   SET IdTipoComprobanteAlquiler = @IdTipoComprobanteDestino
      ,LetraAlquiler = @LetraDestino
      ,CentroEmisorAlquiler = @CentroEmisorDestino
      ,NumeroComprobanteAlquiler = NumeroComprobanteAlquiler + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = Cargos.IdSucursal
         AND V.IdTipoComprobante = Cargos.IdTipoComprobanteAlquiler
         AND V.Letra = Cargos.LetraAlquiler
         AND V.CentroEmisor = Cargos.CentroEmisorAlquiler
         AND V.NumeroComprobante = Cargos.NumeroComprobanteAlquiler
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'MovimientosVentas: Actualizo a Emisor Nuevo.'
;
UPDATE MovimientosVentas
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = MovimientosVentas.IdSucursal
         AND V.IdTipoComprobante = MovimientosVentas.IdTipoComprobante
         AND V.Letra = MovimientosVentas.Letra
         AND V.CentroEmisor = MovimientosVentas.CentroEmisor
         AND V.NumeroComprobante = MovimientosVentas.NumeroComprobante
         AND V.IdTipoComprobante = @IdTipoComprobanteOrigen
         AND V.Letra = @LetraOrigen
         AND V.CentroEmisor = @CentroEmisorOrigen
         AND V.NumeroComprobante >= @NumeroOrigen
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

/* -------- GENERO LAS CUENTAS CORRIENTES CON EL NUEVO EMISOR -------- */

PRINT ''
PRINT 'CuentasCorrientes: Inserto con Emisor Nuevo.'
;
INSERT INTO CuentasCorrientes
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
      ,IdUsuario
      ,IdEstadoComprobante
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
      ,IdSucursalVinculado
      ,IdTipoComprobanteVinculado
      ,LetraVinculado
      ,CentroEmisorVinculado
      ,NumeroComprobanteVinculado)
SELECT IdSucursal
      ,@IdTipoComprobanteDestino AS XXIdTipoComprobanteDestino
      ,@LetraDestino AS XXLetra
      ,@CentroEmisorDestino AS XXCentroEmisor
      ,NumeroComprobante + @NumeroDiferencia
      ,@FechaDestino AS XXFecha
      ,@FechaDestino+30 AS XXFechaVencimiento
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
      ,IdUsuario
      ,IdEstadoComprobante
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
      ,IdSucursalVinculado
      ,IdTipoComprobanteVinculado
      ,LetraVinculado
      ,CentroEmisorVinculado
      ,NumeroComprobanteVinculado
    FROM CuentasCorrientes
   WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
     AND Letra = @LetraOrigen
     AND CentroEmisor = @CentroEmisorOrigen
     AND NumeroComprobante >= @NumeroOrigen
     --AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
;

PRINT ''
PRINT 'CuentasCorrientesPagos: Actualizo a Emisor Nuevo.'
;
UPDATE CuentasCorrientesPagos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante
          AND CC.IdTipoComprobante = @IdTipoComprobanteOrigen
          AND CC.Letra = @LetraOrigen
          AND CC.CentroEmisor = @CentroEmisorOrigen
          AND CC.NumeroComprobante >= @NumeroOrigen
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          --AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') 
          )
;

PRINT ''
PRINT 'CuentasCorrientesPagos: Actualizo a Emisor 2 Nuevo.'
;
UPDATE CuentasCorrientesPagos
   SET IdTipoComprobante2 = @IdTipoComprobanteDestino
      ,Letra2 = @LetraDestino
      ,CentroEmisor2 = @CentroEmisorDestino
      ,NumeroComprobante2 = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante2
          AND CC.Letra = CuentasCorrientesPagos.Letra2
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor2
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante2
          AND CC.IdTipoComprobante = @IdTipoComprobanteOrigen
          AND CC.Letra = @LetraOrigen
          AND CC.CentroEmisor = @CentroEmisorOrigen
          AND CC.NumeroComprobante >= @NumeroOrigen
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          --AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') 
          )
;

PRINT ''
PRINT 'CuentasCorrientesCheques: Actualizo a Emisor Nuevo.'
;
UPDATE CuentasCorrientesCheques
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesCheques.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesCheques.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesCheques.Letra
          AND CC.CentroEmisor = CuentasCorrientesCheques.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesCheques.NumeroComprobante
          AND CC.IdTipoComprobante = @IdTipoComprobanteOrigen
          AND CC.Letra = @LetraOrigen
          AND CC.CentroEmisor = @CentroEmisorOrigen
          AND CC.NumeroComprobante >= @NumeroOrigen
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          --AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') 
          )
;

PRINT ''
PRINT 'CuentasCorrientesRetenciones: Actualizo a Emisor Nuevo.'
;
UPDATE CuentasCorrientesRetenciones
   SET IdTipoComprobante = @IdTipoComprobanteDestino
      ,Letra = @LetraDestino
      ,CentroEmisor = @CentroEmisorDestino
      ,NumeroComprobante = NumeroComprobante + @NumeroDiferencia
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesRetenciones.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesRetenciones.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesRetenciones.Letra
          AND CC.CentroEmisor = CuentasCorrientesRetenciones.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesRetenciones.NumeroComprobante
          AND CC.IdTipoComprobante = @IdTipoComprobanteOrigen
          AND CC.Letra = @LetraOrigen
          AND CC.CentroEmisor = @CentroEmisorOrigen
          AND CC.NumeroComprobante >= @NumeroOrigen
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          --AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') 
          )
;

/* -------- BORRO LAS CUENTAS CORRIENTES CON EL EMISOR ANTERIOR -------- */

PRINT ''
PRINT 'CuentasCorrientesPagos: Actualizo a Emisor Nuevo.'
;
DELETE CuentasCorrientes
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
   AND Letra = @LetraOrigen
   AND CentroEmisor = @CentroEmisorOrigen
   AND NumeroComprobante >= @NumeroOrigen
--   AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
;

/* -------- BORRO LAS VENTAS CON EL EMISOR ANTERIOR -------- */

PRINT ''
PRINT 'Ventas: Borro los movimientos con el Emisor Anterior.'
;
DELETE Ventas
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
   AND Letra = @LetraOrigen
   AND CentroEmisor = @CentroEmisorOrigen
   AND NumeroComprobante >= @NumeroOrigen
   --AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
;

/* -------- ACTUALIZO LOS PUNTEROS -------- */


PRINT ''
PRINT 'VentasNumeros: Creo los valores Nuevos (da error si existe).'
;
--INSERT INTO VentasNumeros
--           (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
--           ,IdTipoComprobanteRelacionado, Fecha)
--     VALUES
--           (@IdTipoComprobanteDestino, @LetraDestino, @CentroEmisorDestino, 1, 0
--           ,NULL, '1900-01-01')
--;


PRINT ''
PRINT 'VentasNumeros: Actualizo a Emisor Nuevo.'
;
--UPDATE VentasNumeros 
--   SET IdTipoComprobante = @IdTipoComprobanteDestino
--      ,LetraFiscal = @LetraDestino
--      ,CentroEmisor = @CentroEmisorDestino
--      ,Numero = Numero + @NumeroDiferencia
-- WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
--   AND LetraFiscal = @LetraOrigen
--   AND CentroEmisor = @CentroEmisorOrigen
--   AND Numero >= @NumeroOrigen
--;
UPDATE VentasNumeros 
   SET Numero = Numero + @NumeroDiferencia
 WHERE IdTipoComprobante = @IdTipoComprobanteDestino
   AND LetraFiscal = @LetraDestino
   AND CentroEmisor = @CentroEmisorDestino
   AND Numero >= @NumeroOrigen
;
