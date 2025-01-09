
UPDATE CuentasCorrientesProv 
   SET CuentasCorrientesProv.CotizacionDolar = C.CotizacionDolar
 FROM CuentasCorrientesProv CC 
 INNER JOIN Compras C ON C.IdSucursal = CC.IdSucursal
 AND C.IdTipoComprobante = CC.IdTipoComprobante
 AND C.Letra = CC.letra
 AND C.CentroEmisor = CC.CentroEmisor
 AND C.NumeroComprobante = CC.NumeroComprobante
 AND C.IdProveedor = CC.IdProveedor
GO

UPDATE CuentasCorrientesProv SET CotizacionDolar = 1 where CotizacionDolar IS NULL
GO

ALTER TABLE CuentasCorrientesProv ALTER COLUMN 	CotizacionDolar decimal(10, 3) NOT NULL
GO

DECLARE @IdTipoComprobanteOrigen VARCHAR(MAX) = 'ANTICIPO'
DECLARE @IdTipoComprobanteDestino VARCHAR(MAX) = 'ANTICIPOPRV'


SET XACT_ABORT ON
BEGIN TRANSACTION

PRINT '1. TiposComprobantes  NUEVO "' + @IdTipoComprobanteDestino + '"'

INSERT INTO [dbo].[TiposComprobantes]
           ([IdTipoComprobante]
           ,[EsFiscal]
           ,[Descripcion]
           ,[Tipo]
           ,[CoeficienteStock]
           ,[GrabaLibro]
           ,[EsFacturable]
           ,[LetrasHabilitadas]
           ,[CantidadMaximaItems]
           ,[Imprime]
           ,[CoeficienteValores]
           ,[ModificaAlFacturar]
           ,[EsFacturador]
           ,[AfectaCaja]
           ,[CargaPrecioActual]
           ,[ActualizaCtaCte]
           ,[DescripcionAbrev]
           ,[PuedeSerBorrado]
           ,[CantidadCopias]
           ,[EsRemitoTransportista]
           ,[ComprobantesAsociados]
           ,[EsComercial]
           ,[CantidadMaximaItemsObserv]
           ,[IdTipoComprobanteSecundario]
           ,[ImporteTope]
           ,[IdTipoComprobanteEpson]
           ,[UsaFacturacionRapida]
           ,[ImporteMinimo]
           ,[EsElectronico]
           ,[UsaFacturacion]
           ,[UtilizaImpuestos]
           ,[NumeracionAutomatica]
           ,[GeneraObservConInvocados]
           ,[ImportaObservDeInvocados]
           ,[IdPlanCuenta]
           ,[EsAnticipo]
           ,[EsRecibo]
           ,[Grupo]
           ,[EsPreElectronico]
           ,[GeneraContabilidad]
           ,[UtilizaCtaSecundariaProd]
           ,[UtilizaCtaSecundariaCateg]
           ,[IncluirEnExpensas]
           ,[IdTipoComprobanteNCred]
           ,[IdTipoComprobanteNDeb]
           ,[IdProductoNCred]
           ,[IdProductoNDeb]
           ,[ConsumePedidos]
           ,[EsPreFiscal]
           ,[CodigoComprobanteSifere]
           ,[EsDespachoImportacion]
           ,[CargaDescRecActual]
           ,[IdTipoComprobanteContraMovInvocar]
           ,[AlInvocarPedidoAfectaFactura]
           ,[AlInvocarPedidoAfectaRemito]
           ,[InvocarPedidosConEstadoEspecifico]
           ,[InvocaCompras]
           ,[LargoMaximoNumero]
           ,[NivelAutorizacion]
           ,[RequiereReferenciaCtaCte]
           ,[ControlaTopeConsumidorFinal]
           ,[CargaDescRecGralActual]
           ,[EsReciboClienteVinculado]
           ,[AFIPWSIncluyeFechaVencimiento]
           ,[AFIPWSEsFEC]
           ,[AFIPWSRequiereReferenciaComercial]
           ,[AFIPWSRequiereComprobanteAsociado]
           ,[AFIPWSRequiereCBU]
           ,[AFIPWSCodigoAnulacion]
           ,[Orden]
           ,[MarcaInvocado]
           ,[PermiteSeleccionarAlicuotaIVA]
           ,[ImportaObservGrales]
           ,[DescripcionImpresion]
           ,[InformaLibroIva])
 SELECT  @IdTipoComprobanteDestino IdTipoComprobante
      ,[EsFiscal]
      ,'Anticipo Proveedor'
      ,[Tipo]
      ,[CoeficienteStock]
      ,[GrabaLibro]
      ,[EsFacturable]
      ,[LetrasHabilitadas]
      ,[CantidadMaximaItems]
      ,[Imprime]
      ,[CoeficienteValores]
      ,[ModificaAlFacturar]
      ,[EsFacturador]
      ,[AfectaCaja]
      ,[CargaPrecioActual]
      ,[ActualizaCtaCte]
      ,'Ant. Prov.'
      ,[PuedeSerBorrado]
      ,[CantidadCopias]
      ,[EsRemitoTransportista]
      ,[ComprobantesAsociados]
      ,[EsComercial]
      ,[CantidadMaximaItemsObserv]
      ,'PAGO'
      ,[ImporteTope]
      ,[IdTipoComprobanteEpson]
      ,[UsaFacturacionRapida]
      ,[ImporteMinimo]
      ,[EsElectronico]
      ,[UsaFacturacion]
      ,[UtilizaImpuestos]
      ,[NumeracionAutomatica]
      ,[GeneraObservConInvocados]
      ,[ImportaObservDeInvocados]
      ,[IdPlanCuenta]
      ,[EsAnticipo]
      ,[EsRecibo]
      ,[Grupo]
      ,[EsPreElectronico]
      ,[GeneraContabilidad]
      ,[UtilizaCtaSecundariaProd]
      ,[UtilizaCtaSecundariaCateg]
      ,[IncluirEnExpensas]
      ,[IdTipoComprobanteNCred]
      ,[IdTipoComprobanteNDeb]
      ,[IdProductoNCred]
      ,[IdProductoNDeb]
      ,[ConsumePedidos]
      ,[EsPreFiscal]
      ,[CodigoComprobanteSifere]
      ,[EsDespachoImportacion]
      ,[CargaDescRecActual]
      ,[IdTipoComprobanteContraMovInvocar]
      ,[AlInvocarPedidoAfectaFactura]
      ,[AlInvocarPedidoAfectaRemito]
      ,[InvocarPedidosConEstadoEspecifico]
      ,[InvocaCompras]
      ,[LargoMaximoNumero]
      ,[NivelAutorizacion]
      ,[RequiereReferenciaCtaCte]
      ,[ControlaTopeConsumidorFinal]
      ,[CargaDescRecGralActual]
      ,[EsReciboClienteVinculado]
      ,[AFIPWSIncluyeFechaVencimiento]
      ,[AFIPWSEsFEC]
      ,[AFIPWSRequiereReferenciaComercial]
      ,[AFIPWSRequiereComprobanteAsociado]
      ,[AFIPWSRequiereCBU]
      ,[AFIPWSCodigoAnulacion]
      ,[Orden]
      ,[MarcaInvocado]
      ,[PermiteSeleccionarAlicuotaIVA]
      ,[ImportaObservGrales]
      ,'Anticipo Proveedor'
      ,[InformaLibroIva]
  FROM [dbo].[TiposComprobantes]
  WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

  
 --CUENTA CORRIENTE PROV
