
/* ------ BORRO LAS TABLAS EXISTENTES ------ */

DROP TABLE dbo.ProduccionProductosComponentes
GO

DROP TABLE dbo.ProduccionProductos
GO

DROP TABLE dbo.Produccion
GO

DROP TABLE dbo.ProductosComponentes
GO


/* ------ CREO LAS TABLAS ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductosComponentes](
	[IdProducto] [varchar](15) NOT NULL,
	[IdProductoComponente] [varchar](15) NOT NULL,
	[Cantidad] [decimal](12, 4) NOT NULL,
 CONSTRAINT [PK_ProductosComponentes] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdProductoComponente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosComponentes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosComponentes_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosComponentes] CHECK CONSTRAINT [FK_ProductosComponentes_Productos]
GO

ALTER TABLE [dbo].[ProductosComponentes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosComponentes_Productos2] FOREIGN KEY([IdProductoComponente])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosComponentes] CHECK CONSTRAINT [FK_ProductosComponentes_Productos2]
GO

/* ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Produccion](
	[IdSucursal] [int] NOT NULL,
	[IdProduccion] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Produccion_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProduccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Produccion_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[Produccion] CHECK CONSTRAINT [FK_Produccion_Sucursales]
GO

ALTER TABLE [dbo].[Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Produccion_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Produccion] CHECK CONSTRAINT [FK_Produccion_Usuarios]
GO

/* ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ProduccionProductos](
	[IdSucursal] [int] NOT NULL,
	[IdProduccion] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[CantidadProducida] [decimal](12, 2) NOT NULL,
	[IdLote] [varchar](10) NULL,
	[FechaVencimiento] [datetime] NULL,
 CONSTRAINT [PK_ProduccionProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProduccion] ASC,
	[Orden] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductos_Produccion] FOREIGN KEY([IdSucursal], [IdProduccion])
REFERENCES [dbo].[Produccion] ([IdSucursal], [IdProduccion])
GO

ALTER TABLE [dbo].[ProduccionProductos] CHECK CONSTRAINT [FK_ProduccionProductos_Produccion]
GO

ALTER TABLE [dbo].[ProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProduccionProductos] CHECK CONSTRAINT [FK_ProduccionProductos_Productos]
GO

ALTER TABLE [dbo].[ProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductos_ProductosLotes] FOREIGN KEY([IdSucursal], [IdProducto], [IdLote])
REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto], [IdLote])
GO

ALTER TABLE [dbo].[ProduccionProductos] CHECK CONSTRAINT [FK_ProduccionProductos_ProductosLotes]
GO

ALTER TABLE [dbo].[ProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductos_ProductosSucursales] FOREIGN KEY([IdSucursal], [IdProduccion])
REFERENCES [dbo].[Produccion] ([IdSucursal], [IdProduccion])
GO

ALTER TABLE [dbo].[ProduccionProductos] CHECK CONSTRAINT [FK_ProduccionProductos_ProductosSucursales]
GO

/* ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ProduccionProductosComponentes](
	[IdSucursal] [int] NOT NULL,
	[IdProduccion] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdProductoComponente] [varchar](15) NOT NULL,
	[Cantidad] [decimal](12, 4) NOT NULL,
	[PrecioCosto] [decimal](12, 4) NULL,
	[PrecioVenta] [decimal](12, 4) NULL,
	[IdMoneda] [int] NULL,
 CONSTRAINT [PK_ProduccionProductosComponentes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProduccion] ASC,
	[Orden] ASC,
	[IdProducto] ASC,
	[IdProductoComponente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProduccionProductosComponentes]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductosComponentes_ProduccionProductos] FOREIGN KEY([IdSucursal], [IdProduccion], [Orden], [IdProducto])
REFERENCES [dbo].[ProduccionProductos] ([IdSucursal], [IdProduccion], [Orden], [IdProducto])
GO

ALTER TABLE [dbo].[ProduccionProductosComponentes] CHECK CONSTRAINT [FK_ProduccionProductosComponentes_ProduccionProductos]
GO

ALTER TABLE [dbo].[ProduccionProductosComponentes]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductosComponentes_Monedas] FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[Monedas] ([IdMoneda])
GO

ALTER TABLE [dbo].[ProduccionProductosComponentes] CHECK CONSTRAINT [FK_ProduccionProductosComponentes_Monedas]
GO



