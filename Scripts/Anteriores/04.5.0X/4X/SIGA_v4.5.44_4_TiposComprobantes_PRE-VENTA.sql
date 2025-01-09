      
-- Creo Comprobante PRE-VENTA para Cajero

INSERT TiposComprobantes 
      (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
      ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
      ,EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
      ,CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
      ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
      ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico
      ,GeneraContabilidad, UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas
      ,IdTipoComprobanteNCred, IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb, ConsumePedidos
      ,EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion) 
VALUES ('PRE-VENTA', 'False', '  PRE-VENTA', 'VENTAS', 0, 'False', 'True'
       ,'X', 100, 'False', 1, 'SI'
       , 'True', 'False', 'False', 'False', 'Pre-Venta', 'True'
       , 1, 'False', '''PRESUP''', 'False', 99
       , NULL, 0, '.', 'False', 0
       , 'False', 'True', 'True', 'False', 'True'
       , 'True', 1, 'False', 'False', 'VENTAS', 'False'
       , 'False', 'False', 'False', 'False'
       , NULL, NULL, NULL, NULL, 'False'
       , 'False', '', 'False')
;
