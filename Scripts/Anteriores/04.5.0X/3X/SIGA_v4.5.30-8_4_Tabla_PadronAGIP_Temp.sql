--USE [PadronesARBA]
--GO

/****** Object:  Table [dbo].[PadronAGIP_Temp]    Script Date: 11/23/2016 19:36:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PadronAGIP_Temp](
	[FechaPublicacion] [varchar](8) NOT NULL,
	[FechaVigenciaDesde] [varchar](8) NOT NULL,
	[FechaVigenciaHasta] [varchar](8) NOT NULL,
	[CUIT] [varchar](11) NOT NULL,
	[TipoContribuyente] [varchar](1) NOT NULL,
	[MarcaAlta] [varchar](1) NOT NULL,
	[MarcaAlicuota] [varchar](1) NOT NULL,
	[AlicuotaPercepcion] [varchar](8) NOT NULL,
	[AlicuotaRetencion] [varchar](8) NOT NULL,
	[GrupoPercepcion] [varchar](2) NOT NULL,
	[GrupoRetencion] [varchar](2) NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


