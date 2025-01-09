
-- Defino la cantidad a Sumar al Numero de Novedad
DECLARE @IdNovedadASumar INT = 20000

-- Inserto las Novedades Re-Numeradas
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
           ,[Version]
           ,VersionFecha
           ,FechaInicioPlan
           ,FechaFinPlan
           ,TiempoEstimado)
SELECT IdTipoNovedad 
      ,IdNovedad + @IdNovedadASumar AS NuevoIdNovedad
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
      ,[Version]
      ,VersionFecha
      ,FechaInicioPlan
      ,FechaFinPlan
      ,TiempoEstimado
  FROM CRMNovedades
  WHERE IdTipoNovedad = 'PENDIENTE'
;

-- Actualizo la Numeracion de las Novedades Padre
UPDATE CRMNovedades
   SET IdNovedadPadre = IdNovedadPadre + @IdNovedadASumar
 WHERE IdTipoNovedadPadre = 'PENDIENTE'
   AND IdNovedadPadre IS NOT NULL
;


-- Actualizo la Numeracion del Seguimiento de Novedades
UPDATE CRMNovedadesSeguimiento
   SET IdNovedad = IdNovedad + @IdNovedadASumar
 WHERE IdTipoNovedad = 'PENDIENTE'
;

-- Actualizo la Numeracion de los Adjuntos de Novedades
UPDATE SIGA_CRMAdjuntos.DBO.CRMNovedadesSeguimientoAdjuntos
   SET IdNovedad = IdNovedad + @IdNovedadASumar
 WHERE IdTipoNovedad = 'PENDIENTE'
;

-- Borro las Novedades con Numeracion Anterior
DELETE CRMNovedades
  WHERE IdTipoNovedad = 'PENDIENTE'
   AND IdNovedad < @IdNovedadASumar
;
