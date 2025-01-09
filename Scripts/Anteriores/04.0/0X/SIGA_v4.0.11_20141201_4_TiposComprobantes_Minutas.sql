
UPDATE TiposComprobantes
 SET ImporteTope = 99999999
   , ImporteMinimo = 0.01
WHERE IdTipoComprobante IN ('RECIBO', 'ANTICIPO', 'RECIBOPROV', 'ANTICIPOPROV')
GO

INSERT INTO TiposComprobantes
   ( IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
   , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
   , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado
   , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
   , IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
   , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo)
SELECT 'MINUTA' AS XXIdTipoComprobante, EsFiscal, 'Minuta' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Minuta' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , NULL AS XXIdTipoComprobanteSecundario, 0 AS XXImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, 0 AS XXImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo
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
   , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo)
SELECT 'MINUTAPROV' AS XXIdTipoComprobante, EsFiscal, 'Minuta Provisorio' AS XXDescripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     , LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar
     , EsFacturador, AfectaCaja, CargaPrecioActual, ActualizaCtaCte, 'Minuta Prv' AS XXDescripcionAbrev, PuedeSerBorrado
     , CantidadCopias, EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
     , NULL AS XXIdTipoComprobanteSecundario, 0 AS XXImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, 0 AS XXImporteMinimo
     , EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
     , ImportaObservDeInvocados, IdPlanCuenta, EsRecibo, EsAnticipo
   FROM TiposComprobantes
WHERE IdTipoComprobante = 'RECIBOPROV'
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',MINUTA,MINUTAPROV'
  WHERE IdImpresora = 'NORMAL'
GO

--Agrego un Espacio para que se acomoden Primeros.
UPDATE TiposComprobantes
  SET Descripcion = ' '+Descripcion
  WHERE IdTipoComprobante IN ('RECIBO', 'RECIBOPROV')
GO
