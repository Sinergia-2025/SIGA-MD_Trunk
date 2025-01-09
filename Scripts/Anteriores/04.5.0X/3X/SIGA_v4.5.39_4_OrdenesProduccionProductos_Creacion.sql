
/****** Object:  Table [dbo].[OrdenesProduccionProductos]    Script Date: 27/4/2017 15:33:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdenesProduccionProductos](
	[IdSucursal] [int] NOT NULL,
	[NumeroOrdenProduccion] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Cantidad] [decimal](12, 4) NOT NULL,
	[Precio] [decimal](12, 4) NOT NULL,
	[Costo] [decimal](12, 4) NOT NULL,
	[ImporteTotal] [decimal](12, 4) NOT NULL,
	[NombreProducto] [varchar](60) NOT NULL,
	[CantEntregada] [decimal](12, 4) NOT NULL,
	[CantEnProceso] [decimal](12, 4) NOT NULL,
	[Orden] [int] NOT NULL,
	[DescuentoRecargoProducto] [decimal](14, 4) NOT NULL,
	[DescuentoRecargoPorc2] [decimal](6, 2) NOT NULL,
	[DescuentoRecargoPorc] [decimal](6, 2) NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[AlicuotaImpuesto] [decimal](6, 2) NOT NULL,
	[ImporteImpuesto] [decimal](14, 4) NOT NULL,
	[PrecioLista] [decimal](12, 4) NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[FechaActualizacion] [datetime] NULL,
	[IdListaPrecios] [int] NOT NULL,
	[NombreListaPrecios] [varchar](50) NOT NULL,
	[ImporteImpuestoInterno] [decimal](14, 2) NOT NULL,
	[PrecioNeto] [decimal](14, 4) NOT NULL,
	[ImporteTotalNeto] [decimal](14, 4) NOT NULL,
	[DescRecGeneral] [decimal](14, 4) NOT NULL,
	[DescRecGeneralProducto] [decimal](14, 4) NOT NULL,
	[Kilos] [decimal](10, 3) NOT NULL,
	[IdCriticidad] [varchar](10) NULL,
	[FechaEntrega] [date] NULL,
	[CantAnulada] [decimal](12, 4) NOT NULL,
	[CantPendiente] [decimal](12, 4) NOT NULL,
 CONSTRAINT [PK_OrdenesProduccionProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroOrdenProduccion] ASC,
	[IdProducto] ASC,
	[Orden] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductos_OrdenesProduccion] FOREIGN KEY([IdSucursal], [NumeroOrdenProduccion], [IdTipoComprobante], [Letra], [CentroEmisor])
REFERENCES [dbo].[OrdenesProduccion] ([IdSucursal], [NumeroOrdenProduccion], [IdTipoComprobante], [Letra], [CentroEmisor])
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos] CHECK CONSTRAINT [FK_OrdenesProduccionProductos_OrdenesProduccion]
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductos_OrdenesProduccionCriticidades] FOREIGN KEY([IdCriticidad])
REFERENCES [dbo].[OrdenesProduccionCriticidades] ([IdCriticidad])
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos] CHECK CONSTRAINT [FK_OrdenesProduccionProductos_OrdenesProduccionCriticidades]
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos] CHECK CONSTRAINT [FK_OrdenesProduccionProductos_Productos]
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductos_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos] CHECK CONSTRAINT [FK_OrdenesProduccionProductos_TiposComprobantes]
GO
