PRINT '1. Borro ePRE-FACT'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'ePRE-FACT'
GO
PRINT '2. Borro eFACT'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'eFACT'
GO
PRINT '3. Inserto eFACT'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('eFACT', 0, 'eFactura', 'VENTAS', -1, 1, 0, 'A,B,C,E', 24, 1, 1, NULL, 1, 1, 0, 1, 'eFactura', 0, 1, 0, NULL, 1, 23, NULL, CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 0, 1, 0, 1, 1, 1, 0, 0, 'VENTAS', 0)
GO

PRINT '4. Borro ePRE-NCRED'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'ePRE-NCRED'
GO
PRINT '5. Borro eNCRED'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'eNCRED'
GO
PRINT '6. Inserto eNCRED'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('eNCRED', 0, 'eNota de Credito', 'VENTAS', 1, 1, 0, 'A,B,C,E', 24, 1, -1, NULL, 1, 1, 0, 1, 'eN.Credito', 0, 1, 0, NULL, 1, 23, NULL, CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 0, 1, 0, 1, 1, 1, 0, 0, 'VENTAS', 0)
GO

PRINT '7. Borro ePRE-NDEB'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'ePRE-NDEB'
GO
PRINT '8. Borro eNDEB'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'eNDEB'
GO
PRINT '9. Inserto eNDEB'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('eNDEB', 0, 'eNota de Debito', 'VENTAS', -1, 1, 0, 'A,B,C,E', 24, 1, 1, NULL, 1, 1, 0, 1, 'eN.Debito', 0, 1, 0, NULL, 1, 23, NULL, CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 0, 1, 0, 1, 1, 1, 0, 0, 'VENTAS', 0)
GO


PRINT '10. Borro ePRE-NDEBCHEQR'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'ePRE-NDEBCHEQR'
GO
PRINT '11. Borro eNDEBCHEQRECH'
GO
DELETE TiposComprobantes
 WHERE IdTipoComprobante = 'eNDEBCHEQRECH'
GO
PRINT '12. Inserto eNDEBCHEQRECH'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('eNDEBCHEQRECH', 0, 'eNota de Deb.Cheq.Rech.', 'VENTAS', -1, 1, 0, 'A,B,C,E', 24, 1, 1, NULL, 1, 1, 0, 1, 'eN.Deb.ChR', 0, 1, 0, NULL, 0, 23, NULL, CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 0, 1, 0, 1, 1, 1, 0, 0, 'VENTAS', 0)
GO

------

PRINT '13. Inserto ePRE-FACT'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('ePRE-FACT', 0, ' ePre-Factura', 'VENTAS', 0, 0, 0, 'A,B,C,E', 24, 1, 1, 'SOLOPRECIOS', 1, 0, 1, 1, 'ePre-Fact.', 0, 1, 0, NULL, 0, 23, 'eFACT', CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1, 1, 0, 1, 1, 2, 0, 0, 'VENTAS', 1)
GO

PRINT '14. Inserto ePRE-NCRED'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('ePRE-NCRED', 0, ' ePre-Nota Cred.', 'VENTAS', 0, 0, 0, 'A,B,C,E', 24, 1, -1, 'SOLOPRECIOS', 1, 0, 1, 1, 'ePre-NCred', 0, 1, 0, NULL, 0, 23, 'eNCRED', CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1, 1, 0, 1, 1, 2, 0, 0, 'VENTAS', 1)
GO

PRINT '15. Inserto ePRE-NDEB'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('ePRE-NDEB', 0, ' ePre-Nota Deb.', 'VENTAS', 0, 0, 0, 'A,B,C,E', 24, 1, 1, 'SOLOPRECIOS', 1, 0, 1, 1, 'ePre-NDeb', 0, 1, 0, NULL, 0, 23, 'eNDEB', CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1, 1, 0, 1, 1, 2, 0, 0, 'VENTAS', 1)
GO

PRINT '16. Inserto ePRE-NDEBCHEQR'
GO
INSERT dbo.TiposComprobantes (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico)
 VALUES ('ePRE-NDEBCHEQR', 0, ' ePre-Nota Deb.Cheq.Rech.', 'VENTAS', 0, 0, 0, 'A,B,C,E', 24, 1, 1, 'SOLOPRECIOS', 1, 0, 1, 1, 'ePre-ND.CR', 0, 1, 0, NULL, 0, 23, 'eNDEBCHEQRECH', CAST(0.00 AS Decimal(10, 2)), '.', 0, CAST(1.00 AS Decimal(10, 2)), 1, 1, 1, 0, 1, 1, 2, 0, 0, 'VENTAS', 1)
GO

---------------

PRINT '17. Cantidad de Registros Electronicos = 8'
GO
SELECT * FROM TiposComprobantes
 WHERE EsElectronico = 'True'
GO
