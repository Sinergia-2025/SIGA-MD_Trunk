
/****** Object:  Table [dbo].[AuditoriaProductos]    Script Date: 13/04/2015 12:27:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AuditoriaProductos](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[NombreProducto] [varchar](60) NOT NULL,
	[Tamano] [decimal](7, 3) NULL,
	[IdUnidadDeMedida] [char](2) NULL,
	[IdMarca] [int] NOT NULL,
	[IdRubro] [int] NOT NULL,
	[MesesGarantia] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[AfectaStock] [bit] NOT NULL,
	[IdModelo] [int] NULL,
	[IdSubRubro] [int] NULL,
	[Foto] [image] NULL,
	[Lote] [bit] NOT NULL,
	[NroSerie] [bit] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[CodigoDeBarras] [varchar](15) NULL,
	[EsServicio] [bit] NOT NULL,
	[Observacion] [varchar](300) NOT NULL,
	[PublicarEnWeb] [bit] NOT NULL,
	[EsDeCompras] [bit] NOT NULL,
	[EsDeVentas] [bit] NOT NULL,
	[DescontarStockComponentes] [bit] NOT NULL,
	[IdMoneda] [int] NOT NULL,
	[EsCompuesto] [bit] NOT NULL,
	[CodigoDeBarrasConPrecio] [bit] NOT NULL,
	[EsAlquilable] [bit] NOT NULL,
	[EquipoMarca] [varchar](20) NULL,
	[EquipoModelo] [varchar](20) NULL,
	[NumeroSerie] [varchar](50) NULL,
	[CaractSII] [varchar](50) NULL,
	[Anio] [int] NULL,
	[PermiteModificarDescripcion] [bit] NOT NULL,
	[Alicuota2] [decimal](6, 2) NULL,
	[PagaIngresosBrutos] [bit] NOT NULL,
	[Embalaje] [int] NOT NULL,
	[Kilos] [decimal](10, 3) NOT NULL,
	[IdFormula] [int] NULL,
	[IdProductoMercosur] [varchar](50) NULL,
	[IdProductoSecretaria] [varchar](50) NULL,
	[PublicarListaDePreciosClientes] [bit] NOT NULL,
	[FacturacionCantidadNegativa] [bit] NOT NULL,
	[SolicitaEnvase] [bit] NOT NULL,
	[AlertaDeCaja] [bit] NOT NULL,
	[NombreCorto] [varchar](30) NULL,
 CONSTRAINT [PK_AuditoriaProductos] PRIMARY KEY CLUSTERED 
(
	[FechaAuditoria] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


