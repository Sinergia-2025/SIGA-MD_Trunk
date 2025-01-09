PRINT ''
PRINT '1. Tabla TiposComprobantes: Ensancho ComprobantesAsociados al Máximo de caracteres.'
GO
ALTER TABLE dbo.TiposComprobantes  ALTER COLUMN ComprobantesAsociados varchar(MAX) NULL;

PRINT ''
PRINT '2. Tabla TiposComprobantes: Nuevo... TiposComprobantes Recibo Unico.'
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
	AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC, AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion)
VALUES 
	('RECIBOUNICO', 'False', '  Recibo Unico', 'CTACTECLIE', 0, 'False', 'False'
	, 'X', 100, 'True', -1, NULL, 'False', 'True'
	, 'False', 'true', 'Rec. Unico', 'False', 1, 'False', '''ANTICIPOPROV'',''COTIZACION'',''DEV-COTIZACION'',''COTIZCHEQRECH'',''NDEB-COTIZACION'',''TICKET-NOFISCAL'',''SALDOINICIAL+'',''SALDOINICIAL-'',''ANTICIPOPROVe'',''AJUSTE2+'',''AJUSTE2-'',''ANTICIPO'',''FACT'',''NCRED'',''eFACT'',''eNCRED'',''eNDEB'',''FACT-F'',''NCRED-F'',''NDEB'',''NDEBCHEQRECH'',''NDEB-F'',''TCK-FACT-F'',''TICKET-F'',''ANTICIPOe'',''eNDEBCHEQRECH'',''AJUSTE+'',''AJUSTE-'',''ANTICIPOUNICO'''
	, 'True', 0, NULL, 99999999, '.', 'False', (1/100)
	, 'False', 'False', 'True', 'True', 'False', 'False', 2
	, 'False', 'True', 'CTACTECLIE', 'False', 'True', 'False','False'
	, 'False', NULL, NULL, NULL, NULL, 'False', 'False'
	, 'R', 'False', 'False', NULL, 'True', 'True', 'True'
	, 'False', 8, 1, 'False', 'True', 'False', 'False'
	, NULL, 'False', 'False', 'False', 'False', 'False')
GO

PRINT ''
PRINT '3. Tabla Impresoras: Asocio Recibo Unico solo para Nutrisur.'
GO
IF dbo.BaseConCuit('20164865720') = 1
	BEGIN
		UPDATE Impresoras 
		   SET ComprobantesHabilitados = ComprobantesHabilitados + ',RECIBOUNICO'
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
/*14*/  [AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion])
SELECT 
/* 1*/  'ANTICIPOUNICO', [EsFiscal], 'Anticipo Unico', [Tipo], [CoeficienteStock], 
/* 2*/  [GrabaLibro], [EsFacturable],[LetrasHabilitadas],[CantidadMaximaItems], [Imprime], 
/* 3*/  -1, [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
/* 4*/  [ActualizaCtaCte], 'Ant. Unico', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
/* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], 'RECIBOUNICO', [ImporteTope], 
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
    WHERE IdTipoComprobante = 'ANTICIPOPROV';

PRINT ''
PRINT '4.1. Tabla TiposComprobantes: Asocio Anticipo Unico al Recibo Unico.'
	UPDATE TiposComprobantes 
	SET IdTipoComprobanteSecundario = 'ANTICIPOUNICO'
    WHERE IdTipoComprobante = 'RECIBOUNICO';

PRINT ''
PRINT '4. 2. Tabla Impresoras: Asocio Anticipo Unico solo para Nutrisur.'
IF dbo.BaseConCuit('20164865720') = 1
		UPDATE Impresoras 
			SET ComprobantesHabilitados = ComprobantesHabilitados + ',ANTICIPOUNICO'
			WHERE IdImpresora = 'NORMAL'
			AND IdSucursal = 1;



PRINT ''
PRINT '5. Tabla TiposComprobantes: Nuevo... TiposComprobantes Minuta Unica.'
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
	AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC, AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion)
VALUES 
	( 'MINUTAUNICA', 'False', N'Minuta Unica', 'CTACTECLIE', 0, 'False', 'False'
	, 'X', 100, 'True', -1, NULL, 'False', 'True'
	, 'False', 'True', 'Min. Unica', 'False', 1, 'False', '''ANTICIPOPROV'',''COTIZACION'',''DEV-COTIZACION'',''COTIZCHEQRECH'',''NDEB-COTIZACION'',''TICKET-NOFISCAL'',''SALDOINICIAL+'',''SALDOINICIAL-'',''ANTICIPOPROVe'',''AJUSTE2+'',''AJUSTE2-'',''ANTICIPO'',''FACT'',''NCRED'',''eFACT'',''eNCRED'',''eNDEB'',''FACT-F'',''NCRED-F'',''NDEB'',''NDEBCHEQRECH'',''NDEB-F'',''TCK-FACT-F'',''TICKET-F'',''ANTICIPOe'',''eNDEBCHEQRECH'',''AJUSTE+'',''AJUSTE-'',''ANTICIPOUNICO'''
	, 'True', 0, NULL, 0, '.', 'False', 0
	, 'False', 'False', 'True', 'True', 'False', 'False', 2
	, 'False', 'True', 'CTACTECLIE', 'False', 'True', 'False','False'
	, 'False', NULL, NULL, NULL, NULL, 'False', 'False'
	, '', 'False', 'False', NULL, 'True', 'True', 'True'
	, 'False', 8, 1, 'False', 'True', 'False', 'False'
	,  NULL, 'False', 'False', 'False', 'False', 'False')
GO


