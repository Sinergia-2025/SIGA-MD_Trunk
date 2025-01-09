
PRINT ''
PRINT '1. TiposComprobantes: Creo LIQUIDO.'
GO
IF NOT EXISTS (SELECT 1 FROM TiposComprobantes WHERE IdTipoComprobante = 'LIQUIDO')

	INSERT TiposComprobantes
	/* 1*/ (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
	/* 5*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 
	/* 6*/  IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
	/* 7*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	/* 8*/  Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
	/* 9*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
	/*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
	/*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
	/*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
	/*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC,
	/*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden,
	/*15*/  MarcaInvocado)
	VALUES
	/* 1*/ ('LIQUIDO', 'False',' Liquido Prod.','VENTAS', 1
	/* 2*/  , 'True', 'True','A,B,C,E,M', 24, 'True'
	/* 3*/ , -1, NULL, 'True', 'True', 'False'
	/* 4*/ , 'True','Liquido P.', 'False', 2, 'False'
	/* 5*/ , NULL, 1, 23, NULL, 0
	/* 6*/ ,'.', 'False', cast(1 as float) / cast(100 as float), 'False', 'True'
	/* 7*/ , 'True', 'False', 'True', 'True', 1
	/* 8*/ ,'INVERSION', 'False', 'False', 'False', 'True'
	/* 9*/ , 'False', 'True', 'False', NULL, NULL
	/*10*/ , NULL, NULL, 'False', 'False', ''
	/*11*/ , 'False', 'False', NULL, 'True', 'True'
	/*12*/ , 'True', 'False', 8, 1, 'False'
	/*13*/ , 'True', 'False', 'False', NULL, 'False'
	/*14*/ , 'False', 'False', 'False', 'False', 10
	/*15*/ , 'True')
GO

PRINT ''
PRINT '2. TiposComprobantes: Creo LIQUIDO-NC.'
GO
IF NOT EXISTS (SELECT 1 FROM TiposComprobantes WHERE IdTipoComprobante = 'LIQUIDO-NC')

	INSERT TiposComprobantes
	/* 1*/ (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
	/* 5*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 
	/* 6*/  IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
	/* 7*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	/* 8*/  Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
	/* 9*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
	/*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
	/*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
	/*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
	/*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC,
	/*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden,
	/*15*/  MarcaInvocado)
	VALUES
	/* 1*/ ('LIQUIDO-NC', 'False',' Liquido Prod. N.Cred.','VENTAS', -1
	/* 2*/  , 'True', 'True','A,B,C,E,M', 24, 'True'
	/* 3*/ , 1, NULL, 'True', 'True', 'False'
	/* 4*/ , 'True','Liquido NC', 'False', 2, 'False'
	/* 5*/ , NULL, 1, 23, NULL, 0
	/* 6*/ ,'.', 'False', cast(1 as float) / cast(100 as float), 'False', 'True'
	/* 7*/ , 'True', 'False', 'True', 'True', 1
	/* 8*/ ,'INVERSION', 'False', 'False', 'False', 'True'
	/* 9*/ , 'False', 'True', 'False', NULL, NULL
	/*10*/ , NULL, NULL, 'False', 'False',''
	/*11*/ , 'False', 'False', NULL, 'True', 'True'
	/*12*/ , 'True', 'False', 8, 1, 'False'
	/*13*/ , 'True', 'False', 'False', NULL, 'False'
	/*14*/ , 'False', 'False', 'False', 'False', 10
	/*15*/ , 'True')
GO

PRINT ''
PRINT '3. TiposComprobantes: Creo DESEMBOLSO.'
GO
IF NOT EXISTS (SELECT 1 FROM TiposComprobantes WHERE IdTipoComprobante = 'DESEMBOLSO')

	INSERT TiposComprobantes
	/* 1*/ (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
	/* 5*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 
	/* 6*/  IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
	/* 7*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	/* 8*/  Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
	/* 9*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
	/*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
	/*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
	/*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
	/*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC,
	/*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden,
	/*15*/  MarcaInvocado)
	VALUES
	/* 1*/ ('DESEMBOLSO', 'False','Desembolso','CTACTECLIE', 0
	/* 2*/  , 'False', 'False','X', 100, 'False'
	/* 3*/ , -1, NULL, 'False', 'True', 'False'
	/* 4*/ , 'True','Desembolso', 'False', 1, 'False'
	/* 5*/ ,'''ANTICIPOIDX'',''RECIBOIDX'',''LIQUIDO'',''LIQUIDO-NC'',''AJUSTE2-'',''AJUSTE2+'',''FACT-INV'',''NCRED-INV''', 1, 0, NULL, cast(-1 as float) / cast(100 as float) 
	/* 6*/ ,'.', 'False', -9999999, 'False', 'False'
	/* 7*/ , 'True', 'True', 'False', 'False', 1
	/* 8*/ ,'INVERSION', 'True', 'False', 'False', 'True'
	/* 9*/ , 'False', 'False', 'False', NULL, NULL
	/*10*/ , NULL, NULL, 'False', 'False', ''
	/*11*/ , 'False', 'False', NULL, 'True', 'True'
	/*12*/ , 'True', 'False', 8, 1, 'False'
	/*13*/ , 'True', 'False', 'False', NULL, 'False'
	/*14*/ , 'False', 'False', 'False', 'False', 10
	/*15*/ , 'True')
