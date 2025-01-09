
/* -------- SETEO LOS EMISORES ACTUAL Y FUTURO -------- */


DECLARE @CentroEmisorOrigen as int = 1
;

DECLARE @CentroEmisorDestino as int = 3
;

PRINT ''
PRINT 'Impresoras: Actualizo Punto.'
;
UPDATE Impresoras 
   SET CentroEmisor = @CentroEmisorDestino
  WHERE IdSucursal = 1
   AND IdImpresora = 'NORMAL'
   AND CentroEmisor = @CentroEmisorOrigen
;

/* -------- GENERO VENTAS -------- */

PRINT ''
PRINT 'Ventas: Inserto con Emisor Nuevo.'
;
INSERT INTO Ventas
           (IdSucursal
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,[SubTotal]
           ,[DescuentoRecargo]
           ,[ImporteTotal]
           ,[IdCategoriaFiscal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[ImporteBruto]
           ,[DescuentoRecargoPorc]
           ,[IdEstadoComprobante]
           ,[IdTipoComprobanteFact]
           ,[LetraFact]
           ,[CentroEmisorFact]
           ,[NumeroComprobanteFact]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[ImportePesos]
           ,[ImporteTickets]
           ,[ImporteTarjetas]
           ,[ImporteCheques]
           ,[Kilos]
           ,[Bultos]
           ,[ValorDeclarado]
           ,[IdTransportista]
           ,[NumeroLote]
           ,[TotalImpuestos]
           ,[CantidadInvocados]
           ,[CantidadLotes]
           ,[Usuario]
           ,[FechaAlta]
           ,[CAE]
           ,[CAEVencimiento]
           ,[Utilidad]
           ,[FechaTransmisionAFIP]
           ,[CotizacionDolar]
           ,[ComisionVendedor]
           ,[FechaImpresion]
           ,[IdAsiento]
           ,[MercDespachada]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[IdActividad]
           ,[IdProvincia]
           ,[FechaEnvio]
           ,[NumeroReparto]
           ,[FechaRendicion]
           ,[IdCliente]
           ,[IdProveedor]
           ,[FechaActualizacion]
           ,[Direccion]
           ,[IdLocalidad]
           ,[IdCategoria]
           ,[CodigoErrorAfip]
           ,[IdPlanCuenta]
           ,[TotalImpuestoInterno]
           ,[MetodoGrabacion]
           ,[IdFuncion]
           ,[SaldoActualCtaCte]
           ,[NumeroOrdenCompra]
           ,[IdCobrador])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,@CentroEmisorDestino AS XXCentroEmisor
      ,[NumeroComprobante]
      ,[Fecha]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[SubTotal]
      ,[DescuentoRecargo]
      ,[ImporteTotal]
      ,[IdCategoriaFiscal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[ImporteBruto]
      ,[DescuentoRecargoPorc]
      ,[IdEstadoComprobante]
      ,[IdTipoComprobanteFact]
      ,[LetraFact]
      ,[CentroEmisorFact]
      ,[NumeroComprobanteFact]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[ImportePesos]
      ,[ImporteTickets]
      ,[ImporteTarjetas]
      ,[ImporteCheques]
      ,[Kilos]
      ,[Bultos]
      ,[ValorDeclarado]
      ,[IdTransportista]
      ,[NumeroLote]
      ,[TotalImpuestos]
      ,[CantidadInvocados]
      ,[CantidadLotes]
      ,[Usuario]
      ,[FechaAlta]
      ,[CAE]
      ,[CAEVencimiento]
      ,[Utilidad]
      ,[FechaTransmisionAFIP]
      ,[CotizacionDolar]
      ,[ComisionVendedor]
      ,[FechaImpresion]
      ,[IdAsiento]
      ,[MercDespachada]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[IdActividad]
      ,[IdProvincia]
      ,[FechaEnvio]
      ,[NumeroReparto]
      ,[FechaRendicion]
      ,[IdCliente]
      ,[IdProveedor]
      ,[FechaActualizacion]
      ,[Direccion]
      ,[IdLocalidad]
      ,[IdCategoria]
      ,[CodigoErrorAfip]
      ,[IdPlanCuenta]
      ,[TotalImpuestoInterno]
      ,[MetodoGrabacion]
      ,[IdFuncion]
      ,[SaldoActualCtaCte]
      ,[NumeroOrdenCompra]
      ,[IdCobrador]
    FROM Ventas
   WHERE CentroEmisor = @CentroEmisorOrigen
     --AND IdTipoComprobante IN ('FACT','NCRED')
     --AND Letra = 'A'
     --AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
;
   
/* -------- ACTUALIZO LAS TABLAS RELACIONADAS CON EL NUEVO EMISOR -------- */

PRINT ''
PRINT 'VentasCheques: Actualizo a Emisor Nuevo.'
;

UPDATE VentasCheques
 SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasCheques.IdSucursal
         AND V.IdTipoComprobante = VentasCheques.IdTipoComprobante
         AND V.Letra = VentasCheques.Letra
         AND V.CentroEmisor = VentasCheques.CentroEmisor
         AND V.NumeroComprobante = VentasCheques.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasChequesRechazado: Actualizo a Emisor Nuevo.'
;
UPDATE VentasChequesRechazados
 SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasChequesRechazados.IdSucursal
         AND V.IdTipoComprobante = VentasChequesRechazados.IdTipoComprobante
         AND V.Letra = VentasChequesRechazados.Letra
         AND V.CentroEmisor = VentasChequesRechazados.CentroEmisor
         AND V.NumeroComprobante = VentasChequesRechazados.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasImpuestos: Actualizo a Emisor Nuevo.'
;
UPDATE VentasImpuestos
   SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasImpuestos.IdSucursal
         AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
         AND V.Letra = VentasImpuestos.Letra
         AND V.CentroEmisor = VentasImpuestos.CentroEmisor
         AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasObservaciones: Actualizo a Emisor Nuevo.'
;
UPDATE VentasObservaciones
   SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasObservaciones.IdSucursal
         AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
         AND V.Letra = VentasObservaciones.Letra
         AND V.CentroEmisor = VentasObservaciones.CentroEmisor
         AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasProductos: Actualizo a Emisor Nuevo.'
;
UPDATE VentasProductos
   SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductos.IdSucursal
         AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
         AND V.Letra = VentasProductos.Letra
         AND V.CentroEmisor = VentasProductos.CentroEmisor
         AND V.NumeroComprobante = VentasProductos.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'VentasProductosLotes: Actualizo a Emisor Nuevo.'
;
UPDATE VentasProductosLotes
 SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductosLotes.IdSucursal
         AND V.IdTipoComprobante = VentasProductosLotes.IdTipoComprobante
         AND V.Letra = VentasProductosLotes.Letra
         AND V.CentroEmisor = VentasProductosLotes.CentroEmisor
         AND V.NumeroComprobante = VentasProductosLotes.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen 
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

PRINT ''
PRINT 'MovimientosVentas: Actualizo a Emisor Nuevo.'
;
UPDATE MovimientosVentas
   SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = MovimientosVentas.IdSucursal
         AND V.IdTipoComprobante = MovimientosVentas.IdTipoComprobante
         AND V.Letra = MovimientosVentas.Letra
         AND V.CentroEmisor = MovimientosVentas.CentroEmisor
         AND V.NumeroComprobante = MovimientosVentas.NumeroComprobante
         AND V.CentroEmisor = @CentroEmisorOrigen 
         --AND V.IdTipoComprobante IN ('FACT','NCRED')   
         --AND V.Letra = 'A'
         --AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01'
         )
;

/* -------- GENERO LAS CUENTAS CORRIENTES CON EL NUEVO EMISOR -------- */

PRINT ''
PRINT 'CuentasCorrientes: Inserto con Emisor Nuevo.'
;
INSERT INTO CuentasCorrientes
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
           ,[IdPlanCuenta]
           ,[MetodoGrabacion]
           ,[IdFuncion]
           ,[ImprimeSaldos]
           ,[IdCobrador]
           ,[IdEstadoCliente]
           ,[NumeroOrdenCompra])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,@CentroEmisorDestino AS XXCentroEmisor
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
      ,[IdPlanCuenta]
      ,[MetodoGrabacion]
      ,[IdFuncion]
      ,[ImprimeSaldos]
      ,[IdCobrador]
      ,[IdEstadoCliente]
      ,[NumeroOrdenCompra]
    FROM CuentasCorrientes
   WHERE CentroEmisor = @CentroEmisorOrigen 
    --AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
    --AND IdTipoComprobante IN ('FACT','NCRED')   
    --AND Letra = 'A'
    AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
