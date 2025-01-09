
INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
  ('REMITOCOM-ND'	,'False'	,'Remito ND Compra'	,'COMPRAS'	,1	,'False'	,'False'	
  ,'X'	,90	,'False' , 1	,NULL	,'False'	
  ,'True'	,'False'	,'True'	,'Rem.ND Com'	,'False'	,1	
  ,'False'	,NULL	,'True'	,89	,NULL	
  ,0.00	,'.'	,'False'	,0.01	,'False'	,'True'	
  ,'True'	,'True'	,'False',	'False'	,2)
GO

/* -------------- */

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',REMITOCOM-ND'
  WHERE IdImpresora = 'NORMAL'
GO


/* -------------- */

UPDATE TiposMovimientos SET
	ComprobantesAsociados = ComprobantesAsociados + ',REMITOCOM-ND'
 WHERE IdTipoMovimiento = 'COMPRA'
GO
