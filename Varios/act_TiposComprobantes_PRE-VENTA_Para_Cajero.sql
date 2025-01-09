INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock,GrabaLibro,EsFacturable
           ,LetrasHabilitadas,CantidadMaximaItems,Imprime,CoeficienteValores,ModificaAlFacturar
           ,EsFacturador,AfectaCaja,CargaPrecioActual,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado
           ,CantidadCopias,EsRemitoTransportista,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv
           ,IdTipoComprobanteSecundario,ImporteTope,IdTipoComprobanteEpson,UsaFacturacionRapida
           ,ImporteMinimo,EsElectronico,UsaFacturacion,UtilizaImpuestos,NumeracionAutomatica
           ,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta,EsAnticipo,EsRecibo,Grupo
           ,EsPreElectronico,GeneraContabilidad,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg
           ,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb,IdProductoNCred,IdProductoNDeb
           ,ConsumePedidos,EsPreFiscal)
SELECT 'PRE-VENTA',EsFiscal,'Pre Venta',Tipo,CoeficienteStock,GrabaLibro,EsFacturable
      ,LetrasHabilitadas,CantidadMaximaItems,Imprime,CoeficienteValores,ModificaAlFacturar
      ,EsFacturador,AfectaCaja,CargaPrecioActual,ActualizaCtaCte,'Pre Venta',PuedeSerBorrado
      ,CantidadCopias,EsRemitoTransportista,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv
      ,IdTipoComprobanteSecundario,ImporteTope,IdTipoComprobanteEpson,UsaFacturacionRapida
      ,ImporteMinimo,EsElectronico,UsaFacturacion,UtilizaImpuestos,NumeracionAutomatica
      ,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta,EsAnticipo,EsRecibo,Grupo
      ,EsPreElectronico,GeneraContabilidad,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg
      ,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb,IdProductoNCred,IdProductoNDeb
      ,ConsumePedidos,EsPreFiscal
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'PRESUP'
;
UPDATE Parametros
   SET ValorParametro = 'PRE-VENTA'
 WHERE IdParametro = 'FACTURACIONTIPOCOMPROBANTEENVIADOCAJERO'
;
