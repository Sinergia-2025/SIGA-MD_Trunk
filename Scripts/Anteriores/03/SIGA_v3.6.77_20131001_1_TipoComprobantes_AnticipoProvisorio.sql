
UPDATE TiposComprobantes 
   SET GrabaLibro = 'True'
      ,LetrasHabilitadas = 'R'
      ,IdPlanCuenta = 1
 WHERE IdTipoComprobante = 'ANTICIPO'
GO

INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
     ('ANTICIPOPROV', 'False', 'Anticipo Provisorio', 'CTACTE',	0, 'False', 'False'
     , 'X',	100, 'False', -1, NULL, 'False'
     , 'True', 'False', 'True', 'Antic.Prov', 'False', 1
     , 'False', NULL, 'True', 0, NULL
     , 0.00, '.', 'False', 0.01, 'False', 'False'
     , 'True', 'True', 'False', 'False', 2) 
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',ANTICIPOPROV'
  WHERE IdImpresora = 'NORMAL'
GO
