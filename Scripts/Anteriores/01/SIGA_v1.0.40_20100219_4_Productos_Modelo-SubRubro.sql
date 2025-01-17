
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.Modelos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD
	IdModelo int NULL,
	IdSubRubro int NULL
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_SubRubros FOREIGN KEY
	(
	IdSubRubro
	) REFERENCES dbo.SubRubros
	(
	IdSubRubro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_Modelos FOREIGN KEY
	(
	IdModelo
	) REFERENCES dbo.Modelos
	(
	IdModelo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*-------------------------*/

--INSERT INTO Modelos (IdModelo, NombreModelo, IdMarca) 
--SELECT IdMarca, left('General ' + NombreMarca,30), IdMarca FROM Marcas
--GO

--INSERT INTO SubRubros VALUES (1, 'General')
--GO

/*-------------------------*/

--UPDATE Productos SET
--    IdModelo = IdMarca, 
--    IdSubRubro = 1
--GO

/*-------------------------*/
    
--ALTER TABLE dbo.Productos ALTER COLUMN IdModelo int NOT NULL 
--GO

--ALTER TABLE dbo.Productos ALTER COLUMN IdSubRubro int NOT NULL 
--GO

