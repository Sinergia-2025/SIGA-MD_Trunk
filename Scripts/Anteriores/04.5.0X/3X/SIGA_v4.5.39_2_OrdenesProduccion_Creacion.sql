
/****** Object:  Table [dbo].[OrdenesProduccion]    Script Date: 18/4/2017 16:21:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdenesProduccion](
	[IdSucursal] [int] NOT NULL,
	[NumeroOrdenProduccion] [int] NOT NULL,
	[FechaOrdenProduccion] [datetime] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[DescuentoRecargo] [decimal](14, 4) NOT NULL,
	[DescuentoRecargoPorc] [decimal](6, 2) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[TipoDocVendedor] [varchar](5) NULL,
	[NroDocVendedor] [varchar](12) NULL,
	[IdFormasPago] [int] NULL,
	[IdTransportista] [int] NULL,
	[CotizacionDolar] [decimal](7, 3) NULL,
	[IdTipoComprobanteFact] [varchar](15) NULL,
	[ImporteBruto] [decimal](12, 2) NOT NULL,
	[SubTotal] [decimal](12, 2) NOT NULL,
	[TotalImpuestos] [decimal](12, 2) NOT NULL,
	[TotalImpuestoInterno] [decimal](14, 2) NOT NULL,
	[ImporteTotal] [decimal](12, 2) NOT NULL,
	[IdEstadoVisita] [int] NOT NULL,
	[NumeroOrdenCompra] [bigint] NULL,
 CONSTRAINT [PK_OrdenesProduccion] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroOrdenProduccion] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_Clientes]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_Empleados] FOREIGN KEY([TipoDocVendedor], [NroDocVendedor])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_Empleados]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_EstadosVisitas] FOREIGN KEY([IdEstadoVisita])
REFERENCES [dbo].[EstadosVisitas] ([IdEstadoVisita])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_EstadosVisitas]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_Sucursales]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_TiposComprobantes]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_TiposComprobantesFact] FOREIGN KEY([IdTipoComprobanteFact])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_TiposComprobantesFact]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_Transportistas] FOREIGN KEY([IdTransportista])
REFERENCES [dbo].[Transportistas] ([IdTransportista])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_Transportistas]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_Usuarios]
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_VentasFormasPago] FOREIGN KEY([IdFormasPago])
REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago])
GO

ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_VentasFormasPago]
GO


