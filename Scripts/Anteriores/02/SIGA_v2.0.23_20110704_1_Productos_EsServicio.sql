
ALTER TABLE Productos ADD EsServicio bit NULL
GO

UPDATE Productos SET EsServicio = 'False'
GO

ALTER TABLE Productos ALTER COLUMN EsServicio bit NOT NULL
GO
