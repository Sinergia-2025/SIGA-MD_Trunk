

USE [SIGA]
GO

---Seteo el parametro para que use la base de datos nueva

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('NOMBREBASEADJUNTOSCRM', 'SIGA_CRMAdjuntos.dbo.', null, 'Nombre de la Base de Adjuntos')
GO



USE [SIGA_CRMAdjuntos]
GO

/****** Object:  Table [dbo].[CRMNovedadesSeguimientoAdjuntos]    Script Date: 13/09/2017 09:23:41 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


INSERT INTO SIGA_CRMAdjuntos.dbo.CRMNovedadesSeguimientoAdjuntos
  (IdTipoNovedad, IdNovedad, IdSeguimiento, NombreAdjunto, Adjunto)
SELECT IdTipoNovedad, IdNovedad, IdSeguimiento, NombreAdjunto, Adjunto
 FROM SIGA.dbo.CRMNovedadesSeguimientoAdjuntos
GO

DROP TABLE SIGA.dbo.CRMNovedadesSeguimientoAdjuntos
GO
