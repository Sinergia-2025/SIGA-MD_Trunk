
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica)

  VALUES ('ePRE-NDEB', 'False', ' ePre-Nota Deb.', 'VENTAS', 0, 'False' , 'False'
         ,'A,B,C', 24, 'True', 1, 'SOLOPRECIOS', 'True'
         ,'False', 'True', 'True' ,'ePre-NDeb' ,'False', 2
         ,'False', NULL, 'False' ,0 , NULL
         ,0 ,'.' , 'False', 1 , 'True', 'True'
         ,'True', 'False')
GO


INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica)

  VALUES ('eNDEB', 'False', 'eNota de Debito', 'VENTAS', -1, 'True' , 'False'
         ,'A,B,C', 24, 'True', 1, NULL, 'True'
         ,'True', 'True', 'True' ,'eN.Debito' ,'False' ,2
         ,'False', NULL, 'True' ,0 ,NULL
         ,0 ,'.' , 'False', 1 , 'True', 'False'
         ,'True', 'False')
GO


UPDATE Impresoras SET
     ComprobantesHabilitados = 'ePRE-FACT,eFACT,ePRE-NCRED,eNCRED,ePRE-NDEB,eNDEB'
  WHERE IdImpresora IN ('ELECTRONICA', 'ELECTRONICO')
GO


INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (2, 'ePRE-NDEB', 'A')
GO
	
INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (2, 'eNDEB', 'A')
GO
	
INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (7, 'ePRE-NDEB', 'B')
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (7, 'eNDEB', 'B')
GO
