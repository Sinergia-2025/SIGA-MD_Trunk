
PRINT '1. CRMTiposNovedades';

/****** Object:  Table [dbo].[CRMTiposNovedades]    Script Date: 10/14/2016 18:25:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMTiposNovedades](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[NombreTipoNovedad] [varchar](30) NULL,
 CONSTRAINT [PK_CRMTiposNovedades] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


PRINT '2. CRMPrioridadesNovedades';

/****** Object:  Table [dbo].[CRMPrioridadesNovedades]    Script Date: 10/27/2016 11:44:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMPrioridadesNovedades](
	[IdPrioridadNovedad] [int] NOT NULL,
	[NombrePrioridadNovedad] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[PorDefecto] [bit] NOT NULL,
 CONSTRAINT [PK_CRMPrioridadesNovedades] PRIMARY KEY CLUSTERED 
(
	[IdPrioridadNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMPrioridadesNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMPrioridadesNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMPrioridadesNovedades] CHECK CONSTRAINT [FK_CRMPrioridadesNovedades_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMPrioridadesNovedades] ADD CONSTRAINT [DF_CRMPrioridadesNovedades_PorDefecto] DEFAULT ((0)) FOR [PorDefecto]
GO


PRINT '3. CRMEstadosNovedades';

/****** Object:  Table [dbo].[CRMEstadosNovedades]    Script Date: 10/27/2016 11:44:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMEstadosNovedades](
	[IdEstadoNovedad] [int] NOT NULL,
	[NombreEstadoNovedad] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[SolicitaUsuario] [bit] NOT NULL,
	[Finalizado] [bit] NOT NULL,
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[PorDefecto] [bit] NOT NULL,
 CONSTRAINT [PK_CRMEstadosNovedades] PRIMARY KEY CLUSTERED 
(
	[IdEstadoNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMEstadosNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMEstadosNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMEstadosNovedades] CHECK CONSTRAINT [FK_CRMEstadosNovedades_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMEstadosNovedades] ADD CONSTRAINT [DF_CRMEstadosNovedades_PorDefecto] DEFAULT ((0)) FOR [PorDefecto]
GO


PRINT '4. CRMCategoriasNovedades';

/****** Object:  Table [dbo].[CRMCategoriasNovedades]    Script Date: 10/27/2016 11:44:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMCategoriasNovedades](
	[IdCategoriaNovedad] [int] NOT NULL,
	[NombreCategoriaNovedad] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[PorDefecto] [bit] NOT NULL,
 CONSTRAINT [PK_CRMCategoriasNovedades] PRIMARY KEY CLUSTERED 
(
	[IdCategoriaNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMCategoriasNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMCategoriasNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMCategoriasNovedades] CHECK CONSTRAINT [FK_CRMCategoriasNovedades_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMCategoriasNovedades] ADD CONSTRAINT [DF_CRMCategoriasNovedades_PorDefecto] DEFAULT ((0)) FOR [PorDefecto]
GO


PRINT '5. CRMMediosComunicacionesNovedades';

/****** Object:  Table [dbo].[CRMMediosComunicacionesNovedades]    Script Date: 10/27/2016 11:43:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMMediosComunicacionesNovedades](
	[IdMedioComunicacionNovedad] [int] NOT NULL,
	[NombreMedioComunicacionNovedad] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[PorDefecto] [bit] NOT NULL,
 CONSTRAINT [PK_CRMMediosComunicacionesNovedades] PRIMARY KEY CLUSTERED 
(
	[IdMedioComunicacionNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMMediosComunicacionesNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMMediosComunicacionesNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMMediosComunicacionesNovedades] CHECK CONSTRAINT [FK_CRMMediosComunicacionesNovedades_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMMediosComunicacionesNovedades] ADD CONSTRAINT [DF_CRMMediosComunicacionesNovedades_PorDefecto] DEFAULT ((0)) FOR [PorDefecto]
GO


PRINT '6. CRMNovedades';

/****** Object:  Table [dbo].[CRMNovedades]    Script Date: 10/28/2016 13:43:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMNovedades](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNovedad] [int] NOT NULL,
	[FechaNovedad] [datetime] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[IdPrioridadNovedad] [int] NOT NULL,
	[IdCategoriaNovedad] [int] NOT NULL,
	[IdEstadoNovedad] [int] NOT NULL,
	[FechaEstadoNovedad] [datetime] NOT NULL,
	[IdUsuarioEstadoNovedad] [varchar](10) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[IdUsuarioAlta] [varchar](10) NOT NULL,
	[IdUsuarioAsignado] [varchar](10) NULL,
	[Avance] [decimal](5, 2) NOT NULL,
	[IdMedioComunicacionNovedad] [int] NULL,
	[IdCliente] [bigint] NULL,
	[IdProspecto] [bigint] NULL,
	[IdFuncion] [varchar](30) NULL,
	[IdSistema] [varchar](10) NULL,
	[FechaProximoContacto] [datetime] NULL,
	[BanderaColor] [int] NULL,
	[Interlocutor] [varchar](30) NULL,
 CONSTRAINT [PK_CRMNovedades] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC,
	[IdNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_Clientes]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_CRMCategoriasNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_CRMCategoriasNovedades]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_CRMCategoriasNovedades1] FOREIGN KEY([IdCategoriaNovedad])
REFERENCES [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_CRMCategoriasNovedades1]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_CRMEstadosNovedades] FOREIGN KEY([IdEstadoNovedad])
REFERENCES [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_CRMEstadosNovedades]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_CRMMediosComunicacionesNovedades] FOREIGN KEY([IdMedioComunicacionNovedad])
REFERENCES [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_CRMMediosComunicacionesNovedades]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_CRMPrioridadesNovedades] FOREIGN KEY([IdPrioridadNovedad])
REFERENCES [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_CRMPrioridadesNovedades]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_Funciones]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_Prospectos] FOREIGN KEY([IdProspecto])
REFERENCES [dbo].[Prospectos] ([IdProspecto])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_Prospectos]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_Usuarios_Alta] FOREIGN KEY([IdUsuarioAlta])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_Usuarios_Alta]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_Usuarios_Asignado] FOREIGN KEY([IdUsuarioAsignado])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_Usuarios_Asignado]
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_Usuarios_EstadoNovedad] FOREIGN KEY([IdUsuarioEstadoNovedad])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_Usuarios_EstadoNovedad]
GO


PRINT '7. CRMNovedadesSeguimiento';

/****** Object:  Table [dbo].[CRMNovedadesSeguimiento]    Script Date: 10/28/2016 13:43:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMNovedadesSeguimiento](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNovedad] [int] NOT NULL,
	[IdSeguimiento] [int] NOT NULL,
	[FechaSeguimiento] [datetime] NOT NULL,
	[Comentario] [varchar](500) NOT NULL,
	[EsComentario] [bit] NOT NULL,
	[UsuarioSeguimiento] [varchar](10) NOT NULL,
	[Interlocutor] [varchar](30) NULL,
 CONSTRAINT [PK_CRMNovedadesSeguimiento] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC,
	[IdNovedad] ASC,
	[IdSeguimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMNovedadesSeguimiento]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesSeguimiento_CRMNovedades] FOREIGN KEY([IdTipoNovedad], [IdNovedad])
REFERENCES [dbo].[CRMNovedades] ([IdTipoNovedad], [IdNovedad])
GO

ALTER TABLE [dbo].[CRMNovedadesSeguimiento] CHECK CONSTRAINT [FK_CRMNovedadesSeguimiento_CRMNovedades]
GO


PRINT '8. CRMTiposNovedadesDinamicos';

/****** Object:  Table [dbo].[CRMTiposNovedadesDinamicos]    Script Date: 10/19/2016 17:08:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMTiposNovedadesDinamicos](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNombreDinamico] [varchar](30) NOT NULL,
	[EsRequerido] [bit] NOT NULL,
 CONSTRAINT [PK_CRMTiposNovedadesDinamicos] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC,
	[IdNombreDinamico] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMTiposNovedadesDinamicos]  WITH CHECK ADD  CONSTRAINT [FK_CRMTiposNovedadesDinamicos_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMTiposNovedadesDinamicos] CHECK CONSTRAINT [FK_CRMTiposNovedadesDinamicos_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMTiposNovedadesDinamicos] ADD CONSTRAINT [DF_CRMTiposNovedadesDinamicos_EsRequerido] DEFAULT ((0)) FOR [EsRequerido]
GO


PRINT '9. CRMClientesInterlocutores';

/****** Object:  Table [dbo].[CRMClientesInterlocutores]    Script Date: 10/28/2016 13:42:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMClientesInterlocutores](
	[IdCliente] [bigint] NOT NULL,
	[Interlocutor] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CRMClientesInterlocutores] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[Interlocutor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

