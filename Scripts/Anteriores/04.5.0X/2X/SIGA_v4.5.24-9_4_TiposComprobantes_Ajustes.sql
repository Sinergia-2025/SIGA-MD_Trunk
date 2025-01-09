
INSERT INTO TiposComprobantes
    (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
    ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
    ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
    ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv
    ,IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo
    ,EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados
    ,ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad)
  VALUES
    ('AJUSTE+', 'False', 'Ajuste (+)', 'VENTAS', 0, 'True', 'False'
    ,'X', 100, 'False', 1, NULL, 'False'
    ,'True', 'False', 'True', 'Ajuste +', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 1, 'False', 'False', 'VENTAS', 'False', 'True')
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
    ('AJUSTE-', 'False', 'Ajuste (-)', 'VENTAS', 0, 'True', 'False'
    ,'X', 100, 'False', -1, NULL, 'False'
    ,'True', 'False', 'True', 'Ajuste -', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 1, 'False', 'False', 'VENTAS', 'False', 'True')
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
    ('AJUSTE2+', 'False', 'Ajuste 2 (+)', 'VENTAS', 0, 'True', 'False'
    ,'X', 100, 'False', 1, NULL, 'False'
    ,'True', 'False', 'True', 'Ajuste 2 +', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 2, 'False', 'False', 'VENTAS', 'False', 'True')
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
    ('AJUSTE2-', 'False', 'Ajuste 2 (-)', 'VENTAS', 0, 'True', 'False'
    ,'X', 100, 'False', -1, NULL, 'False'
    ,'True', 'False', 'True', 'Ajuste 2 -', 'True', 1
    ,'False', NULL, 'False', 99
    ,NULL, 0, '.', 'False', 10/100
    ,'False', 'False', 'False', 'True', 'False'
    ,'False', 2, 'False', 'False', 'VENTAS', 'False', 'True')
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'AJUSTE+' + CHAR(39) + ',' + CHAR(39) + 'AJUSTE-' + CHAR(39)
 WHERE EsRecibo = 'True' 
   AND GrabaLibro = 'True' 
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'AJUSTE2+' + CHAR(39) + ',' + CHAR(39) + 'AJUSTE2-' + CHAR(39)
 WHERE EsRecibo = 'True' 
   AND GrabaLibro = 'False' 
GO

UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',AJUSTE+,AJUSTE-,AJUSTE2+,AJUSTE2-'
 WHERE IdImpresora = 'NORMAL'
GO
