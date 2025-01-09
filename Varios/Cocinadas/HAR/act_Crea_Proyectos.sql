
BEGIN

INSERT INTO Proyectos
           (IdProyecto
           ,NombreProyecto
           ,IdCliente
           ,FechaInicio
           ,FechaFin
           ,Estimado
           ,Presupuestado
           ,IdClasificacion
           ,IdEstado
           ,IdPrioridadImporte
           ,IdPrioridadEstrategico
           ,IdPrioridadComplejidad
           ,IdPrioridadReplicabilidad
           ,IdPrioridadProyecto)

 SELECT 1200+IdCliente AS IdProyecto
--		   ,NombreDeFantasia
           ,IdZonaGeografica AS NombreProyecto
           ,IdCliente
           ,FechaAlta AS FechaInicio
           ,FechaAlta+60 AS FechaFin
           --,'3000-01-01' AS FechaFin
           ,0 AS Estimado
           ,0 AS Presupuestado
           ,2 AS IdClasificacion	--Externo
           ,4 AS IdEstado			--Finalizado
		   ,5 AS IdPrioridadImporte
	       ,5 AS IdPrioridadEstrategico
	       ,5 AS IdPrioridadComplejidad
	       ,5 AS IdPrioridadReplicabilidad
	       ,5 AS IdPrioridadProyecto
  FROM Clientes
 WHERE 1=1 --IdZonaGeografica  IN ('SIGA', 'SILIVE')
  AND NOT EXISTS 
     (SELECT * FROM Proyectos Proy
       WHERE Proy.IdCliente = Clientes.IdCliente
	     AND Proy.IdClasificacion = 2	--Externo
	     --AND Proy.IdEstado = 7	--FA (Fuera de Alcance)
      )
--ORDER BY IdCliente, IdProyecto
END
GO
