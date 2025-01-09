----- AGREGAR CONTROL DE EXISTENCIA /// EN RESTA SE SACA A MANO 15/08/2019 16:19 HS

PRINT ''
PRINT '1. Nuevo Tipo de Comprobante: RECIBO COMPRA'
IF EXISTS(SELECT * FROM TiposComprobantes WHERE IdTipoComprobante = 'REC-COMP')
BEGIN
    PRINT ''
    PRINT '1.1. Insert: RECIBO COMPRA'
    INSERT [dbo].[TiposComprobantes]
    /* 1*/ ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], 
    /* 2*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], 
    /* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
    /* 4*/  [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
    /* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
    /* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
    /* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
    /* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
    /* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
    /*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
    /*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
    /*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
    /*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC]) --VALUES
    SELECT 
    /* 1*/  'REC-COMP', [EsFiscal], 'Recibo Compra', [Tipo], [CoeficienteStock], 
    /* 2*/  [GrabaLibro], [EsFacturable], 'A,B,C', [CantidadMaximaItems], [Imprime], 
    /* 3*/  [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], 
    /* 4*/  [ActualizaCtaCte], 'Rec.Comp', [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], 
    /* 5*/  [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], 
    /* 6*/  [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], 
    /* 7*/  [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], 
    /* 8*/  [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
    /* 9*/  [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
    /*10*/  [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], 
    /*11*/  [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
    /*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
    /*13*/  [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], 'False', 'False'
      FROM [dbo].[TiposComprobantes]
     WHERE IdTipoComprobante = 'FACTCOM'

    PRINT ''
    PRINT '1.2. Asociar Recibo Compra a Tipo de Movimiento'
    UPDATE TiposMovimientos SET
         ComprobantesAsociados = ComprobantesAsociados + ',REC-COMP'
      WHERE IdTipoMovimiento = 'COMPRA'
END

PRINT ''
PRINT '2. Tabla AFIPTiposComprobantesTiposCbtes: Nuevos tipo de comprobante compra RECIBO COMPRA (4, 9, 15)'
DELETE AFIPTiposComprobantesTiposCbtes WHERE IdTipoComprobante = 'REC-COMP';
INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante,IdTipoComprobante,Letra)
    VALUES (4,'REC-COMP','A'),
           (9,'REC-COMP','B'),
           (15,'REC-COMP','C')
 
PRINT ''
PRINT '3. Menu Listas de Control por Productos'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '3.1. Menu Listas de Control por Productos: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('ListasControlProductos', 'Listas de Control por Productos', 'Listas de Control por Productos', 'True', 'False', 'True', 'True'
             ,'Calidad', 70, 'Eniac.Win', 'ListasControlProductos', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '3.2. Menu Listas de Control por Productos: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlProductos' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

END;

PRINT ''
PRINT '4. Nueva tabla CalidadListasControlProductosItems'
CREATE TABLE [dbo].[CalidadListasControlProductosItems](
	[IdProducto] [varchar](15) NOT NULL,
	[IdListaControl] [int] NOT NULL,
	[Item] [int] NOT NULL,
	[IdListaControlItem] [int] NOT NULL,
	[Ok] [bit] NOT NULL,
	[NoOk] [bit] NOT NULL,
	[Obs] [bit] NOT NULL,
	[Mat] [bit] NOT NULL,
	[NA] [bit] NOT NULL,
	[Observ] [varchar](1000) NULL,
	[Orden] [int] NULL,
	[Usuario] [varchar](50) NULL,
	[FechaMod] [datetime] NULL,
 CONSTRAINT [PK_CalidadListasControlItemsProductos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdListaControl] ASC,
	[Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CalidadListasControlProductosItems]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlItemsProductos_CalidadListasControlItems] FOREIGN KEY([IdListaControlItem])
REFERENCES [dbo].[CalidadListasControlItems] ([IdListaControlItem])
GO
ALTER TABLE [dbo].[CalidadListasControlProductosItems] CHECK CONSTRAINT [FK_CalidadListasControlItemsProductos_CalidadListasControlItems]
GO
ALTER TABLE [dbo].[CalidadListasControlProductosItems]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlItemsProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[CalidadListasControlProductosItems] CHECK CONSTRAINT [FK_CalidadListasControlItemsProductos_Productos]
GO
ALTER TABLE [dbo].[CalidadListasControlProductosItems]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductosItems_CalidadListasControlConfig] FOREIGN KEY([IdListaControl], [Item])
REFERENCES [dbo].[CalidadListasControlConfig] ([IdListaControl], [Item])
GO
ALTER TABLE [dbo].[CalidadListasControlProductosItems] CHECK CONSTRAINT [FK_CalidadListasControlProductosItems_CalidadListasControlConfig]
GO

PRINT ''
PRINT '5. Nueva tabla ProductosLinks'
CREATE TABLE [dbo].[ProductosLinks](
	[IdProducto] [varchar](15) NOT NULL,
	[ItemLink] [int] NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Link] [varchar](8000) NULL,
 CONSTRAINT [PK_ProductosLinks] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[ItemLink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '6. Nueva tabla CalidadListasControlConfigLinks'
CREATE TABLE [dbo].[CalidadListasControlConfigLinks](
	[IdListaControl] [int] NOT NULL,
	[Item] [int] NOT NULL,
	[ItemLink] [int] NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Link] [varchar](8000) NULL,
 CONSTRAINT [PK_CalidadListasControlConfigLinks] PRIMARY KEY CLUSTERED 
(
	[IdListaControl] ASC,
	[Item] ASC,
	[ItemLink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CalidadListasControlConfigLinks]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlConfig] FOREIGN KEY([IdListaControl], [Item])
REFERENCES [dbo].[CalidadListasControlConfig] ([IdListaControl], [Item])
GO
ALTER TABLE [dbo].[CalidadListasControlConfigLinks] CHECK CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlConfig]
GO

PRINT ''
PRINT '7. Nueva tabla CalidadListasControlRoles'
CREATE TABLE [dbo].[CalidadListasControlRoles](
	[IdListaControl] [int] NOT NULL,
	[IdRol] [varchar](12) NOT NULL,
 CONSTRAINT [PK_CalidadListasControlRoles] PRIMARY KEY CLUSTERED 
(
	[IdListaControl] ASC,
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CalidadListasControlRoles]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlRoles_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO
ALTER TABLE [dbo].[CalidadListasControlRoles] CHECK CONSTRAINT [FK_CalidadListasControlRoles_CalidadListasControl]
GO
ALTER TABLE [dbo].[CalidadListasControlRoles]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlRoles_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[CalidadListasControlRoles] CHECK CONSTRAINT [FK_CalidadListasControlRoles_Roles]
GO

PRINT ''
PRINT '8. Tabla CalidadListasControlRoles: Cargar datos iniciales'
-- Agrego permiso Admin, Suoervisor
INSERT INTO [dbo].[CalidadListasControlRoles]
           ([IdListaControl]
           ,[IdRol])
 SELECT IdListaControl, 'Adm' FROM CalidadListasControl
 UNION ALL
 SELECT IdListaControl, 'Supervisor' FROM CalidadListasControl

PRINT ''
PRINT '9. Menu Roles de Listas de Control'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '9.1. Menu Roles de Listas de Control: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('ListasControlRoles', 'Roles de Listas de Control ', 'Roles de Listas de Control', 'True', 'False', 'True', 'True'
             ,'Calidad', 40, 'Eniac.Win', 'ListasControlRoles', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '9.2. Menu Roles de Listas de Control: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlRoles' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

    PRINT ''
    PRINT '9.3. Menu ListasControlUsuarios: Inactivar función'
    UPDATE Funciones SET Visible = 'False', Enabled = 'False' WHERE id = 'ListasControlUsuarios'
END;



PRINT ''
PRINT '10. Modificar buscador de clientes'
IF dbo.BaseConCuit('33631312379') = 'True'      --SOLO METALSUR
BEGIN

    UPDATE BuscadoresCampos SET Orden = Orden + 100 WHERE IdBuscador = 2 AND Orden > 3
    UPDATE Parametros SET ValorParametro = 'True' Where IdParametro = 'CLIENTEMOSTRARPRODUCTOSASOCIADOS'

    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'NombreCliente', 4, N'Cliente', 16, 200, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'NombreDeFantasia', 5, N'Fantasia', 16, 200, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadStatusLiberado', 6, N'Liberado', 32, 50, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFechaLiberado', 7, N'Fecha Liberado', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadUserLiberado', 8, N'Usuario Liberado', 16, 100, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadStatusEntregado', 9, N'Entregado', 32, 50, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFechaEntregado', 10, N'Fecha Entregado', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadUserEntregado', 11, N'Usuario Entregado', 16, 100, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFechaIngreso', 12, N'Fecha Ingreso', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFechaEgreso', 13, N'Fecha Ingreso', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadNroCertificado', 14, N'Nro Certificado', 16, 200, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFecCertificado', 15, N'Fecha Certificado', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadUsrCertificado', 16, N'Usuario Certificado', 16, 100, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadObservaciones', 17, N'Observaciones Calidad', 16, 300, N'', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFechaPreEnt', 18, N'Fecha Pre Entrega', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)
    INSERT [dbo].[BuscadoresCampos] ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila]) 
    VALUES (2, N'CalidadFechaEntProg', 18, N'Fecha Ent Programado', 32, 100, N'dd/MM/yyyy HH:mm', NULL, NULL, NULL)

END


PRINT ''
PRINT '11. Tabla CalidadListasControlProductosItems: Nuevos campos'
ALTER TABLE CalidadListasControlProductosItems ADD OkCalidad bit NULL,
			NoOkCalidad bit NULL,
			ObsCalidad bit NULL,
			MatCalidad bit NULL,
			NACalidad bit NULL,
			ObservCalidad varchar(1000) NULL,
			UsuarioCalidad varchar(50) NULL,
			FechaModCalidad datetime NULL
GO
PRINT ''
PRINT '11.1. Tabla CalidadListasControlProductosItems: Valores por defecto'
UPDATE CalidadListasControlProductosItems SET OkCalidad = 'False',
			NoOkCalidad = 'False',
			ObsCalidad = 'False',
			MatCalidad = 'False',
			NACalidad = 'False'

PRINT ''
PRINT '11.2. Tabla CalidadListasControlProductosItems: Campos NOT NULL'
ALTER TABLE CalidadListasControlProductosItems ALTER COLUMN OkCalidad bit NOT NULL
ALTER TABLE	CalidadListasControlProductosItems ALTER COLUMN NoOkCalidad bit NOT NULL
ALTER TABLE CalidadListasControlProductosItems ALTER COLUMN	ObsCalidad bit NOT NULL
ALTER TABLE CalidadListasControlProductosItems ALTER COLUMN	MatCalidad bit NOT NULL
ALTER TABLE CalidadListasControlProductosItems ALTER COLUMN	NACalidad bit NOT NULL


