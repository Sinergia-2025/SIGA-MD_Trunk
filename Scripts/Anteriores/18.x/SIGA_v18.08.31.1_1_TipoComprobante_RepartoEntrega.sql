
PRINT ''
PRINT '1. TiposComprobantes: Nuevo Comprobante "Reparto Entrega".'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock
           ,GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime
           ,CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
           ,ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista
           ,ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope
           ,IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
           ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
           ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
           ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
           ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion
           ,CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion)
     VALUES
           ('REPARTO-ENTREGA', 'False', 'Reparto Entrega', 'VENTAS', 1
           ,'False', 'True', 'X', 100, 'True'
           ,-1, 'SOLOPRECIOS', 'True', 'False', 'True'
           ,'False', 'Rep.Entreg', 'False', 1, 'True'
           ,NULL, 'False', 99, NULL, 0
           ,'.', 'False', 0.01, 'False', 'False'
           ,'True', 'False', 'True', 'True', 2
           ,'False', 'False', 'VENTAS', 'False', 'False'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'False', 'False', '', 'False'
           ,'True', NULL, 'True', 'True',
           'True', 'False', 8, 1)
GO
