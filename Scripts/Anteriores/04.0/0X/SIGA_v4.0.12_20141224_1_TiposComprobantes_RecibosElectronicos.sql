
INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo)
SELECT 'RECIBOe' AS XXIdTipoComprobante, EsFiscal, ' Recibo Electronico' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Rec.Elect.' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , NULL AS XXIdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'RECIBO'
GO

INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo)
SELECT 'ANTICIPOe' AS XXIdTipoComprobante, EsFiscal, 'Anticipo Electronico' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Ant.Elect.' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , NULL AS XXIdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'ANTICIPO'
GO

INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo)
SELECT 'RECIBOPROVe' AS XXIdTipoComprobante, EsFiscal, ' Recibo Prov. Electronico' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Rec.Elec.P' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , NULL AS XXIdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'RECIBOPROV'
GO

INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo)
SELECT 'ANTICIPOPROVe' AS XXIdTipoComprobante, EsFiscal, 'Anticipo Prov. Electron.' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Ant.Elec.P' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , NULL AS XXIdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'ANTICIPOPROV'
GO

-- Asocio los Comprobantes Secundarios entre SI.


UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'RECIBOe'
 WHERE IdTipoComprobante = 'ANTICIPOe'
GO
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'ANTICIPOe'
 WHERE IdTipoComprobante = 'RECIBOe'
GO

UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'RECIBOPROVe'
 WHERE IdTipoComprobante = 'ANTICIPOPROVe'
GO
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'ANTICIPOPROVe'
 WHERE IdTipoComprobante = 'RECIBOPROVe'
GO


-- Habilito los comprobantes en la Impresora Principal.
UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',RECIBOe,ANTICIPOe,RECIBOPROVe,ANTICIPOPROVe'
  WHERE IdImpresora = 'NORMAL'
GO

-- Vinculo  (CHR 39 es la comilla simple que no la puedo asignar manualmente)

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'ANTICIPOe' + CHAR(39)
 WHERE IdTipoComprobante IN ('RECIBO','RECIBOe','MINUTA')
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'ANTICIPOPROVe' + CHAR(39)
 WHERE IdTipoComprobante IN ('RECIBOPROV','RECIBOPROVe','MINUTAPROV')
GO