;

PRINT ''
PRINT 'CuentasCorrientesPagos: Actualizo a Emisor Nuevo.'
;
UPDATE CuentasCorrientesPagos
 SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante
          AND CC.CentroEmisor = @CentroEmisorOrigen 
          --AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          --AND CC.Letra = 'A'
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
;

PRINT ''
PRINT 'CuentasCorrientesPagos: Actualizo a Emisor 2 Nuevo.'
;
UPDATE CuentasCorrientesPagos
 SET CentroEmisor2 = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante2
          AND CC.Letra = CuentasCorrientesPagos.Letra2
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor2
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante2
          AND CC.CentroEmisor = @CentroEmisorOrigen 
          --AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          --AND CC.Letra = 'A'
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
;

PRINT ''
PRINT 'CuentasCorrientesCheques: Actualizo a Emisor Nuevo.'
;
UPDATE CuentasCorrientesCheques
 SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesCheques.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesCheques.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesCheques.Letra
          AND CC.CentroEmisor = CuentasCorrientesCheques.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesCheques.NumeroComprobante
          AND CC.CentroEmisor = @CentroEmisorOrigen 
          --AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          --AND CC.Letra = 'A'
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
;

PRINT ''
PRINT 'CuentasCorrientesRetenciones: Actualizo a Emisor Nuevo.'
;
UPDATE CuentasCorrientesRetenciones
 SET CentroEmisor = @CentroEmisorDestino
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesRetenciones.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesRetenciones.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesRetenciones.Letra
          AND CC.CentroEmisor = CuentasCorrientesRetenciones.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesRetenciones.NumeroComprobante
          AND CC.CentroEmisor = @CentroEmisorOrigen 
          --AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          --AND CC.Letra = 'A'
          --AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
