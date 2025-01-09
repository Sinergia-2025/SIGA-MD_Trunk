
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
ALTER TABLE dbo.Conceptos ADD GrupoGastos char(1) NULL;
GO
UPDATE Conceptos SET GrupoGastos = 'A';
ALTER TABLE dbo.Conceptos ALTER COLUMN GrupoGastos char(1) NOT NULL;
GO
ALTER TABLE dbo.Conceptos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
