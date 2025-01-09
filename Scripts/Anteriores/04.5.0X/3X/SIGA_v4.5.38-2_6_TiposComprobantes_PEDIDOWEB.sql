
INSERT INTO TiposComprobantes
	(IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
     LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, 
     EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, 
     CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, 
     IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, 
     EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, 
     ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, 
     UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas,IdTipoComprobanteNCred, 
     IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb,ConsumePedidos,EsPreFiscal)
SELECT IdTipoComprobante + 'WEB'
      ,EsFiscal, Descripcion + ' Web', Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
       LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, 
       EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev + ' Web', PuedeSerBorrado, 
       CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, 
       IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, 
       EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, 
       ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, 
       UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, 
       IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb,'False', 'False'
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'PEDIDO'
GO

UPDATE TiposComprobantes
   SET UsaFacturacion = (CASE WHEN IdTipoComprobante = 'PEDIDO' THEN 'True' ELSE 'False' END)
 WHERE Tipo = 'PEDIDOSCLIE'
GO

SELECT IdTipoComprobante, Descripcion, UsaFacturacion 
  FROM TiposComprobantes 
 WHERE Tipo = 'PEDIDOSCLIE'
GO
