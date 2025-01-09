
/****** Object:  Table [dbo].[[PedidosEstadosProveedores]]    Script Date: 03/19/2013 11:08:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosEstadosProveedores](
	[IdSucursal] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaEstado] [datetime] NOT NULL,
	[IdEstado] [varchar](10) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[CantEntregada] [decimal](12, 2) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[Letra] [varchar](1) NULL,
	[CentroEmisor] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
	[TipoDocProveedor] [varchar](5) NULL,
	[NroDocProveedor] [bigint] NULL,
 CONSTRAINT [PK_PedidosEstadosProveedores] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdPedido] ASC,
	[IdProducto] ASC,
	[FechaEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_PedidosProductosProveedores] FOREIGN KEY([IdSucursal], [IdPedido], [IdProducto])
REFERENCES [dbo].[PedidosProductosProveedores] ([IdSucursal], [IdPedido], [IdProducto])
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_PedidosProductosProveedores]
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_Usuarios]
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_Compras]
GO

