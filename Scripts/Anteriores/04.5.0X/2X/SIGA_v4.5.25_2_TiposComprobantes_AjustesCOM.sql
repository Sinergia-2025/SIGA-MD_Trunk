
INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad)
  VALUES
    ('AJUSTECOM+', 'False', 'Ajuste Compra (+)', 'COMPRAS', 0, 'True', 'False'
    ,'X', 100, 'False', 1, NULL, 'False'
    ,'True', 'False', 'True', 'Aj.Comp. +', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 1, 'False', 'False', 'COMPRAS', 'False', 'True')
GO

INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad)
  VALUES
    ('AJUSTECOM-', 'False', 'Ajuste Compra (-)', 'COMPRAS', 0, 'True', 'False'
    ,'X', 100, 'False', -1, NULL, 'False'
    ,'True', 'False', 'True', 'Aj.Comp. -', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 1, 'False', 'False', 'COMPRAS', 'False', 'True')
GO

INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad)
  VALUES
    ('AJUSTECOM2+', 'False', 'Ajuste Compra 2 (+)', 'COMPRAS', 0, 'True', 'False'
    ,'X', 100, 'False', 1, NULL, 'False'
    ,'True', 'False', 'True', 'Aj.Comp.2+', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 2, 'False', 'False', 'COMPRAS', 'False', 'True')
GO

INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad)
  VALUES
    ('AJUSTECOM2-', 'False', 'Ajuste Compra 2 (-)', 'COMPRAS', 0, 'True', 'False'
    ,'X', 100, 'False', -1, NULL, 'False'
    ,'True', 'False', 'True', 'Aj.Comp.2-', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 2, 'False', 'False', 'COMPRAS', 'False', 'True')
GO

-- No hace falta porque no van hacerse desde compra. Son directo en CtaCte.
--UPDATE TiposMovimientos
--   SET ComprobantesAsociados = ComprobantesAsociados + ',AJUSTECOM+,AJUSTECOM-,AJUSTECOM2+,AJUSTECOM2-'
--  WHERE IdTipoMovimiento = 'VARIOS'
--GO


UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',AJUSTECOM+,AJUSTECOM-,AJUSTECOM2+,AJUSTECOM2-'
 WHERE IdImpresora = 'NORMAL'
GO
