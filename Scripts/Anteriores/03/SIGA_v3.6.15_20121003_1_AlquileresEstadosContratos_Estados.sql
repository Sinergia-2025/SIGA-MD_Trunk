
-- Reordone los codigos de los Estados para que numericamente esten en el orden Logico del proceso.

INSERT INTO AlquileresEstadosContratos
     (IdEstado, NombreEstado)
  VALUES
     (10, 'ALTA'), 
     (20, 'En Vigencia'), 
     (30, 'Renovado'),
     (40, 'Finalizado') 
GO


UPDATE Alquileres
   SET IdEstado = 10
 WHERE IdEstado = 0		--Alta
GO

UPDATE Alquileres
   SET IdEstado = 20
 WHERE IdEstado = 1		--En Vigencia
GO

UPDATE Alquileres
   SET IdEstado = 30
 WHERE IdEstado = 3		--Renovado
GO

UPDATE Alquileres
   SET IdEstado = 40
 WHERE IdEstado = 2		--Finalizado
GO


DELETE AlquileresEstadosContratos
 WHERE IdEstado < 10
GO
