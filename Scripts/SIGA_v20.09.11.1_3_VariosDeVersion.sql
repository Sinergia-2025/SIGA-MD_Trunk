IF dbo.BaseConCuit('33631312379') = 1
BEGIN
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OC', EsFiscal, 'Orden Compra', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OC', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'Orden Compra', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OCA', EsFiscal, 'Orden Compra A', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OCA', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'Orden Compra A', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OCC', EsFiscal, 'Orden Compra C', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OCC', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'Orden Compra C', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OCI', EsFiscal, 'Orden Compra I', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OCI', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'Orden Compra I', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OCR', EsFiscal, 'Orden Compra R', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OCR', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'Orden Compra R', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OCV', EsFiscal, 'Orden Compra V', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OCV', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'Orden Compra V', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion)
     SELECT
	/* 1*/  'OIM', EsFiscal, 'OIM', Tipo, CoeficienteStock, 
	/* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
	/* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
	/* 4*/  ActualizaCtaCte, 'OIM', PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
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
	/*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, 'OIM', InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
       FROM TiposComprobantes
      WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'

UPDATE I
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',OC,OCA,OCC,OCI,OCR,OCV,OIM'
  FROM Impresoras I
 WHERE (I.ComprobantesHabilitados LIKE 'PEDIDOPROVEEDOR,%' OR I.ComprobantesHabilitados LIKE '%,PEDIDOPROVEEDOR,%' OR I.ComprobantesHabilitados LIKE '%,PEDIDOPROVEEDOR')

END
