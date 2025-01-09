
ALTER TABLE ClientesDirecciones ADD IdTipoDireccion int null
GO

UPDATE ClientesDirecciones SET IdTipoDireccion = 1 
GO

ALTER TABLE ClientesDirecciones ALTER COLUMN IdTipoDireccion int not null
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
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposDirecciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesDirecciones ADD CONSTRAINT
	FK_ClientesDirecciones_TiposDirecciones FOREIGN KEY
	(
	IdTipoDireccion
	) REFERENCES dbo.TiposDirecciones
	(
	IdTipoDireccion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesDirecciones ADD CONSTRAINT
	FK_ClientesDirecciones_Localidades FOREIGN KEY
	(
	IdLocalidad
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesDirecciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
