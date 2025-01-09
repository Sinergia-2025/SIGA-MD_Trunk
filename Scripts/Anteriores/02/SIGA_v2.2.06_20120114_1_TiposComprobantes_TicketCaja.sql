
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica)

  VALUES ('TICKET-CAJA', 'False', '  Ticket Caja', 'VENTAS', -1, 'False' , 'False'
         ,'A,B,C', 100, 'True', 1, 'NO', 'True'
         ,'True', 'True', 'True' ,'Tick. Caja' ,'False' ,1
         ,'False', NULL, 'True' ,0 ,NULL
         ,0 ,'.' , 'True', 0.01 , 'False', 'True'
         ,'True', 'False')
GO

INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica)

  VALUES ('TICKET-NC-CAJA', 'False', '  Ticket NCred. Caja', 'VENTAS', 1, 'False' , 'False'
         ,'A,B,C', 100, 'True', -1, 'NO', 'True'
         ,'True', 'True', 'True' ,'Tick.NC C.' ,'False' ,1
         ,'False', NULL, 'True' ,0 ,NULL
         ,0 ,'.' , 'True', 0.01 , 'False', 'True'
         ,'True', 'False')
GO

INSERT INTO Impresoras
     (IdSucursal, IdImpresora, TipoImpresora, CentroEmisor, ComprobantesHabilitados, 
      Puerto, Velocidad, EsProtocoloExtendido, Modelo, OrigenPapel, CantidadCopias,
      TipoFormulario, TamanioLetra, Marca, Metodo)
  VALUES
      (1, 'TICKET1', 'NORMAL', 100, 'TICKET-CAJA,TICKET-NC-CAJA', 
       0, 0, 'False', NULL, NULL, 1,
       NULL, 0, NULL, NULL)
GO

--INSERT INTO ImpresorasPCs
--      (IdSucursal, IdImpresora, NombrePC)
--   VALUES
--      (1, 'TICKET1', 'TERRA-PC'),
--      (1, 'TICKET1', 'DIHEPROPC'),
--      (1, 'TICKET1', 'DiegoRolla-PC')
--GO