PRINT '10. CuentasCorrientesProv  NUEVO"' + @IdTipoComprobanteDestino + '"'
INSERT INTO CuentasCorrientesProv
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,FechaVencimiento,ImporteTotal,IdFormasPago,Observacion
           ,Saldo,CantidadCuotas,ImportePesos,ImporteDolares,ImporteEuros,ImporteCheques,ImporteTransfBancaria,ImporteTickets,IdCuentaBancaria,IdCaja
           ,NumeroPlanilla,NumeroMovimiento,ImporteRetenciones,ImporteTarjetas,IdEstadoComprobante
           ,IdUsuario,IdProveedor,FechaActualizacion,IdAsiento,IdPlanCuenta
           ,ImprimeSaldos,MetodoGrabacion,IdFuncion, IdEjercicio, CotizacionDolar)
    SELECT IdSucursal,@IdTipoComprobanteDestino IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,FechaVencimiento,ImporteTotal,IdFormasPago,Observacion
           ,Saldo,CantidadCuotas,ImportePesos,ImporteDolares,ImporteEuros,ImporteCheques,ImporteTransfBancaria,ImporteTickets,IdCuentaBancaria,IdCaja
           ,NumeroPlanilla,NumeroMovimiento,ImporteRetenciones,ImporteTarjetas,IdEstadoComprobante
           ,IdUsuario,IdProveedor,FechaActualizacion,IdAsiento,IdPlanCuenta
           ,ImprimeSaldos,MetodoGrabacion,IdFuncion, IdEjercicio, CotizacionDolar
      FROM CuentasCorrientesProv
     WHERE IdTipoComprobante = @IdTipoComprobanteOrigen


PRINT '11.1. CuentasCorrientesProvPagos - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '11.2. CuentasCorrientesProvPagos - IdTipoComprobante2 de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante2 = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante2 = @IdTipoComprobanteOrigen

PRINT '11.3. CuentasCorrientesProvCheques - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvCheques
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '11.4. CuentasCorrientesProvRetenciones - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvRetenciones
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

 PRINT '13.1. CuentasCorrientes BORRA IdTipoComprobante"' + @IdTipoComprobanteOrigen + '"'
DELETE FROM CuentasCorrientesProv WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

UPDATE TiposComprobantes SET IdTipoComprobanteSecundario =  @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = 'PAGO'

     --Asignacion a la Normal
    UPDATE Impresoras
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',' + @IdTipoComprobanteDestino
     WHERE IdImpresora = 'NORMAL'

COMMIT
GO

DECLARE @IdTipoComprobanteOrigen VARCHAR(MAX) = 'ANTICIPOPROV'
DECLARE @IdTipoComprobanteDestino VARCHAR(MAX) = 'ANTICIPOPRVPROV'

SET XACT_ABORT ON
BEGIN TRANSACTION

