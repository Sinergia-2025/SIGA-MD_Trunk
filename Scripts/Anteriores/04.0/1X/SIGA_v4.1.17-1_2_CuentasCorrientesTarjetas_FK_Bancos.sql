
--SELECT * FROM CuentasCorrientesTarjetas
-- WHERE NOT EXISTS 
--     ( SELECT * FROM Bancos B
--       WHERE B.IdBanco = CuentasCorrientesTarjetas.IdBanco )
--GO


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
ALTER TABLE dbo.Bancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesTarjetas ADD CONSTRAINT
	FK_CuentasCorrientesTarjetas_Bancos FOREIGN KEY
	(
	IdBanco
	) REFERENCES dbo.Bancos
	(
	IdBanco
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientesTarjetas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
