
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
    ('RECLASIFICACION', 'False', 'Reclasificacion', 'COMPRAS', 0, 'True', 'False'
    ,'X', 100, 'False', 1, NULL, 'False'
    ,'False', 'False', 'False', 'Reclasif.', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'True', 'False', 'True', 'False'
    ,'False', 1, 'False', 'False', 'COMPRAS', 'False', 'True'
    ,1)
GO

UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',RECLASIFICACION'
  WHERE IdTipoMovimiento = 'VARIOS'
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',RECLASIFICACION'
 WHERE IdImpresora = 'NORMAL'
GO
