
INSERT INTO TiposComprobantes

    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 

     LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,

     AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias)

 VALUES

   ('PRESUP', 'False', 'Presupuesto', 'VENTAS', 0, 'False', 'True', 

    'A,B,C', 100, 'True', 1, 'SI', 'False', 

    'False', 'False', 'False', 'Presup.', 'True', 1)

GO

