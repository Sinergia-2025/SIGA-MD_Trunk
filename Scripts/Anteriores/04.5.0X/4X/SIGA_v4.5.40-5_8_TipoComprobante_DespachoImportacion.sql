INSERT INTO TiposComprobantes
           (IdTipoComprobante
           ,EsFiscal
           ,Descripcion
           ,Tipo
           ,CoeficienteStock
           ,GrabaLibro
           ,EsFacturable
           ,LetrasHabilitadas
           ,CantidadMaximaItems
           ,Imprime
           ,CoeficienteValores
           ,ModificaAlFacturar
           ,EsFacturador
           ,AfectaCaja
           ,CargaPrecioActual
           ,ActualizaCtaCte
           ,DescripcionAbrev
           ,PuedeSerBorrado
           ,CantidadCopias
           ,EsRemitoTransportista
           ,ComprobantesAsociados
           ,EsComercial
           ,CantidadMaximaItemsObserv
           ,IdTipoComprobanteSecundario
           ,ImporteTope
           ,IdTipoComprobanteEpson
           ,UsaFacturacionRapida
           ,ImporteMinimo
           ,EsElectronico
           ,UsaFacturacion
           ,UtilizaImpuestos
           ,NumeracionAutomatica
           ,GeneraObservConInvocados
           ,ImportaObservDeInvocados
           ,IdPlanCuenta
           ,EsAnticipo
           ,EsRecibo
           ,Grupo
           ,EsPreElectronico
           ,GeneraContabilidad
           ,UtilizaCtaSecundariaProd
           ,UtilizaCtaSecundariaCateg
           ,IncluirEnExpensas
           ,IdTipoComprobanteNCred
           ,IdTipoComprobanteNDeb
           ,IdProductoNCred
           ,IdProductoNDeb
           ,ConsumePedidos
           ,EsPreFiscal
           ,CodigoComprobanteSifere
           ,EsDespachoImportacion)
SELECT 'DESPACHOIMP' AS IdTipoComprobante
      ,EsFiscal
      ,'Despacho Importacion' Descripcion
      ,Tipo
      ,0 CoeficienteStock
      ,GrabaLibro
      ,EsFacturable
      ,'D' AS LetrasHabilitadas
      ,CantidadMaximaItems
      ,Imprime
      ,CoeficienteValores
      ,ModificaAlFacturar
      ,EsFacturador
      ,AfectaCaja
      ,CargaPrecioActual
      ,ActualizaCtaCte
      ,'Desp. Imp.' AS DescripcionAbrev
      ,PuedeSerBorrado
      ,CantidadCopias
      ,EsRemitoTransportista
      ,ComprobantesAsociados
      ,EsComercial
      ,CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario
      ,ImporteTope
      ,IdTipoComprobanteEpson
      ,UsaFacturacionRapida
      ,ImporteMinimo
      ,EsElectronico
      ,UsaFacturacion
      ,UtilizaImpuestos
      ,NumeracionAutomatica
      ,GeneraObservConInvocados
      ,ImportaObservDeInvocados
      ,IdPlanCuenta
      ,EsAnticipo
      ,EsRecibo
      ,Grupo
      ,EsPreElectronico
      ,GeneraContabilidad
      ,UtilizaCtaSecundariaProd
      ,UtilizaCtaSecundariaCateg
      ,IncluirEnExpensas
      ,IdTipoComprobanteNCred
      ,IdTipoComprobanteNDeb
      ,IdProductoNCred
      ,IdProductoNDeb
      ,ConsumePedidos
      ,EsPreFiscal
      ,'' AS CodigoComprobanteSifere
      ,'True' AS EsDespachoImportacion
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'FACTCOM'
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',DESPACHOIMP'
 WHERE IdImpresora = 'NORMAL'
   AND IdSucursal = 1
GO
