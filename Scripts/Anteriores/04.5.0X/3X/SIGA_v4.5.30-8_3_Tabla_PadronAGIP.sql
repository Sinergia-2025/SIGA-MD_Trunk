--USE [PadronesARBA]
--GO

/****** Object:  Table [dbo].[PadronAGIP]    Script Date: 11/24/2016 13:24:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PadronAGIP](
	[PeriodoInformado] [int] NOT NULL,
	[IdPadronAGIP] [bigint] NOT NULL,
	[FechaPublicacion] [datetime] NOT NULL,
	[FechaVigenciaDesde] [datetime] NOT NULL,
	[FechaVigenciaHasta] [datetime] NOT NULL,
	[CUIT] [bigint] NOT NULL,
	[TipoContribuyente] [varchar](1) NOT NULL,
	[MarcaAlta] [varchar](1) NOT NULL,
	[MarcaAlicuota] [varchar](1) NOT NULL,
	[AlicuotaPercepcion] [decimal](5, 2) NOT NULL,
	[AlicuotaRetencion] [decimal](5, 2) NOT NULL,
	[GrupoPercepcion] [int] NOT NULL,
	[GrupoRetencion] [int] NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PadronAGIP] PRIMARY KEY CLUSTERED 
(
	[PeriodoInformado] ASC,
	[IdPadronAGIP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


