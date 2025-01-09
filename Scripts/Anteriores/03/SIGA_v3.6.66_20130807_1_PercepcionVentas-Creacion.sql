
CREATE TABLE [dbo].[PercepcionVentas](
	[IdSucursal] [int] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[EmisorPercepcion] [int] NOT NULL,
	[NumeroPercepcion] [bigint] NOT NULL,
	[TipoDocCliente] [varchar](5) NOT NULL,
	[NroDocCliente] [varchar](12) NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[BaseImponible] [decimal](14, 4) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[ImporteTotal] [decimal](14, 4) NOT NULL,
	[IdCajaIngreso] [int] NULL,
	[NroPlanillaIngreso] [int] NULL,
	[NroMovimientoIngreso] [int] NULL,
	[IdEstado] [varchar](10) NOT NULL,
	[IdActividad] [int] NOT NULL,
	[IdProvincia] [char](2) NOT NULL,
 CONSTRAINT [PK_PercepcionVentas_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorPercepcion] ASC,
	[NumeroPercepcion] ASC,
	[TipoDocCliente] ASC,
	[NroDocCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PercepcionVentas]  WITH CHECK ADD  CONSTRAINT [FK_PercepcionVentas_CajasDetalle] FOREIGN KEY([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso])
REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento])
GO

ALTER TABLE [dbo].[PercepcionVentas] CHECK CONSTRAINT [FK_PercepcionVentas_CajasDetalle]
GO

ALTER TABLE [dbo].[PercepcionVentas]  WITH CHECK ADD  CONSTRAINT [FK_PercepcionVentas_Clientes] FOREIGN KEY([TipoDocCliente], [NroDocCliente])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[PercepcionVentas] CHECK CONSTRAINT [FK_PercepcionVentas_Clientes]
GO

ALTER TABLE [dbo].[PercepcionVentas]  WITH CHECK ADD  CONSTRAINT [FK_PercepcionVentas_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[PercepcionVentas] CHECK CONSTRAINT [FK_PercepcionVentas_Sucursales]
GO

ALTER TABLE [dbo].[PercepcionVentas]  WITH CHECK ADD  CONSTRAINT [FK_PercepcionVentas_TiposImpuestos] FOREIGN KEY([IdTipoImpuesto])
REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
GO

ALTER TABLE [dbo].[PercepcionVentas] CHECK CONSTRAINT [FK_PercepcionVentas_TiposImpuestos]
GO


