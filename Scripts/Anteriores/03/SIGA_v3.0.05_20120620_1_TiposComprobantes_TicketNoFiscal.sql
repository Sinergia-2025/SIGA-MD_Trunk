DELETE TiposComprobantes 
 WHERE IdTipoComprobante = 'TICKET-NOFISCAL'
GO


INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados)

  VALUES ('TICKET-NOFISCAL', 'True', 'Ticket NO Fiscal', 'VENTAS', -1, 'False' , 'False'
         ,'A,B,C', 100, 'True', 1, 'NO', 'True'
         ,'True', 'True', 'True' ,'Tick.NO F.' ,'True' ,1
         ,'False', NULL, 'True' ,99 ,NULL
         ,0 ,'.' , 'True', 0.01 , 'False', 'True'
         ,'True', 'False', 'True')
GO

/* NO LO CARGO AUTOMATICO, DEBERIA IR EN LA IMPRESORA DE CADA FISCAL (SI HAY) */
 
--INSERT INTO Impresoras
--     (IdSucursal, IdImpresora, TipoImpresora, CentroEmisor, ComprobantesHabilitados, 
--      Puerto, Velocidad, EsProtocoloExtendido, Modelo, OrigenPapel, CantidadCopias,
--      TipoFormulario, TamanioLetra, Marca, Metodo)
--  VALUES
--      (1, 'TICKET-NO-F', 'NORMAL', 100, 'TICKET-NO-FISCAL', 
--       0, 0, 'False', NULL, NULL, 1,
--       NULL, 0, NULL, NULL)
--GO

--INSERT INTO ImpresorasPCs
--      (IdSucursal, IdImpresora, NombrePC)
--   VALUES
--      (1, 'TICKET-NO-F', 'TERRA-PC'),
--      (1, 'TICKET-NO-F', 'DIHEPROPC'),
--      (1, 'TICKET-NO-F', 'DiegoRolla-PC')
--GO
