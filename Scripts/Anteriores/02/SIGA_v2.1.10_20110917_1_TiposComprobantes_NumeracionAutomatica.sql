
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
ALTER TABLE dbo.TiposComprobantes ADD NumeracionAutomatica bit NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ---------- */

UPDATE TiposComprobantes SET NumeracionAutomatica = 'False'
GO

ALTER TABLE dbo.TiposComprobantes ALTER COLUMN NumeracionAutomatica bit NOT NULL
GO

UPDATE TiposComprobantes SET NumeracionAutomatica = 'True'
  WHERE IdTipoComprobante IN ('REMITOCOM', 'REMITOCOM-NC', 'GASTO')
GO
