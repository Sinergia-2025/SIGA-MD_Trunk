INSERT INTO CRMNovedades
           (IdTipoNovedad
           ,IdNovedad
           ,FechaNovedad
           ,Descripcion
           ,IdPrioridadNovedad
           ,IdCategoriaNovedad
           ,IdEstadoNovedad
           ,FechaEstadoNovedad
           ,IdUsuarioEstadoNovedad
           ,FechaAlta
           ,IdUsuarioAlta
           ,IdUsuarioAsignado
           ,Avance
           ,IdMedioComunicacionNovedad
           ,IdCliente
           ,IdProspecto
           ,IdFuncion
           ,IdSistema
           ,FechaProximoContacto
           ,BanderaColor
           ,Interlocutor
           ,IdMetodoResolucionNovedad
           ,IdProveedor
           ,IdProyecto
           ,RevisionAdministrativa
           ,Priorizado
           ,IdTipoNovedadPadre
           ,IdNovedadPadre
           ,Version
           ,VersionFecha
           ,FechaInicioPlan
           ,FechaFinPlan
           ,TiempoEstimado
           ,IdUsuarioResponsable
           ,Cantidad
           ,Letra
           ,CentroEmisor
           ,LetraPadre
           ,CentroEmisorPadre)
SELECT REPLACE(IdTipoNovedad,'RECCLTE','TICKETS') AS XXIdTipoNovedad
      ,IdNovedad
      ,FechaNovedad
      ,Descripcion
      ,IdPrioridadNovedad+436
      ,IdCategoriaNovedad+417
      ,IdEstadoNovedad+425
      ,FechaEstadoNovedad
      ,IdUsuarioEstadoNovedad
      ,FechaAlta
      ,IdUsuarioAlta
      ,IdUsuarioAsignado
      ,Avance
      ,IdMedioComunicacionNovedad+120
      ,IdCliente
      ,IdProspecto
      ,IdFuncion
      ,IdSistema
      ,FechaProximoContacto
      ,BanderaColor
      ,Interlocutor
      ,IdMetodoResolucionNovedad+300
      ,IdProveedor
      ,IdProyecto
      ,RevisionAdministrativa
      ,Priorizado
      ,IdTipoNovedadPadre
      ,IdNovedadPadre
      ,Version
      ,VersionFecha
      ,FechaInicioPlan
      ,FechaFinPlan
      ,TiempoEstimado
      ,IdUsuarioResponsable
      ,Cantidad
      ,Letra
      ,CentroEmisor
      ,LetraPadre
      ,CentroEmisorPadre
  FROM CRMNovedades A
    WHERE IdTipoNovedad = 'RECCLTE'
	and FechaNovedad<'2019-02-01'
	and not exists
	(select IDNovedad FROM CRMNovedades B
    WHERE B.IdTipoNovedad = 'TICKETS'
	AND A.IDNovedad=B.IDNovedad)
GO

INSERT INTO CRMNovedadesSeguimiento
           (IdTipoNovedad
           ,IdNovedad
           ,IdSeguimiento
           ,FechaSeguimiento
           ,Comentario
           ,EsComentario
           ,UsuarioSeguimiento
           ,Interlocutor
           ,Letra
           ,CentroEmisor)
SELECT REPLACE(IdTipoNovedad,'RECCLTE','TICKETS') AS XXIdTipoNovedad
      ,IdNovedad
      ,IdSeguimiento
      ,FechaSeguimiento
      ,Comentario
      ,EsComentario
      ,UsuarioSeguimiento
      ,Interlocutor
      ,Letra
      ,CentroEmisor
  FROM CRMNovedadesSeguimiento A
    WHERE IdTipoNovedad = 'RECCLTE'
	and FechaSeguimiento<'2019-02-01'
	and not exists
	(select IDNovedad FROM CRMNovedadesSeguimiento B
    WHERE B.IdTipoNovedad = 'TICKETS'
	AND A.IDNovedad=B.IDNovedad)
GO
