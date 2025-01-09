
ALTER TABLE Sucursales ADD DireccionComercial varchar(50) null
GO
ALTER TABLE Sucursales ADD IdLocalidadComercial	int	null
GO

UPDATE Sucursales 
   SET DireccionComercial = Direccion
      ,IdLocalidadComercial = IdLocalidad 
GO

ALTER TABLE Sucursales ALTER COLUMN DireccionComercial varchar(50) not null
GO
ALTER TABLE Sucursales ALTER COLUMN IdLocalidadComercial int not null
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
ALTER TABLE dbo.Sucursales ADD CONSTRAINT
	FK_Sucursales_LocalidadesComercial FOREIGN KEY
	(
	IdLocalidadComercial
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Sucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
