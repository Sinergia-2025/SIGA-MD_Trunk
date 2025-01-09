
INSERT INTO TiposComprobantes
      (IdTipoComprobante ,EsFiscal ,Descripcion ,Tipo ,CoeficienteStock 
      ,GrabaLibro ,EsFacturable
      ,LetrasHabilitadas ,CantidadMaximaItems ,Imprime ,CoeficienteValores ,ModificaAlFacturar
      ,EsFacturador ,AfectaCaja ,CargaPrecioActual ,ActualizaCtaCte ,DescripcionAbrev ,PuedeSerBorrado
      ,CantidadCopias ,EsRemitoTransportista ,ComprobantesAsociados ,EsComercial ,CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario ,ImporteTope ,IdTipoComprobanteEpson ,UsaFacturacionRapida
      ,ImporteMinimo ,EsElectronico ,UsaFacturacion ,UtilizaImpuestos ,NumeracionAutomatica
      ,GeneraObservConInvocados ,ImportaObservDeInvocados ,IdPlanCuenta)
SELECT 'SALARIO' AS xIdTipoComprobante ,EsFiscal ,'Salario' AS xDescripcion ,Tipo ,CoeficienteStock 
      ,(CASE WHEN GrabaLibro = 'True' THEN 'False' ELSE 'True' END) AS xGrabaLibro ,EsFacturable
      ,LetrasHabilitadas ,CantidadMaximaItems ,Imprime ,CoeficienteValores ,ModificaAlFacturar
      ,EsFacturador ,AfectaCaja ,CargaPrecioActual ,ActualizaCtaCte ,'Salario' AS xDescripcionAbrev ,PuedeSerBorrado
      ,CantidadCopias ,EsRemitoTransportista ,ComprobantesAsociados ,EsComercial ,CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario ,ImporteTope ,IdTipoComprobanteEpson ,UsaFacturacionRapida
      ,ImporteMinimo ,EsElectronico ,UsaFacturacion ,UtilizaImpuestos ,NumeracionAutomatica
      ,GeneraObservConInvocados ,ImportaObservDeInvocados , (CASE WHEN IdPlanCuenta = 1 THEN 2 ELSE 1 END) AS xIdPlanCuenta
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'SUELDO'
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',SALARIO'
  WHERE IdImpresora = 'NORMAL'
GO
