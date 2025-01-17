
INSERT TiposComprobantes
        (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
        ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
        ,EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev
        ,PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial
        ,CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson
        ,UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos
        ,NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
        ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, UtilizaCtaSecundariaProd
        ,UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
        ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere
        ,EsDespachoImportacion)
VALUES ('ADELANTO', 'False', 'ADELANTO', 'CTACTE', 0, 'True', 'False'
       ,'X', 999, 'False', -1, NULL
       ,'False', 'True', 'False', 'True', 'ADELANTO'
       ,'True', 1, 'False', NULL, 'False'
       ,998, NULL, 0, '.'
       ,'False', -100000, 'False', 'False', 'False'
       ,'True', 'True', 'True', 1
       ,'False', 'False', 'CTACTE', 'False', 'False', 'False'
       ,'False', 'False', NULL, NULL
       ,NULL, NULL, 'False', 'False', ''
       ,'False')
GO
