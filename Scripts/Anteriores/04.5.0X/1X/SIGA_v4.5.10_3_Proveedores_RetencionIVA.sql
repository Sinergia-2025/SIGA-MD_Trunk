
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
ALTER TABLE dbo.Proveedores ADD
	EsPasibleRetencionIVA bit NOT NULL CONSTRAINT DF_Proveedores_EsPasibleRetencionIVA DEFAULT 0,
	IdRegimenIVA int NULL
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_Regimenes_IVA FOREIGN KEY
	(
	IdRegimenIVA
	) REFERENCES dbo.Regimenes
	(
	IdRegimen
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
