
INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad)
  VALUES
    ('NDEBCHEQRECHCOM', 'False', 'N.Deb.Ch.Rech. Compra', 'COMPRAS', 0, 'True', 'False'
    ,'A,B,C,E', 100, 'False', 1, NULL, 'False'
    ,'True', 'False', 'True', 'NDebChReCo', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'True', 'True', 'False', 'False'
    ,'False', 1, 'False', 'False', 'COMPRAS', 'False', 'True')
GO

UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',NDEBCHEQRECHCOM'
  WHERE IdTipoMovimiento = 'VARIOS'
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',NDEBCHEQRECHCOM'
 WHERE IdImpresora = 'NORMAL'
GO
