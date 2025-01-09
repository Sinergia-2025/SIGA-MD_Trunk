
/****** Object:  Table [dbo].[OrdenesProduccionEstados]    Script Date: 27/4/2017 15:35:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdenesProduccionEstados](
	[IdSucursal] [int] NOT NULL,
	[NumeroOrdenProduccion] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaEstado] [datetime] NOT NULL,
	[IdEstado] [varchar](10) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[IdTipoComprobanteFact] [varchar](15) NULL,
	[LetraFact] [varchar](1) NULL,
	[CentroEmisorFact] [int] NULL,
	[NumeroComprobanteFact] [bigint] NULL,
	[Orden] [int] NOT NULL,
	[IdCriticidad] [varchar](10) NOT NULL,
	[FechaEntrega] [date] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroReparto] [int] NULL,
	[CantEstado] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_OrdenesProduccionEstados] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroOrdenProduccion] ASC,
	[IdProducto] ASC,
	[FechaEstado] ASC,
	[Orden] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_EstadosOrdenesProduccion] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadosOrdenesProduccion] ([idEstado])
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_EstadosOrdenesProduccion]
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_OrdenesProduccionCriticidades] FOREIGN KEY([IdCriticidad])
REFERENCES [dbo].[OrdenesProduccionCriticidades] ([IdCriticidad])
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_OrdenesProduccionCriticidades]
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_OrdenesProduccionProductos] FOREIGN KEY([IdSucursal], [NumeroOrdenProduccion], [IdProducto], [Orden], [IdTipoComprobante], [Letra], [CentroEmisor])
REFERENCES [dbo].[OrdenesProduccionProductos] ([IdSucursal], [NumeroOrdenProduccion], [IdProducto], [Orden], [IdTipoComprobante], [Letra], [CentroEmisor])
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_OrdenesProduccionProductos]
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_TiposComprobantes]
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_Usuarios]
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_Ventas] FOREIGN KEY([IdTipoComprobanteFact], [LetraFact], [CentroEmisorFact], [NumeroComprobanteFact], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_Ventas]
GO
