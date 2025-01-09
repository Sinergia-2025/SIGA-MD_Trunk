
INSERT INTO TiposComprobantes
	(IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
     LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, 
     EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, 
     CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, 
     IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, 
     EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, 
     ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, 
     UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas,IdTipoComprobanteNCred, 
     IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere)
SELECT 'ORDENPRODUCCION'
      ,EsFiscal, 'Orden Producción', 'PRODUCCION', CoeficienteStock, GrabaLibro, EsFacturable, 
       LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, 
       EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte,'OrdenProd.', PuedeSerBorrado, 
       CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, 
       IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, 
       EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, 
       ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, 'PRODUCCION', EsPreElectronico, GeneraContabilidad, 
       UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, 
       IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb, 'False' AS XXConsumePedidos, 'False' AS XXEsPreFiscal, '' AS XXCodigoComprobanteSifere
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'PEDIDO'
GO

-- Lo Habilito solo si existe el Menu que Carga Ordenes (puede no tenerlo contratado)

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'OrdenesDeProduccion')
    BEGIN
		UPDATE Impresoras 
		   SET ComprobantesHabilitados = ComprobantesHabilitados + ',ORDENPRODUCCION'
		 WHERE IdImpresora = 'NORMAL'
	END;
