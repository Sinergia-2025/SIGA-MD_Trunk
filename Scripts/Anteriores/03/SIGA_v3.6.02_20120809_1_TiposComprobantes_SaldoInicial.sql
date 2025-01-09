
--SELECT * FROM TiposComprobantes 
--  WHERE IdTipoComprobante = 'SALDOINICIAL'
--GO

DELETE TiposComprobantes 
 WHERE IdTipoComprobante = 'SALDOINICIAL'
GO

INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados)
  VALUES ('SALDOINICIAL', 'False', 'Saldo Inicial', 'VENTAS', 0, 'False' , 'True'
         ,'X', 999, 'False', 1, NULL, 'False'
         ,'False', 'False', 'True' ,'Saldo Inic' ,'False', 1
         ,'False', NULL, 'False' ,998 , NULL
         ,0 ,'.' , 'False', -100000.00 , 'False', 'True'
         ,'True', 'False', 'True')
GO
