
PRINT '1. CRMProspectosInterlocutores';

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMProspectosInterlocutores](
	[IdProspecto] [bigint] NOT NULL,
	[Interlocutor] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CRMProspectosInterlocutores] PRIMARY KEY CLUSTERED 
(
	[IdProspecto] ASC,
	[Interlocutor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

------------------------------------------------------------

PRINT '2. Genero el Historial de Interlocutores';

INSERT INTO CRMProspectosInterlocutores
  (IdProspecto, Interlocutor)
SELECT DISTINCT Cab.IdProspecto, Det.Interlocutor
  FROM CRMNovedades Cab, CRMNovedadesSeguimiento Det
  WHERE Cab.IdTipoNovedad = Det.IdTipoNovedad
    AND Cab.IdNovedad = Det.IdNovedad 
    AND Cab.IdTipoNovedad = 'PROSP'
    AND Det.Interlocutor <> ''
;

------------------------------------------------------------

PRINT '3. CRMProveedoresInterlocutores';

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMProveedoresInterlocutores](
	[IdProveedor] [bigint] NOT NULL,
	[Interlocutor] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CRMProveedoresInterlocutores] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC,
	[Interlocutor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

