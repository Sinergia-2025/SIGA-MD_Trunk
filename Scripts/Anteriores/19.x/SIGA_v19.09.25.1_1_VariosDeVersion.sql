PRINT ''
PRINT '1. Tabla TiposComprobantes: Nuevo ... Impuesto NC.'
GO

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
/*14*/  [AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion])
SELECT 
/* 1*/  'IMPUESTONC', [EsFiscal], 'Impuesto NC', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  -1, [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'ImpuestoNC', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC],
/*14*/  [AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion]
    FROM [dbo].[TiposComprobantes]
    WHERE IdTipoComprobante = 'IMPUESTO'
GO

PRINT ''
PRINT '2. Tabla Impresoras: Asocio Impuesto NC a la Impresora NORMAL.'
GO
UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',IMPUESTONC'
 WHERE IdImpresora = 'NORMAL'
GO

PRINT ''
PRINT '3. Tabla TiposMovimientos: Asocio Impuesto NC a COMPRA-NC.'
GO
UPDATE TiposMovimientos 
   SET ComprobantesAsociados = ComprobantesAsociados + ',IMPUESTONC'
  WHERE IdTipoMovimiento = 'COMPRA-NC'
GO
