
UPDATE TiposComprobantes 
   SET GrabaLibro = 'True'
      ,LetrasHabilitadas = 'R'
      ,IdPlanCuenta = 1   
 WHERE IdTipoComprobante = 'RECIBO'
GO

INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
     ('RECIBOPROV', 'False', 'Recibo Provisorio', 'CTACTECLIE',	0, 'False', 'False'
     , 'X',	100, 'True', -1, NULL, 'False'
     , 'True', 'False', 'True', 'ReciboProv', 'False', 1
     , 'False', NULL, 'True', 0, NULL
     , 0.00, '.', 'False', 0.01, 'False', 'False'
     , 'True', 'True', 'False', 'False', 2) 
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',RECIBOPROV'
  WHERE IdImpresora = 'NORMAL'
GO
