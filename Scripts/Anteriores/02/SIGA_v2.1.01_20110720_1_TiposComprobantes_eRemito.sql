INSERT INTO TiposComprobantes 

     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable

     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador

     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias

     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario

     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion)

  VALUES ('eREMITO', 'False', ' eRemito', 'VENTAS', 0, 'False' , 'False'

         ,'A,B,C', 24, 'True', 1, 'SOLOPRECIOS', 'False'

         ,'False', 'True', 'True' ,'eRemito' ,'False', 2

         ,'False', NULL, 'False' ,0 , NULL

         ,0 ,'.' , 'False', 0.10 , 'True', 'True')
GO
