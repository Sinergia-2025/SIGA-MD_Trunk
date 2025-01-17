
DROP TABLE [AlquileresTarifasProductos]
GO

DROP TABLE [Alquileres]
GO

DROP TABLE [AlquileresEstadosContratos]
GO

/****** Object:  Table [dbo].[EstadosContrato]    Script Date: 05/24/2012 20:54:39 ******/
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
     (0, 'Todos'), 
     (1, 'En Vigencia'), 
     (2, 'Finalizado'), 
     (3, 'Renovado')
GO


/****** Object:  Table [dbo].[Alquileres]    Script Date: 06/24/2012 10:47:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Alquileres](
	[IdSucursal] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[EsRenovable] [bit] NOT NULL,
	[TipoDocCliente] [varchar](5) NOT NULL,
	[NroDocCliente] [varchar](12) NOT NULL,
	[ImporteTotal] [decimal](14, 4) NOT NULL,
	[HoraE] [varchar](5) NULL,
	[HoraR] [varchar](5) NULL,
	[Lugar] [varchar](200) NULL,
	[Personal] [varchar](200) NULL,
	[IdEstado] [int] NOT NULL,
	[FechaRealFin] [date] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Alquileres] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProducto] ASC,
	[FechaDesde] ASC,
	[FechaHasta] ASC
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




/****** Object:  Table [dbo].[AlquileresTarifasProductos]    Script Date: 06/20/2012 21:31:45 ******/
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



/****** Object:  Table [dbo].[Equipos]    Script Date: 05/24/2012 20:54:39 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[Equipos](
--	[IdProducto] [varchar](15) NOT NULL,
--	[NombreEquipo] [varchar](100) NULL,
--	[modelo] [varchar](50) NULL,
--	[chasis] [varchar](50) NULL,
--	[nroSerie] [varchar](50) NULL,
--	[caractSII] [varchar](50) NULL,
--	[urlFoto] [nvarchar](50) NULL,
--	[año] [varchar](4) NULL,
-- CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
--(
--	[idEquipo] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET ANSI_PADDING OFF
--GO

