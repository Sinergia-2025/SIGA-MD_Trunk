
INSERT INTO TiposComprobantes

  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 

   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,

   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, 

   EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv)

 VALUES

   ('COTIZCHEQRECH', 'False', 'Cotiz. Cheq. Rech.', 'VENTAS', -1, 'True', 'False', 

   'X', 100, 'True', 1, NULL, 'False', 

   'True', 'True', 'True', 'Cotz.ChRec', 'False', 1, 

   'False', NULL, 'False', 0)

GO

