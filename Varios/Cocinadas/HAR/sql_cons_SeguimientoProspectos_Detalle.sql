
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
	  , CONVERT(DATE, N.FechaEstadoNovedad) AS FechaEstadoNovedadSinHora
      , EN.NombreEstadoNovedad
      , (CASE WHEN EN.Finalizado = 'True' THEN 'SI' ELSE 'NO' END) AS Finalizado

      , NS.IdSeguimiento 
      --, NS.FechaSeguimiento 
      , CONVERT(DATE, NS.FechaSeguimiento) AS FechaSeguimiento_Fecha
      , ES.NombreEstadoNovedad AS EstadoSeguimiento

      --, CONVERT(VARCHAR(5), NS.FechaSeguimiento, 108) AS FechaSeguimiento_Hora

      , NS.Comentario 
      -- , NS.EsComentario 
      ,NS.UsuarioSeguimiento
      ,NS.UsuarioAsignado
      , N.IdUsuarioAlta

      , N.Avance
	  
      , NS.Interlocutor AS InterlocutorSeguimiento 
      , PN.NombrePrioridadNovedad AS Prioridad
      , MN.NombreMedioComunicacionNovedad


 --      , N.BanderaColor AS Color

      --, N.Descripcion
      --, N.IdPrioridadNovedad
      --, N.IdCategoriaNovedad
      --, N.IdEstadoNovedad
      --, N.FechaEstadoNovedad
      --, N.IdUsuarioEstadoNovedad
      --, N.IdUsuarioAsignado
      --, N.IdMedioComunicacionNovedad
      --, N.IdCliente
      --, N.IdProspecto
--      , N.IdFuncion
      --, N.FechaProximoContacto
      --, N.Interlocutor
      --, N.IdMetodoResolucionNovedad
      --, N.IdProveedor
      --, N.IdProyecto
      --, N.RevisionAdministrativa
      --, N.Priorizado
      --, N.IdTipoNovedadPadre
      --, N.IdNovedadPadre
      --, N.Version
      --, N.VersionFecha
      --, N.FechaInicioPlan
      --, N.FechaFinPlan
      --, N.TiempoEstimado
      --, N.IdUsuarioResponsable
      --, N.Cantidad
      --, N.LetraPadre
      --, N.CentroEmisorPadre
      --, N.IdSucursalService
      --, N.IdTipoComprobanteService
      --, N.LetraService
      --, N.CentroEmisorService
      --, N.NumeroComprobanteService
      --, N.IdProducto
      --, N.CantidadProducto
      --, N.CostoReparacion
      --, N.IdProductoPrestado
      --, N.CantidadProductoPrestado
      --, N.ProductoPrestadoDevuelto
      --, N.IdProveedorService
      --, N.Contador1
      --, N.Contador2
      --, N.FechaActualizacionWeb
      --, N.IdProductoNovedad
      --, N.EtiquetaNovedad
      --, N.NroDeSerie
      --, N.TieneGarantiaService
      --, N.UbicacionService
      --, N.NroSerieProductoPrestado
      --, N.IdSucursalFact
      --, N.IdTipoComprobanteFact
      --, N.LetraFact
      --, N.CentroEmisorFact
      --, N.NumeroComprobanteFact
      --, N.RequiereTesteo
      --, N.FechaEntregado
      --, N.FechaFinalizado
      --, N.IdEstadoNovedadEntregado
      --, N.IdEstadoNovedadFinalizado
      --, N.IdUsuarioEntregado
      --, N.IdUsuarioFinalizado
      --, N.NombreProducto
      --, N.IdEstadoNovedadAnterior
      --, N.AvanceAnterior
      --, N.Observacion
 
-- , CONVERT(DATE, N.FechaEstadoNovedad) AS FechaEstadoNovedad_Fecha
-- , CONVERT(VARCHAR(5), N.FechaEstadoNovedad, 108) AS FechaEstadoNovedad_Hora
-- , CONVERT(DATE, N.FechaProximoContacto) AS FechaProximoContacto_Fecha
 --, CONVERT(VARCHAR(5), N.FechaProximoContacto, 108) AS FechaProximoContacto_Hora
-- , NS.IdEstadoNovedad
-- , TN.NombreTipoNovedad
-- , MRN.NombreMetodoResolucionNovedad
 --, C.CodigoCliente
 --, C.NombreCliente
 --, P.CodigoProspecto
 --, PR.CodigoProveedor
 --, PR.NombreProveedor
 --, UE.Nombre AS NombreUsuarioEstadoNovedad
 --, UA.Nombre AS NombreUsuarioAlta
 --, UG.Nombre AS NombreUsuarioAsignado
-- , FN.Nombre AS NombreFuncion
 --, CONVERT(DATE, N.FechaNovedad) AS FechaNovedadSinHora
 --, CONVERT(DATE, N.FechaEstadoNovedad) AS FechaEstadoNovedadSinHora
 --, CONVERT(DATE, N.FechaProximoContacto) AS FechaProximoContactoSinHora
 --, CASE WHEN EN.Finalizado = 0 THEN NULL ELSE 
 --      CONVERT(VARCHAR(4),(CONVERT(INT, ROUND(CONVERT(decimal(20,10), FechaEstadoNovedad - FechaNovedad),0,1)) * 24)
 --          + DATEPART(hh, FechaEstadoNovedad - FechaNovedad))
 --          + ':' + RIGHT('00' + CONVERT(VARCHAR(2), DATEPART(mi, FechaEstadoNovedad - FechaNovedad)), 2)
 --          + ':' + RIGHT('00' + CONVERT(VARCHAR(2), DATEPART(ss, FechaEstadoNovedad - FechaNovedad)), 2) END AS HorasFinalizacion
  FROM CRMNovedades AS N
 INNER JOIN CRMNovedadesSeguimiento AS NS ON NS.IdTipoNovedad = N.IdTipoNovedad and NS.IdNovedad = N.IDNovedad
-- INNER JOIN CRMTiposNovedades AS TN ON TN.IdTipoNovedad = N.IdTipoNovedad
  LEFT JOIN CRMPrioridadesNovedades AS PN ON PN.IdPrioridadNovedad = N.IdPrioridadNovedad
  LEFT JOIN CRMCategoriasNovedades AS CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad
  LEFT JOIN CRMEstadosNovedades AS EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
  LEFT JOIN CRMEstadosNovedades AS ES ON ES.IdEstadoNovedad = NS.IdEstadoNovedad
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
  AND NS.FechaSeguimiento >= '19000507 00:00:00'
  AND NS.FechaSeguimiento <= '20210507 23:59:59'
  AND NS.EsComentario = 1
--  and N.IdNovedad = 1192

 ORDER BY N.IdNovedad
