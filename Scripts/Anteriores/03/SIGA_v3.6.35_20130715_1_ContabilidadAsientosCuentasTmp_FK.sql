
--Apunto el FK a ContabilidadAsientosTmp en lugar de ContabilidadAsientos !!

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
ALTER TABLE dbo.ContabilidadAsientosTmp SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContabilidadAsientosCuentasTmp
	DROP CONSTRAINT FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientos
GO
ALTER TABLE dbo.ContabilidadAsientos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContabilidadAsientosCuentasTmp ADD CONSTRAINT
	FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp FOREIGN KEY
	(
	IdPlanCuenta,
	IdAsiento
	) REFERENCES dbo.ContabilidadAsientosTmp
	(
	IdPlanCuenta,
	IdAsiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContabilidadAsientosCuentasTmp SET (LOCK_ESCALATION = TABLE)
GO
COMMIT