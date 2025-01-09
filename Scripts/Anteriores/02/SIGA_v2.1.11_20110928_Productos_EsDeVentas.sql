ALTER TABLE Productos ADD EsDeVentas bit NULL
GO

UPDATE Productos SET EsDeVentas = 'True'
GO

ALTER TABLE Productos ALTER COLUMN EsDeVentas bit NOT NULL
GO