
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
ALTER TABLE dbo.ComprasProductos ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT FK_ComprasProductos_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.ComprasProductos SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE dbo.VentasProductos ADD IdCentroCosto int NULL
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT
	FK_VentasProductos_ContabilidadCentrosCostos FOREIGN KEY (IdCentroCosto)
	REFERENCES dbo.ContabilidadCentrosCostos (IdCentroCosto)
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE dbo.CajasDetalle ADD
	IdCentroCosto int NULL
GO
ALTER TABLE dbo.CajasDetalle ADD CONSTRAINT FK_CajasDetalle_ContabilidadCentrosCostos
    FOREIGN KEY (IdCentroCosto)
    REFERENCES dbo.ContabilidadCentrosCostos(IdCentroCosto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CajasDetalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
