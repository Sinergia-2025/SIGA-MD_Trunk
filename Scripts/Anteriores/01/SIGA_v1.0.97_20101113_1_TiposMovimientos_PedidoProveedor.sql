/*

INSERT INTO TiposMovimientos
  (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal,
   MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio)
VALUES
  ('PEDIDOPROVEEDOR', 'Pedido a Proveedor', 0, NULL, 'False', 
   'True', 'True', 'False', 'True', 'PrecioCosto')
GO

*/


UPDATE TiposMovimientos SET
    ComprobantesAsociados = ComprobantesAsociados + ',PEDIDOPROVEEDOR'
 WHERE IdTipoMovimiento = 'VARIOS'
GO


INSERT INTO TiposComprobantes
  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,
   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, 
   EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv)
 VALUES
  ('PEDIDOPROVEEDOR', 'False', 'Pedido a Proveedor', 'COMPRAS', 0 , 'False', 'False', 
   'X', 100, 'True', 1, NULL, 'False', 
   'False', 'True', 'False', 'Ped.Prov.', 'True', 1,
   'False', NULL, 'False', 0)
GO
