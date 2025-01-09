
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
ALTER TABLE dbo.PeriodosFiscales ADD VentasHabilitadas bit NULL
GO
UPDATE PeriodosFiscales SET VentasHabilitadas = CASE WHEN FechaCierre IS NULL THEN 1 ELSE 0 END;

ALTER TABLE dbo.PeriodosFiscales ALTER COLUMN VentasHabilitadas bit NOT NULL
GO
ALTER TABLE dbo.PeriodosFiscales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
