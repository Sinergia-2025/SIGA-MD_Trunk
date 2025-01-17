
INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta])
 VALUES ('SALDOINICIAL', 0, 'Saldo Inicial', 'VENTAS', 0, 0, 0, 'X', 999, 1, 1, NULL, 0, 1, 0, 1, 'Saldo Inic', 0, 2, 0, NULL, 0, 998, NULL, 0, '.', 0, -100000, 0, 1, 1, 0, 1, 1, 2)
GO

INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta])
 VALUES ('SALDOINICIAL-NC', 0, 'Saldo Inicial NC', 'VENTAS', 0, 0, 0, 'X', 999, 1, -1, NULL, 0, 1, 0, 1, 'Saldo I.NC', 0, 2, 0, NULL, 0, 998, NULL, 0, '.', 0, -100000, 0, 1, 1, 0, 1, 1, 2)
GO

INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta])
 VALUES ('SALDOINICOM', 0, 'Saldo Inic. Compra', 'COMPRAS', 0, 0, 0, 'X', 999, 1, 1, NULL, 0, 1, 0, 1, 'S. I.COM', 0, 2, 0, NULL, 0, 998, NULL, 0, '.', 0, -100000, 0, 1, 1, 0, 1, 1, 2)
GO

INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta])
 VALUES ('SALDOINICOM-NC', 0, 'Saldo Inic. Compra NC', 'COMPRAS', 0, 0, 0, 'X', 999, 1, -1, NULL, 0, 1, 0, 1, 'S.I.COM-NC', 0, 2, 0, NULL, 0, 998, NULL, 0, '.', 0, -100000, 0, 1, 1, 0, 1, 1, 2)
GO

UPDATE TiposComprobantes
  SET AfectaCaja='True'
 WHERE IdTipoComprobante IN ('SALDOINICIAL','SALDOINICIAL-NC','SALDOINICOM','SALDOINICOM-NC')
GO
