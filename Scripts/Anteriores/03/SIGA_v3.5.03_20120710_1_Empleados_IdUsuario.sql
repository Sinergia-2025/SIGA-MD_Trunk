
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
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
--BEGIN TRANSACTION
--GO
ALTER TABLE dbo.Empleados ADD
	IdUsuario varchar(10) NULL
GO
ALTER TABLE dbo.Empleados ADD CONSTRAINT
	FK_Empleados_Usuarios FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
--COMMIT
