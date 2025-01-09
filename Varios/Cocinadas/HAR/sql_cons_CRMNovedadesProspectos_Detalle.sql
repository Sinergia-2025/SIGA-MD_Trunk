
SELECT --DISTINCT
       N.IdSistema
      ,  CN.NombreCategoriaNovedad
      --, N.Letra
      --, N.CentroEmisor
	  --, N.IdTipoNovedad
      , N.IdNovedad
      --, N.FechaAlta
      --, N.FechaNovedad
      , CONVERT(DATE, N.FechaNovedad) AS FechaNovedad_Fecha
      , P.NombreProspecto

      --, CONVERT(VARCHAR(5), N.FechaNovedad, 108) AS FechaNovedad_Hora
      --, N.FechaEstadoNovedad
      , CONVERT(DATE, N.FechaEstadoNovedad) AS FechaEstadoNovedad_Fecha

      , EN.NombreEstadoNovedad
      , (CASE WHEN EN.Finalizado = 'True' THEN 'SI' ELSE 'NO' END) AS Finalizado
      , N.Descripcion
      , N.IdUsuarioFinalizado
      , N.IdUsuarioAsignado
      , N.IdUsuarioAlta

      , N.Avance
	  
      , N.Interlocutor
      , PN.NombrePrioridadNovedad AS Prioridad
      , MN.NombreMedioComunicacionNovedad


 
 FROM CRMNovedades AS N
-- INNER JOIN CRMTiposNovedades AS TN ON TN.IdTipoNovedad = N.IdTipoNovedad
  LEFT JOIN CRMPrioridadesNovedades AS PN ON PN.IdPrioridadNovedad = N.IdPrioridadNovedad
  LEFT JOIN CRMCategoriasNovedades AS CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad
  LEFT JOIN CRMEstadosNovedades AS EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
  LEFT JOIN CRMMediosComunicacionesNovedades AS MN ON MN.IdMedioComunicacionNovedad = N.IdMedioComunicacionNovedad
--  LEFT JOIN CRMMetodosResolucionesNovedades AS MRN ON MRN.IdMetodoResolucionNovedad = N.IdMetodoResolucionNovedad
--  LEFT JOIN Proyectos AS PRO ON PRO.IdProyecto = N.IdProyecto
--  LEFT JOIN ProyectosEstados AS PROE ON PRO.IdEstado = PROE.IdEstado
--  LEFT JOIN Clasificaciones AS CL ON PRO.IdClasificacion = CL.IdClasificacion
  --LEFT JOIN Clientes AS C ON C.IdCliente = N.IdCliente
  LEFT JOIN Prospectos AS P ON P.IdProspecto = N.IdProspecto
  --LEFT JOIN Proveedores AS PR ON PR.IdProveedor = N.IdProveedor
  --LEFT JOIN Usuarios AS UE ON UE.Id = N.IdUsuarioEstadoNovedad
  --LEFT JOIN Usuarios AS UA ON UA.Id = N.IdUsuarioAlta
  --LEFT JOIN Usuarios AS UG ON UG.Id = N.IdUsuarioAsignado
--  LEFT JOIN Funciones AS FN ON FN.Id = N.IdFuncion
 WHERE N.IdTipoNovedad = 'PROSP'
  AND N.FechaEstadoNovedad >= '19000507 00:00:00'
  AND N.FechaEstadoNovedad <= '20210507 23:59:59'
--  and N.IdNovedad = 1192

 ORDER BY N.IdNovedad
