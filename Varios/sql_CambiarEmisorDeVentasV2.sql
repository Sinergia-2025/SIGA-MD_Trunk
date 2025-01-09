/* -------- PREPARO EL EMISOR 2 -------- */

UPDATE Impresoras 
   SET CentroEmisor=99
  WHERE IdImpresora = 'FISCAL2'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante
           ,EsFiscal
           ,Descripcion
           ,Tipo
           ,CoeficienteStock
           ,GrabaLibro
           ,EsFacturable
           ,LetrasHabilitadas
           ,CantidadMaximaItems
           ,Imprime
           ,CoeficienteValores
           ,ModificaAlFacturar
           ,EsFacturador
           ,AfectaCaja
           ,CargaPrecioActual
           ,ActualizaCtaCte
           ,DescripcionAbrev
           ,PuedeSerBorrado
           ,CantidadCopias
           ,ComprobantesAsociados
           ,EsRemitoTransportista
           ,EsComercial
           ,CantidadMaximaItemsObserv
           ,IdTipoComprobanteSecundario
           ,ImporteTope
           ,IdTipoComprobanteEpson
           ,UsaFacturacionRapida
           ,ImporteMinimo
           ,EsElectronico
           ,UsaFacturacion
           ,UtilizaImpuestos
           ,NumeracionAutomatica)
SELECT IdTipoComprobante + '-MANUAL'
      ,EsFiscal
      ,Descripcion + ' Manual'
      ,Tipo
      ,CoeficienteStock
      ,GrabaLibro
      ,EsFacturable
      ,LetrasHabilitadas
      ,CantidadMaximaItems
      ,Imprime
      ,CoeficienteValores
      ,ModificaAlFacturar
      ,EsFacturador
      ,AfectaCaja
      ,CargaPrecioActual
      ,ActualizaCtaCte
      ,DescripcionAbrev
      ,PuedeSerBorrado
      ,CantidadCopias
      ,ComprobantesAsociados
      ,EsRemitoTransportista
      ,EsComercial
      ,CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario
      ,ImporteTope
      ,IdTipoComprobanteEpson
      ,UsaFacturacionRapida
      ,ImporteMinimo
      ,EsElectronico
      ,UsaFacturacion
      ,UtilizaImpuestos
      ,NumeracionAutomatica
  FROM TiposComprobantes
 WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB')
GO

UPDATE TiposComprobantes
   SET DescripcionAbrev = 'Fact.Man.'
 WHERE IdTipoComprobante = 'FACT-MANUAL'
GO

UPDATE TiposComprobantes
   SET DescripcionAbrev = 'NCred.Man.'
 WHERE IdTipoComprobante = 'NCRED-MANUAL'
GO

UPDATE TiposComprobantes
   SET DescripcionAbrev = 'NDeb.Man.'
 WHERE IdTipoComprobante = 'NDEB-MANUAL'
GO


UPDATE Impresoras 
   SET ComprobantesHabilitados='COTIZACION,FV,ANTICIPO,COTIZCHEQRECH,DEV-COTIZACION,FACTCOM,GASTO,NCREDCOM,NDEBCOM,NDEBCHEQRECH,NDEB-COTIZACION,PAGO,PEDIDOPROVEEDOR,PRESUP,RECIBO,REMITOCOM,REMITOCOM-NC,REMITOTRANSP'
  WHERE IdImpresora = 'NORMAL'
GO

/* -------- GENERO EL EMISOR 2 PARA CAMBIAR COMPROBANTES -------- */

INSERT INTO Impresoras
           (IdSucursal
           ,IdImpresora
           ,TipoImpresora
           ,CentroEmisor
           ,ComprobantesHabilitados
           ,Puerto
           ,Velocidad
           ,EsProtocoloExtendido
           ,Modelo
           ,OrigenPapel
           ,CantidadCopias
           ,TipoFormulario
           ,TamanioLetra
           ,Marca
           ,Metodo)
