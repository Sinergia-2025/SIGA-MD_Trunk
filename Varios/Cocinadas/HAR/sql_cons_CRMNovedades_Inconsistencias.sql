
--- CONTROLA POR CLIENTE DE NOVEDAD VS PROYECTO

SELECT TOP (200) P.IdCliente, ClieP.CodigoCliente, ClieP.NombreCliente, CRMN.IdCliente, ClieCRMN.CodigoCliente, ClieCRMN.NombreCliente, CRMN.IdProyecto, CRMN.*
--SELECT COUNT(P.IdCliente)
  FROM CRMNovedades CRMN
 INNER JOIN Proyectos P ON P.IdProyecto = CRMN.IdProyecto 
 INNER JOIN Clientes ClieCRMN ON ClieCRMN.IdCliente = CRMN.IdCliente
 INNER JOIN Clientes ClieP ON ClieP.IdCliente = P.IdCliente
    AND P.IdCliente <> CRMN.IdCliente
--	AND P.IdCliente = 38
 ORDER BY FechaNovedad DESC

 --- CONTROLA POR PROYECTO DE NOVEDAD VS PADRE

SELECT TOP (200) CRMN.IdProyecto, CRMNP.IdProyecto, CRMN.IdCliente, ClieCRMN.CodigoCliente, ClieCRMN.NombreCliente, CRMN.*
--SELECT COUNT(P.IdCliente)
  FROM CRMNovedades CRMN
 INNER JOIN Clientes ClieCRMN ON ClieCRMN.IdCliente = CRMN.IdCliente
 INNER JOIN CRMNovedades CRMNP ON CRMNP.IdTipoNovedad = CRMN.IdTipoNovedadPadre  AND CRMNP.IdNovedad = CRMN.IdNovedadPadre AND CRMN.IdNovedadPadre > 0 
    AND CRMN.IdProyecto <> CRMNP.IdProyecto
--	AND P.IdCliente = 38
 ORDER BY FechaNovedad DESC
