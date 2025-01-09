
/****** Object:  Table [dbo].[RecepcionEstados]    Script Date: 07/15/2011 10:43:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionEstados](
	[IdEstado] [int] NOT NULL,
	[NombreEstado] [varchar](50) NULL,
 CONSTRAINT [PK_ReparacionEstados] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



-- CREO LOS ESTADOS ESPACIADOS PARA FUTURAS SITUACIONES.

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (0, 'TODOS')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (10, 'Devuelto')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (20, 'Service')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (25, 'Trabajando')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (30, 'Reparado')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (40, 'No reparado')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (50, 'Entregado')
GO

-------------------------------------------------------------------------------------------------------


/****** Object:  Table [dbo].[RecepcionNotas]    Script Date: 07/15/2011 10:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionNotas](
	[IdSucursal] [int] NOT NULL,
	[NroNota] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[Letra] [varchar](1) NULL,
	[CentroEmisor] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaNota] [datetime] NOT NULL,
	[CantidadProductos] [decimal](12, 2) NOT NULL,
	[CostoReparacion] [decimal](12, 2) NOT NULL,
	[DefectoProducto] [varchar](250) NOT NULL,
	[Observacion] [varchar](250) NOT NULL,
	[EstaPrestado] [bit] NOT NULL,
	[IdProductoPrestado] [varchar](15) NULL,
	[CantidadPrestada] [decimal](12, 2) NULL,
	[ObservacionPrestamo] [varchar](150) NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecepcionNotas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroNota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecepcionNotas]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotas_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[RecepcionNotas] CHECK CONSTRAINT [FK_RecepcionNotas_Clientes]
GO

ALTER TABLE [dbo].[RecepcionNotas]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotas_ProductoPrestado] FOREIGN KEY([IdProductoPrestado])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[RecepcionNotas] CHECK CONSTRAINT [FK_RecepcionNotas_ProductoPrestado]
GO

ALTER TABLE [dbo].[RecepcionNotas]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotas_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[RecepcionNotas] CHECK CONSTRAINT [FK_RecepcionNotas_Sucursales]
GO

ALTER TABLE [dbo].[RecepcionNotas]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotas_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[RecepcionNotas] CHECK CONSTRAINT [FK_RecepcionNotas_Ventas]
GO

ALTER TABLE [dbo].[RecepcionNotas]  WITH CHECK ADD  CONSTRAINT [FK_ReparacionNotas_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[RecepcionNotas] CHECK CONSTRAINT [FK_ReparacionNotas_Productos]
GO



/****** Object:  Table [dbo].[RecepcionNotasEstados]    Script Date: 07/15/2011 10:44:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionNotasEstados](
	[IdSucursal] [int] NOT NULL,
	[NroNota] [int] NOT NULL,
	[FechaEstado] [datetime] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Observacion] [varchar](150) NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecepcionNotasEstado] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroNota] ASC,
	[FechaEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecepcionNotasEstados]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasEstados_RecepcionEstados] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[RecepcionEstados] ([IdEstado])
GO

ALTER TABLE [dbo].[RecepcionNotasEstados] CHECK CONSTRAINT [FK_RecepcionNotasEstados_RecepcionEstados]
GO

ALTER TABLE [dbo].[RecepcionNotasEstados]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasEstados_RecepcionNotas] FOREIGN KEY([IdSucursal], [NroNota])
REFERENCES [dbo].[RecepcionNotas] ([IdSucursal], [NroNota])
GO

ALTER TABLE [dbo].[RecepcionNotasEstados] CHECK CONSTRAINT [FK_RecepcionNotasEstados_RecepcionNotas]
GO


/****** Object:  Table [dbo].[RecepcionNotasProveedores]    Script Date: 07/15/2011 10:44:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionNotasProveedores](
	[IdSucursal] [int] NOT NULL,
	[NroNota] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[Observacion] [varchar](150) NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecepcionNotasProveedores_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroNota] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecepcionNotasProveedores]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasProveedores_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[RecepcionNotasProveedores] CHECK CONSTRAINT [FK_RecepcionNotasProveedores_Proveedores]
GO

ALTER TABLE [dbo].[RecepcionNotasProveedores]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasProveedores_RecepcionNotas] FOREIGN KEY([IdSucursal], [NroNota])
REFERENCES [dbo].[RecepcionNotas] ([IdSucursal], [NroNota])
GO

ALTER TABLE [dbo].[RecepcionNotasProveedores] CHECK CONSTRAINT [FK_RecepcionNotasProveedores_RecepcionNotas]
GO
