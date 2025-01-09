
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
ALTER TABLE dbo.ContabilidadAsientosCuentas ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.ContabilidadAsientosCuentas ADD CONSTRAINT FK_ContabilidadAsientosCuentas_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.ContabilidadAsientosCuentas SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.ContabilidadAsientosCuentasTmp ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.ContabilidadAsientosCuentasTmp ADD CONSTRAINT FK_ContabilidadAsientosCuentasTmp_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.ContabilidadAsientosCuentasTmp SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
