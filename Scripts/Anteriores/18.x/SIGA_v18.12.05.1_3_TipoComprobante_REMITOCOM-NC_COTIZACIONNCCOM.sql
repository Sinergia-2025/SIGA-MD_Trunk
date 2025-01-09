DECLARE @IdTipoComprobanteOrigen VARCHAR(MAX) = 'REMITOCOM-NC'
DECLARE @IdTipoComprobanteDestino VARCHAR(MAX) = 'COTIZACIONNCCOM'

-----------------------------------------  IMPORTANTE  -----------------------------------------
-- ANTE UN ERROR SE REVIERTE TODA LA TRANSACCION
-- ANTE UN ERROR INFORMAR PARA ANALIZAR EL MOTIVO
------------------------------------------------------------------------------------------------

SET XACT_ABORT ON
BEGIN TRANSACTION

PRINT '1. TiposComprobantes  NUEVO "' + @IdTipoComprobanteDestino + '"'
--TIPO COMPROBANTE
INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion,UtilizaImpuestos
           ,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta,EsAnticipo,EsRecibo
           ,Grupo,EsPreElectronico,GeneraContabilidad,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas
           ,IdTipoComprobanteNCred,IdTipoComprobanteNDeb,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal
           ,CodigoComprobanteSifere,EsDespachoImportacion,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura
           ,AlInvocarPedidoAfectaRemito,InvocarPedidosConEstadoEspecifico,InvocaCompras,LargoMaximoNumero,NivelAutorizacion,RequiereReferenciaCtaCte
           ,ControlaTopeConsumidorFinal,CargaDescRecGralActual)
     SELECT @IdTipoComprobanteDestino IdTipoComprobante,EsFiscal,'NC. Cotizacion Compra' Descripcion,Tipo,CoeficienteStock,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual,ActualizaCtaCte,'NC.Cot.Com' DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion,UtilizaImpuestos
           ,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta,EsAnticipo,EsRecibo
           ,Grupo,EsPreElectronico,GeneraContabilidad,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas
           ,IdTipoComprobanteNCred,IdTipoComprobanteNDeb,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal
           ,CodigoComprobanteSifere,EsDespachoImportacion,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura
           ,AlInvocarPedidoAfectaRemito,InvocarPedidosConEstadoEspecifico,InvocaCompras,LargoMaximoNumero,NivelAutorizacion,RequiereReferenciaCtaCte
           ,ControlaTopeConsumidorFinal,CargaDescRecGralActual
       FROM TiposComprobantes
      WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '2.1 TiposComprobantes - IdTipoComprobanteContraMovInvocar de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE TiposComprobantes
   SET IdTipoComprobanteContraMovInvocar = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteContraMovInvocar = @IdTipoComprobanteOrigen
PRINT '2.2 TiposComprobantes - IdTipoComprobanteNCred de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE TiposComprobantes
   SET IdTipoComprobanteNCred = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteNCred = @IdTipoComprobanteOrigen
PRINT '2.3 TiposComprobantes - IdTipoComprobanteNDeb de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE TiposComprobantes
   SET IdTipoComprobanteNDeb = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteNDeb = @IdTipoComprobanteOrigen
PRINT '2.4 TiposComprobantes - IdTipoComprobanteSecundario de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE TiposComprobantes
   SET IdTipoComprobanteSecundario = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteSecundario = @IdTipoComprobanteOrigen

PRINT '3 TiposComprobantesLetras - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE TiposComprobantesLetras
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen


PRINT '4.1 VentasNumeros - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE VentasNumeros SET IdTipoComprobanteRelacionado = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteRelacionado = @IdTipoComprobanteOrigen
PRINT '4.2 VentasNumeros - IdTipoComprobante de ",' + @IdTipoComprobanteOrigen + '," a ",' + @IdTipoComprobanteDestino + ',"'
UPDATE VentasNumeros SET IdTipoComprobanteRelacionado = REPLACE(IdTipoComprobanteRelacionado, ',' + @IdTipoComprobanteOrigen + ',', ',' + @IdTipoComprobanteDestino + ',')
 WHERE IdTipoComprobanteRelacionado LIKE '%,' + @IdTipoComprobanteOrigen + ',%'
PRINT '4.3 VentasNumeros - IdTipoComprobante de ",' + @IdTipoComprobanteOrigen + '" a ",' + @IdTipoComprobanteDestino + '"'
UPDATE VentasNumeros SET IdTipoComprobanteRelacionado = REPLACE(IdTipoComprobanteRelacionado, ',' + @IdTipoComprobanteOrigen, ',' + @IdTipoComprobanteDestino)
 WHERE IdTipoComprobanteRelacionado LIKE '%,' + @IdTipoComprobanteOrigen
