
SELECT IdCliente, CodigoCliente, NombreCliente
  FROM Clientes
 WHERE CodigoCliente = 357
GO

--SELECT COUNT(IdProyecto)
SELECT * FROM Proyectos 
 WHERE IdCliente = 362
  AND IdProyecto NOT IN (362, 1757)

GO


SELECT  * FROM CRMNovedades
 WHERE IdCliente = 362
  AND IdProyecto NOT IN (362, 1757)
GO

SELECT  * FROM CRMNovedades
 WHERE IdNovedad = 55702
