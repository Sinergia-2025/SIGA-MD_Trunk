
PRINT '1. Creo el TiposComprobantes "TICKET-CAJA".'
 
INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
         ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta 
         ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
         ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
         ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere
         ,EsDespachoImportacion, CargaDescRecActual
         ,AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, InvocarPedidosConEstadoEspecifico)
         
  VALUES ('TICKET-CAJA', 'False', 'Ticket Caja', 'VENTAS', -1, 'False' , 'False'
         ,'A,B,C', 1000, 'True', 1, 'NO', 'True'
         ,'True', 'True', 'True' ,'Tick. Caja' ,'True' ,1
         ,'False', NULL, 'True' ,999 ,NULL
         ,0 ,'.' , 'True', 0.01 , 'False', 'True'
        ,'True', 'False', 'True', 'True', 2
        ,'False', 'False', 'VENTAS', 'False', 'True'
        ,'False', 'False', 'False', NULL, NULL
        ,NULL, NULL, 'True', 'False', ''
        ,'False', 'False'
        ,'True', 'True', 'True')
GO


PRINT ''
PRINT '2. Creo el TiposComprobantes "TICKET-NC-CAJA".'

INSERT INTO TiposComprobantes 
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
         ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta 
         ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
         ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
         ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere
         ,EsDespachoImportacion, CargaDescRecActual
         ,AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, InvocarPedidosConEstadoEspecifico)

  VALUES ('TICKET-NC-CAJA', 'False', 'Ticket NCred. Caja', 'VENTAS', 1, 'False' , 'False'
         ,'A,B,C', 1000, 'True', -1, 'NO', 'True'
         ,'True', 'True', 'True' ,'Tick. C.NC' ,'True' ,1
         ,'False', NULL, 'True' ,999 ,NULL
         ,0 ,'.' , 'True', 0.01 , 'False', 'True'
        ,'True', 'False', 'True', 'True', 2
        ,'False', 'False', 'VENTAS', 'False', 'True'
        ,'False', 'False', 'False', NULL, NULL
        ,NULL, NULL, 'False', 'False', ''
        ,'False', 'False'
        ,'True', 'True', 'True')
GO


-- Sñl

PRINT ''
PRINT '3. Ajusto Seteos si es SÑL.'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('30711217785'))
BEGIN

    UPDATE TiposComprobantes
       SET AlInvocarPedidoAfectaFactura = 'True'
          ,AlInvocarPedidoAfectaRemito = 'False'
          ,InvocarPedidosConEstadoEspecifico = 'False'
     WHERE IdTipoComprobante IN ('TICKET-CAJA','TICKET-NC-CAJA');
END;

--INSERT INTO Impresoras
--     (IdSucursal, IdImpresora, TipoImpresora, CentroEmisor, ComprobantesHabilitados, 
--      Puerto, Velocidad, EsProtocoloExtendido, Modelo, OrigenPapel, CantidadCopias,
--      TipoFormulario, TamanioLetra, Marca, Metodo)
--  VALUES
--      (1, 'TICKET1', 'NORMAL', 101, 'TICKET-CAJA,TICKET-NC-CAJA', 
--       0, 0, 'False', NULL, NULL, 1,
--       NULL, 0, NULL, NULL)
--GO

-- Asignacion a la Normal
--UPDATE Impresoras 
--   SET ComprobantesHabilitados = ComprobantesHabilitados + ',TICKET-CAJA,TICKET-NC-CAJA'
-- WHERE IdImpresora = 'NORMAL'
--   AND IdSucursal = 1
--GO

-- Crear una especifica.
--INSERT INTO ImpresorasPCs
--      (IdSucursal, IdImpresora, NombrePC)
--   VALUES
--      (1, 'TICKET1', 'TERRA-PC'),
--      (1, 'TICKET1', 'DIHEPROPC'),
--GO

--PRINT ''
--PRINT '4. Comparo con otros comprobantes por las dudas.'

--SELECT * FROM TiposComprobantes
-- WHERE IdTipoComprobante IN ('COTIZACION','TICKET-CAJA','TICKET-NOFISCAL');
 
-- SELECT * FROM TiposComprobantes
-- WHERE IdTipoComprobante IN ('DEV-COTIZACION','TICKET-NC-CAJA');
 