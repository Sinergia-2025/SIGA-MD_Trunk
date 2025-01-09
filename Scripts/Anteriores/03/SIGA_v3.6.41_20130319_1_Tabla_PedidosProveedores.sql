
/****** Object:  Table [dbo].[PedidosProveedores]    Script Date: 03/19/2013 11:00:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosProveedores](
	[IdSucursal] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[FechaPedido] [date] NOT NULL,
	[IdPeriodo] [int] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_PedidosProveedores] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProveedores_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[PedidosProveedores] CHECK CONSTRAINT [FK_PedidosProveedores_Proveedores]
GO

ALTER TABLE [dbo].[PedidosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProveedores_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[PedidosProveedores] CHECK CONSTRAINT [FK_PedidosProveedores_Sucursales]
GO

ALTER TABLE [dbo].[PedidosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProveedores_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[PedidosProveedores] CHECK CONSTRAINT [FK_PedidosProveedores_Usuarios]
GO


