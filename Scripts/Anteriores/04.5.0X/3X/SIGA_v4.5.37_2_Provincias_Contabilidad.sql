
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
ALTER TABLE dbo.ContabilidadCuentas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Provincias ADD IdCuentaDebe bigint NULL
ALTER TABLE dbo.Provincias ADD IdCuentaHaber bigint NULL
GO
ALTER TABLE dbo.Provincias ADD CONSTRAINT FK_Provincias_ContabilidadCuentas_Debe
    FOREIGN KEY (IdCuentaDebe)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Provincias ADD CONSTRAINT FK_Provincias_ContabilidadCuentas_Haber
    FOREIGN KEY (IdCuentaHaber)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Provincias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
