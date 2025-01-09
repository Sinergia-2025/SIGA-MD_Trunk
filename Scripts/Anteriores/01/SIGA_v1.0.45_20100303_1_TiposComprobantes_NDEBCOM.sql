
INSERT INTO TiposComprobantes

  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable,

   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, 
   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias)

 VALUES

  ('NDEBCOM','False', 'N. Deb. Compra','COMPRAS', 1 ,'True','False', 

   'A,B,C', 100, 'True', 1, NULL, 'False', 

   'True', 'True', 'True', 'NDeb Comp.', 'False', 1)

GO


UPDATE TiposMovimientos SET
	ComprobantesAsociados = 'FACTCOM,REMITOCOM,NDEBCOM'
 WHERE IdTipoMovimiento = 'COMPRA'
GO


