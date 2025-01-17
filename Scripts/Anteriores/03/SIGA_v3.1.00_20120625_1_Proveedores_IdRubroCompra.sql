
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
ALTER TABLE dbo.RubrosCompras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Proveedores ADD
	IdRubroCompra int NULL
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_RubrosCompras FOREIGN KEY
	(
	IdRubroCompra
	) REFERENCES dbo.RubrosCompras
	(
	IdRubro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

------------------------------------------------

UPDATE dbo.Proveedores SET IdRubroCompra = 1
GO

ALTER TABLE dbo.Proveedores ALTER COLUMN IdRubroCompra int NOT NULL
GO
