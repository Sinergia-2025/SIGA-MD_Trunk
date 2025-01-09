
--Crear Tipo de comprobante

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
     ('TRANSFERENCIA', 'False', 'Trans. Bancaria', 'BANCO', 0, 'False', 'False'
     ,'X', 100, 'True', 1, NULL
     ,'False', 'True', 'False', 'False', 'Trans.Banc', 'False'
     ,1 ,NULL, 'False', 'True', 0
     ,NULL, 0.00, '.', 'False'
     ,0.01, 'False', 'True', 'True', 'False'
     ,'False', 'False', 1, 'False', 'False', 'BANCO'
     ,'False', 'True', 'False', 'False'
     ,'False', NULL, NULL, NULL, NULL)
GO


UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',TRANSFERENCIA'
 WHERE IdImpresora = 'NORMAL'
GO

-- Para Comparar los datos Principales
SELECT IdTipoComprobante, Descripcion, CoeficienteValores
      ,AfectaCaja, IdPlanCuenta, GeneraContabilidad, Grupo
  FROM TiposComprobantes
 WHERE Tipo = 'BANCO'
GO