PRINT '1. TiposComprobantes  NUEVO "' + @IdTipoComprobanteDestino + '"'
INSERT INTO [dbo].[TiposComprobantes]
           ([IdTipoComprobante]
           ,[EsFiscal]
           ,[Descripcion]
           ,[Tipo]
           ,[CoeficienteStock]
           ,[GrabaLibro]
           ,[EsFacturable]
           ,[LetrasHabilitadas]
           ,[CantidadMaximaItems]
           ,[Imprime]
           ,[CoeficienteValores]
           ,[ModificaAlFacturar]
           ,[EsFacturador]
           ,[AfectaCaja]
           ,[CargaPrecioActual]
           ,[ActualizaCtaCte]
           ,[DescripcionAbrev]
           ,[PuedeSerBorrado]
           ,[CantidadCopias]
           ,[EsRemitoTransportista]
           ,[ComprobantesAsociados]
           ,[EsComercial]
           ,[CantidadMaximaItemsObserv]
           ,[IdTipoComprobanteSecundario]
           ,[ImporteTope]
           ,[IdTipoComprobanteEpson]
           ,[UsaFacturacionRapida]
           ,[ImporteMinimo]
           ,[EsElectronico]
           ,[UsaFacturacion]
           ,[UtilizaImpuestos]
           ,[NumeracionAutomatica]
           ,[GeneraObservConInvocados]
           ,[ImportaObservDeInvocados]
           ,[IdPlanCuenta]
           ,[EsAnticipo]
           ,[EsRecibo]
           ,[Grupo]
           ,[EsPreElectronico]
           ,[GeneraContabilidad]
           ,[UtilizaCtaSecundariaProd]
           ,[UtilizaCtaSecundariaCateg]
           ,[IncluirEnExpensas]
           ,[IdTipoComprobanteNCred]
           ,[IdTipoComprobanteNDeb]
           ,[IdProductoNCred]
           ,[IdProductoNDeb]
           ,[ConsumePedidos]
           ,[EsPreFiscal]
           ,[CodigoComprobanteSifere]
           ,[EsDespachoImportacion]
           ,[CargaDescRecActual]
           ,[IdTipoComprobanteContraMovInvocar]
           ,[AlInvocarPedidoAfectaFactura]
           ,[AlInvocarPedidoAfectaRemito]
           ,[InvocarPedidosConEstadoEspecifico]
           ,[InvocaCompras]
           ,[LargoMaximoNumero]
           ,[NivelAutorizacion]
           ,[RequiereReferenciaCtaCte]
           ,[ControlaTopeConsumidorFinal]
           ,[CargaDescRecGralActual]
           ,[EsReciboClienteVinculado]
           ,[AFIPWSIncluyeFechaVencimiento]
           ,[AFIPWSEsFEC]
           ,[AFIPWSRequiereReferenciaComercial]
           ,[AFIPWSRequiereComprobanteAsociado]
           ,[AFIPWSRequiereCBU]
           ,[AFIPWSCodigoAnulacion]
           ,[Orden]
           ,[MarcaInvocado]
           ,[PermiteSeleccionarAlicuotaIVA]
           ,[ImportaObservGrales]
           ,[DescripcionImpresion]
           ,[InformaLibroIva])
 SELECT  @IdTipoComprobanteDestino IdTipoComprobante
      ,[EsFiscal]
      ,'Anticipo Prv. Provisorio'
      ,[Tipo]
      ,[CoeficienteStock]
      ,[GrabaLibro]
      ,[EsFacturable]
      ,[LetrasHabilitadas]
      ,[CantidadMaximaItems]
      ,[Imprime]
      ,[CoeficienteValores]
      ,[ModificaAlFacturar]
      ,[EsFacturador]
      ,[AfectaCaja]
      ,[CargaPrecioActual]
      ,[ActualizaCtaCte]
      ,'Ant.Pr.Prv'
      ,[PuedeSerBorrado]
      ,[CantidadCopias]
      ,[EsRemitoTransportista]
      ,[ComprobantesAsociados]
      ,[EsComercial]
      ,[CantidadMaximaItemsObserv]
      ,'PAGOPROV'
      ,[ImporteTope]
      ,[IdTipoComprobanteEpson]
      ,[UsaFacturacionRapida]
      ,[ImporteMinimo]
      ,[EsElectronico]
      ,[UsaFacturacion]
      ,[UtilizaImpuestos]
      ,[NumeracionAutomatica]
      ,[GeneraObservConInvocados]
      ,[ImportaObservDeInvocados]
      ,[IdPlanCuenta]
      ,[EsAnticipo]
      ,[EsRecibo]
      ,[Grupo]
      ,[EsPreElectronico]
      ,[GeneraContabilidad]
      ,[UtilizaCtaSecundariaProd]
      ,[UtilizaCtaSecundariaCateg]
      ,[IncluirEnExpensas]
      ,[IdTipoComprobanteNCred]
      ,[IdTipoComprobanteNDeb]
      ,[IdProductoNCred]
      ,[IdProductoNDeb]
      ,[ConsumePedidos]
      ,[EsPreFiscal]
      ,[CodigoComprobanteSifere]
      ,[EsDespachoImportacion]
      ,[CargaDescRecActual]
      ,[IdTipoComprobanteContraMovInvocar]
      ,[AlInvocarPedidoAfectaFactura]
      ,[AlInvocarPedidoAfectaRemito]
      ,[InvocarPedidosConEstadoEspecifico]
      ,[InvocaCompras]
      ,[LargoMaximoNumero]
      ,[NivelAutorizacion]
      ,[RequiereReferenciaCtaCte]
      ,[ControlaTopeConsumidorFinal]
      ,[CargaDescRecGralActual]
      ,[EsReciboClienteVinculado]
      ,[AFIPWSIncluyeFechaVencimiento]
      ,[AFIPWSEsFEC]
      ,[AFIPWSRequiereReferenciaComercial]
      ,[AFIPWSRequiereComprobanteAsociado]
      ,[AFIPWSRequiereCBU]
      ,[AFIPWSCodigoAnulacion]
      ,[Orden]
      ,[MarcaInvocado]
      ,[PermiteSeleccionarAlicuotaIVA]
      ,[ImportaObservGrales]
      ,'Anticipo Proveedor Provisorio'
      ,[InformaLibroIva]
  FROM [dbo].[TiposComprobantes]
  WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

  
 --CUENTA CORRIENTE PROV