SELECT IdSucursal
      ,'PRE-IMPRESO' AS ID
      ,TipoImpresora
      ,2 AS Emisor
      ,'FACT,NCRED,NDEB' AS ComprobHabilitados
      ,Puerto
      ,Velocidad
      ,EsProtocoloExtendido
      ,Modelo
      ,OrigenPapel
      ,CantidadCopias
      ,TipoFormulario
      ,TamanioLetra
      ,Marca
      ,Metodo
   FROM Impresoras
   WHERE CentroEmisor = 1 
     AND IdImpresora = 'NORMAL'
GO


INSERT INTO ImpresorasPCs
      (IdSucursal, IdImpresora, NombrePC)
   VALUES
      (1, 'PRE-IMPRESO','NACHO-PC'),
      (1, 'PRE-IMPRESO','SERVIDOR'),
      (1, 'PRE-IMPRESO','TERRA-PC')
GO

INSERT INTO Impresoras
           (IdSucursal
           ,IdImpresora
           ,TipoImpresora
           ,CentroEmisor
           ,ComprobantesHabilitados
           ,Puerto
           ,Velocidad
           ,EsProtocoloExtendido
           ,Modelo
           ,OrigenPapel
           ,CantidadCopias
           ,TipoFormulario
           ,TamanioLetra
           ,Marca
           ,Metodo)
SELECT IdSucursal
      ,'NO-USAR' AS ID
      ,TipoImpresora
      ,1001 AS Emisor
      ,'FACT-MANUAL,NCRED-MANUAL,NDEB-MANUAL' AS ComprobHabilitados
      ,Puerto
      ,Velocidad
      ,EsProtocoloExtendido
      ,Modelo
      ,OrigenPapel
      ,CantidadCopias
      ,TipoFormulario
      ,TamanioLetra
      ,Marca
      ,Metodo
   FROM Impresoras
   WHERE CentroEmisor = 1 
     AND IdImpresora = 'NORMAL'
GO

INSERT INTO ImpresorasPCs
      (IdSucursal, IdImpresora, NombrePC)
   VALUES
      (1, 'NO-USAR','NO-USAR')
GO

/* -------- GENERO LAS VENTAS CON EL NUEVO EMISOR -------- */

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
      ,IdTipoComprobante
      ,Letra
      ,2 AS Emisor
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
     AND Letra = 'A'
     AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
GO
   
/* -------- ACTUALIZO LAS TABLAS RELACIONADAS CON EL NUEVO EMISOR -------- */

UPDATE VentasCheques
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasCheques.IdSucursal
         AND V.IdTipoComprobante = VentasCheques.IdTipoComprobante
         AND V.Letra = VentasCheques.Letra
         AND V.CentroEmisor = VentasCheques.CentroEmisor
         AND V.NumeroComprobante = VentasCheques.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasChequesRechazados
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasChequesRechazados.IdSucursal
         AND V.IdTipoComprobante = VentasChequesRechazados.IdTipoComprobante
         AND V.Letra = VentasChequesRechazados.Letra
         AND V.CentroEmisor = VentasChequesRechazados.CentroEmisor
         AND V.NumeroComprobante = VentasChequesRechazados.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasImpuestos
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasImpuestos.IdSucursal
         AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
         AND V.Letra = VentasImpuestos.Letra
         AND V.CentroEmisor = VentasImpuestos.CentroEmisor
         AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasObservaciones
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasObservaciones.IdSucursal
         AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
         AND V.Letra = VentasObservaciones.Letra
         AND V.CentroEmisor = VentasObservaciones.CentroEmisor
         AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasProductos
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductos.IdSucursal
         AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
         AND V.Letra = VentasProductos.Letra
         AND V.CentroEmisor = VentasProductos.CentroEmisor
         AND V.NumeroComprobante = VentasProductos.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE VentasProductosLotes
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductosLotes.IdSucursal
         AND V.IdTipoComprobante = VentasProductosLotes.IdTipoComprobante
         AND V.Letra = VentasProductosLotes.Letra
         AND V.CentroEmisor = VentasProductosLotes.CentroEmisor
         AND V.NumeroComprobante = VentasProductosLotes.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
         AND CONVERT(varchar(11), V.Fecha, 120) < '2012-01-01')
