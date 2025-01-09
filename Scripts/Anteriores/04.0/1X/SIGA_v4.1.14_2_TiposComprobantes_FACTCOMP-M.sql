
INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo, EsPreElectronico)
SELECT 'FACTCOM-M' AS XXIdTipoComprobante, EsFiscal, 'Factura Compra "M"' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , 'M' AS XXLetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Fact.Cmp.M' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo, EsPreElectronico
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'FACTCOM'
GO

INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo, EsPreElectronico)
SELECT 'NCREDCOM-M' AS XXIdTipoComprobante, EsFiscal, 'N. Cred. Compra "M"' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , 'M' AS XXLetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'NC Comp.M' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo, EsPreElectronico
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'NCREDCOM'
GO

INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo, EsPreElectronico)
SELECT 'NDEBCOM-M' AS XXIdTipoComprobante, EsFiscal, 'N. Deb. Compra "M"' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , 'M' AS XXLetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'ND Comp.M' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo, Grupo, EsPreElectronico
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'NDEBCOM'
GO

-- Comprobantes de VENTAS
INSERT INTO AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
  VALUES (51, 'FACTCOM-M', 'M')
GO
INSERT INTO AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
  VALUES (52, 'NDEBCOM-M', 'M')
GO
INSERT INTO AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
  VALUES (53, 'NCREDCOM-M', 'M')
GO

UPDATE TiposMovimientos SET
     ComprobantesAsociados = ComprobantesAsociados + ',FACTCOM-M,NDEBCOM-M'
  WHERE IdTipoMovimiento = 'COMPRA'
GO
UPDATE TiposMovimientos SET
     ComprobantesAsociados = ComprobantesAsociados + ',NCREDCOM-M'
  WHERE IdTipoMovimiento = 'COMPRA-NC'
GO
 
 
-- NO Habilito los comprobantes para hacerlo Manualmente solo donde los usan.
--UPDATE Impresoras SET
--     ComprobantesHabilitados = ComprobantesHabilitados + ',FACTCOM-M,NDEBCOM-M,NCREDCOM-M'
--  WHERE IdImpresora = 'NORMAL'
--GO
