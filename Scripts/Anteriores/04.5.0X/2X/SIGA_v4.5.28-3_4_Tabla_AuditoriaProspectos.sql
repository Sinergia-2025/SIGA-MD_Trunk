
/****** Object:  Table [dbo].[AuditoriaProspectos]    Script Date: 10/13/2016 18:19:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AuditoriaProspectos](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[TipoDocumentoAnterior] [varchar](5) NULL,
	[NroDocumentoAnterior] [varchar](12) NULL,
	[NombreProspecto] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NULL,
	[NroOperacion] [int] NULL,
	[CorreoElectronico] [varchar](500) NULL,
	[Celular] [varchar](100) NULL,
	[NombreTrabajo] [varchar](100) NULL,
	[DireccionTrabajo] [varchar](100) NULL,
	[IdLocalidadTrabajo] [int] NULL,
	[TelefonoTrabajo] [varchar](100) NULL,
	[CorreoTrabajo] [varchar](100) NULL,
	[FechaIngresoTrabajo] [datetime] NULL,
	[FechaAlta] [datetime] NULL,
	[SaldoPendiente] [decimal](10, 2) NULL,
	[IdCategoria] [int] NULL,
	[IdCategoriaFiscal] [smallint] NULL,
	[Cuit] [varchar](13) NULL,
	[TipoDocVendedor] [varchar](5) NOT NULL,
	[NroDocVendedor] [varchar](12) NOT NULL,
	[Observacion] [varchar](1000) NULL,
	[IdListaPrecios] [int] NOT NULL,
	[IdZonaGeografica] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[LimiteDeCredito] [decimal](10, 2) NULL,
	[IdSucursalAsociada] [int] NULL,
	[NombreDeFantasia] [varchar](100) NULL,
	[DescuentoRecargoPorc] [decimal](6, 2) NULL,
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
	[IdProspecto] [bigint] NOT NULL,
	[CodigoProspecto] [bigint] NOT NULL,
	[IdProspectoGarante] [bigint] NULL,
	[TipoDocProspecto] [varchar](5) NULL,
	[NroDocProspecto] [bigint] NULL,
	[DescuentoRecargoPorc2] [decimal](6, 2) NULL,
	[IdProspectoCtaCte] [bigint] NULL,
	[PaginaWeb] [varchar](100) NULL,
	[LimiteDiasVtoFactura] [int] NULL,
 CONSTRAINT [PK_AuditoriaProspectos] PRIMARY KEY CLUSTERED 
(
	[FechaAuditoria] ASC,
	[IdProspecto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AuditoriaProspectos]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaProspectos_Usuarios] FOREIGN KEY([UsuarioAuditoria])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[AuditoriaProspectos] CHECK CONSTRAINT [FK_AuditoriaProspectos_Usuarios]
GO
