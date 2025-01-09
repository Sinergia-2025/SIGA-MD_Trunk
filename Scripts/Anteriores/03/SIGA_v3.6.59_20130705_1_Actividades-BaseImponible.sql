
ALTER TABLE Actividades ADD BaseImponible decimal(10,2) NULL	
GO

UPDATE Actividades SET BaseImponible = 0
GO

ALTER TABLE Actividades ALTER COLUMN BaseImponible decimal(10,2) NOT NULL	
GO
