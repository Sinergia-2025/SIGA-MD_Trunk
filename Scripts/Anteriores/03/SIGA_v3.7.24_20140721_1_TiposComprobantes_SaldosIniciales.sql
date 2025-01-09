
INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
  ('SALDOINICIAL+'	,'False'	,'Saldo Inicial (+)'	,'VENTAS'	,0	,'False'	,'False'	
  ,'X'	,999	,'False' , 1	,NULL	,'False'	
  ,'True'	,'False'	,'True'	,'S.I.(+)'	,'True'	,1	
  ,'False'	,NULL	,'False' ,998 ,NULL	
  ,0.00	,'.'	,'False'	,100000.00	, 'False'	,'False'	
  ,'False'	,'True'	,'True',	'True'	,2)
GO
	
IF NOT EXISTS (SELECT IdSucursal FROM CuentasCorrientes
                WHERE IdTipoComprobante = 'SALDOINICIAL' )
    BEGIN
    DELETE TiposComprobantes WHERE IdTipoComprobante = 'SALDOINICIAL'
    END
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',SALDOINICIAL+'
  WHERE IdImpresora = 'NORMAL'
GO

/* -------------- */


INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
  ('SALDOINICIAL-'	,'False'	,'Saldo Inicial (-)'	,'VENTAS'	,0	,'False'	,'False'	
  ,'X'	,999	,'False' , -1	,NULL	,'False'	
  ,'True'	,'False'	,'True'	,'S.I.(-)'	,'True'	,1	
  ,'False'	,NULL	,'False' ,998 ,NULL	
  ,0.00	,'.'	,'False'	,-100000.00	, 'False'	,'False'	
  ,'False'	,'True'	,'True',	'True'	,2)
GO
	
IF NOT EXISTS (SELECT IdSucursal FROM CuentasCorrientes
                WHERE IdTipoComprobante = 'SALDOINICIAL-NC' )
    BEGIN
    DELETE TiposComprobantes WHERE IdTipoComprobante = 'SALDOINICIAL-NC'
    END
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',SALDOINICIAL-'
  WHERE IdImpresora = 'NORMAL'
GO

/* -------------------------------------------------------------------------------- */

INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
  ('SALDOINICOM+'	,'False'	,'Saldo Inicial Compra (+)'	,'COMPRAS'	,0	,'False'	,'False'	
  ,'X'	,999	,'False' , 1	,NULL	,'False'	
  ,'True'	,'False'	,'True'	,'S.I.COM(+)'	,'True'	,1	
  ,'False'	,NULL	,'False' ,998 ,NULL	
  ,0.00	,'.'	,'False'	,100000.00	, 'False'	,'False'	
  ,'False'	,'True'	,'True',	'True'	,2)
GO
	
IF NOT EXISTS (SELECT IdSucursal FROM CuentasCorrientes
                WHERE IdTipoComprobante = 'SALDOINICOM' )
    BEGIN
    DELETE TiposComprobantes WHERE IdTipoComprobante = 'SALDOINICOM'
    END
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',SALDOINICOM+'
  WHERE IdImpresora = 'NORMAL'
GO

/* -------------- */


INSERT INTO [TiposComprobantes]
     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable
     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador
     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias
     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario
     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
     ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta)
  VALUES
  ('SALDOINICOM-'	,'False'	,'Saldo Inicial Compra (-)'	,'COMPRAS'	,0	,'False'	,'False'	
  ,'X'	,999	,'False' , -1	,NULL	,'False'	
  ,'True'	,'False'	,'True'	,'S.I.COM(-)'	,'True'	,1	
  ,'False'	,NULL	,'False' ,998 ,NULL	
  ,0.00	,'.'	,'False'	,-100000.00	, 'False'	,'False'	
  ,'False'	,'True'	,'True',	'True'	,2)
GO
	
IF NOT EXISTS (SELECT IdSucursal FROM CuentasCorrientes
                WHERE IdTipoComprobante = 'SALDOINICOM-NC' )
    BEGIN
    DELETE TiposComprobantes WHERE IdTipoComprobante = 'SALDOINICOM-NC'
    END
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',SALDOINICOM-'
  WHERE IdImpresora = 'NORMAL'
GO
