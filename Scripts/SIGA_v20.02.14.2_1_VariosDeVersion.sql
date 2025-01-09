PRINT ''
PRINT '1.- Nueva Tabla: TurismoTurnos'
/****** Object:  Table [dbo].[TurismoTurnos]    Script Date: 10/2/2020 11:04:23 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurismoTurnos](
	[IdTurno] [int] NOT NULL,
	[NombreTurno] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TurismoTurnos] PRIMARY KEY CLUSTERED 
([IdTurno] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '2.- Nueva Tabla: TurismoCursos'
CREATE TABLE [dbo].[TurismoCursos](
	[IdCurso] [int] NOT NULL,
	[NombreCurso] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TurismoCursos] PRIMARY KEY CLUSTERED 
([IdCurso] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '3.- Nueva Tabla: Reservas'
CREATE TABLE [dbo].[Reservas](
	[IdSucursal] [int] NOT NULL,
	[IdTipoReserva] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[NumeroReserva] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdEstablecimiento] [bigint] NOT NULL,
	[IdCurso] [int] NULL,
	[Division] [varchar](30) NULL,
	[IdTurno] [int] NULL,
	[IdResponsable] [int] NOT NULL,
	[IdPrograma] [varchar](15) NULL,
	[Mes] [varchar](30) NULL,
	[QuincenaSemana] [varchar](30) NULL,
	[Dia] [datetime] NULL,
	[IdTipoVehiculo] [int] NULL,
	[CapacidadMax] [int] NULL,
	[LugarSalida] [varchar](50) NULL,
	[CantidadAlumnos] [int] NULL,
	[Costo] [decimal](12, 2) NULL,
	[BaseAlumnos] [int] NULL,
	[IdFormaPago] [int] NULL,
	[Liberados] [varchar](200) NULL,
	[Seguimiento] [bit] NULL,
	[CDDigital] [bit] NULL,
	[IdEstadoTurismo] [int] NOT NULL,
	[IdUsuarioAlta] [varchar](10) NOT NULL,
	[IdUsuarioEstadoTurismo] [varchar](10) NOT NULL,
	[FechaEstadoTurismo] [datetime] NOT NULL,
	[BanderaColor] [int] NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
([IdSucursal] ASC,[IdTipoReserva] ASC,[Letra] ASC,[CentroEmisor] ASC,[NumeroReserva] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Clientes] FOREIGN KEY([IdEstablecimiento])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Clientes]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_EstadosTurismo] FOREIGN KEY([IdEstadoTurismo])
REFERENCES [dbo].[EstadosTurismo] ([IdEstadoTurismo])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_EstadosTurismo]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Productos] FOREIGN KEY([IdPrograma])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Productos]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Sucursales]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TiposComprobantes] FOREIGN KEY([IdTipoReserva])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TiposComprobantes]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TiposVehiculos] FOREIGN KEY([IdTipoVehiculo])
REFERENCES [dbo].[TiposVehiculos] ([IdTipoVehiculo])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TiposVehiculos]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TurismoCursos] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[TurismoCursos] ([IdCurso])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TurismoCursos]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TurismoTurnos] FOREIGN KEY([IdTurno])
REFERENCES [dbo].[TurismoTurnos] ([IdTurno])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TurismoTurnos]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_VentasFormasPago] FOREIGN KEY([IdFormaPago])
REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_VentasFormasPago]
GO

PRINT ''
PRINT '4.- Nueva Tabla: ReservasProductos'
CREATE TABLE [dbo].[ReservasProductos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoReserva] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[NumeroReserva] [bigint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdProductoComponente] [varchar](15) NOT NULL,
	[IdFormula] [int] NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_ReservasProductos] PRIMARY KEY CLUSTERED 
([IdSucursal] ASC,[IdTipoReserva] ASC,[Letra] ASC,[CentroEmisor] ASC,[NumeroReserva] ASC,[IdProducto] ASC,[IdProductoComponente] ASC,[IdFormula] ASC,[Orden] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReservasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ReservasProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ReservasProductos] CHECK CONSTRAINT [FK_ReservasProductos_Productos]
GO

ALTER TABLE [dbo].[ReservasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ReservasProductos_ProductosFormulas] FOREIGN KEY([IdProducto], [IdFormula])
REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
GO
ALTER TABLE [dbo].[ReservasProductos] CHECK CONSTRAINT [FK_ReservasProductos_ProductosFormulas]
GO

ALTER TABLE [dbo].[ReservasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ReservasProductos_Reservas] FOREIGN KEY([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
REFERENCES [dbo].[Reservas] ([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
GO
ALTER TABLE [dbo].[ReservasProductos] CHECK CONSTRAINT [FK_ReservasProductos_Reservas]
GO