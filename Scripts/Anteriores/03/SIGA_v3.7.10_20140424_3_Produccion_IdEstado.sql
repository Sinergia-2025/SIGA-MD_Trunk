
ALTER TABLE Produccion ADD IdEstado varchar(10) NULL
GO

UPDATE Produccion SET IdEstado = 'NORMAL'
GO

ALTER TABLE Produccion ALTER COLUMN IdEstado varchar(10) NOT NULL
GO
