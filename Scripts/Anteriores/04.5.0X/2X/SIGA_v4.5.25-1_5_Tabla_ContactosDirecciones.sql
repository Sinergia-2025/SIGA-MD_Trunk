
/****** Object:  Table [dbo].[ContactosDirecciones]    Script Date: 5/8/2016 16:57:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContactosDirecciones](
	[IdContacto] [bigint] NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[IdTipoDireccion] [int] NOT NULL,
	[Celular] [varchar](100) NULL,
	[Telefono] [varchar](100) NULL,
	[CorreoElectronico] [varchar](500) NULL,
 CONSTRAINT [PK_ContactosDirecciones] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC,
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ContactosDirecciones]  WITH CHECK ADD  CONSTRAINT [FK_ContactosDirecciones_Contactos] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contactos] ([IdContacto])
GO

ALTER TABLE [dbo].[ContactosDirecciones] CHECK CONSTRAINT [FK_ContactosDirecciones_Contactos]
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
ALTER TABLE dbo.TiposDirecciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContactosDirecciones ADD CONSTRAINT
	FK_ContactosDirecciones_Localidades FOREIGN KEY
	(
	IdLocalidad
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContactosDirecciones ADD CONSTRAINT
	FK_ContactosDirecciones_TiposDirecciones FOREIGN KEY
	(
	IdTipoDireccion
	) REFERENCES dbo.TiposDirecciones
	(
	IdTipoDireccion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContactosDirecciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
