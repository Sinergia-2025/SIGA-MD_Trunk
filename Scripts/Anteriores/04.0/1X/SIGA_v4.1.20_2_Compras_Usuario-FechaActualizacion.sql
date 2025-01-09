
ALTER TABLE Compras ADD Usuario	varchar(10) null
GO
UPDATE Compras SET Usuario = 'admin'
GO
ALTER TABLE Compras ALTER COLUMN Usuario varchar(10) not null
GO


ALTER TABLE Compras ADD FechaActualizacion datetime NULL
GO
UPDATE Compras SET FechaActualizacion = Fecha
GO
ALTER TABLE Compras ALTER COLUMN FechaActualizacion datetime NOT NULL
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
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Compras ADD CONSTRAINT
	FK_Compras_Usuarios FOREIGN KEY
	(
	Usuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
