
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompraPedidos_Clientes]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompraPedidos]'))
ALTER TABLE [dbo].[OrdenesCompraPedidos] DROP CONSTRAINT [FK_OrdenesCompraPedidos_Clientes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompraPedidos_OrdenesCompra]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompraPedidos]'))
ALTER TABLE [dbo].[OrdenesCompraPedidos] DROP CONSTRAINT [FK_OrdenesCompraPedidos_OrdenesCompra]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompraPedidos_TiposComprobantes]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompraPedidos]'))
ALTER TABLE [dbo].[OrdenesCompraPedidos] DROP CONSTRAINT [FK_OrdenesCompraPedidos_TiposComprobantes]
GO

/****** Object:  Table [dbo].[OrdenesCompraPedidos]    Script Date: 04/19/2017 09:15:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenesCompraPedidos]') AND type in (N'U'))
DROP TABLE [dbo].[OrdenesCompraPedidos]
GO

/****** Object:  Table [dbo].[OrdenesCompraPedidos]    Script Date: 04/19/2017 09:15:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdenesCompraPedidos](
	[IdSucursal] [int] NOT NULL,
	[NumeroOrdenCompra] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[NumeroPedido] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
 CONSTRAINT [PK_OrdenesCompraPedidos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroOrdenCompra] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrdenesCompraPedidos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompraPedidos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[OrdenesCompraPedidos] CHECK CONSTRAINT [FK_OrdenesCompraPedidos_Clientes]
GO

ALTER TABLE [dbo].[OrdenesCompraPedidos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompraPedidos_OrdenesCompra] FOREIGN KEY([IdSucursal], [NumeroOrdenCompra])
REFERENCES [dbo].[OrdenesCompra] ([IdSucursal], [NumeroOrdenCompra])
GO

ALTER TABLE [dbo].[OrdenesCompraPedidos] CHECK CONSTRAINT [FK_OrdenesCompraPedidos_OrdenesCompra]
GO

ALTER TABLE [dbo].[OrdenesCompraPedidos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompraPedidos_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[OrdenesCompraPedidos] CHECK CONSTRAINT [FK_OrdenesCompraPedidos_TiposComprobantes]
GO
