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

 SELECT 500+IdCliente AS IdProyecto
           ,IdZonaGeografica AS NombreProyecto
           ,IdCliente
           ,FechaAlta AS FechaInicio
           ,'3000-01-01' AS FechaFin
           ,0 AS Estimado
           ,0 AS Presupuestado
           ,3 AS IdClasificacion
           ,7 AS IdEstado	--Fuera de Alcance
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
	     AND Proy.IdEstado = 7	--FA (Fuera de Alcance)
      )
--ORDER BY IdCliente, IdProyecto
END
GO
