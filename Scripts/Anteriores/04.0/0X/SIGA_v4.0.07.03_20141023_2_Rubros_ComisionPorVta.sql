
ALTER TABLE Rubros ADD ComisionPorVenta decimal(5, 2) NULL
GO

UPDATE Rubros SET ComisionPorVenta = 0
GO

ALTER TABLE Rubros ALTER COLUMN ComisionPorVenta decimal(5, 2) NOT NULL
GO
