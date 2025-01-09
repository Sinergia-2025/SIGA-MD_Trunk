
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PadronARBA](
	[PeriodoInformado] [int] NOT NULL,
	[IdPadronARBA] [bigint] NOT NULL,
	[TipoRegimen] [varchar](1) NOT NULL,
	[FechaPublicacion] [datetime] NOT NULL,
	[FechaVigenciaDesde] [datetime] NOT NULL,
	[FechaVigenciaHasta] [datetime] NOT NULL,
	[CUIT] [bigint] NOT NULL,
	[TipoContribuyente] [varchar](1) NOT NULL,
	[AccionARBA] [varchar](1) NOT NULL,
	[CambioAlicuota] [bit] NOT NULL,
	[Alicuota] [decimal](5, 2) NOT NULL,
	[Grupo] [int] NOT NULL,
 CONSTRAINT [PK_PadronARBA] PRIMARY KEY CLUSTERED 
(
	[PeriodoInformado] ASC,
	[IdPadronARBA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_PadronARBA]    Script Date: 02/12/2016 17:04:13 ******/
CREATE NONCLUSTERED INDEX [IX_PadronARBA] ON [dbo].[PadronARBA] 
(
	[CUIT] ASC,
	[PeriodoInformado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