PRINT '10. CuentasCorrientesProv  NUEVO"' + @IdTipoComprobanteDestino + '"'
INSERT INTO CuentasCorrientesProv
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,FechaVencimiento,ImporteTotal,IdFormasPago,Observacion
           ,Saldo,CantidadCuotas,ImportePesos,ImporteDolares,ImporteEuros,ImporteCheques,ImporteTransfBancaria,ImporteTickets,IdCuentaBancaria,IdCaja
           ,NumeroPlanilla,NumeroMovimiento,ImporteRetenciones,ImporteTarjetas,IdEstadoComprobante
           ,IdUsuario,IdProveedor,FechaActualizacion,IdAsiento,IdPlanCuenta
           ,ImprimeSaldos,MetodoGrabacion,IdFuncion, IdEjercicio, CotizacionDolar)
    SELECT IdSucursal,@IdTipoComprobanteDestino IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,FechaVencimiento,ImporteTotal,IdFormasPago,Observacion
           ,Saldo,CantidadCuotas,ImportePesos,ImporteDolares,ImporteEuros,ImporteCheques,ImporteTransfBancaria,ImporteTickets,IdCuentaBancaria,IdCaja
           ,NumeroPlanilla,NumeroMovimiento,ImporteRetenciones,ImporteTarjetas,IdEstadoComprobante
           ,IdUsuario,IdProveedor,FechaActualizacion,IdAsiento,IdPlanCuenta
           ,ImprimeSaldos,MetodoGrabacion,IdFuncion, IdEjercicio, CotizacionDolar
      FROM CuentasCorrientesProv
     WHERE IdTipoComprobante = @IdTipoComprobanteOrigen


PRINT '11.1. CuentasCorrientesProvPagos - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '11.2. CuentasCorrientesProvPagos - IdTipoComprobante2 de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante2 = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante2 = @IdTipoComprobanteOrigen

PRINT '11.3. CuentasCorrientesProvCheques - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvCheques
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '11.4. CuentasCorrientesProvRetenciones - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE CuentasCorrientesProvRetenciones
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
 
PRINT '13.1. CuentasCorrientes BORRA IdTipoComprobante"' + @IdTipoComprobanteOrigen + '"'
DELETE FROM CuentasCorrientesProv WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

UPDATE TiposComprobantes SET IdTipoComprobanteSecundario =  @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = 'PAGOPROV'

UPDATE Impresoras
    SET ComprobantesHabilitados = ComprobantesHabilitados + ',' + @IdTipoComprobanteDestino
     WHERE IdImpresora = 'NORMAL'

 COMMIT
GO

UPDATE TiposComprobantes
 SET ImporteTope = 99999999
   , ImporteMinimo = 0.01
WHERE IdTipoComprobante IN ('PAGO', 'ANTICIPOPRV', 'PAGOPROV', 'ANTICIPOPRVPROV')
GO

