
ALTER TABLE Productos ADD IdMoneda int NULL
GO

UPDATE Productos SET IdMoneda = 1	---Pesos
GO

ALTER TABLE Productos ALTER COLUMN IdMoneda int NOT NULL
GO


/* Genero el FK en Productos */

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
ALTER TABLE dbo.Monedas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_Monedas FOREIGN KEY
	(
	IdMoneda
	) REFERENCES dbo.Monedas
	(
	IdMoneda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT