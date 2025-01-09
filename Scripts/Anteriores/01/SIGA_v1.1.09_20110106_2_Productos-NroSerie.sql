ALTER TABLE Productos ADD NroSerie bit NULL
GO

UPDATE Productos SET NroSerie = 'False'
GO

ALTER TABLE Productos ALTER COLUMN NroSerie bit NOT NULL 
GO
