
PRINT ''
PRINT '1. Crear Tabla RepartosProductosSinDescargar y FK asociadas.'
GO

CREATE TABLE [dbo].[RepartosProductosSinDescargar](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Cantidad] [decimal](16, 4) NOT NULL,
	[Precio] [decimal](16, 4) NOT NULL,
 CONSTRAINT [PK_RepartoProductosSinDescargar] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RepartosProductosSinDescargar]  WITH CHECK ADD  CONSTRAINT [FK_RepartosProductosSinDescargar_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[RepartosProductosSinDescargar] CHECK CONSTRAINT [FK_RepartosProductosSinDescargar_Productos]
GO

ALTER TABLE [dbo].[RepartosProductosSinDescargar]  WITH CHECK ADD  CONSTRAINT [FK_RepartosProductosSinDescargar_Repartos] FOREIGN KEY([IdSucursal], [IdReparto])
REFERENCES [dbo].[Repartos] ([IdSucursal], [IdReparto])
GO

ALTER TABLE [dbo].[RepartosProductosSinDescargar] CHECK CONSTRAINT [FK_RepartosProductosSinDescargar_Repartos]
GO
