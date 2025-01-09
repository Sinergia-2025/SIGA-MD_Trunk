CREATE TABLE [dbo].[ProductosComponentes](
	[IdProducto] [varchar](15) NOT NULL,
	[IdProductoComponente] [varchar](15) NOT NULL,
	[Cantidad] [decimal](12, 2) NOT NULL,
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
