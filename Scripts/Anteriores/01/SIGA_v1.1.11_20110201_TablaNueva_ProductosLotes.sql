
CREATE TABLE [dbo].[ProductosLotes](
	[IdSucursal] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdLote] [varchar](10) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[CantidadInicial] [decimal](10, 2) NOT NULL,
	[CantidadActual] [decimal](10, 2) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_ProductosLotes_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProducto] ASC,
	[IdLote] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosLotes_ProductosSucursales] FOREIGN KEY([IdProducto], [IdSucursal])
REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal])
GO

ALTER TABLE [dbo].[ProductosLotes] CHECK CONSTRAINT [FK_ProductosLotes_ProductosSucursales]
GO


