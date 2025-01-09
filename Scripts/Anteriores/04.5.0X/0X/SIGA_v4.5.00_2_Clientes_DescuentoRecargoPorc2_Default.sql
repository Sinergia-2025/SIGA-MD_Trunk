
ALTER TABLE Clientes ADD DEFAULT 0 FOR DescuentoRecargoPorc2 
GO

--No aplicar porque aca va cuando tocan.
--ALTER TABLE AuditoriaClientes ADD DEFAULT 0 FOR DescuentoRecargoPorc2 
--GO

--Actualizo aquello que existen y podrian estar mal (el comando anterior no los afecta)

UPDATE Clientes 
   SET DescuentoRecargoPorc2 = 0
 WHERE DescuentoRecargoPorc2 IS NULL
GO
