
INSERT INTO TiposMovimientos
  (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal,
   MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio)
VALUES
  ('VARIOS', 'Varios', 0, 'GASTO', 'False', 
   'True', 'True', 'True', 'True', 'PrecioCosto')
GO


INSERT INTO TiposComprobantes
  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,
   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, 
   EsRemitoTransportista, ComprobantesAsociados, EsComercial)
 VALUES
  ('GASTO', 'False', 'Gasto', 'COMPRAS', 0 , 'True', 'False', 
   'A,B,C', 100, 'True', 1, NULL, 'False', 
   'False', 'True', 'False', 'Gasto', 'False', 1,
   'False', NULL, 'False')
GO


UPDATE TiposMovimientos SET
	ComprobantesAsociados = 'GASTO'
 WHERE IdTipoMovimiento = 'VARIOS'
GO


