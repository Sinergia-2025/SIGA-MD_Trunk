
/****** Object:  Table [dbo].[[PedidosProductosProveedores]]    Script Date: 03/19/2013 11:09:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosProductosProveedores](
	[IdSucursal] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Cantidad] [decimal](12, 4) NOT NULL,
	[Precio] [decimal](12, 4) NOT NULL,
	[Costo] [decimal](12, 4) NOT NULL,
	[ImporteTotal] [decimal](12, 4) NOT NULL,
	[NombreProducto] [varchar](60) NOT NULL,
	[CantEntregada] [decimal](12, 4) NOT NULL,
	[CantEnProceso] [decimal](12, 4) NOT NULL,
 CONSTRAINT [PK_PedidosProductosProveedores] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdPedido] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidosProductosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProductosProveedores_PedidosProveedores] FOREIGN KEY([IdSucursal], [IdPedido])
REFERENCES [dbo].[PedidosProveedores] ([IdSucursal], [IdPedido])
GO

ALTER TABLE [dbo].[PedidosProductosProveedores] CHECK CONSTRAINT [FK_PedidosProductosProveedores_PedidosProveedores]
GO

ALTER TABLE [dbo].[PedidosProductosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProductosProveedores_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[PedidosProductosProveedores] CHECK CONSTRAINT [FK_PedidosProductosProveedores_Productos]
GO


