--SELECT * FROM ProyectosEstados WHERE Finalizado = 0
/*
	1	Alta	
	2	Ejecutando	
	3	Suspendido	
	7	FA	
	8	Negociando	
*/


SELECT C.NombreCliente, p.* FROM Proyectos P
 INNER JOIN Clientes C ON P.IdCliente = C.IdCliente
WHERE P.IdEstado IN (2)
 AND  P.IdCliente IN (SELECT IdCliente from Clientes Clie
                     INNER JOIN Categorias Cat ON CLIE.IdCategoria = cAT.IdCategoria
                     WHERE RequiereRevisionAdministrativa = 1)
 AND P.IdCliente not in (314)
 AND P.IdProyecto not in (1656, 1117)
go



UPDATE Proyectos
 SET IdEstado = 4
where IdProyecto in
(
SELECT p.IdProyecto FROM Proyectos P
 INNER JOIN Clientes C ON P.IdCliente = C.IdCliente
WHERE P.IdEstado IN (2)
 AND  P.IdCliente IN (SELECT IdCliente from Clientes Clie
                     INNER JOIN Categorias Cat ON CLIE.IdCategoria = cAT.IdCategoria
                     WHERE RequiereRevisionAdministrativa = 1)
 AND P.IdCliente not in (314)
 AND P.IdProyecto not in (1656, 1117)
)
