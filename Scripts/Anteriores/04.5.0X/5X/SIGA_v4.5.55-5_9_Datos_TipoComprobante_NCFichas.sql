
INSERT TiposComprobantes 
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
     GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
     CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
     ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
     ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 
     IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
     UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
     EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, 
     UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
     IdProductoNCred, IdProductoNDeb, EsPreFiscal, ConsumePedidos, CodigoComprobanteSifere, 
     EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar) 
VALUES 
    ('NCFICHAS', 'False', 'NC Fichas', 'VENTAS', 0, 
     'False', 'True', 'X', 100, 'True', 
     -1, NULL, 'True', 'True', 'False', 
     'True', 'NC Ficha', 'False', 1, 'False', 
     NULL, 'True', 99, NULL, 0, 
     '.', 'False', 0.01, 'False', 'True', 
     'True', 'False', 'True', 'True', 2, 
     'False', 'False', 'VENTAS', 'False', 'True',
     'False', 'False', 'False', NULL, NULL, 
     NULL, NULL, 'False', 'False', '', 
     'False', 1, NULL)
;
