
ALTER TABLE Productos ADD PublicarEnWeb bit NULL
GO

UPDATE Productos SET PublicarEnWeb = 'False'
GO

ALTER TABLE Productos ALTER COLUMN PublicarEnWeb bit NOT NULL
GO
