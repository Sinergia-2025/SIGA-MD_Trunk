
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
ALTER TABLE dbo.SueldosCategorias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.SueldosCierreLiqDatos ADD IdCategoria int NULL
GO
ALTER TABLE dbo.SueldosCierreLiqDatos ADD CONSTRAINT
	FK_SueldosCierreLiqDatos_SueldosCategorias FOREIGN KEY
	(
	IdCategoria
	) REFERENCES dbo.SueldosCategorias
	(
	idCategoria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.SueldosCierreLiqDatos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* -------------------- */

UPDATE SueldosCierreLiqDatos 
   SET SueldosCierreLiqDatos.IdCategoria = SP.IdCategoria
 FROM SueldosCierreLiqDatos SCLD
 INNER JOIN SueldosPersonal SP ON SCLD.IdLegajo = SP.IdLegajo
 WHERE SCLD.IdCategoria IS NULL
GO

/* -------------------- */

ALTER TABLE dbo.SueldosCierreLiqDatos ALTER COLUMN IdCategoria int NOT NULL
GO