GO

PRINT ''
PRINT '4. TiposComprobantes: Creo ANTICIPODES.'
GO
IF NOT EXISTS (SELECT 1 FROM TiposComprobantes WHERE IdTipoComprobante = 'ANTICIPODES')

	INSERT TiposComprobantes
	/* 1*/ (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
	/* 5*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 
	/* 6*/  IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
	/* 7*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	/* 8*/  Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
	/* 9*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
	/*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
	/*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
	/*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
	/*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC,
	/*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden,
	/*15*/  MarcaInvocado)
	VALUES
	/* 1*/ ('ANTICIPODES', 'False','Anticipo Desembolso','CTACTE', 0
	/* 2*/ , 'False', 'False','R', 100, 'False'
	/* 3*/ , -1, NULL, 'False', 'True', 'False'
	/* 4*/ , 'True','Antic.CyO', 'False', 1, 'False'
	/* 5*/ , NULL, 1, 0, NULL, 99999999
	/* 6*/ ,'.', 'False', cast(1 as float) / cast(100 as float), 'False', 'False'
	/* 7*/ , 'True', 'True', 'False', 'False', 1
	/* 8*/ ,'ALQUILER', 'False', 'True', 'False', 'False'
	/* 9*/ , 'False', 'False', 'False', NULL, NULL
	/*10*/ , NULL, NULL, 'False', 'False', ''
	/*11*/ , 'False', 'False', NULL, 'True', 'True'
	/*12*/ , 'True', 'False', 8, 1, 'False'
	/*13*/ , 'True', 'False', 'False', NULL, 'False'
	/*14*/ , 'False', 'False', 'False', 'False', 10
	/*15*/ , 'True')
GO

PRINT ''
PRINT '5. TiposComprobantes: Enlazo ANTICIPODES a DESEMBOLSO.'
GO
UPDATE TiposComprobantes
   SET IdTipoComprobanteSecundario = 'ANTICIPODES'
 WHERE IdTipoComprobante = 'DESEMBOLSO'
  AND (IdTipoComprobanteSecundario IS NULL OR IdTipoComprobanteSecundario <> 'ANTICIPODES')
GO

PRINT ''
PRINT '6. TiposComprobantes: Enlazo DESEMBOLSO a ANTICIPODES.'
GO
UPDATE TiposComprobantes
   SET IdTipoComprobanteSecundario = 'DESEMBOLSO'
 WHERE IdTipoComprobante = 'ANTICIPODES'
  AND (IdTipoComprobanteSecundario IS NULL OR IdTipoComprobanteSecundario <> 'DESEMBOLSO')
GO


PRINT ''
PRINT '7. TiposComprobantes: Creo MINUTADESEMB.'
GO
IF NOT EXISTS (SELECT 1 FROM TiposComprobantes WHERE IdTipoComprobante = 'MINUTADESEMB')

	INSERT TiposComprobantes
	/* 1*/ (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
	/* 5*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 
	/* 6*/  IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
	/* 7*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
	/* 8*/  Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
	/* 9*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
	/*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
	/*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
	/*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
	/*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC,
	/*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden,
	/*15*/  MarcaInvocado)
	VALUES
	/* 1*/ ('MINUTADESEMB', 0,'Minuta Desembolso','CTACTECLIE', 0
	/* 2*/  , 'False', 'False','X', 100,'False'
	/* 3*/ , -1, NULL, 'False', 'True', 'False'
	/* 4*/ , 'True','Minuta Des', 'False', 1, 'False'
	/* 5*/ ,'''LIQUIDO'',''LIQUIDO-NC'',''FACT-INV'',''NCRED-INV'',''FACT'',''eFACT'',''eNDEB'',''FACT-F'',''NDEB'',''NDEBCHEQRECH'',''NDEB-F'',''TCK-FACT-F'',''TICKET-F''', 1, 0, NULL, 0
	/* 6*/ ,'.', 'False', 0, 'False', 'False'
	/* 7*/ , 'True', 'True', 'False', 'False', 1
	/* 8*/ ,'INVERSION', 'False', 'False', 'False', 'True'
	/* 9*/ , 'False', 'False', 'False', NULL, NULL
	/*10*/ , NULL, NULL, 'False', 'False', ''
	/*11*/ , 'False', 'False', NULL, 'True', 'True'
	/*12*/ , 'True', 'False', 8, 1, 'False'
	/*13*/ , 'True', 'False', 'False', NULL, 'False'
	/*14*/ , 'False', 'False', 'False', 'False', 10
	/*15*/ , 'True')
GO
