
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
ALTER TABLE dbo.Tarjetas ADD PorcIntereses decimal(12, 2) NULL
ALTER TABLE dbo.Tarjetas ADD CantidadCuotas int NULL
GO
ALTER TABLE dbo.Tarjetas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------- */

UPDATE dbo.Tarjetas 
   SET PorcIntereses = 0
      ,CantidadCuotas = 0
GO

ALTER TABLE dbo.Tarjetas ALTER COLUMN PorcIntereses decimal(12, 2) NOT NULL
GO
ALTER TABLE dbo.Tarjetas ALTER COLUMN CantidadCuotas int NOT NULL
GO
