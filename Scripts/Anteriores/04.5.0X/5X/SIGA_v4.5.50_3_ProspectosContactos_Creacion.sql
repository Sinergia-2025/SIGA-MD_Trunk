
/****** Object:  Table [dbo].[ProspectosContactos]    Script Date: 08/08/2017 16:30:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProspectosContactos](
	[IdProspecto] [bigint] NOT NULL,
	[IdContacto] [int] NOT NULL,
	[NombreContacto] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](100) NULL,
	[CorreoElectronico] [varchar](500) NULL,
	[Celular] [varchar](100) NULL,
	[Observacion] [varchar](1000) NULL,
	[Activo] [bit] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[IdTipoContacto] [int] NOT NULL,
 CONSTRAINT [PK_ProspectosContactos] PRIMARY KEY CLUSTERED 
(
	[IdProspecto] ASC,
	[IdContacto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProspectosContactos]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosContactos_Prospectos] FOREIGN KEY([IdProspecto])
REFERENCES [dbo].[Prospectos] ([IdProspecto])
GO

ALTER TABLE [dbo].[ProspectosContactos] CHECK CONSTRAINT [FK_ProspectosContactos_Prospectos]
GO

ALTER TABLE [dbo].[ProspectosContactos]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosContactos_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO

ALTER TABLE [dbo].[ProspectosContactos] CHECK CONSTRAINT [FK_ProspectosContactos_Localidades]
GO

ALTER TABLE [dbo].[ProspectosContactos]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosContactos_TiposContactos] FOREIGN KEY([IdTipoContacto])
REFERENCES [dbo].[TiposContactos] ([IdTipoContacto])
GO

ALTER TABLE [dbo].[ProspectosContactos] CHECK CONSTRAINT [FK_ProspectosContactos_TiposContactos]
GO

ALTER TABLE [dbo].[ProspectosContactos]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosContactos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[ProspectosContactos] CHECK CONSTRAINT [FK_ProspectosContactos_Usuarios]
GO
