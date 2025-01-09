
DELETE TiposComprobantes 
 WHERE IdTipoComprobante = 'DEV-REMITO'
GO

INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados)
  VALUES ('DEV-REMITO', 'False', 'Dev. de Remito', 'VENTAS', 1, 'False' , 'True'
         ,'X', 100, 'True', -1, 'SOLOPRECIOS', 'False'
         ,'False', 'True', 'False' ,'Dev.Remito' ,'False', 1
         ,'False', NULL, 'False' ,99 , NULL
         ,0 ,'.' , 'False', 0.01 , 'False', 'True'
         ,'True', 'False', 'True')
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',DEV-REMITO'
  WHERE IdImpresora IN ('NORMAL')
GO
