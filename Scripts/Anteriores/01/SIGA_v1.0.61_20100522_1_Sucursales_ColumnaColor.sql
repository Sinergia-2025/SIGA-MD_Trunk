
ALTER TABLE dbo.Sucursales
	ADD ColorSucursal int NULL
GO

UPDATE dbo.Sucursales
    SET ColorSucursal = -1
GO

ALTER TABLE dbo.Sucursales ALTER COLUMN ColorSucursal int NOT NULL 
GO