INSERT INTO [dbo].[TiposComprobantes]
           ([IdTipoComprobante]
           ,[EsFiscal]
           ,[Descripcion]
           ,[Tipo]
           ,[CoeficienteStock]
           ,[GrabaLibro]
           ,[EsFacturable]
           ,[LetrasHabilitadas]
           ,[CantidadMaximaItems]
           ,[Imprime]
           ,[CoeficienteValores]
           ,[ModificaAlFacturar]
           ,[EsFacturador]
           ,[AfectaCaja]
           ,[CargaPrecioActual]
           ,[ActualizaCtaCte]
           ,[DescripcionAbrev]
           ,[PuedeSerBorrado]
           ,[CantidadCopias]
           ,[EsRemitoTransportista]
           ,[ComprobantesAsociados]
           ,[EsComercial]
           ,[CantidadMaximaItemsObserv]
           ,[IdTipoComprobanteSecundario]
           ,[ImporteTope]
           ,[IdTipoComprobanteEpson]
           ,[UsaFacturacionRapida]
           ,[ImporteMinimo]
           ,[EsElectronico]
           ,[UsaFacturacion]
           ,[UtilizaImpuestos]
           ,[NumeracionAutomatica]
           ,[GeneraObservConInvocados]
           ,[ImportaObservDeInvocados]
           ,[IdPlanCuenta]
           ,[EsAnticipo]
           ,[EsRecibo]
           ,[Grupo]
           ,[EsPreElectronico]
           ,[GeneraContabilidad]
           ,[UtilizaCtaSecundariaProd]
           ,[UtilizaCtaSecundariaCateg]
           ,[IncluirEnExpensas]
           ,[IdTipoComprobanteNCred]
           ,[IdTipoComprobanteNDeb]
           ,[IdProductoNCred]
           ,[IdProductoNDeb]
           ,[ConsumePedidos]
           ,[EsPreFiscal]
           ,[CodigoComprobanteSifere]
           ,[EsDespachoImportacion]
           ,[CargaDescRecActual]
           ,[IdTipoComprobanteContraMovInvocar]
           ,[AlInvocarPedidoAfectaFactura]
           ,[AlInvocarPedidoAfectaRemito]
           ,[InvocarPedidosConEstadoEspecifico]
           ,[InvocaCompras]
           ,[LargoMaximoNumero]
           ,[NivelAutorizacion]
           ,[RequiereReferenciaCtaCte]
           ,[ControlaTopeConsumidorFinal]
           ,[CargaDescRecGralActual]
           ,[EsReciboClienteVinculado]
           ,[AFIPWSIncluyeFechaVencimiento]
           ,[AFIPWSEsFEC]
           ,[AFIPWSRequiereReferenciaComercial]
           ,[AFIPWSRequiereComprobanteAsociado]
           ,[AFIPWSRequiereCBU]
           ,[AFIPWSCodigoAnulacion]
           ,[Orden]
           ,[MarcaInvocado]
           ,[PermiteSeleccionarAlicuotaIVA]
           ,[ImportaObservGrales]
           ,[DescripcionImpresion]
           ,[InformaLibroIva])
		   SELECT 'MINUTAPRV' AS XXIdTipoComprobante
      ,[EsFiscal]
      , 'Minuta Proveedor' AS XXDescripcion
      ,[Tipo]
      ,[CoeficienteStock]
      ,[GrabaLibro]
      ,[EsFacturable]
      ,[LetrasHabilitadas]
      ,[CantidadMaximaItems]
      ,[Imprime]
      ,[CoeficienteValores]
      ,[ModificaAlFacturar]
      ,[EsFacturador]
      ,[AfectaCaja]
      ,[CargaPrecioActual]
      ,[ActualizaCtaCte]
      ,'Minuta Prv' AS XXDescripcionAbrev
      ,[PuedeSerBorrado]
      ,[CantidadCopias]
      ,[EsRemitoTransportista]
      ,[ComprobantesAsociados]
      ,[EsComercial]
      ,[CantidadMaximaItemsObserv]
      , NULL AS XXIdTipoComprobanteSecundario
      , 0 AS XXImporteTope
      ,[IdTipoComprobanteEpson]
      ,[UsaFacturacionRapida]
      ,0 AS XXImporteMinimo
      ,[EsElectronico]
      ,[UsaFacturacion]
      ,[UtilizaImpuestos]
      ,[NumeracionAutomatica]
      ,[GeneraObservConInvocados]
      ,[ImportaObservDeInvocados]
      ,[IdPlanCuenta]
      ,[EsAnticipo]
      ,[EsRecibo]
      ,[Grupo]
      ,[EsPreElectronico]
      ,[GeneraContabilidad]
      ,[UtilizaCtaSecundariaProd]
      ,[UtilizaCtaSecundariaCateg]
      ,[IncluirEnExpensas]
      ,[IdTipoComprobanteNCred]
      ,[IdTipoComprobanteNDeb]
      ,[IdProductoNCred]
      ,[IdProductoNDeb]
      ,[ConsumePedidos]
      ,[EsPreFiscal]
      ,[CodigoComprobanteSifere]
      ,[EsDespachoImportacion]
      ,[CargaDescRecActual]
      ,[IdTipoComprobanteContraMovInvocar]
      ,[AlInvocarPedidoAfectaFactura]
      ,[AlInvocarPedidoAfectaRemito]
      ,[InvocarPedidosConEstadoEspecifico]
      ,[InvocaCompras]
      ,[LargoMaximoNumero]
      ,[NivelAutorizacion]
      ,[RequiereReferenciaCtaCte]
      ,[ControlaTopeConsumidorFinal]
      ,[CargaDescRecGralActual]
      ,[EsReciboClienteVinculado]
      ,[AFIPWSIncluyeFechaVencimiento]
      ,[AFIPWSEsFEC]
      ,[AFIPWSRequiereReferenciaComercial]
      ,[AFIPWSRequiereComprobanteAsociado]
      ,[AFIPWSRequiereCBU]
      ,[AFIPWSCodigoAnulacion]
      ,[Orden]
      ,[MarcaInvocado]
      ,[PermiteSeleccionarAlicuotaIVA]
      ,[ImportaObservGrales]
      , 'Minuta Proveedor' AS XXDescripcionImpresion
      ,[InformaLibroIva]
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'PAGO'
GO

