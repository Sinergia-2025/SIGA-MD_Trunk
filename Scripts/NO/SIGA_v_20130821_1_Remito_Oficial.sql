--DELETE TiposComprobantes
-- WHERE IdTipoComprobante = 'REMITO-R'
--GO

INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES ('REMITO-R', 'False', 'Remito Oficial', 'COMPRAS', 1, 'False' , 'True'
         ,'R', 100, 'False', 1, 'NO', 'False'
         ,'False', 'True', 'False' ,'Remito Of.' ,'False', 1
         ,'False', NULL, 'False' ,99 , NULL
         ,0 ,'.' , 'False', 0.10 , 'False', 'True'
         ,'True', 'False', 'True', 'True', 1)
GO


UPDATE TiposMovimientos SET
	ComprobantesAsociados = ComprobantesAsociados + ',REMITO-R'
 WHERE IdTipoMovimiento = 'COMPRA'
GO


UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',REMITO-R'
  WHERE IdImpresora = 'NORMAL'
GO