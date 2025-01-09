
/* -------- GENERO LAS VENTAS CON EL TIPO DE VENTAS -------- */

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
           ,TipoDocCliente
           ,NroDocCliente
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
           ,CotizacionDolar)
SELECT IdSucursal
      ,IdTipoComprobante + '-MANUAL' AS TipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,TipoDocVendedor
      ,NroDocVendedor
      ,SubTotal
      ,DescuentoRecargo
      ,ImporteTotal
      ,TipoDocCliente
      ,NroDocCliente
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
    FROM Ventas
   WHERE CentroEmisor = 1 
     AND IdTipoComprobante IN ('FACT','NCRED')
     AND Letra = 'B'
     AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
GO
   
/* -------- ACTUALIZO LAS TABLAS RELACIONADAS CON EL NUEVO EMISOR -------- */

UPDATE VentasCheques
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasCheques.IdSucursal
         AND V.IdTipoComprobante = VentasCheques.IdTipoComprobante
         AND V.Letra = VentasCheques.Letra
         AND V.CentroEmisor = VentasCheques.CentroEmisor
         AND V.NumeroComprobante = VentasCheques.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasChequesRechazados
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasChequesRechazados.IdSucursal
         AND V.IdTipoComprobante = VentasChequesRechazados.IdTipoComprobante
         AND V.Letra = VentasChequesRechazados.Letra
         AND V.CentroEmisor = VentasChequesRechazados.CentroEmisor
         AND V.NumeroComprobante = VentasChequesRechazados.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasImpuestos
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasImpuestos.IdSucursal
         AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
         AND V.Letra = VentasImpuestos.Letra
         AND V.CentroEmisor = VentasImpuestos.CentroEmisor
         AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasObservaciones
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasObservaciones.IdSucursal
         AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
         AND V.Letra = VentasObservaciones.Letra
         AND V.CentroEmisor = VentasObservaciones.CentroEmisor
         AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasProductos
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductos.IdSucursal
         AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
         AND V.Letra = VentasProductos.Letra
         AND V.CentroEmisor = VentasProductos.CentroEmisor
         AND V.NumeroComprobante = VentasProductos.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasProductosLotes
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductosLotes.IdSucursal
         AND V.IdTipoComprobante = VentasProductosLotes.IdTipoComprobante
         AND V.Letra = VentasProductosLotes.Letra
         AND V.CentroEmisor = VentasProductosLotes.CentroEmisor
         AND V.NumeroComprobante = VentasProductosLotes.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE MovimientosVentas
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = MovimientosVentas.IdSucursal
         AND V.IdTipoComprobante = MovimientosVentas.IdTipoComprobante
         AND V.Letra = MovimientosVentas.Letra
         AND V.CentroEmisor = MovimientosVentas.CentroEmisor
         AND V.NumeroComprobante = MovimientosVentas.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'B'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

/* -------- GENERO LAS CUENTAS CORRIENTES CON EL NUEVO EMISOR -------- */

INSERT INTO CuentasCorrientes
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,FechaVencimiento
           ,ImporteTotal
           ,TipoDocCliente
           ,NroDocCliente
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
           ,ImporteRetenciones)
SELECT IdSucursal
      ,IdTipoComprobante + '-MANUAL' AS TipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,FechaVencimiento
      ,ImporteTotal
      ,TipoDocCliente
      ,NroDocCliente
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
    FROM CuentasCorrientes
   WHERE CentroEmisor = 1 
    AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
    AND IdTipoComprobante IN ('FACT','NCRED')   
    AND Letra = 'B'
    AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
GO

UPDATE CuentasCorrientesPagos
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'B'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

UPDATE CuentasCorrientesPagos
   SET IdTipoComprobante2 = IdTipoComprobante2 + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante2
          AND CC.Letra = CuentasCorrientesPagos.Letra2
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor2
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante2
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'B'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

UPDATE CuentasCorrientesCheques
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesCheques.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesCheques.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesCheques.Letra
          AND CC.CentroEmisor = CuentasCorrientesCheques.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesCheques.NumeroComprobante
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'B'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

UPDATE CuentasCorrientesRetenciones
   SET IdTipoComprobante = IdTipoComprobante + '-MANUAL'
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesRetenciones.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesRetenciones.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesRetenciones.Letra
          AND CC.CentroEmisor = CuentasCorrientesRetenciones.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesRetenciones.NumeroComprobante
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'B'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

/* -------- BORRO LAS CUENTAS CORRIENTES CON EL EMISOR ANTERIOR -------- */

DELETE CuentasCorrientes
 WHERE CentroEmisor = 1 
   AND IdTipoComprobante IN ('FACT','NCRED')   
   AND Letra = 'B'
   AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
   AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
GO

/* -------- BORRO LAS VENTAS CON EL EMISOR ANTERIOR -------- */

DELETE Ventas
 WHERE CentroEmisor = 1 
   AND IdTipoComprobante IN ('FACT','NCRED')   
   AND Letra = 'B'
   AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
GO


