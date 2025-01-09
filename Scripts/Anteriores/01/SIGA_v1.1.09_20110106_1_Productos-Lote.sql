ALTER TABLE Productos ADD Lote bit NULL
GO

UPDATE Productos SET Lote = 'False'
GO

ALTER TABLE Productos ALTER COLUMN Lote bit NOT NULL 
GO
