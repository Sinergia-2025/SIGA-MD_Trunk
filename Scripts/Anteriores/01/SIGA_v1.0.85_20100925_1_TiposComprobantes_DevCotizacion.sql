
INSERT INTO TiposComprobantes

  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 

   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,

   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, 

   EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv)

 VALUES

   ('DEV-COTIZACION', 'False', 'Dev. de Cotizacion', 'VENTAS', 1, 'False', 'False', 

   'X', 100, 'True', -1, NULL, 'False', 

   'True', 'True', 'True', 'Dev.Cotiz.', 'False', 1, 

   'False', NULL, 'True', 0)

GO


