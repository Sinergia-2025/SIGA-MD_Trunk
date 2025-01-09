
PRINT ''
PRINT '1. PlantillasCampos: Actualizo la Plantilla base que tiene un salto en la numeracion por contemplar Nombre Producto 2 (pero no lo usa).'
GO

UPDATE PlantillasCampos
   SET OrdenColumna = IdCampo - 1
 WHERE IdPlantilla = 1
  AND OrdenColumna >= 4
GO


PRINT ''
PRINT '2. TiposComprobantes: Creo el comprobante eFactura Web.'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock
           ,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual
           ,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion
           ,UtilizaImpuestos,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta
           ,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb
           ,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal,CodigoComprobanteSifere,EsDespachoImportacion
           ,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura,AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico)
     VALUES
           ('eFACT-Web', 'False', 'eFactura Web', 'VENTAS', -1
           ,'True', 'False', 'A,B,C,E', 100, 'False'
           ,1, NULL, 'True', 'True', 'False'
           ,'True', 'eFact.Web', 'False', 1, 'False'
           ,NULL, 'True', 23, NULL, 0
           ,'.', 'False', 1, 'False', 'True'
           ,'True', 'False', 'True', 'True', 1
           ,'False', 'False', 'VENTAS', 'False', 'True'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'True', 'False', '', 'False'
           ,'False', NULL, 'True', 'True',
           'True'
           )
GO


PRINT ''
PRINT '3. TiposComprobantes: Creo el comprobante eNota de Credito Web.'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock
           ,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual
           ,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion
           ,UtilizaImpuestos,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta
           ,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb
           ,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal,CodigoComprobanteSifere,EsDespachoImportacion
           ,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura,AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico)
     VALUES
           ('eNCRED-Web', 'False', 'eNota de Cred. Web', 'VENTAS', 1
           ,'True', 'False', 'A,B,C,E', 100, 'False'
           ,-1, NULL, 'True', 'True', 'False'
           ,'True', 'eNCred.Web', 'False', 1, 'False'
           ,NULL, 'True', 23, NULL, 0
           ,'.', 'False', 1, 'False', 'True'
           ,'True', 'False', 'True', 'True', 1
           ,'False', 'False', 'VENTAS', 'False', 'True'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'False', 'False', '', 'False'
           ,'False', NULL, 'True', 'True',
           'True'
           )
GO


PRINT ''
PRINT '4. TiposComprobantes: Creo el comprobante eNota de Debito Web.'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock
           ,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual
           ,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion
           ,UtilizaImpuestos,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta
           ,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb
           ,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal,CodigoComprobanteSifere,EsDespachoImportacion
           ,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura,AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico)
     VALUES
           ('eNDEB-Web', 'False', 'eNota de Deb. Web', 'VENTAS', -1
           ,'True', 'False', 'A,B,C,E', 100, 'False'
           ,1, NULL, 'True', 'True', 'False'
           ,'True', 'eNDeb.Web', 'False', 1, 'False'
           ,NULL, 'True', 23, NULL, 0
           ,'.', 'False', 1, 'False', 'True'
           ,'True', 'False', 'True', 'True', 1
           ,'False', 'False', 'VENTAS', 'False', 'True'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'True', 'False', '', 'False'
           ,'False', NULL, 'True', 'True',
           'True'
           )
GO


PRINT ''
PRINT '5. Impresoras: Creo la Impresora WEB y asocios los comprobantes.'
GO

INSERT INTO Impresoras
           (IdSucursal, IdImpresora, TipoImpresora, CentroEmisor, ComprobantesHabilitados
           ,Puerto, Velocidad, EsProtocoloExtendido, Modelo, OrigenPapel, CantidadCopias, TipoFormulario
           ,TamanioLetra, Marca, Metodo, AbrirCajonDinero, GrabarLOGs, ImprimirLineaALinea, CierreFiscalEstandar
           ,PorCtaOrden, DireccionCentroEmisor, IdLocalidadCentroEmisor)
     VALUES
           (1, 'WEB', 'NORMAL', 5555, 'eFACT-Web,eNCRED-Web,eNDEB-Web'
			,0, 0, 'False', NULL, NULL, 0, NULL	
			,0, NULL, NULL, 'False', 'False', 'False', 'False'
           ,'False', NULL, NULL)
GO
