DELETE TiposComprobantes 
 WHERE IdTipoComprobante = 'NDEB-COTIZACION'
GO


INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica)

  VALUES ('NDEB-COTIZACION', 'False', 'NDeb. Cotizacion', 'VENTAS', -1, 'False' , 'False'
         ,'X', 50, 'True', 1, NULL, 'True'
         ,'True', 'True', 'True' ,'NDeb.Cotiz' ,'False' ,1
         ,'False', NULL, 'True' ,0 ,NULL
         ,0 ,'.' , 'False', 0.01 , 'False', 'True'
         ,'True', 'False')
GO


UPDATE TiposComprobantes
   SET UsaFacturacionRapida = 'False'
      ,EsFacturador = 'True'
 WHERE IdTipoComprobante IN ('DEV-COTIZACION', 'NCRED', 'NCRED-F', 'NDEB', 'NDEB-F')
GO


UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',NDEB-COTIZACION'
  WHERE IdImpresora IN ('NORMAL')
GO
