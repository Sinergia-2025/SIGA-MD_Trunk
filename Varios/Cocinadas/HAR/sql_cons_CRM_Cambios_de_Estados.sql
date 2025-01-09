
SELECT YEAR(CrmCE.FechaCambioEstado) AS Año, MONTH(CrmCE.FechaCambioEstado) AS Mes, COUNT(CrmCE.IdNovedad) AS Cantidad
  FROM CRMNovedadesCambiosEstados CrmCE
  WHERE CrmCE.IdTipoNovedad = 'PENDIENTE'
    AND CrmCE.FechaCambioEstado>='20210601'
	AND CrmCE.IdEstadoNovedad = 442 --RE ASIGNADO
  GROUP BY YEAR(CrmCE.FechaCambioEstado), MONTH(CrmCE.FechaCambioEstado)
GO



--SELECT CrmCE.*, CrmEN.NombreEstadoNovedad
--  FROM CRMNovedadesCambiosEstados CrmCE
-- INNER JOIN CRMEstadosNovedades CrmEN 
--         ON CrmEN .IdTipoNovedad = CrmCE.IdTipoNovedad AND CrmEN.IdEstadoNovedad = CrmCE.IdEstadoNovedad
--  WHERE CrmCE.IdTipoNovedad = 'PENDIENTE'
--    AND CrmCE.FechaCambioEstado>='20210601'
--	AND CrmCE.IdEstadoNovedad = 442 --RE ASIGNADO
--GO


--SELECT * FROM CRMEstadosNovedades CrmEN 
-- WHERE CrmEN.IdTipoNovedad = 'PENDIENTE'
--   AND CrmEN.Entregado = 'Graba'
--GO
