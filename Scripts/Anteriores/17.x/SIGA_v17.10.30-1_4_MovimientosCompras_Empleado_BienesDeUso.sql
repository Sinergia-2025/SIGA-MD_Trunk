
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
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimientosCompras ADD TipoDocEmpleado varchar(5) NULL
ALTER TABLE dbo.MovimientosCompras ADD NroDocEmpleado varchar(12) NULL
GO
ALTER TABLE dbo.MovimientosCompras ADD CONSTRAINT FK_MovimientosCompras_Empleados
    FOREIGN KEY (TipoDocEmpleado, NroDocEmpleado)
    REFERENCES dbo.Empleados (TipoDocEmpleado, NroDocEmpleado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.MovimientosCompras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

