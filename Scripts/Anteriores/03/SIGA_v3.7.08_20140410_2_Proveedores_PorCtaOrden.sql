
ALTER TABLE Proveedores ADD PorCtaOrden bit NULL
GO

UPDATE Proveedores SET PorCtaOrden = 0
GO

ALTER TABLE Proveedores ALTER COLUMN PorCtaOrden bit NOT NULL
GO
