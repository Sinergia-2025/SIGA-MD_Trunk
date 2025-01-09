
INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
    ,UtilizaCtaSecundariaProd)
  VALUES
    ('RES-BANCARIO', 'False', 'Resumen Bancario', 'COMPRAS', 0, 'True', 'False'
    ,'X', 100, 'False', 1, NULL, 'False'
    ,'False', 'False', 'False', 'Rs.Bancar.', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'True', 'False', 'True', 'False'
    ,'False', 1, 'False', 'False', 'COMPRAS', 'False', 'True'
    ,'False')
GO

UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',RES-BANCARIO'
  WHERE IdTipoMovimiento = 'VARIOS'
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',RES-BANCARIO'
 WHERE IdImpresora = 'NORMAL'
GO
