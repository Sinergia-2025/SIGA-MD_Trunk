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
ALTER TABLE dbo.Categorias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Proveedores ADD	IdCategoria int NULL
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_Categorias FOREIGN KEY
	(
	IdCategoria
	) REFERENCES dbo.Categorias
	(
	IdCategoria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*--------------*/

UPDATE dbo.Proveedores SET
	IdCategoria = 1
GO


ALTER TABLE dbo.Proveedores ALTER COLUMN IdCategoria int NOT NULL
GO
