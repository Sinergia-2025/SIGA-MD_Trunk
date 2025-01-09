--No se corre en HAR porque ya se implementó el script.
IF dbo.SoyHAR() = 0
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
    /* 1*/  REPLACE(REPLACE(IdTipoComprobante, 'ANTICIPO', 'ANTIDEV'), 'RECIBO', 'DEVOLUCION') IdTipoComprobante, 
            EsFiscal, 
            LTRIM(REPLACE(REPLACE(Descripcion, 'Anticipo', 'Anticipo Dev.'), 'Recibo', 'Devolucion')) Descripcion, Tipo, CoeficienteStock, 
    /* 2*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
    /* 3*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
    /* 4*/  ActualizaCtaCte, 
            CASE IdTipoComprobante WHEN 'ANTICIPO' THEN 'Ant.Dev.'   WHEN 'ANTICIPOPROV' THEN 'Ant.Dev.Pr' WHEN 'ANTICIPOUNICO' THEN 'Ant.Dev.Un'
                                    WHEN 'RECIBO'   THEN 'Devolucion' WHEN 'RECIBOPROV'   THEN 'Devol.Pr.'  WHEN 'RECIBOUNICO'   THEN 'Devol.Un.' END DescripcionAbrev,
            PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
    /* 5*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, 
            CASE IdTipoComprobante WHEN 'ANTICIPO' THEN 'RECIBO'   WHEN 'ANTICIPOPROV' THEN 'RECIBOPROV'   WHEN 'ANTICIPOUNICO' THEN 'RECIBOUNICO'
                                    WHEN 'RECIBO'   THEN 'ANTICIPO' WHEN 'RECIBOPROV'   THEN 'ANTICIPOPROV' WHEN 'RECIBOUNICO'   THEN 'ANTICIPOUNICO' END IdTipoComprobanteSecundario,
            -0.01 ImporteTope, 
    /* 6*/  IdTipoComprobanteEpson, UsaFacturacionRapida, -99999999.00 ImporteMinimo, EsElectronico, UsaFacturacion, 
    /* 7*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
    /* 8*/  Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
    /* 9*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
    /*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
    /*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
    /*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
    /*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC,
    /*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden,
    /*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, LTRIM(REPLACE(REPLACE(Descripcion, 'Anticipo', 'Anticipo Dev.'), 'Recibo', 'Devolucion')) DescripcionImpresion, InformaLibroIva,
    /*16*/  SolicitaFechaDevolucion
      FROM TiposComprobantes
     WHERE IdTipoComprobante IN ('ANTICIPO','ANTICIPOPROV','ANTICIPOUNICO')
        OR IdTipoComprobante IN ('RECIBO','RECIBOPROV','RECIBOUNICO')

    UPDATE I
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',DEVOLUCION,ANTIDEV'
      FROM Impresoras I
     WHERE (I.ComprobantesHabilitados LIKE 'RECIBO,%' OR I.ComprobantesHabilitados LIKE '%,RECIBO,%' OR I.ComprobantesHabilitados LIKE '%,RECIBO')
    UPDATE I
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',DEVOLUCIONPROV,ANTIDEVPROV'
      FROM Impresoras I
     WHERE (I.ComprobantesHabilitados LIKE 'RECIBOPROV,%' OR I.ComprobantesHabilitados LIKE '%,RECIBOPROV,%' OR I.ComprobantesHabilitados LIKE '%,RECIBOPROV')
    UPDATE I
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',DEVOLUCIONUNICO,ANTIDEVUNICO'
      FROM Impresoras I
     WHERE (I.ComprobantesHabilitados LIKE 'RECIBOUNICO,%' OR I.ComprobantesHabilitados LIKE '%,RECIBOUNICO,%' OR I.ComprobantesHabilitados LIKE '%,RECIBOUNICO')
END

/*
,ANTIDEV,ANTIDEVPROV,ANTIDEVUNICO,DEVOLUCION,DEVOLUCIONPROV,DEVOLUCIONUNICO
*/
/*
SELECT *
  FROM TiposComprobantes
 WHERE IdTipoComprobante IN ('ANTICIPO','ANTICIPOPROV','ANTICIPOUNICO')

SELECT *
  FROM TiposComprobantes
 WHERE IdTipoComprobante IN ('RECIBO','RECIBOPROV','RECIBOUNICO')
*/

/*
DELETE
  FROM TiposComprobantes
 WHERE IdTipoComprobante IN ('ANTIDEV','ANTIDEVPROV','ANTIDEVUNICO')
*/