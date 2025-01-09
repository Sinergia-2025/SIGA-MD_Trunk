
/****** Object:  Table [dbo].[CRMNovedadesSeguimientoAdjuntos]    Script Date: 01/12/2017 16:49:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMNovedadesSeguimientoAdjuntos](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNovedad] [int] NOT NULL,
	[IdSeguimiento] [int] NOT NULL,
	[NombreAdjunto] [varchar](260) NULL,
	[Adjunto] [varbinary](max) NULL,
 CONSTRAINT [PK_CRMNovedadesSeguimientoAdjuntos] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC,
	[IdNovedad] ASC,
	[IdSeguimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
