
ALTER TABLE Clientes ADD DescuentoRecargoPorc2 decimal(6, 2) null
GO
ALTER TABLE AuditoriaClientes ADD DescuentoRecargoPorc2	decimal(6, 2) null
GO

UPDATE Clientes SET DescuentoRecargoPorc2 = 0
GO
UPDATE AuditoriaClientes SET DescuentoRecargoPorc2 = 0
GO