PRINT '4.4 VentasNumeros - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '," a "' + @IdTipoComprobanteDestino + ',"'
UPDATE VentasNumeros SET IdTipoComprobanteRelacionado = REPLACE(IdTipoComprobanteRelacionado, @IdTipoComprobanteOrigen + ',', @IdTipoComprobanteDestino + ',')
 WHERE IdTipoComprobanteRelacionado LIKE @IdTipoComprobanteOrigen + ',%'


--IMPRESORAS
PRINT '5.1 Impresoras - ComprobantesHabilitados de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE Impresoras SET ComprobantesHabilitados = @IdTipoComprobanteDestino
 WHERE ComprobantesHabilitados = @IdTipoComprobanteOrigen
PRINT '5.2 Impresoras - ComprobantesHabilitados de ",' + @IdTipoComprobanteOrigen + '," a ",' + @IdTipoComprobanteDestino + ',"'
UPDATE Impresoras SET ComprobantesHabilitados = REPLACE(ComprobantesHabilitados, ',' + @IdTipoComprobanteOrigen + ',', ',' + @IdTipoComprobanteDestino + ',')
 WHERE ComprobantesHabilitados LIKE '%,' + @IdTipoComprobanteOrigen + ',%'
PRINT '5.3 Impresoras - ComprobantesHabilitados de ",' + @IdTipoComprobanteOrigen + '" a ",' + @IdTipoComprobanteDestino + '"'
UPDATE Impresoras SET ComprobantesHabilitados = REPLACE(ComprobantesHabilitados, ',' + @IdTipoComprobanteOrigen, ',' + @IdTipoComprobanteDestino)
 WHERE ComprobantesHabilitados LIKE '%,' + @IdTipoComprobanteOrigen
PRINT '5.4 Impresoras - ComprobantesHabilitados de "' + @IdTipoComprobanteOrigen + '," a "' + @IdTipoComprobanteDestino + ',"'
UPDATE Impresoras SET ComprobantesHabilitados = REPLACE(ComprobantesHabilitados, @IdTipoComprobanteOrigen + ',', @IdTipoComprobanteDestino + ',')
 WHERE ComprobantesHabilitados LIKE @IdTipoComprobanteOrigen + ',%'


--PARAMETROS



--PROVEEDOR
PRINT '6 Proveedores - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE Proveedores
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen


--COMPRAS
PRINT '7. Compras  NUEVO"' + @IdTipoComprobanteDestino + '"'
INSERT INTO Compras
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,TipoDocComprador,NroDocComprador,Neto210_Viejo,Neto105_Viejo
           ,Neto270_Viejo,NetoNoGravado_Viejo,DescuentoRecargo,IVA210_Viejo,IVA105_Viejo,IVA270_Viejo,ImporteTotal,IdCategoriaFiscal,IdFormasPago,Observacion
           ,PorcentajeIVA,IdRubro,Bruto210_Viejo,Bruto105_Viejo,Bruto270_Viejo,BrutoNoGravado_Viejo,DescuentoRecargoPorc,PercepcionIVA,PercepcionIB,PercepcionGanancias
           ,PercepcionVarias,PeriodoFiscal,IdAsiento,ImportePesos,ImporteTarjetas,ImporteCheques,ImporteTransfBancaria,IdCuentaBancaria,IdEstadoComprobante,IdTipoComprobanteFact
           ,LetraFact,CentroEmisorFact,NumeroComprobanteFact,CantidadInvocados,IdProveedor,IdProveedorFact,Usuario,FechaActualizacion,IdPlanCuenta,CotizacionDolar
           ,FechaOficializacionDespacho,IdAduana,IdDestinacion,NumeroDespacho,DigitoVerificadorDespacho
           ,IdDespachante,IdAgenteTransporte,DerechoAduanero,BienCapitalDespacho,MetodoGrabacion
           ,IdFuncion,NumeroManifiestoDespacho,Bultos,ValorDeclarado,IdTransportista,NumeroLote,IVA105Calculado,IVA210Calculado,IVA270Calculado,IVAModificadoManual
           ,TotalBruto,TotalNeto,TotalIVA,TotalPercepciones,IdSucursalVenta,IdTipoComprobanteVenta,LetraVenta,CentroEmisorVenta,NumeroComprobanteVenta)
    SELECT IdSucursal,@IdTipoComprobanteDestino IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,TipoDocComprador,NroDocComprador,Neto210_Viejo,Neto105_Viejo
           ,Neto270_Viejo,NetoNoGravado_Viejo,DescuentoRecargo,IVA210_Viejo,IVA105_Viejo,IVA270_Viejo,ImporteTotal,IdCategoriaFiscal,IdFormasPago,Observacion
           ,PorcentajeIVA,IdRubro,Bruto210_Viejo,Bruto105_Viejo,Bruto270_Viejo,BrutoNoGravado_Viejo,DescuentoRecargoPorc,PercepcionIVA,PercepcionIB,PercepcionGanancias
           ,PercepcionVarias,PeriodoFiscal,IdAsiento,ImportePesos,ImporteTarjetas,ImporteCheques,ImporteTransfBancaria,IdCuentaBancaria,IdEstadoComprobante,IdTipoComprobanteFact
           ,LetraFact,CentroEmisorFact,NumeroComprobanteFact,CantidadInvocados,IdProveedor,IdProveedorFact,Usuario,FechaActualizacion,IdPlanCuenta,CotizacionDolar
           ,FechaOficializacionDespacho,IdAduana,IdDestinacion,NumeroDespacho,DigitoVerificadorDespacho
           ,IdDespachante,IdAgenteTransporte,DerechoAduanero,BienCapitalDespacho,MetodoGrabacion
           ,IdFuncion,NumeroManifiestoDespacho,Bultos,ValorDeclarado,IdTransportista,NumeroLote,IVA105Calculado,IVA210Calculado,IVA270Calculado,IVAModificadoManual
           ,TotalBruto,TotalNeto,TotalIVA,TotalPercepciones,IdSucursalVenta,IdTipoComprobanteVenta,LetraVenta,CentroEmisorVenta,NumeroComprobanteVenta
      FROM Compras
     WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '7.1. Compras - IdTipoComprobanteFact de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE Compras
   SET IdTipoComprobanteFact = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteFact = @IdTipoComprobanteOrigen

