
/****** Object:  Table [dbo].[Prospectos]    Script Date: 10/13/2016 13:50:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Prospectos](
	[IdProspecto] [bigint] NOT NULL,
	[CodigoProspecto] [bigint] NOT NULL,
	[NombreProspecto] [varchar](100) NOT NULL,
	[TipoDocProspecto] [varchar](5) NULL,
	[NroDocProspecto] [bigint] NULL,
	[IdProspectoCtaCte] [bigint] NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[NroOperacion] [int] NULL,
	[CorreoElectronico] [varchar](500) NULL,
	[Celular] [varchar](100) NULL,
	[NombreTrabajo] [varchar](100) NULL,
	[DireccionTrabajo] [varchar](100) NULL,
	[IdLocalidadTrabajo] [int] NULL,
	[TelefonoTrabajo] [varchar](100) NULL,
	[CorreoTrabajo] [varchar](100) NULL,
	[FechaIngresoTrabajo] [datetime] NULL,
	[FechaAlta] [datetime] NOT NULL,
	[SaldoPendiente] [decimal](10, 2) NULL,
	[IdCategoria] [int] NOT NULL,
	[IdCategoriaFiscal] [smallint] NOT NULL,
	[Cuit] [varchar](13) NULL,
	[TipoDocVendedor] [varchar](5) NOT NULL,
	[NroDocVendedor] [varchar](12) NOT NULL,
	[Observacion] [varchar](1000) NULL,
	[IdListaPrecios] [int] NOT NULL,
	[IdZonaGeografica] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[LimiteDeCredito] [decimal](10, 2) NOT NULL,
	[IdSucursalAsociada] [int] NULL,
	[NombreDeFantasia] [varchar](100) NULL,
	[DescuentoRecargoPorc] [decimal](6, 2) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[IdFormasPago] [int] NULL,
	[Foto] [image] NULL,
	[IdTransportista] [int] NULL,
	[IngresosBrutos] [varchar](20) NULL,
	[InscriptoIBStaFe] [bit] NOT NULL,
	[LocalIB] [bit] NOT NULL,
	[ConvMultilateralIB] [bit] NOT NULL,
	[NumeroLote] [bigint] NULL,
	[IdCaja] [int] NULL,
	[GeoLocalizacionLat] [float] NULL,
	[GeoLocalizacionLng] [float] NULL,
	[IdTipoDeExension] [smallint] NULL,
	[AnioExension] [int] NULL,
	[NroCertExension] [varchar](6) NULL,
	[NroCertPropio] [varchar](12) NULL,
	[IdProspectoGarante] [bigint] NULL,
	[DescuentoRecargoPorc2] [decimal](6, 2) NULL,
	[PaginaWeb] [varchar](100) NULL,
	[LimiteDiasVtoFactura] [int] NOT NULL,
	[TipoDocumentoAnterior] [varchar](5) NULL,
	[NroDocumentoAnterior] [varchar](12) NULL,
 CONSTRAINT [PK_Prospectos] PRIMARY KEY CLUSTERED 
(
	[IdProspecto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Prospectos] UNIQUE NONCLUSTERED 
(
	[CodigoProspecto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_Categorias]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_CategoriasFiscales] FOREIGN KEY([IdCategoriaFiscal])
REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_CategoriasFiscales]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_Prospectos] FOREIGN KEY([IdProspectoCtaCte])
REFERENCES [dbo].[Prospectos] ([IdProspecto])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_Prospectos]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_Empleados] FOREIGN KEY([TipoDocVendedor], [NroDocVendedor])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_Empleados]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_ListasDePrecios]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_Localidades]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_LocalidadesTrabajo] FOREIGN KEY([IdLocalidadTrabajo])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_LocalidadesTrabajo]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_TiposComprobantes]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_TiposDeExension] FOREIGN KEY([IdTipoDeExension])
REFERENCES [dbo].[TiposDeExension] ([IdTipoDeExension])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_TiposDeExension]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_TiposDocumento] FOREIGN KEY([TipoDocumentoAnterior])
REFERENCES [dbo].[TiposDocumento] ([TipoDocumento])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_TiposDocumento]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_Transportistas] FOREIGN KEY([IdTransportista])
REFERENCES [dbo].[Transportistas] ([IdTransportista])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_Transportistas]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_VentasFormasPago] FOREIGN KEY([IdFormasPago])
REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_VentasFormasPago]
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_ZonasGeograficas] FOREIGN KEY([IdZonaGeografica])
REFERENCES [dbo].[ZonasGeograficas] ([IdZonaGeografica])
GO

ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_ZonasGeograficas]
GO

ALTER TABLE [dbo].[Prospectos] ADD  DEFAULT ((0)) FOR [DescuentoRecargoPorc2]
GO

ALTER TABLE [dbo].[Prospectos] ADD  DEFAULT ((0)) FOR [LimiteDiasVtoFactura]
GO


