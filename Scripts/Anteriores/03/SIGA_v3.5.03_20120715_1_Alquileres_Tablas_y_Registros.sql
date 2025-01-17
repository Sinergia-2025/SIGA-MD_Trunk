
DROP TABLE [AlquileresTarifasProductos]
GO

DROP TABLE [Alquileres]
GO

DROP TABLE [AlquileresEstadosContratos]
GO

/****** [EstadosContrato] ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AlquileresEstadosContratos](
	[IdEstado] [int] NOT NULL,
	[NombreEstado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AlquileresEstadosContratos] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


INSERT INTO AlquileresEstadosContratos
     (IdEstado, NombreEstado)
  VALUES
     (0, 'ALTA'), 
     (1, 'En Vigencia'), 
     (2, 'Finalizado'), 
     (3, 'Renovado')
GO


/****** [Alquileres] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Alquileres](
	[IdSucursal] [int] NOT NULL,
	[NumeroContrato] [bigint] NOT NULL,
	[FechaContrato] [date] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[EsRenovable] [bit] NOT NULL,
	[TipoDocCliente] [varchar](5) NOT NULL,
	[NroDocCliente] [varchar](12) NOT NULL,
	[LocatarioNroDocumento]	[bigint] NOT NULL,
	[LocatarioNombre] [varchar](50) NOT NULL,
	[LocatarioCargo] [varchar](20) NOT NULL,
	[ImporteTotal] [decimal](14, 4) NOT NULL,
	[PersonalCapacitado] [varchar](200) NULL,
	[LugarER] [varchar](200) NULL,
	[HoraE] [varchar](5) NULL,
	[HoraR] [varchar](5) NULL,
	[IdEstado] [int] NOT NULL,
	[FechaRealFin] [date] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Alquileres] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroContrato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_AlquileresEstadosContratos] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[AlquileresEstadosContratos] ([IdEstado])
GO

ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_AlquileresEstadosContratos]
GO

ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Clientes] FOREIGN KEY([TipoDocCliente], [NroDocCliente])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Clientes]
GO

ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Productos]
GO

ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Sucursales]
GO

ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Usuarios]
GO


/****** [AlquileresTarifasProductos] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[AlquileresTarifasProductos](
	[IdSucursal] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[CantDias] [int] NOT NULL,
	[PrecioAlquiler] [decimal](12, 4) NOT NULL,
 CONSTRAINT [PK_AlquileresTarifasProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProducto] ASC,
	[CantDias] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AlquileresTarifasProductos]  WITH CHECK ADD  CONSTRAINT [FK_AlquileresTarifasProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[AlquileresTarifasProductos] CHECK CONSTRAINT [FK_AlquileresTarifasProductos_Productos]
GO

ALTER TABLE [dbo].[AlquileresTarifasProductos]  WITH CHECK ADD  CONSTRAINT [FK_AlquileresTarifasProductos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[AlquileresTarifasProductos] CHECK CONSTRAINT [FK_AlquileresTarifasProductos_Sucursales]
GO
