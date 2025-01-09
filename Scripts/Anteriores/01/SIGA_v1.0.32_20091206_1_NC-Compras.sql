
INSERT INTO TiposMovimientos
  (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal,
   MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio)
VALUES
 ('COMPRA-NC','Compra NC', -1, 'NCREDCOM,REMITOCOM-NC', 'False', 'True', 'True', 'True',
  'True', 'PrecioCosto')
  
GO


INSERT INTO TiposComprobantes
  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable,
   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar,
   EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, 
   PuedeSerBorrado, CantidadCopias)
 VALUES
  ('NCREDCOM','False', 'N. Cred. Compra','COMPRAS', -1 ,'True','False', 'A,B,C', 100, 'True', -1,
  	NULL, 'False', 'True', 'True', 'True', 'NC Compra', 'False', 1)
GO


INSERT INTO TiposComprobantes
  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable,
   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar,
   EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, 
   PuedeSerBorrado, CantidadCopias)
 VALUES
  ('REMITOCOM-NC','False', 'Remito NC Compra','COMPRAS', -1 ,'False','False', 'X', 100, 'True', -1,
  	NULL, 'False', 'True', 'True', 'True', 'Rem.NC Com', 'False', 1)
GO


