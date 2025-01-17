

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
ALTER TABLE dbo.Retenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones ADD CONSTRAINT
	FK_CuentasCorrientesRetenciones_Retenciones FOREIGN KEY
	(
	IdSucursal,
	IdTipoImpuesto,
	EmisorRetencion,
	NumeroRetencion
	) REFERENCES dbo.Retenciones
	(
	idSucursal,
	IdTipoImpuesto,
	EmisorRetencion,
	NumeroRetencion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
