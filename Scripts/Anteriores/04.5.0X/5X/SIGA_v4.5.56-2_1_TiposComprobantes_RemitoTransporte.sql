
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
         IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 
         EsDespachoImportacion, CargaDescRecActual)
 VALUES ('REMITOCOMTRANSP', 'False', 'Remito Compras Transporte', 'COMPRAS', -1, 
        'False', 'False', 'X', 24, 'False', 
         1, NULL, 'False', 'False', 'False', 
        'False', 'Rem.Transp', 'False', 1, 'True', 
         NULL, 'False', 23, NULL, 0, 
         '.', 'False', 0.01, 'False', 'True',
        'True', 'True', 'False', 'False', 2, 
        'False', 'False', 'COMPRAS', 'False', 'False',
        'False', 'False', 'False', NULL, NULL, 
         NULL, NULL, 'False', 'False', '', 
        'False', 'False')
GO

UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',REMITOCOMTRANSP'
  WHERE IdTipoMovimiento = 'COMPRA-NC'
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',REMITOCOMTRANSP'
 WHERE IdImpresora = 'NORMAL'
   AND IdSucursal = 1
GO
