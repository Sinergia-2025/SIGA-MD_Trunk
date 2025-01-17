

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.Impresoras ADD ImprimirLineaALinea bit NULL
GO
ALTER TABLE dbo.Impresoras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ---------------- */

UPDATE dbo.Impresoras SET ImprimirLineaALinea = 'False'
GO

ALTER TABLE dbo.Impresoras ALTER COLUMN ImprimirLineaALinea bit NOT NULL
GO
