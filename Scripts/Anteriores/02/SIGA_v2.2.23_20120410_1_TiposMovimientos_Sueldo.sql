
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados)

  VALUES ('SUELDO', 'False', 'Sueldo', 'COMPRAS', 0, 'False' , 'False'
         ,'X', 100, 'False', 1, 'NO', 'False'
         ,'True', 'True', 'True' ,'Sueldo' ,'False' ,1
         ,'False', NULL, 'False' ,0 ,NULL
         ,0 ,'.' , 'False', 0.01 , 'False', 'False'
         ,'False', 'False', 'False')
GO


INSERT INTO TiposMovimientos
  (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal,
   MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio)
VALUES
 ('SUELDO','Sueldo', 0, 'SUELDO', 'False',
  'False', 'True', 'True', 'False', 'NO')
GO


UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',SUELDO'
  WHERE IdImpresora = 'NORMAL'
GO
