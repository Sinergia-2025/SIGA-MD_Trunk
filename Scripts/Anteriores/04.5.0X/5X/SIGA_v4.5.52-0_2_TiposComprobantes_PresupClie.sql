
INSERT TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
     GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
     CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
     ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
     ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope,
     IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion,
     UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta,
     Grupo, EsRecibo, EsAnticipo, EsPreElectronico, GeneraContabilidad, 
     UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb,
     IdProductoNCred, IdProductoNDeb, ConsumePedidos, 
     EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion)
VALUES 
     ('PRESUPCLIE', 'False', 'Presupuesto', 'PRESUPCLIE', 0, 
      'False', 'True', 'X', 100, 'True',
      1, 'SI', 'True', 'False', 'False', 
      'False', 'Presup.', 'True', 1, 'False',
      NULL, 'False', 99, NULL, 0, 
      '.', 'False', 0.01, 'False', 'True',
      'True', 'False', 'True', 'True', 2, 
      'PRESUPCLIE', 'False', 'False', 'False', 'False',
      'False', 'False', 'False', NULL, NULL, 
      NULL, NULL, 'False', 
      'False', '', 'False')
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',PRESUPCLIE'
 WHERE IdImpresora = 'NORMAL'
   AND IdSucursal = 1
GO


-- Ajusto la descripion del Item Presupuesto de Ventas.
-- Encontrarle un mejor nombre.

UPDATE TiposComprobantes
   SET Descripcion = 'Presupuesto (V.)'
     , DescripcionAbrev = 'Presup. V.'
 WHERE IdTipoComprobante = 'PRESUP'
GO


--5 Linea Origianl:      '''PRESUP CLIE''', 'False', 99, NULL, 0, 

--UPDATE TiposComprobantes
--  SET ComprobantesAsociados = 'NULL'
--  WHERE IdTipoComprobante = 'PRESUPCLIE'
--GO


