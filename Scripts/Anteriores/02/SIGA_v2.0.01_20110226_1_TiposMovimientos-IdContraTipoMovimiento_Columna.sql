
ALTER TABLE TiposMovimientos ADD IdContraTipoMovimiento varchar(15) NULL
GO

UPDATE TiposMovimientos 
     SET IdContraTipoMovimiento = 'REC-SUC'
   WHERE IdTipoMovimiento = 'ENV-SUC'
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
ALTER TABLE dbo.TiposMovimientos ADD CONSTRAINT
	FK_TiposMovimientos_TiposMovimientos FOREIGN KEY
	(
	IdContraTipoMovimiento
	) REFERENCES dbo.TiposMovimientos
	(
	IdTipoMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TiposMovimientos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

