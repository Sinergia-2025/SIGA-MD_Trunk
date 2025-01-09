
INSERT INTO TiposComprobantes

    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 

     LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,

     AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias)

 VALUES

   ('ENTREGAMERCAD', 'False', 'Entrega de Mercaderia', 'VENTAS', -1, 'False', 'True', 

    'X', 27, 'True', 1, 'SOLOPRECIOS', 'True', 

    'False', 'True', 'False', 'Entrega M.', 'False', 2)

GO