INSERT INTO [dbo].[TiposComprobantes]
           ([IdTipoComprobante]
           ,[EsFiscal]
           ,[Descripcion]
           ,[Tipo]
           ,[CoeficienteStock]
           ,[GrabaLibro]
           ,[EsFacturable]
           ,[LetrasHabilitadas]
           ,[CantidadMaximaItems]
           ,[Imprime]
           ,[CoeficienteValores]
           ,[ModificaAlFacturar]
           ,[EsFacturador]
           ,[AfectaCaja]
           ,[CargaPrecioActual]
           ,[ActualizaCtaCte]
           ,[DescripcionAbrev]
           ,[PuedeSerBorrado]
           ,[CantidadCopias]
           ,[EsRemitoTransportista]
           ,[ComprobantesAsociados]
           ,[EsComercial]
           ,[CantidadMaximaItemsObserv]
           ,[IdTipoComprobanteSecundario]
           ,[ImporteTope]
           ,[IdTipoComprobanteEpson]
           ,[UsaFacturacionRapida]
           ,[ImporteMinimo]
           ,[EsElectronico]
           ,[UsaFacturacion]
           ,[UtilizaImpuestos]
           ,[NumeracionAutomatica]
           ,[GeneraObservConInvocados]
           ,[ImportaObservDeInvocados]
           ,[IdPlanCuenta]
           ,[EsAnticipo]
           ,[EsRecibo]
           ,[Grupo]
           ,[EsPreElectronico]
           ,[GeneraContabilidad]
           ,[UtilizaCtaSecundariaProd]
           ,[UtilizaCtaSecundariaCateg]
           ,[IncluirEnExpensas]
           ,[IdTipoComprobanteNCred]
           ,[IdTipoComprobanteNDeb]
           ,[IdProductoNCred]
           ,[IdProductoNDeb]
           ,[ConsumePedidos]
           ,[EsPreFiscal]
           ,[CodigoComprobanteSifere]
           ,[EsDespachoImportacion]
           ,[CargaDescRecActual]
           ,[IdTipoComprobanteContraMovInvocar]
           ,[AlInvocarPedidoAfectaFactura]
           ,[AlInvocarPedidoAfectaRemito]
           ,[InvocarPedidosConEstadoEspecifico]
           ,[InvocaCompras]
           ,[LargoMaximoNumero]
           ,[NivelAutorizacion]
           ,[RequiereReferenciaCtaCte]
           ,[ControlaTopeConsumidorFinal]
           ,[CargaDescRecGralActual]
           ,[EsReciboClienteVinculado]
           ,[AFIPWSIncluyeFechaVencimiento]
           ,[AFIPWSEsFEC]
           ,[AFIPWSRequiereReferenciaComercial]
           ,[AFIPWSRequiereComprobanteAsociado]
           ,[AFIPWSRequiereCBU]
           ,[AFIPWSCodigoAnulacion]
           ,[Orden]
           ,[MarcaInvocado]
           ,[PermiteSeleccionarAlicuotaIVA]
           ,[ImportaObservGrales]
           ,[DescripcionImpresion]
           ,[InformaLibroIva])
		   SELECT 'MINUTAPRVPROV' AS XXIdTipoComprobante
      ,[EsFiscal]
      , 'Minuta Prv. Provisoria' AS XXDescripcion
      ,[Tipo]
      ,[CoeficienteStock]
      ,[GrabaLibro]
      ,[EsFacturable]
      ,[LetrasHabilitadas]
      ,[CantidadMaximaItems]
      ,[Imprime]
      ,[CoeficienteValores]
      ,[ModificaAlFacturar]
      ,[EsFacturador]
      ,[AfectaCaja]
      ,[CargaPrecioActual]
      ,[ActualizaCtaCte]
      ,'Min.Pr.Prv'  AS XXDescripcionAbrev
      ,[PuedeSerBorrado]
      ,[CantidadCopias]
      ,[EsRemitoTransportista]
      ,[ComprobantesAsociados]
      ,[EsComercial]
      ,[CantidadMaximaItemsObserv]
      , NULL AS XXIdTipoComprobanteSecundario
      , 0 AS XXImporteTope
      ,[IdTipoComprobanteEpson]
      ,[UsaFacturacionRapida]
      ,0 AS XXImporteMinimo
      ,[EsElectronico]
      ,[UsaFacturacion]
      ,[UtilizaImpuestos]
      ,[NumeracionAutomatica]
      ,[GeneraObservConInvocados]
      ,[ImportaObservDeInvocados]
      ,[IdPlanCuenta]
      ,[EsAnticipo]
      ,[EsRecibo]
      ,[Grupo]
      ,[EsPreElectronico]
      ,[GeneraContabilidad]
      ,[UtilizaCtaSecundariaProd]
      ,[UtilizaCtaSecundariaCateg]
      ,[IncluirEnExpensas]
      ,[IdTipoComprobanteNCred]
      ,[IdTipoComprobanteNDeb]
      ,[IdProductoNCred]
      ,[IdProductoNDeb]
      ,[ConsumePedidos]
      ,[EsPreFiscal]
      ,[CodigoComprobanteSifere]
      ,[EsDespachoImportacion]
      ,[CargaDescRecActual]
      ,[IdTipoComprobanteContraMovInvocar]
      ,[AlInvocarPedidoAfectaFactura]
      ,[AlInvocarPedidoAfectaRemito]
      ,[InvocarPedidosConEstadoEspecifico]
      ,[InvocaCompras]
      ,[LargoMaximoNumero]
      ,[NivelAutorizacion]
      ,[RequiereReferenciaCtaCte]
      ,[ControlaTopeConsumidorFinal]
      ,[CargaDescRecGralActual]
      ,[EsReciboClienteVinculado]
      ,[AFIPWSIncluyeFechaVencimiento]
      ,[AFIPWSEsFEC]
      ,[AFIPWSRequiereReferenciaComercial]
      ,[AFIPWSRequiereComprobanteAsociado]
      ,[AFIPWSRequiereCBU]
      ,[AFIPWSCodigoAnulacion]
      ,[Orden]
      ,[MarcaInvocado]
      ,[PermiteSeleccionarAlicuotaIVA]
      ,[ImportaObservGrales]
      , 'Minuta Prv. Provisoria' AS XXDescripcionImpresion
      ,[InformaLibroIva]
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'PAGOPROV'
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',MINUTAPRV,MINUTAPRVPROV'
  WHERE IdImpresora = 'NORMAL'
