
INSERT INTO TiposComprobantes

  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 

   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,

   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, 

   EsRemitoTransportista, ComprobantesAsociados, EsComercial)

 VALUES

   ('REMITO', 'False', 'Remito', 'VENTAS', -1, 'False', 'True', 

   'X', 100, 'True', 1, 'SOLOPRECIOS', 'False', 

   'False', 'True', 'False', 'Remito', 'False', 1, 

   'False', NULL, 'False')

GO
