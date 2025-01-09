
--DELETE TiposComprobantes
-- WHERE IdTipoComprobante = 'EXTRACCION'
--GO

INSERT INTO TiposComprobantes
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     ,EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
     ,CantidadCopias, ComprobantesAsociados, EsRemitoTransportista, EsComercial, CantidadMaximaItemsObserv
     ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida
     ,ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica
     ,GeneraObservConInvocados, ImportaObservDeInvocados,IdPlanCuenta, EsAnticipo, EsRecibo, Grupo
     ,EsPreElectronico, GeneraContabilidad, UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg
     ,IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb)
   VALUES
     ('EXTRACCION', 'False', 'Extracción Bancaria', 'BANCO', 0, 'False', 'False'
     ,'X', 100, 'True', 1, NULL
     ,'False', 'True', 'False', 'False', 'Extracción', 'False'
     ,1 ,NULL, 'False', 'True', 0
     ,NULL, 0.00, '.', 'False'
     ,0.01, 'False', 'True', 'True', 'False'
     ,'False', 'False', 1, 'False', 'False', 'BANCO'
     ,'False', 'True', 'False', 'False'
     ,'False', NULL, NULL, NULL, NULL)
GO


UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',DEPOSITO,EXTRACCION'
 WHERE IdImpresora = 'NORMAL'
GO


UPDATE TiposComprobantes
   SET IdPlanCuenta = 1
 WHERE IdTipoComprobante = 'DEPOSITO'
GO


SELECT DISTINCT EsFiscal, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
      ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
      ,EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, PuedeSerBorrado
      ,CantidadCopias, ComprobantesAsociados, EsRemitoTransportista, EsComercial, CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida
      ,ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica
      ,GeneraObservConInvocados, ImportaObservDeInvocados,IdPlanCuenta, EsAnticipo, EsRecibo, Grupo
      ,EsPreElectronico, GeneraContabilidad, UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg
      ,IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb
  FROM TiposComprobantes
 WHERE IdTipoComprobante IN ('DEPOSITO','EXTRACCION')
GO
