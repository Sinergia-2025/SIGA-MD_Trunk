
ALTER TABLE Ventas ADD FechaActualizacion datetime NULL
GO

UPDATE Ventas 
   SET FechaActualizacion = Fecha
GO

ALTER TABLE Ventas ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
