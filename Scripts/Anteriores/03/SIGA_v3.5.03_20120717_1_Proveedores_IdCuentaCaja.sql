ALTER TABLE RubrosCompras DROP CONSTRAINT FK_RubrosCompras_CuentasDeCajas
GO

ALTER TABLE RubrosCompras DROP COLUMN IdCuentaCaja
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
ALTER TABLE dbo.CuentasDeCajas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Proveedores ADD IdCuentaCaja int NULL
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_CuentasDeCajas FOREIGN KEY
	(
	IdCuentaCaja
	) REFERENCES dbo.CuentasDeCajas
	(
	IdCuentaCaja
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* -------------- */

UPDATE dbo.Proveedores SET IdCuentaCaja = 4	--Pagos a Proveedores
GO

ALTER TABLE dbo.Proveedores ALTER COLUMN IdCuentaCaja int NOT NULL
GO

