
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)

  VALUES ('PEDIDO', 'False', 'Pedido', 'VENTAS', 0, 'False' , 'True'
         ,'X', 100, 'False', 1, 'SI', 'False'
         ,'False', 'False', 'False' ,'Pedido' ,'True', 1
         ,'False', NULL, 'False' ,99 , NULL
         ,0 ,'.' , 'False', 0.01 , 'False', 'False'
         ,'True', 'False', 'True', 'True', 1)
GO
