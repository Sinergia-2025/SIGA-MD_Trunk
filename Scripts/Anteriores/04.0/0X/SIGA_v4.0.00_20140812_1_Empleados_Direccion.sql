
ALTER TABLE Empleados ADD Direccion	varchar(100) NULL
GO
UPDATE Empleados SET Direccion = '.'
GO
ALTER TABLE Empleados ALTER COLUMN Direccion varchar(100) NOT NULL
GO

ALTER TABLE Empleados ADD IdLocalidad int NULL
GO
UPDATE Empleados SET IdLocalidad = (SELECT IdLocalidad FROM Sucursales WHERE SoyLaCentral = 'True')
GO
ALTER TABLE Empleados ALTER COLUMN IdLocalidad int NOT NULL
GO

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
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Empleados ADD CONSTRAINT
	FK_Empleados_Localidades FOREIGN KEY
	(
	IdLocalidad
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

