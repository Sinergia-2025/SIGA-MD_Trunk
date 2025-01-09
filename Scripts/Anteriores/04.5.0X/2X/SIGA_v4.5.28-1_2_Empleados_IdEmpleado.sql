
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
ALTER TABLE dbo.Empleados ADD IdEmpleado int NULL
ALTER TABLE dbo.Empleados ADD IdEmpleadoT int NOT NULL IDENTITY (1, 1)
GO

UPDATE Empleados
   SET IdEmpleado = IdEmpleadoT
GO

ALTER TABLE dbo.Empleados DROP COLUMN IdEmpleadoT
ALTER TABLE dbo.Empleados ALTER COLUMN IdEmpleado int NOT NULL
GO

ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

