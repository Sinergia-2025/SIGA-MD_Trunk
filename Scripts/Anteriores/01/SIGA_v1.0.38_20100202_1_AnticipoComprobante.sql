INSERT INTO TiposComprobantes
           (IdTipoComprobante
           ,EsFiscal
           ,Descripcion
           ,Tipo
           ,CoeficienteStock
           ,GrabaLibro
           ,EsFacturable
           ,LetrasHabilitadas
           ,CantidadMaximaItems
           ,Imprime
           ,CoeficienteValores
           ,ModificaAlFacturar
           ,EsFacturador
           ,AfectaCaja
           ,CargaPrecioActual
           ,ActualizaCtaCte
           ,DescripcionAbrev
           ,PuedeSerBorrado
           ,CantidadCopias)
     VALUES
           ('ANTICIPO', 'False', 'Anticipo', 'CTACTE', 0, 'False', 'False', NULL, 100, 'False',
           -1, NULL, 'False', 'True', 'False', 'True', 'Anticipo', 'False', 1)
