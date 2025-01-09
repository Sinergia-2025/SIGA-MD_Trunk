DROP TABLE dbo.ProductosNrosSerie
GO

/****** Object:  Table [dbo].[ProductosNrosSerie]    Script Date: 07/12/2012 13:38:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductosNrosSerie](
	[IdProducto] [varchar](15) NOT NULL,
	[NroSerie] [varchar](50) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[Vendido] [bit] NOT NULL,
	[IdTipoCompCompra] [varchar](15) NULL,
	[LetraCompra] [varchar](1) NULL,
	[CentroEmisorCompra] [int] NULL,
	[NumeroComprobanteCompra] [bigint] NULL,
	[TipoDocProveedor] [varchar](5) NULL,
	[NroDocProveedor] [bigint] NULL,
	[IdSucursalVenta] [int] NULL,
	[IdTipoCompVenta] [varchar](15) NULL,
	[LetraVenta] [varchar](1) NULL,
	[CentroEmisorVenta] [int] NULL,
	[NumeroComprobanteVenta] [bigint] NULL,
 CONSTRAINT [PK_ProductosNrosSerie] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[NroSerie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_ProductosNrosSerie_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosNrosSerie] CHECK CONSTRAINT [FK_ProductosNrosSerie_Productos]
GO

ALTER TABLE [dbo].[ProductosNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_ProductosNrosSerie_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[ProductosNrosSerie] CHECK CONSTRAINT [FK_ProductosNrosSerie_Sucursales]
GO


