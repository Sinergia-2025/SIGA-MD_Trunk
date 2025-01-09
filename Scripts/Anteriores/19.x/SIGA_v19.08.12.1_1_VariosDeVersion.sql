PRINT ''
PRINT '1. Tabla TiposComprobantes: Nuevos campos AFIPWSIncluyeFechaVencimiento y AFIPWSEsFEC'
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSIncluyeFechaVencimiento bit NULL
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSEsFEC bit NULL
GO
PRINT ''
PRINT '1.1. Tabla TiposComprobantes: valores por defecto para AFIPWSEsFEC'
UPDATE TiposComprobantes SET AFIPWSEsFEC = 0;
PRINT ''
PRINT '1.2. Tabla TiposComprobantes: NOT NULL para AFIPWSEsFEC'
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AFIPWSEsFEC bit NOT NULL
GO

PRINT ''
PRINT '2. Tabla CuentasBancarias: Nuevos campos ParaInformarEnFEC'
ALTER TABLE dbo.CuentasBancarias ADD ParaInformarEnFEC bit NULL
GO
PRINT ''
PRINT '2.1. Tabla CuentasBancarias: valores por defecto para ParaInformarEnFEC'
UPDATE CuentasBancarias SET ParaInformarEnFEC = 0;
PRINT ''
PRINT '2.2. Tabla CuentasBancarias: NOT NULL para ParaInformarEnFEC'
ALTER TABLE dbo.CuentasBancarias ALTER COLUMN ParaInformarEnFEC bit NOT NULL
GO

PRINT ''
PRINT '3. Nuevo Tipo de Comprobante: eFCE - eFactura de Crédigo Electrónica'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'eFCE', [EsFiscal], 'eFactura CE', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'eFact. CE', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], 'True', 'True'
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'eFact'

PRINT ''
PRINT '4. Nuevo Tipo de Comprobante: eNCCE - eNota de Credito de Crédigo Electrónica'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'eNCCE', [EsFiscal], 'eNota de Credito CE', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'eN.Cred.CE', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], 'True', 'True' 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'eNCRED'

PRINT ''
PRINT '5. Nuevo Tipo de Comprobante: eNDCE - eNota de Debito de Crédigo Electrónica'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'eNDCE', [EsFiscal], 'eNota de Debito CE', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'eN.Deb.CE', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], 'True', 'True' 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'eNDEB'

PRINT ''
PRINT '6. Nuevo Tipo de Comprobante: eNDCECHEQRECH - eNota de Debito de Crédigo Electrónica por Cheque Rechazado'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'eNDCECHEQRECH', [EsFiscal], 'eNota de Debito CE (ChR)', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'eND.CE.ChR', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], 'True', 'True' 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'eNDEBCHEQRECH'



PRINT ''
PRINT '7. Nuevo Tipo de Comprobante: ePRE-FCE - ePre-Factura de Crédito Electrónica'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'ePRE-FCE', [EsFiscal], '  ePre-F CE', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'ePre-FCE', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], 'eFCE', [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC] 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'ePRE-Fact'

PRINT ''
PRINT '8. Nuevo Tipo de Comprobante: ePRE-NCCE - ePre-Nota de Crédito de Crédito Electrónica'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'ePRE-NCCE', [EsFiscal], '  ePre-NC CE', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'ePre-NCCE', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  '''eFCE'',''eNDCE''', [EsComercial], [CantidadMaximaItemsObserv], 'eNCCE', [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC] 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'ePRE-NCRED'

PRINT ''
PRINT '9. Nuevo Tipo de Comprobante: ePRE-NDCE - ePre-Nota de Débito de Crédito Electrónica'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'ePRE-NDCE', [EsFiscal], '  ePre-ND CE', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'ePre-NDCE', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], 'eNDCE', [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC] 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'ePRE-NDEB'

PRINT ''
PRINT '10. Nuevo Tipo de Comprobante: ePRE-NDCECHEQR - ePre-Nota de Débito de Crédito Electrónica por Cheque Rechazado'
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
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
SELECT 
/* 1*/  'ePRE-NDCECHEQR', [EsFiscal], '  ePre-ND CE.Cheq.Rech', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
/* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'ePreNDCECR', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], 'eNDCECHEQRECH', [ImporteTope], 
/* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
/* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
/* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
/* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
/*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
/*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
/*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
/*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC] 
  FROM [dbo].[TiposComprobantes]
 WHERE IdTipoComprobante = 'ePRE-NDEBCHEQR'



PRINT ''
PRINT '11. Tabla AFIPTiposComprobantes: Nuevos tipos de comprobantes FCE (201,202,203,206,207,208,211,212,213)'
INSERT INTO AFIPTiposComprobantes
            (IdAFIPTipoComprobante,NombreAFIPTipoComprobante,IdTipoComprobante,Letra,IdAFIPTipoDocumento,IncluyeFechaVencimiento)
     VALUES (201,'Factura de Crédito electrónica MiPyMEs (FCE) A',NULL,NULL,NULL,NULL),
            (202,'Nota de Débito electrónica MiPyMEs (FCE) A'    ,NULL,NULL,NULL,NULL),
            (203,'Nota de Crédito electrónica MiPyMEs (FCE) A'   ,NULL,NULL,NULL,NULL),
          
            (206,'Factura de Crédito electrónica MiPyMEs (FCE) B',NULL,NULL,NULL,NULL),
            (207,'Nota de Débito electrónica MiPyMEs (FCE) B'    ,NULL,NULL,NULL,NULL),
            (208,'Nota de Crédito electrónica MiPyMEs (FCE) B'   ,NULL,NULL,NULL,NULL),
          
            (211,'Factura de Crédito electrónica MiPyMEs (FCE) C',NULL,NULL,NULL,NULL),
            (212,'Nota de Débito electrónica MiPyMEs (FCE) C'    ,NULL,NULL,NULL,NULL),
            (213,'Nota de Crédito electrónica MiPyMEs (FCE) C'   ,NULL,NULL,NULL,NULL)
GO

PRINT ''
PRINT '12. Tabla AFIPTiposComprobantesTiposCbtes: Nuevos tipos de comprobantes FCE (201,202,203,206,207,208,211,212,213)'
INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante,IdTipoComprobante,Letra)
    VALUES (201,'eFCE','A'),
           (202,'eNDCE','A'),
           (202,'eNDCECHEQRECH','A'),
           (203,'eNCCE','A'),

           (206,'eFCE','B'),
           (207,'eNDCE','B'),
           (207,'eNDCECHEQRECH','B'),
           (208,'eNCCE','B'),

           (211,'eFCE','C'),
           (212,'eNDCE','C'),
           (212,'eNDCECHEQRECH','C'),
           (213,'eNCCE','C')
GO

PRINT ''
PRINT '13. Tabla AFIPTiposComprobantesTiposCbtes: Nuevos PRE tipos de comprobantes FCE (201,202,203,206,207,208,211,212,213)'
INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante,IdTipoComprobante,Letra)
    VALUES (201,'ePRE-FCE','A'),
           (202,'ePRE-NDCE','A'),
           (202,'ePRE-NDCECHEQR','A'),
           (203,'ePRE-NCCE','A'),

           (206,'ePRE-FCE','B'),
           (207,'ePRE-NDCE','B'),
           (207,'ePRE-NDCECHEQR','B'),
           (208,'ePRE-NCCE','B'),

           (211,'ePRE-FCE','C'),
           (212,'ePRE-NDCE','C'),
           (212,'ePRE-NDCECHEQR','C'),
           (213,'ePRE-NCCE','C')
GO