GO


--Agrego un Espacio para que se acomoden Primeros.
UPDATE TiposComprobantes
  SET Descripcion = ' '+Descripcion
  WHERE IdTipoComprobante IN ('PAGO', 'PAGOPROV')
GO

SET QUOTED_IDENTIFIER OFF
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = "'AJUSTECOM-','FACTCOM', 'AJUSTECOM+' , 'NDEBCOM','PAGO', 'NCREDCOM', 'ANTICIPOPRV'"                       
 WHERE IdTipoComprobante IN ('PAGO','MINUTAPRV')
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = "'COTIZACIONNCCOM', 'PAGOPROV',  'COTIZACIONCOM', 'ANTICIPOPRVPROV'"
 WHERE IdTipoComprobante IN ('PAGOPROV','MINUTAPRVPROV')
GO

SET QUOTED_IDENTIFIER ON
GO


SET QUOTED_IDENTIFIER OFF
GO

PRINT ''
PRINT '2. Tabla TiposComprobantes: Nuevo... TiposComprobantes Pago Unico.'
GO
INSERT dbo.TiposComprobantes 
	(IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
	LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja,
	CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados,
	EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo,
	EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, 
	IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal,
	CodigoComprobanteSifere, EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, InvocarPedidosConEstadoEspecifico,
	InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, 
	AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC, AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden, 
	MarcaInvocado,PermiteSeleccionarAlicuotaIVA,ImportaObservGrales, DescripcionImpresion, InformaLibroIva)
VALUES 
	('PAGOUNICO', 'False', '  Pago Unico', 'CTACTEPROV', 0, 'False', 'False'
	, 'X', 100, 'True', -1, NULL, 'False', 'True'
	, 'False', 'true', 'Pago Unico', 'False', 1, 'False', "'AJUSTECOM-','FACTCOM', 'AJUSTECOM+' , 'NDEBCOM','PAGO', 'NCREDCOM', 'ANTICIPOPRV', 'COTIZACIONNCCOM', 'PAGOPROV',  'COTIZACIONCOM', 'ANTICIPOPRVPROV'"
	, 'True', 0, NULL, 99999999, '.', 'False', (1/100)
	, 'False', 'False', 'True', 'True', 'False', 'False', 2
	, 'False', 'True', 'CTACTEPROV', 'False', 'True', 'False','False'
	, 'False', NULL, NULL, NULL, NULL, 'False', 'False'
	, 'R', 'False', 'False', NULL, 'True', 'True', 'True'
	, 'False', 8, 1, 'False', 'True', 'False', 'False'
	, NULL, 'False', 'False', 'False', 'False', 'False',10	,'True', 'False', 'False',	'Pago Unico','False')
GO

PRINT ''
PRINT '3. Tabla Impresoras: Asocio Pago Unico solo para Nutrisur.'
GO
IF dbo.BaseConCuit('20164865720') = 1
	BEGIN
		UPDATE Impresoras 
		   SET ComprobantesHabilitados = ComprobantesHabilitados + ',PAGOUNICO'
		 WHERE IdImpresora = 'NORMAL'
		   AND IdSucursal = 1;
	END
GO

PRINT ''
PRINT '4. Nuevo Tipo de Comprobante: Anticipo Unico'
INSERT [dbo].[TiposComprobantes]
/* 1*/ ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC],
/*14*/  [AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion]  ,[Orden] ,[MarcaInvocado] ,[PermiteSeleccionarAlicuotaIVA],[ImportaObservGrales],[DescripcionImpresion] ,[InformaLibroIva])
SELECT 
/* 1*/  'ANTICIPOPRUNICO', [EsFiscal], 'Anticipo Proveedor Unico', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable],[LetrasHabilitadas],[CantidadMaximaItems], [Imprime], 
/* 3*/  -1, [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'Ant.Prv.U.', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], 'PAGOUNICO', [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC],
/*14*/  [AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion]  ,[Orden] ,[MarcaInvocado] ,[PermiteSeleccionarAlicuotaIVA],[ImportaObservGrales],[DescripcionImpresion],[InformaLibroIva]
    FROM [dbo].[TiposComprobantes]
    WHERE IdTipoComprobante = 'ANTICIPOPRVPROV';
	GO

PRINT ''
PRINT '4.1. Tabla TiposComprobantes: Asocio Anticipo Proveedor Unico al PAGO Unico.'
	UPDATE TiposComprobantes 
	SET IdTipoComprobanteSecundario = 'ANTICIPOPRUNICO'
    WHERE IdTipoComprobante = 'PAGOUNICO';
	GO

