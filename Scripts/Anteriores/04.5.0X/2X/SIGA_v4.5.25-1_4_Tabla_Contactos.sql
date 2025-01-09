
/****** Object:  Table [dbo].[Contactos]    Script Date: 5/8/2016 16:57:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Contactos](
	[IdContacto] [bigint] NOT NULL,
	[NombreContacto] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[CorreoElectronico] [varchar](500) NULL,
	[Celular] [varchar](100) NULL,
	[NombreTrabajo] [varchar](100) NULL,
	[DireccionTrabajo] [varchar](100) NULL,
	[IdLocalidadTrabajo] [int] NULL,
	[TelefonoTrabajo] [varchar](100) NULL,
	[CorreoTrabajo] [varchar](100) NULL,
	[FechaIngresoTrabajo] [datetime] NULL,
	[FechaAlta] [datetime] NOT NULL,
	[IdCategoriaFiscal] [smallint] NOT NULL,
	[Cuit] [varchar](13) NULL,
	[Observacion] [varchar](1000) NULL,
	[IdZonaGeografica] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[NombreDeFantasia] [varchar](100) NULL,
	[Foto] [image] NULL,
	[GeoLocalizacionLat] [float] NULL,
	[GeoLocalizacionLng] [float] NULL,
	[TipoDocContacto] [varchar](5) NULL,
	[NroDocContacto] [bigint] NULL,
	[PaginaWeb] [varchar](100) NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[IdTipoContacto] [int] NOT NULL,
	[Privado] [bit] NOT NULL,
 CONSTRAINT [PK_Contactos] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contactos_TiposContactos] FOREIGN KEY([IdTipoContacto])
REFERENCES [dbo].[TiposContactos] ([IdTipoContacto])
GO

ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contactos_TiposContactos]
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ZonasGeograficas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Contactos ADD CONSTRAINT
	FK_Contactos_Localidades FOREIGN KEY
	(
	IdLocalidad
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contactos ADD CONSTRAINT
	FK_Contactos_Localidades1 FOREIGN KEY
	(
	IdLocalidadTrabajo
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contactos ADD CONSTRAINT
	FK_Contactos_Usuarios FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contactos ADD CONSTRAINT
	FK_Contactos_ZonasGeograficas FOREIGN KEY
	(
	IdZonaGeografica
	) REFERENCES dbo.ZonasGeograficas
	(
	IdZonaGeografica
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contactos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
