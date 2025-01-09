
/****** Object:  Table [dbo].[PedidosClientesContactos]    Script Date: 09/07/2017 10:20:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosClientesContactos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroPedido] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdContacto] [int] NOT NULL,
 CONSTRAINT [PK_PedidosClientesContactos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroPedido] ASC,
	[IdCliente] ASC,
	[IdContacto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidosClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_PedidosClientesContactos_ClientesContactos] FOREIGN KEY([IdCliente], [IdContacto])
REFERENCES [dbo].[ClientesContactos] ([IdCliente], [IdContacto])
GO

ALTER TABLE [dbo].[PedidosClientesContactos] CHECK CONSTRAINT [FK_PedidosClientesContactos_ClientesContactos]
GO

ALTER TABLE [dbo].[PedidosClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_PedidosClientesContactos_Pedidos] FOREIGN KEY([IdSucursal], [NumeroPedido], [IdTipoComprobante], [Letra], [CentroEmisor])
REFERENCES [dbo].[Pedidos] ([IdSucursal], [NumeroPedido], [IdTipoComprobante], [Letra], [CentroEmisor])
GO

ALTER TABLE [dbo].[PedidosClientesContactos] CHECK CONSTRAINT [FK_PedidosClientesContactos_Pedidos]
GO
