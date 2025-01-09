
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposDeExension](
	[IdTipoDeExension] [smallint] NOT NULL,
	[NombreTipoDeExension] [varchar](40) NOT NULL,
	[NombreTipoDeExensionAbrev] [varchar](10) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoDeExension] PRIMARY KEY CLUSTERED 
(
	[IdTipoDeExension] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/* ------------------------- */

INSERT INTO TiposDeExension
     (IdTipoDeExension, NombreTipoDeExension, NombreTipoDeExensionAbrev, Activo)
  VALUES
     (0, 'No exento', 'No exento', 'True'),
     (1, 'Certificado de no retención', 'CertNoRet', 'True'),
     (2, 'Certificado de exención', 'CertExenc', 'True'),
     (3, 'Certificado de no percepción', 'CertNoPerc', 'True'),
     (4, 'Art. 3ero. Res 15/97 y modif.', 'Art3R15/97', 'True')
GO
