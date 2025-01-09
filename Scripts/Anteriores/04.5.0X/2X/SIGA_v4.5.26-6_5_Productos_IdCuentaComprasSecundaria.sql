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
ALTER TABLE dbo.Productos DROP CONSTRAINT FK_Productos_ContabilidadCuentas_Secundaria
GO
ALTER TABLE dbo.Productos DROP COLUMN IdCuentaVentaSecundaria
GO
ALTER TABLE dbo.ContabilidadCuentas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD IdCuentaComprasSecundaria bigint NULL
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
    FK_Productos_ContabilidadCuentas_ComprasSecundaria FOREIGN KEY (IdCuentaComprasSecundaria)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.AuditoriaProductos DROP COLUMN IdCuentaVentaSecundaria
GO
ALTER TABLE dbo.AuditoriaProductos ADD IdCuentaComprasSecundaria bigint NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