GO

UPDATE MovimientosVentas
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = MovimientosVentas.IdSucursal
         AND V.IdTipoComprobante = MovimientosVentas.IdTipoComprobante
         AND V.Letra = MovimientosVentas.Letra
         AND V.CentroEmisor = MovimientosVentas.CentroEmisor
         AND V.NumeroComprobante = MovimientosVentas.NumeroComprobante
         AND V.CentroEmisor = 1 
         AND V.IdTipoComprobante IN ('FACT','NCRED')   
         AND V.Letra = 'A'
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
      ,IdTipoComprobante
      ,Letra
      ,2 AS Emisor
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
    AND Letra = 'A'
    AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
GO

UPDATE CuentasCorrientesPagos
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'A'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

UPDATE CuentasCorrientesPagos
 SET CentroEmisor2 = 2
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante2
          AND CC.Letra = CuentasCorrientesPagos.Letra2
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor2
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante2
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'A'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

UPDATE CuentasCorrientesCheques
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesCheques.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesCheques.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesCheques.Letra
          AND CC.CentroEmisor = CuentasCorrientesCheques.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesCheques.NumeroComprobante
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'A'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

UPDATE CuentasCorrientesRetenciones
 SET CentroEmisor = 2
 WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesRetenciones.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesRetenciones.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesRetenciones.Letra
          AND CC.CentroEmisor = CuentasCorrientesRetenciones.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesRetenciones.NumeroComprobante
          AND CC.CentroEmisor = 1 
          AND CC.IdTipoComprobante IN ('FACT','NCRED')   
          AND CC.Letra = 'A'
          AND CONVERT(varchar(11), CC.Fecha, 120) < '2012-01-01'
          AND CC.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO') )
GO

/* -------- BORRO LAS CUENTAS CORRIENTES CON EL EMISOR ANTERIOR -------- */

DELETE CuentasCorrientes
 WHERE CentroEmisor = 1 
   AND IdTipoComprobante IN ('FACT','NCRED')   
   AND Letra = 'A'
   AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
   AND IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
GO

/* -------- BORRO LAS VENTAS CON EL EMISOR ANTERIOR -------- */

DELETE Ventas
 WHERE CentroEmisor = 1 
   AND IdTipoComprobante IN ('FACT','NCRED')   
   AND Letra = 'A'
   AND CONVERT(varchar(11), Fecha, 120) < '2012-01-01'
GO

/* -------- ACTUALIZO LOS PUNTEROS -------- */


UPDATE VentasNumeros 
   SET CentroEmisor = 2
 WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB','NDEBCHEQRECH')   
GO

UPDATE VentasNumeros 
   SET Numero = 3500
 WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB','NDEBCHEQRECH')   
   AND LetraFiscal = 'A'
GO

UPDATE VentasNumeros 
   SET Numero = 0
 WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB','NDEBCHEQRECH')   
   AND LetraFiscal = 'B'
GO

INSERT INTO VentasNumeros
    (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero, IdTipoComprobanteRelacionado)
  VALUES
    ('FACT-MANUAL', 'A', 1, 1, 2300, 'NCRED-MANUAL,NDEB-MANUAL'),
    ('NCRED-MANUAL', 'A', 1, 1, 2300, 'FACT-MANUAL,NDEB-MANUAL'),
    ('NDEB-MANUAL', 'A', 1, 1, 2300, 'FACT-MANUAL,NCRED-MANUAL')
GO

INSERT INTO VentasNumeros
    (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero, IdTipoComprobanteRelacionado)
  VALUES
    ('FACT-MANUAL', 'B', 1, 1, 450, 'NCRED-MANUAL,NDEB-MANUAL'),
    ('NCRED-MANUAL', 'B', 1, 1, 450, 'FACT-MANUAL,NDEB-MANUAL'),
    ('NDEB-MANUAL', 'B', 1, 1, 450, 'FACT-MANUAL,NCRED-MANUAL')
GO

