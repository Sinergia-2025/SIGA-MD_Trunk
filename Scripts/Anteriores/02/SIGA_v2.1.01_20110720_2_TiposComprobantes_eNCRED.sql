
INSERT INTO TiposComprobantes 

     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable

     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador

     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias

     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario

     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion)

  VALUES ('eNCRED', 'False', 'eNota de Credito', 'VENTAS', 1, 'True' , 'False'

         ,'A,B,C', 24, 'True', -1, NULL, 'True'

         ,'True', 'True', 'True' ,'eN.Credito' ,'False', 2

         ,'False', NULL, 'True' ,0 , NULL

         ,0 ,'.' , 'False', 0.10 , 'True', 'True')
GO
