
--INSERT INTO Proyectos
--           (IdProyecto
--           ,NombreProyecto
--           ,IdCliente
--           ,FechaInicio
--           ,FechaFin
--           ,Estimado
--           ,Presupuestado
--           ,IdClasificacion
--           ,IdEstado
--		     ,IdPrioridadImporte
--		     ,IdPrioridadEstrategico
--		     ,IdPrioridadComplejidad
--		     ,IdPrioridadReplicabilidad
--		     ,IdPrioridadProyecto
 SELECT IdCliente AS IdProyecto
           ,IdSistema AS NombreProyecto
           ,IdCliente
           ,MIN(FechaAlta) AS FechaInicio
           ,MIN(FechaAlta) AS FechaFin
           ,0 AS Estimado
           ,0 AS Presupuestado
           ,3 AS IdClasificacion
           ,1 AS IdEstado	--ALTA
		   ,3 AS IdPrioridadImporte
	       ,3 AS IdPrioridadEstrategico
	       ,3 AS IdPrioridadComplejidad
	       ,3 AS IdPrioridadReplicabilidad
	       ,3 AS IdPrioridadProyecto
  FROM CRMNovedades
 WHERE IdTipoNovedad  IN ('PENDIENTE','ACTIVIDAD')
  AND IdSistema='SIGA'
  AND NOT EXISTS 
     (SELECT * FROM Proyectos Po
       WHERE Po.IdProyecto=CRMNovedades.IdProyecto
      )
  GROUP BY IdCliente
           ,IdSistema
           ,IdCliente
ORDER BY IdCliente, IdProyecto
GO
