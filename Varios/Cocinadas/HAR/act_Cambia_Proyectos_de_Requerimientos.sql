--UPDATE CRMNovedades
--   SET Priorizado = 'True' 
----SELECT * FROM CRMNovedades
-- WHERE FechaFinalizado IS NULL
--   AND Priorizado = 'False' 
--   AND EXISTS
--        (SELECT IdCategoriaNovedad FROM CRMCategoriasNovedades Cat
--          WHERE Cat.NombreCategoriaNovedad LIKE '%ERROR%'
--		    AND Cat.IdCategoriaNovedad = CRMNovedades.IdCategoriaNovedad)
--GO



--UPDATE CRMNovedades
--   SET Priorizado = 'True' 
-- WHERE FechaFinalizado IS NULL
--   AND Priorizado = 'False' 
--   AND EXISTS
--        (SELECT Proy.IdProyecto FROM Proyectos Proy
--	      WHERE Proy.IdClasificacion IN (5,6)  --('Ext. Estandar', 'Ext. Largar')
--		    AND Proy.IdProyecto = CRMNovedades.IdProyecto)
--GO


-- Identifico la Clasificacion para largar
SELECT IdClasificacion  FROM Clasificaciones
 WHERE NombreClasificacion IN ('Ext. Estandar', 'Ext. Largar')	---5, 6
GO

---- Identifico los Proyectos para Largar
--SELECT * FROM Proyectos
-- WHERE IdClasificacion IN (5,6)
-- --WHERE EXISTS
-- --    (SELECT Cla.IdClasificacion FROM Clasificaciones Cla
--	--	 WHERE NombreClasificacion = 'Ext. Largar'
--	--	   AND CLA.IdClasificacion = Proyectos.IdClasificacion
-- --     )
--GO



/* PASO 1 */ 

----- Consulto Pendientes y/o Tickets que tienen distinto poryecto que el Requerimiento (Pudo ser reclasificado)
--SELECT Hijo.IdTipoNovedad, Hijo.IdNovedad, hijo.IdProyecto FROM CRMNovedades Hijo
--WHERE IdTipoNovedad IN ('TICKETS', 'PENDIENTE')
--  AND IdTipoNovedadPadre = 'REQUER'
----  AND IdProyecto IN (1714, 1723, 1724)
--  AND EXISTS
--     (SELECT Padre.IdProyecto FROM CRMNovedades Padre
--		 WHERE Padre.IdTipoNovedad = 'REQUER'
--          AND Padre.IdProyecto IN (1714, 1723, 1724)
--		  AND Padre.IdNovedad = Hijo.IdNovedadPadre
--		  AND Padre.IdProyecto <> Hijo.IdProyecto
--      )
--GO

----- Actualizo Pendientes y/o Tickets que tienen distinto poryecto que el Requerimiento (Pudo ser reclasificado)
--UPDATE Hijo
--   SET Hijo.IdProyecto = Padre.IdProyecto 
-- FROM CRMNovedades Hijo 
--  INNER JOIN CRMNovedades Padre 
--           ON Padre.IdTipoNovedad = 'REQUER'
--          AND Padre.IdProyecto IN (1714, 1723, 1724)
--		  AND Padre.IdNovedad = Hijo.IdNovedadPadre
--		  AND Padre.IdProyecto <> Hijo.IdProyecto
-- WHERE Hijo.IdTipoNovedad IN ('TICKETS', 'PENDIENTE')
----   AND Hijo.IdProyecto IN (1714, 1723, 1724)
--GO

/* -------------- */


/* PASO 2 */ 

----- Consulto Pendientes y/o Tickets que tienen distinto poryecto que el Requerimiento (Pudo ser reclasificado)
--SELECT Hijo.IdTipoNovedad, Hijo.IdNovedad, hijo.IdProyecto FROM CRMNovedades Hijo
--WHERE IdTipoNovedad = 'ACTIVIDAD'
--  AND IdTipoNovedadPadre IN ('REQUER', 'TICKETS', 'PENDIENTE') 
----  AND IdProyecto IN (1714, 1723, 1724)
--  AND EXISTS
--     (SELECT Padre.IdProyecto FROM CRMNovedades Padre
--		 WHERE Padre.IdTipoNovedad IN ('REQUER', 'TICKETS', 'PENDIENTE') 
--		  AND Padre.IdNovedad = Hijo.IdNovedadPadre
--		  AND Padre.IdProyecto <> Hijo.IdProyecto
--          AND Padre.IdProyecto IN (1714, 1723, 1724)
--      )
--GO

----- Actualizo Pendientes y/o Tickets que tienen distinto poryecto que el Requerimiento (Pudo ser reclasificado)
--UPDATE Hijo
--   SET Hijo.IdProyecto = Padre.IdProyecto 
-- FROM CRMNovedades Hijo 
--  INNER JOIN CRMNovedades Padre 
--           ON Padre.IdTipoNovedad IN ('REQUER', 'TICKETS', 'PENDIENTE')  
--		  AND Padre.IdNovedad = Hijo.IdNovedadPadre
--		  AND Padre.IdProyecto <> Hijo.IdProyecto
--          AND Padre.IdProyecto IN (1714, 1723, 1724)
-- WHERE Hijo.IdTipoNovedad = 'ACTIVIDAD'
----   AND Hijo.IdProyecto IN (1714, 1723, 1724)
--GO

/* -------------- */



---- Busco los Requerimientos segun Proyecto
--SELECT * FROM CRMNovedades
--WHERE IdTipoNovedad = 'REQUER'
--  AND IdProyecto = 1707
----  AND IdNovedad NOT in (28890, 28892)
--GO


--------- Reasigno los Requerimientos segun proyecto
--UPDATE CRMNovedades
--  SET IdProyecto = 1727
--WHERE IdTipoNovedad = 'REQUER'
--  AND IdProyecto = 1707
----  AND IdNovedad NOT in (28890, 28892)
----  AND IdNovedad = 28892
--GO



--SELECT TOP(100) *  FROM CRMNovedades
--WHERE IdTipoNovedad IN ('TICKETS', 'PENDIENTE')
--  AND IdTipoNovedadPadre = 'REQUER'
--GO


