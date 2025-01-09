UPDATE CRMNovedades
   SET IdUsuarioResponsable = IdUsuarioAsignado
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE EN.ActualizaUsuarioResponsable = 1

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de EN DESARROLLO%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de EN DESARROLLO%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PARA DESARROLLAR%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PARA DESARROLLAR%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de ASIGNADO%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de ASIGNADO%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de EN PROCESO%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de EN PROCESO%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PENDIENTE%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EN.Finalizado = 1
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PENDIENTE%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PARA TESTEAR%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EN.Finalizado = 1
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PARA TESTEAR%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PARA NIVELAR%' ORDER BY S.FechaSeguimiento DESC)
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EN.Finalizado = 1
   AND EXISTS (SELECT TOP 1 S.UsuarioSeguimiento FROM CRMNovedadesSeguimiento S WHERE S.IdTipoNovedad = N.IdTipoNovedad AND S.IdNovedad = N.IdNovedad AND S.Comentario LIKE '%de PARA NIVELAR%' ORDER BY S.FechaSeguimiento DESC)

UPDATE CRMNovedades
   SET IdUsuarioResponsable = IdUsuarioAsignado
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PENDIENTE'
   AND N.IdUsuarioResponsable IS NULL
   AND EN.Finalizado = 1
