
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
ALTER TABLE dbo.CuentasCorrientesPagos ADD ImporteCapital decimal(12, 2) NULL
ALTER TABLE dbo.CuentasCorrientesPagos ADD ImporteInteres decimal(12, 2) NULL
GO
UPDATE CuentasCorrientesPagos SET ImporteCapital = ImporteCuota, ImporteInteres = 0;
ALTER TABLE dbo.CuentasCorrientesPagos ALTER COLUMN ImporteCapital decimal(12, 2) NOT NULL
ALTER TABLE dbo.CuentasCorrientesPagos ALTER COLUMN ImporteInteres decimal(12, 2) NOT NULL
GO
ALTER TABLE dbo.CuentasCorrientesPagos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
