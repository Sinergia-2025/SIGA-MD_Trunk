DROP TABLE [dbo].[VentasProductosLotes]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasProductosLotes](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdLote] [varchar](10) NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Cantidad] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_VentasProductosLotes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[Orden] ASC,
	[IdProducto] ASC,
	[IdLote] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosLotes_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[VentasProductosLotes] CHECK CONSTRAINT [FK_VentasProductosLotes_Productos]
GO

ALTER TABLE [dbo].[VentasProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosLotes_ProductosLotes] FOREIGN KEY([IdSucursal], [IdProducto], [IdLote])
REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto], [IdLote])
GO

ALTER TABLE [dbo].[VentasProductosLotes] CHECK CONSTRAINT [FK_VentasProductosLotes_ProductosLotes]
GO

ALTER TABLE [dbo].[VentasProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosLotes_VentasProductos] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
REFERENCES [dbo].[VentasProductos] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
GO

ALTER TABLE [dbo].[VentasProductosLotes] CHECK CONSTRAINT [FK_VentasProductosLotes_VentasProductos]
GO

