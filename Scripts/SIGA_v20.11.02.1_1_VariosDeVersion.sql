/****** Object:  Table [dbo].[RepartosCobranzas]    Script Date: 04/08/2020 19:40:05 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

PRINT ''
PRINT '1. Nueva Tabla: RepartosCobranzas'

CREATE TABLE [dbo].[RepartosCobranzas](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdCobranza] [int] NOT NULL,
	[FechaRendicion] [datetime] NOT NULL,
	[IdCaja] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[IdUsuarioAlta] [varchar](10) NOT NULL,
 CONSTRAINT [PK_RepartosCobranzas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
    [IdCobranza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '2. Nueva Tabla: RepartosCobranzasComprobantes'

CREATE TABLE [dbo].[RepartosCobranzasComprobantes](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdCobranza] [int] NOT NULL,
	[IdSucursalComp] [int] NOT NULL,
	[IdTipoComprobanteComp] [varchar](15) NOT NULL,
	[LetraComp] [varchar](1) NOT NULL,
	[CentroEmisorComp] [int] NOT NULL,
	[NumeroComprobanteComp] [bigint] NOT NULL,
	[MedioPagoSeleccionado] [varchar](20) NOT NULL,
	[SaldoComprobante] [decimal](14, 2) NOT NULL,
	[TotalEfectivo] [decimal](14, 2) NOT NULL,
	[TotalCuentaCorriente] [decimal](14, 2) NOT NULL,
	[TotalCheques] [decimal](14, 2) NOT NULL,
	[TotalNC] [decimal](14, 2) NOT NULL,
	[TotalAplicado] [decimal](14, 2) NOT NULL,
	[TotalReenvio] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_RepartosCobranzasComprobantes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
    [IdCobranza] ASC,
	[IdSucursalComp] ASC,
	[IdTipoComprobanteComp] ASC,
	[LetraComp] ASC,
	[CentroEmisorComp] ASC,
	[NumeroComprobanteComp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

PRINT ''
PRINT '3. Nueva Tabla: RepartosCobranzasProductos'

CREATE TABLE [dbo].[RepartosCobranzasProductos](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdCobranza] [int] NOT NULL,
	[IdSucursalComp] [int] NOT NULL,
	[IdTipoComprobanteComp] [varchar](15) NOT NULL,
	[LetraComp] [varchar](1) NOT NULL,
	[CentroEmisorComp] [int] NOT NULL,
	[NumeroComprobanteComp] [bigint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Orden] [int] NOT NULL,
	[CantidadDevuelta] [decimal](14, 2) NOT NULL,
	[IdEstadoVenta] [int] NOT NULL,
 CONSTRAINT [PK_RepartosCobranzasProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
    [IdCobranza] ASC,
	[IdSucursalComp] ASC,
	[IdTipoComprobanteComp] ASC,
	[LetraComp] ASC,
	[CentroEmisorComp] ASC,
	[NumeroComprobanteComp] ASC,
	[IdProducto] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

PRINT ''
PRINT '4. Nueva Tabla: RepartosCobranzasCheques'

CREATE TABLE [dbo].[RepartosCobranzasCheques](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdCobranza] [int] NOT NULL,
	[IdSucursalComp] [int] NOT NULL,
	[IdTipoComprobanteComp] [varchar](15) NOT NULL,
	[LetraComp] [varchar](1) NOT NULL,
	[CentroEmisorComp] [int] NOT NULL,
	[NumeroComprobanteComp] [bigint] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[NroOperacion] [varchar](20) NOT NULL,
	[IdTipoCheque] [varchar](3) NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaCobro] [datetime] NOT NULL,
	[Titular] [varchar](40) NOT NULL,
	[Importe] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_RepartosCobranzasCheques] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
    [IdCobranza] ASC,
	[IdSucursalComp] ASC,
	[IdTipoComprobanteComp] ASC,
	[LetraComp] ASC,
	[CentroEmisorComp] ASC,
	[NumeroComprobanteComp] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC,
	[NumeroCheque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

PRINT ''
PRINT '5. Nueva Tabla: RepartosCobranzasNCAplicadas'

CREATE TABLE [dbo].[RepartosCobranzasNCAplicadas](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdCobranza] [int] NOT NULL,
	[IdSucursalComp] [int] NOT NULL,
	[IdTipoComprobanteComp] [varchar](15) NOT NULL,
	[LetraComp] [varchar](1) NOT NULL,
	[CentroEmisorComp] [int] NOT NULL,
	[NumeroComprobanteComp] [bigint] NOT NULL,
	[IdSucursalNC] [int] NOT NULL,
	[IdTipoComprobanteNC] [varchar](15) NOT NULL,
	[LetraNC] [varchar](1) NOT NULL,
	[CentroEmisorNC] [int] NOT NULL,
	[NumeroComprobanteNC] [bigint] NOT NULL,
	[SaldoComprobante] [decimal](14, 2) NULL,
	[ImporteAplicado] [decimal](14, 2) NULL,
 CONSTRAINT [PK_RepartosCobranzasNCAplicadas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
    [IdCobranza] ASC,
	[IdSucursalComp] ASC,
	[IdTipoComprobanteComp] ASC,
	[LetraComp] ASC,
	[CentroEmisorComp] ASC,
	[NumeroComprobanteComp] ASC,
	[IdSucursalNC] ASC,
	[IdTipoComprobanteNC] ASC,
	[LetraNC] ASC,
	[CentroEmisorNC] ASC,
	[NumeroComprobanteNC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

SET ANSI_PADDING OFF
GO

PRINT ''
PRINT '1 -> 5. Tablas RepartosCobranzas, RepartosCobranzasComprobantes, RepartosCobranzasProductos, RepartosCobranzasCheques y RepartosCobranzasNCAplicadas: FK'

ALTER TABLE [dbo].[RepartosCobranzas]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzas_CajasNombres] FOREIGN KEY([IdSucursal], [IdCaja])
REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja])
ALTER TABLE [dbo].[RepartosCobranzas] CHECK CONSTRAINT [FK_RepartosCobranzas_CajasNombres]
GO

ALTER TABLE [dbo].[RepartosCobranzas]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzas_Repartos] FOREIGN KEY([IdSucursal], [IdReparto])
REFERENCES [dbo].[Repartos] ([IdSucursal], [IdReparto])
ALTER TABLE [dbo].[RepartosCobranzas] CHECK CONSTRAINT [FK_RepartosCobranzas_Repartos]
GO

ALTER TABLE [dbo].[RepartosCobranzas]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzas_Usuarios] FOREIGN KEY([IdUsuarioAlta])
REFERENCES [dbo].[Usuarios] ([Id])
ALTER TABLE [dbo].[RepartosCobranzas] CHECK CONSTRAINT [FK_RepartosCobranzas_Usuarios]
GO

ALTER TABLE [dbo].[RepartosCobranzasComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasComprobantes_RepartosCobranzas] FOREIGN KEY([IdSucursal], [IdReparto], [IdCobranza])
REFERENCES [dbo].[RepartosCobranzas] ([IdSucursal], [IdReparto], [IdCobranza])
ALTER TABLE [dbo].[RepartosCobranzasComprobantes] CHECK CONSTRAINT [FK_RepartosCobranzasComprobantes_RepartosCobranzas]
GO

ALTER TABLE [dbo].[RepartosCobranzasComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasComprobantes_CuentasCorrientes] FOREIGN KEY([IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
ALTER TABLE [dbo].[RepartosCobranzasComprobantes] CHECK CONSTRAINT [FK_RepartosCobranzasComprobantes_CuentasCorrientes]
GO


ALTER TABLE [dbo].[RepartosCobranzasProductos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasProductos_EstadosVenta] FOREIGN KEY([IdEstadoVenta])
REFERENCES [dbo].[EstadosVenta] ([IdEstadoVenta])
ALTER TABLE [dbo].[RepartosCobranzasProductos] CHECK CONSTRAINT [FK_RepartosCobranzasProductos_EstadosVenta]
GO

ALTER TABLE [dbo].[RepartosCobranzasProductos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
ALTER TABLE [dbo].[RepartosCobranzasProductos] CHECK CONSTRAINT [FK_RepartosCobranzasProductos_Productos]
GO

ALTER TABLE [dbo].[RepartosCobranzasProductos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasProductos_RepartosCobranzasComprobantes] FOREIGN KEY([IdSucursal], [IdReparto], [IdCobranza], [IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
REFERENCES [dbo].[RepartosCobranzasComprobantes] ([IdSucursal], [IdReparto], [IdCobranza], [IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
ALTER TABLE [dbo].[RepartosCobranzasProductos] CHECK CONSTRAINT [FK_RepartosCobranzasProductos_RepartosCobranzasComprobantes]
GO

ALTER TABLE [dbo].[RepartosCobranzasCheques]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasCheques_Bancos] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Bancos] ([IdBanco])
ALTER TABLE [dbo].[RepartosCobranzasCheques] CHECK CONSTRAINT [FK_RepartosCobranzasCheques_Bancos]
GO

ALTER TABLE [dbo].[RepartosCobranzasCheques]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasCheques_RepartosCobranzasComprobantes] FOREIGN KEY([IdSucursal], [IdReparto], [IdCobranza], [IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
REFERENCES [dbo].[RepartosCobranzasComprobantes] ([IdSucursal], [IdReparto], [IdCobranza], [IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
ALTER TABLE [dbo].[RepartosCobranzasCheques] CHECK CONSTRAINT [FK_RepartosCobranzasCheques_RepartosCobranzasComprobantes]
GO

ALTER TABLE [dbo].[RepartosCobranzasNCAplicadas]  WITH CHECK ADD  CONSTRAINT [FK_RepartosCobranzasNCAplicadas_RepartosCobranzasComprobantes] FOREIGN KEY([IdSucursal], [IdReparto], [IdCobranza], [IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
REFERENCES [dbo].[RepartosCobranzasComprobantes] ([IdSucursal], [IdReparto], [IdCobranza], [IdSucursalComp], [IdTipoComprobanteComp], [LetraComp], [CentroEmisorComp], [NumeroComprobanteComp])
ALTER TABLE [dbo].[RepartosCobranzasNCAplicadas] CHECK CONSTRAINT [FK_RepartosCobranzasNCAplicadas_RepartosCobranzasComprobantes]
GO


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
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
PRINT ''
PRINT '6. Tabla RepartosCobranzasComprobantes: Nuevos campos IdSucursalRecibo, IdTipoComprobanteRecibo, LetraRecibo, CentroEmisorRecibo, NumeroComprobanteRecibo'
ALTER TABLE dbo.RepartosCobranzasComprobantes ADD IdSucursalRecibo int NULL
ALTER TABLE dbo.RepartosCobranzasComprobantes ADD IdTipoComprobanteRecibo varchar(15) NULL
ALTER TABLE dbo.RepartosCobranzasComprobantes ADD LetraRecibo varchar(1) NULL
ALTER TABLE dbo.RepartosCobranzasComprobantes ADD CentroEmisorRecibo int NULL
ALTER TABLE dbo.RepartosCobranzasComprobantes ADD NumeroComprobanteRecibo bigint NULL
GO
ALTER TABLE dbo.RepartosCobranzasComprobantes ADD CONSTRAINT FK_RepartosCobranzasComprobantes_CuentasCorrientes_Recibo
    FOREIGN KEY (IdSucursalRecibo, IdTipoComprobanteRecibo, LetraRecibo, CentroEmisorRecibo, NumeroComprobanteRecibo)
    REFERENCES dbo.CuentasCorrientes (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.RepartosCobranzasComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



PRINT ''
PRINT '7. Nueva Tabla: MovimientosVentasProductosLotes'
CREATE TABLE MovimientosVentasProductosLotes(
	IdSucursal INT NOT NULL,
	IdTipoMovimiento VARCHAR(15) NOT NULL,
	NumeroMovimiento BIGINT NOT NULL,
	Orden INT NOT NULL,
	IdProducto VARCHAR(15) NOT NULL,
	IdLote VARCHAR(30) NOT NULL,
	Cantidad DECIMAL(16,4) NOT NULL
	PRIMARY KEY (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto, IdLote)
)
GO

PRINT ''
PRINT '7.1. Tabla MovimientosVentasProductosLotes: FK_MovimientosVentasProductosLotes_MovimientosVentasProductos'
ALTER TABLE MovimientosVentasProductosLotes
	ADD CONSTRAINT FK_MovimientosVentasProductosLotes_MovimientosVentasProductos
	FOREIGN KEY (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto) REFERENCES MovimientosVentasProductos (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
GO


PRINT ''
PRINT '7.2. Tabla MovimientosVentasProductosLotes: Actualización de Datos Historicos'
INSERT INTO MovimientosVentasProductosLotes (
	IdSucursal, 
	IdTipoMovimiento, 
	NumeroMovimiento, 
	IdProducto,
	Cantidad,
	IdLote,
	Orden) 
SELECT IdSucursal, 
	   IdTipoMovimiento, 
	   NumeroMovimiento, 
	   IdProducto, 
	   Cantidad, 
	   IdLote, 
	   Orden 
FROM MovimientosVentasProductos WHERE IdLote IS NOT NULL
GO

PRINT ''
PRINT '7.3. Elimino el campo IdLote de la tabla de MovimientosVentasProductos'
ALTER TABLE MovimientosVentasProductos DROP CONSTRAINT FK_MovimientosVentasProductos_ProductosLotes
GO
ALTER TABLE MovimientosVentasProductos DROP COLUMN IdLote
GO

PRINT ''
PRINT '8. Nueva opción de menu: Registración de Pagos (v2)'
IF dbo.ExisteFuncion('RegistracionPagos') = 1 AND dbo.ExisteFuncion('Logistica') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('RegistracionPagosV2', 'Registración de Pagos (v2)', 'Registración de Pagos (v2)', 'True', 'False', 'True', 'True'
        ,'Logistica', 45, 'Eniac.Win', 'RegistracionPagosV2', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'RegistracionPagosV2' FROM RolesFunciones WHERE IdFuncion = 'RegistracionPagos'
END
