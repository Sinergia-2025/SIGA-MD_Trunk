
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
ALTER TABLE dbo.ContabilidadCuentas DROP CONSTRAINT FK_ContabilidadCuentas_ContabilidadCentrosCostos
GO
ALTER TABLE dbo.ContabilidadCentrosCostos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContabilidadCuentas DROP COLUMN IdCentroCosto
GO
ALTER TABLE dbo.ContabilidadCuentas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.ContabilidadCentrosCostos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT FK_Productos_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProductos ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.ContabilidadCentrosCostos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasDeCajas ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.CuentasDeCajas ADD CONSTRAINT FK_CuentasDeCajas_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CuentasDeCajas SET (LOCK_ESCALATION = TABLE)
GO

/* ---------------- */

ALTER TABLE dbo.CuentasBancos ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.CuentasBancos ADD CONSTRAINT FK_CuentasBancos_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CuentasBancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
