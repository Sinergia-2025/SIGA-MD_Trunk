
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion)
  VALUES ('ePRE-NCRED', 'False', ' ePre-Nota Cred.', 'VENTAS', 0, 'False' , 'False'
         ,'A,B,C', 24, 'True', -1, 'SOLOPRECIOS', 'True'
         ,'False', 'True', 'True' ,'ePre-NCred' ,'False', 2
         ,'False', NULL, 'False' ,0 , NULL
         ,0 ,'.' , 'False', 0.10 , 'True', 'True')
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = 'ePRE-FACT,eFACT,ePRE-NCRED,eNCRED'
  WHERE IdImpresora IN ( 'ELECTRONICA', 'ELECTRONICO')
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante
           ,IdTipoComprobante
           ,Letra)
SELECT IdAFIPTipoComprobante
      ,'ePRE-NCRED' AS TipoComprobante
      ,Letra
  FROM AFIPTiposComprobantesTiposCbtes
  WHERE IdTipoComprobante = 'eNCRED'
GO

UPDATE TiposComprobantes
   SET ImporteMinimo = 1
 WHERE EsElectronico = 'True'
GO

UPDATE TiposComprobantes
   SET UsaFacturacion = 'False'
  WHERE IdTipoComprobante = 'eNCRED'
GO
