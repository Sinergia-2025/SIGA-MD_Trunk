
ALTER TABLE Empleados ADD ComisionPorVenta decimal(5, 2) null
GO

UPDATE Empleados SET ComisionPorVenta = 0
GO

ALTER TABLE Empleados ALTER COLUMN ComisionPorVenta decimal(5, 2) not null
GO