PRINT '8.1. ComprasProductos - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE ComprasProductos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '8.2. ComprasObservaciones IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE ComprasObservaciones
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '8.3. ComprasImpuestos - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE ComprasImpuestos
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '8.4. ComprasCheques - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE ComprasCheques
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

PRINT '9. MovimientosCompras - IdTipoComprobante de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE MovimientosCompras
   SET IdTipoComprobante = @IdTipoComprobanteDestino
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

 --CUENTA CORRIENTE PROV
PRINT '10. CuentasCorrientesProv  NUEVO"' + @IdTipoComprobanteDestino + '"'
INSERT INTO CuentasCorrientesProv
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,FechaVencimiento,ImporteTotal,IdFormasPago,Observacion
           ,Saldo,CantidadCuotas,ImportePesos,ImporteDolares,ImporteEuros,ImporteCheques,ImporteTransfBancaria,ImporteTickets,IdCuentaBancaria,IdCaja
           ,NumeroPlanilla,NumeroMovimiento,ImporteRetenciones,ImporteTarjetas,IdEstadoComprobante
           ,IdUsuario,IdProveedor,FechaActualizacion,IdAsiento,IdPlanCuenta
           ,ImprimeSaldos,MetodoGrabacion,IdFuncion)
    SELECT IdSucursal,@IdTipoComprobanteDestino IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Fecha,FechaVencimiento,ImporteTotal,IdFormasPago,Observacion
           ,Saldo,CantidadCuotas,ImportePesos,ImporteDolares,ImporteEuros,ImporteCheques,ImporteTransfBancaria,ImporteTickets,IdCuentaBancaria,IdCaja
           ,NumeroPlanilla,NumeroMovimiento,ImporteRetenciones,ImporteTarjetas,IdEstadoComprobante
           ,IdUsuario,IdProveedor,FechaActualizacion,IdAsiento,IdPlanCuenta
           ,ImprimeSaldos,MetodoGrabacion,IdFuncion
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

 --PEDIDOS PROVEEDORES
PRINT '12.1. PedidosEstadosProveedores - IdTipoComprobanteRemito de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
 UPDATE PedidosEstadosProveedores
   SET IdTipoComprobanteRemito = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteRemito = @IdTipoComprobanteOrigen
PRINT '12.2. PedidosEstadosProveedores - IdTipoComprobanteFact de "' + @IdTipoComprobanteOrigen + '" a "' + @IdTipoComprobanteDestino + '"'
UPDATE PedidosEstadosProveedores
   SET IdTipoComprobanteFact = @IdTipoComprobanteDestino
 WHERE IdTipoComprobanteFact = @IdTipoComprobanteOrigen


PRINT '13.1. CuentasCorrientes BORRA IdTipoComprobante"' + @IdTipoComprobanteOrigen + '"'
DELETE FROM CuentasCorrientesProv WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
PRINT '13.2. Compras BORRA IdTipoComprobante"' + @IdTipoComprobanteOrigen + '"'
DELETE FROM Compras WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
PRINT '13.3. TiposComprobantes BORRA IdTipoComprobante"' + @IdTipoComprobanteOrigen + '"'
DELETE FROM TiposComprobantes WHERE IdTipoComprobante = @IdTipoComprobanteOrigen

COMMIT

/*
EXEC sp_fkeys 'VentasNumeros'

SELECT *
  FROM VentasNumeros
 WHERE IdTipoComprobante = @IdTipoComprobanteOrigen
SELECT *
  FROM VentasNumeros
 WHERE IdTipoComprobanteRelacionado LIKE '%REMITOCOM%'

*/
