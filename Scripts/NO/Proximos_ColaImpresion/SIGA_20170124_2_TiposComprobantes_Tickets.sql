INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock,GrabaLibro,EsFacturable
           ,LetrasHabilitadas,CantidadMaximaItems,Imprime,CoeficienteValores,ModificaAlFacturar
           ,EsFacturador,AfectaCaja,CargaPrecioActual,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado
           ,CantidadCopias,EsRemitoTransportista,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv
           ,IdTipoComprobanteSecundario,ImporteTope,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo
           ,EsElectronico,UsaFacturacion,NumeracionAutomatica,UtilizaImpuestos,GeneraObservConInvocados
           ,ImportaObservDeInvocados,IdPlanCuenta,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred
           ,IdTipoComprobanteNDeb,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal)

     SELECT 'PRE-' + IdTipoComprobante,0 /*EsFiscal*/,
                 REPLACE(Descripcion,'Ticket','P-Tckt'),Tipo,0 /*CoeficienteStock*/,GrabaLibro,EsFacturable
           ,LetrasHabilitadas,CantidadMaximaItems,Imprime,CoeficienteValores,ModificaAlFacturar
           ,EsFacturador,AfectaCaja,CargaPrecioActual,ActualizaCtaCte,
                 REPLACE(DescripcionAbrev,'Ticket','P-Tckt'),PuedeSerBorrado
           ,CantidadCopias,EsRemitoTransportista,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv
           ,IdTipoComprobante /*IdTipoComprobanteSecundario*/,
                 ImporteTope,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo
           ,EsElectronico,UsaFacturacion,NumeracionAutomatica,UtilizaImpuestos,GeneraObservConInvocados
           ,ImportaObservDeInvocados,IdPlanCuenta,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred
           ,IdTipoComprobanteNDeb,IdProductoNCred,IdProductoNDeb,ConsumePedidos,1 /*EsPreFiscal*/
  FROM TiposComprobantes
 WHERE EsFiscal = 1
   AND PuedeSerBorrado = 0
   AND CoeficienteValores > 0
   AND IdTipoComprobante LIKE 'T%'
