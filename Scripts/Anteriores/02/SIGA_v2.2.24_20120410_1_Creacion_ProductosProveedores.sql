CREATE TABLE [dbo].[ProductosProveedores](
	[IdProducto] [varchar](15) NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[CodigoProductoProveedor] [varchar](20) NULL,
	[UltimoPrecioCompra] [decimal](12, 2) NULL,
 CONSTRAINT [PK_ProductosProveedores] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_ProductosProveedores_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosProveedores] CHECK CONSTRAINT [FK_ProductosProveedores_Productos]
GO

ALTER TABLE [dbo].[ProductosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_ProductosProveedores_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[ProductosProveedores] CHECK CONSTRAINT [FK_ProductosProveedores_Proveedores]
GO
