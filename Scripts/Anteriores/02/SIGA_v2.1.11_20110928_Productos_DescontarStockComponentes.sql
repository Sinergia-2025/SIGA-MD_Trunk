ALTER TABLE Productos ADD DescontarStockComponentes bit NULL
GO

UPDATE Productos SET DescontarStockComponentes = 'False'
GO

ALTER TABLE Productos ALTER COLUMN DescontarStockComponentes bit NOT NULL
GO