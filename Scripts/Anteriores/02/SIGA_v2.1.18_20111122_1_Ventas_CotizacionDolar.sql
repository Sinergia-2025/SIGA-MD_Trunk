
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
ALTER TABLE dbo.Ventas ADD CotizacionDolar decimal(7, 3) NULL
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* ------------ */

UPDATE dbo.Ventas SET CotizacionDolar = 0
GO

ALTER TABLE dbo.Ventas ALTER COLUMN CotizacionDolar decimal(7, 3) NOT NULL
GO


