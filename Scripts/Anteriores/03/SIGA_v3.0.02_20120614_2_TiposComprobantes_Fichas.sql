
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados)

  VALUES ('FICHAS', 'False', 'Fichas', 'VENTAS', 0, 'False' , 'False'
         ,'X', 100, 'True', 1, 'NO', 'False'
         ,'True', 'True', 'True' ,'Ficha' ,'False' ,1
         ,'False', NULL, 'True' ,0 ,NULL
         ,0 ,'.' , 'False', 0.01 , 'False', 'True'
         ,'True', 'False', 'False')
 GO


--UPDATE Impresoras SET
--     ComprobantesHabilitados = ComprobantesHabilitados + ',FICHAS'
--  WHERE IdImpresora = 'NORMAL'
--GO