;

/* -------- BORRO LAS CUENTAS CORRIENTES CON EL EMISOR ANTERIOR -------- */

PRINT ''
PRINT 'CuentasCorrientesPagos: Actualizo a Emisor Nuevo.'
;
DELETE CuentasCorrientes
 WHERE CentroEmisor = @CentroEmisorOrigen 
   --AND IdTipoComprobante IN ('FACT','NCRED')   
   --AND Letra = 'A'
   --AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
   AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
;

/* -------- BORRO LAS VENTAS CON EL EMISOR ANTERIOR -------- */

PRINT ''
PRINT 'Ventas: Borro los movimientos con el Emisor Anterior.'
;
DELETE Ventas
 WHERE CentroEmisor = @CentroEmisorOrigen 
   --AND IdTipoComprobante IN ('FACT','NCRED')   
   --AND Letra = 'A'
   --AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
;

/* -------- ACTUALIZO LOS PUNTEROS -------- */


PRINT ''
PRINT 'VentasNumeros: Actualizo a Emisor Nuevo.'
;
UPDATE VentasNumeros 
   SET CentroEmisor = @CentroEmisorDestino
 WHERE CentroEmisor = @CentroEmisorOrigen
-- WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB','NDEBCHEQRECH')   
;

--UPDATE VentasNumeros 
--   SET Numero = 3500
-- WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB','NDEBCHEQRECH')   
--   AND LetraFiscal = 'A'
--;

--UPDATE VentasNumeros 
--   SET Numero = 0
-- WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB','NDEBCHEQRECH')   
--   AND LetraFiscal = 'B'
--;