PRINT ''
PRINT '4. 2. Tabla Impresoras: Asocio Anticipo Proveedor Unico solo para Nutrisur.'
IF dbo.BaseConCuit('20164865720') = 1
		UPDATE Impresoras 
			SET ComprobantesHabilitados = ComprobantesHabilitados + ',ANTICIPOPRUNICO'
			WHERE IdImpresora = 'NORMAL'
			AND IdSucursal = 1;

GO

PRINT ''
PRINT '5. Tabla TiposComprobantes: Nuevo... TiposComprobantes Minuta Proveedor Unica.'

INSERT dbo.TiposComprobantes 
	(IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
	LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja,
	CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados,
	EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo,
	EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, 
	IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal,
	CodigoComprobanteSifere, EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, InvocarPedidosConEstadoEspecifico,
	InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, 
	AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC, AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion ,[Orden] ,[MarcaInvocado] ,[PermiteSeleccionarAlicuotaIVA],[ImportaObservGrales],[DescripcionImpresion],[InformaLibroIva])
VALUES 
	( 'MINUTAPRUNICA', 'False', N'Minuta Proveedor Unica', 'CTACTEPROV', 0, 'False', 'False'
	, 'X', 100, 'True', -1, NULL, 'False', 'True'
	, 'False', 'True', 'Min.Pr.U.', 'False', 1, 'False', "'AJUSTECOM-','FACTCOM', 'AJUSTECOM+' , 'NDEBCOM','PAGO', 'NCREDCOM', 'ANTICIPOPRV','COTIZACIONNCCOM', 'PAGOPROV',  'COTIZACIONCOM', 'ANTICIPOPRVPROV'"
	, 'True', 0, NULL, 0, '.', 'False', 0
	, 'False', 'False', 'True', 'True', 'False', 'False', 2
	, 'False', 'True', 'CTACTEPROV', 'False', 'True', 'False','False'
	, 'False', NULL, NULL, NULL, NULL, 'False', 'False'
	, '', 'False', 'False', NULL, 'True', 'True', 'True'
	, 'False', 8, 1, 'False', 'True', 'False', 'False'
	,  NULL, 'False', 'False', 'False', 'False', 'False',10	,'True', 'False', 'False',	'Minuta Proveedor Unica','False')
GO


PRINT ''
PRINT '4. 2. Tabla Impresoras: Asocio Minuta Proveedor Unica solo para Nutrisur.'
IF dbo.BaseConCuit('20164865720') = 1

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',MINUTAPRUNICA'
  WHERE IdImpresora = 'NORMAL'

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ",'ANTICIPOPRUNICO'"                      
 WHERE IdTipoComprobante IN ('PAGOUNICO','MINUTAPRUNICA')
GO

/****** Object:  Table [dbo].[AplicacionesFunciones]    Script Date: 03/07/2020 11:07:37 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AplicacionesFunciones](
	[IdAplicacion] [varchar](20) NOT NULL,
	[IdFuncion] [varchar](30) NOT NULL,
	[NombreFuncion] [varchar](60) NOT NULL,
	[IdFuncionPadre] [varchar](30) NULL,
 CONSTRAINT [PK_AplicacionesFunciones] PRIMARY KEY CLUSTERED 
([IdAplicacion] ASC,[IdFuncion] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AplicacionesFunciones]  WITH CHECK ADD  CONSTRAINT [FK_AplicacionesFunciones_Aplicaciones] FOREIGN KEY([IdAplicacion])
REFERENCES [dbo].[Aplicaciones] ([IdAplicacion])
GO
ALTER TABLE [dbo].[AplicacionesFunciones] CHECK CONSTRAINT [FK_AplicacionesFunciones_Aplicaciones]
GO

ALTER TABLE [dbo].[AplicacionesFunciones]  WITH CHECK ADD  CONSTRAINT [FK_AplicacionesFunciones_AplicacionesFunciones_Padre] FOREIGN KEY([IdAplicacion], [IdFuncionPadre])
REFERENCES [dbo].[AplicacionesFunciones] ([IdAplicacion], [IdFuncion])
GO
ALTER TABLE [dbo].[AplicacionesFunciones] CHECK CONSTRAINT [FK_AplicacionesFunciones_AplicacionesFunciones_Padre]
GO

PRINT ''
PRINT '1. Nuevo Campo en Proveedores: CBUProveedor'
ALTER TABLE Proveedores
	ADD CBUProveedor CHAR(22) NULL
GO

PRINT ''
PRINT '2. Nuevo Campo en Proveedores: CBUAliasProveedor'
ALTER TABLE Proveedores
	ADD CBUAliasProveedor VARCHAR(20) NULL
GO

PRINT ''
PRINT '1. Deshabilitar función: Consultar Cta. Cte. Proveedores'
UPDATE Funciones SET
	[Enabled] = 0,
	 Visible = 0
		WHERE Id = 'ConsultarCtaCteProveedores'
GO

PRINT ''
PRINT '2. Deshabilitar función: Consultar Cta. Cte. Detalle Proveedores'
UPDATE Funciones SET
	[Enabled] = 0,
	 Visible = 0 
		WHERE Id = 'ConsultarCtaCteDetalleProv'
GO