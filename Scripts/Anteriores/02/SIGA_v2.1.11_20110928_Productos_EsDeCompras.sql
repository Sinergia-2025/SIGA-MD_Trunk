
ALTER TABLE Productos ADD EsDeCompras bit NULL
GO

UPDATE Productos SET EsDeCompras = 'True'
GO

ALTER TABLE Productos ALTER COLUMN EsDeCompras bit NOT NULL
GO
