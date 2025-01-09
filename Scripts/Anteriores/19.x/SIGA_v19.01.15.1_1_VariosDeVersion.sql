PRINT ''
PRINT '1.- Nuevo campo EsReciboClienteVinculado en TiposComprobantes'
ALTER TABLE dbo.TiposComprobantes ADD EsReciboClienteVinculado bit NULL
GO
UPDATE TiposComprobantes SET EsReciboClienteVinculado = 0;
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN EsReciboClienteVinculado bit NOT NULL
GO


PRINT ''
PRINT '2.- Nuevo TiposComprobantes: RECIBOV - Recibo Vinculado'
INSERT [dbo].[TiposComprobantes] 
      ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], 
       [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
       [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
       [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
       
       [ComprobantesAsociados], 
       [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 

       [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
       [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
       [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
       [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
       [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 

       [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
       [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
       [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado]
      ) VALUES
      (N'RECIBOV', 'False', N' Recibo Vinculado', N'CTACTECLIE', 0,
       'True', 'False', N'R', 100, 'True', 
       -1, NULL, 'False', 'True', 'False', 
       'True', N'Recibo V.', 'False', 1, 'False', 
       
       N'''ANTICIPO'',''ANTICIPOe'',''TICKET-F'',''TCK-FACT-F'',''FACT'',''AJUSTE-'',''AJUSTE+'',''eFACT'',''eNCRED'',''eNDEB'',''eNDEBCHEQRECH'',''FACT-F'',''NCRED-F'',''NDEB-F'',''NDEBCHEQRECH'',''NCRED'',''NDEB''', 
       'True', 0, N'RECIBO', 99999999.00, 

       '.', 'False', 0.01, 'False', 'True',
       'True', 'True', 'False', 'False', 1, 
       'False', 'True', N'CTACTECLIE', 'False', 'True', 
       'False', 'False', 'False', NULL, NULL, 
       NULL, NULL, 'False', 'False', N'', 
       
       'False', 'False', NULL, 'True', 'True', 
       'True', 'False', 8, 1, 'False', 
       'True', 'False', 'True')
GO
PRINT ''
PRINT '3.- Nuevo TiposComprobantes: RECIBOVPROV - Recibo Vinc. Provisorio'
INSERT [dbo].[TiposComprobantes] 
      ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], 
       [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
       [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
       [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
       
       [ComprobantesAsociados], 
       [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 

       [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
       [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
       [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
       [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
       [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 

       [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
       [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
       [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado]
      ) VALUES
      (N'RECIBOVPROV', 'False', N' Recibo Vinc. Provisorio', N'CTACTECLIE', 0, 
       'False', 'False', N'X', 100, 'True',
       -1, NULL, 'False', 'True', 'False',
       'True', N'ReciboV.Pr', 'False', 1, 'False', 
       
       N'''ANTICIPOPROV'',''COTIZACION'',''DEV-COTIZACION'',''COTIZCHEQRECH'',''NDEB-COTIZACION'',''TICKET-NOFISCAL'',''SALDOINICIAL+'',''SALDOINICIAL-'',''ANTICIPOPROVe'',''AJUSTE2+'',''AJUSTE2-''', 
       'True', 0, N'RECIBOPROV', 99999999.00,
       '.', 'False', 0.01, 'False', 'False', 
       'True', 'True', 'False', 'False', 2,
       'False', 'True', N'CTACTECLIE', 'False', 'True', 
       'False', 'False', 'False', NULL, NULL, 
       NULL, NULL, 'False', 'False', N'', 
       
       'False', 'False', NULL, 'True', 'True', 
       'True', 'False', 8, 1, 'False', 
       'True', 'False', 'True')
GO

PRINT ''
PRINT '4.- Asociar el recibo RECIBOV a la impresora donde está RECIBO'
UPDATE Impresoras
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',RECIBOV'
 WHERE (ComprobantesHabilitados LIKE '%,RECIBO,%' OR ComprobantesHabilitados LIKE 'RECIBO,%' OR ComprobantesHabilitados LIKE '%,RECIBO')

PRINT ''
PRINT '5.- Asociar RECIBOVPROV a la impresora donde está RECIBOPROV'
UPDATE Impresoras
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',RECIBOVPROV'
 WHERE (ComprobantesHabilitados LIKE '%,RECIBOPROV,%' OR ComprobantesHabilitados LIKE 'RECIBOPROV,%' OR ComprobantesHabilitados LIKE '%,RECIBOPROV')

PRINT ''
PRINT '6.- Agregar FK al recibo Vinculado'
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientes ADD IdSucursalVinculado int NULL
ALTER TABLE dbo.CuentasCorrientes ADD IdTipoComprobanteVinculado varchar(15) NULL
ALTER TABLE dbo.CuentasCorrientes ADD LetraVinculado varchar(1) NULL
ALTER TABLE dbo.CuentasCorrientes ADD CentroEmisorVinculado int NULL
ALTER TABLE dbo.CuentasCorrientes ADD NumeroComprobanteVinculado bigint NULL
GO
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT FK_CuentasCorrientes_CuentasCorrientes_Vinculado
    FOREIGN KEY (IdSucursalVinculado,IdTipoComprobanteVinculado,LetraVinculado,CentroEmisorVinculado,NumeroComprobanteVinculado)
    REFERENCES dbo.CuentasCorrientes (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '7.- Nueva opción de menú ´Emisión de Recibos Vinculados´'
	INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
			 IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
			 PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
			('RecibosVinculados', 'Emisión de Recibos Vinculados', 'Emisión de Recibos Vinculados', 'True', 'False', 'True', 'True', 
			 'CuentasCorrientes', 13, 'Eniac.Win', 'Recibos', NULL, 'RECIBOVINCULADO',
			 'True', 'S', 'N', 'N', 'N');


	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT IdRol, 'RecibosVinculados' FROM RolesFunciones WHERE IdFuncion = 'RecibosNuevos'

PRINT ''
PRINT '8.- Completar el IdClienteCtaCte que quedaron en blanco'
UPDATE CuentasCorrientes
   SET IdClienteCtaCte = IdCliente
 WHERE ISNULL(IdClienteCtaCte, 0) = 0
