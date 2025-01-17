
PRINT ''
PRINT 'X. Tabla CRMTiposNovedades: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMTiposNovedades
           (IdTipoNovedad
           ,NombreTipoNovedad
           ,UnidadDeMedida
           ,UsuarioRequerido
           ,UsuarioPorDefecto
           ,ProximoContactoRequerido
           ,PrimerOrdenGrilla
           ,PrimerOrdenDesc
           ,SegundoOrdenGrilla
           ,SegundoOrdenDesc
           ,VisualizaOtrasNovedades
           ,VisualizaRevisionAdministrativa
           ,PermiteBorrarComentarios
           ,DiasProximoContacto
           ,PermiteIngresarNumero
           ,ReportaCantidad
           ,ReportaAvance
           ,LetrasHabilitadas)
SELECT 'TICKETS' AS XXIdTipoNovedad
      ,'Tickets' AS NombreTipoNovedad
      ,UnidadDeMedida
      ,UsuarioRequerido
      ,UsuarioPorDefecto
      ,ProximoContactoRequerido
      ,PrimerOrdenGrilla
      ,PrimerOrdenDesc
      ,SegundoOrdenGrilla
      ,SegundoOrdenDesc
      ,VisualizaOtrasNovedades
      ,VisualizaRevisionAdministrativa
      ,PermiteBorrarComentarios
      ,DiasProximoContacto
      ,PermiteIngresarNumero
      ,ReportaCantidad
      ,ReportaAvance
      ,LetrasHabilitadas
  FROM CRMTiposNovedades
  WHERE IdTipoNovedad = 'RECCLTE'
GO

PRINT ''
PRINT 'X. Tabla CRMTiposNovedadesDinamicos: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMTiposNovedadesDinamicos
           (IdTipoNovedad
           ,IdNombreDinamico
           ,EsRequerido
           ,Orden)
SELECT 'TICKETS' AS XXIdTipoNovedad
      ,IdNombreDinamico
      ,EsRequerido
      ,Orden
  FROM CRMTiposNovedadesDinamicos
WHERE IdTipoNovedad = 'RECCLTE'
GO


PRINT ''
PRINT 'X. Tabla CRMPrioridadesNovedades: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMPrioridadesNovedades
           (IdPrioridadNovedad
           ,NombrePrioridadNovedad
           ,Posicion
           ,IdTipoNovedad
           ,PorDefecto)
SELECT IdPrioridadNovedad+436
      ,NombrePrioridadNovedad
      ,Posicion
      ,'TICKETS' AS XXIdTipoNovedad
      ,PorDefecto
  FROM CRMPrioridadesNovedades
  WHERE IdTipoNovedad = 'RECCLTE'
GO

PRINT ''
PRINT 'X. Tabla CRMMetodosResolucionesNovedades: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMMetodosResolucionesNovedades
           (IdMetodoResolucionNovedad
           ,NombreMetodoResolucionNovedad
           ,Posicion
           ,IdTipoNovedad
           ,PorDefecto)
SELECT IdMetodoResolucionNovedad+300
      ,NombreMetodoResolucionNovedad
      ,Posicion
      ,'TICKETS' AS XXIdTipoNovedad
      ,PorDefecto
  FROM CRMMetodosResolucionesNovedades
    WHERE IdTipoNovedad = 'RECCLTE'
GO

PRINT ''
PRINT 'X. Tabla CRMMediosComunicacionesNovedades: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMMediosComunicacionesNovedades
           (IdMedioComunicacionNovedad
           ,NombreMedioComunicacionNovedad
           ,Posicion
           ,IdTipoNovedad
           ,PorDefecto)
SELECT IdMedioComunicacionNovedad+120
      ,NombreMedioComunicacionNovedad
      ,Posicion
      ,'TICKETS' AS XXIdTipoNovedad
      ,PorDefecto
  FROM CRMMediosComunicacionesNovedades
    WHERE IdTipoNovedad = 'RECCLTE'
GO

PRINT ''
PRINT 'X. Tabla CRMEstadosNovedades: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMEstadosNovedades
           (IdEstadoNovedad
           ,NombreEstadoNovedad
           ,Posicion
           ,SolicitaUsuario
           ,Finalizado
           ,IdTipoNovedad
           ,PorDefecto
           ,Color
           ,DiasProximoContacto
           ,ActualizaUsuarioResponsable)
SELECT IdEstadoNovedad+425
      ,NombreEstadoNovedad
      ,Posicion
      ,SolicitaUsuario
      ,Finalizado
      ,'TICKETS' AS XXIdTipoNovedad
      ,PorDefecto
      ,Color
      ,DiasProximoContacto
      ,ActualizaUsuarioResponsable
  FROM CRMEstadosNovedades
    WHERE IdTipoNovedad = 'RECCLTE'
GO


PRINT ''
PRINT 'X. Tabla CRMCategoriasNovedades: Creo los registros desde Tablero RECCLTE.'
GO
INSERT INTO CRMCategoriasNovedades
           (IdCategoriaNovedad
           ,NombreCategoriaNovedad
           ,Posicion
           ,IdTipoNovedad
           ,PorDefecto
           ,Reporta
           ,Color)
SELECT IdCategoriaNovedad+417
      ,NombreCategoriaNovedad
      ,Posicion
      ,'TICKETS' AS XXIdTipoNovedad
      ,PorDefecto
      ,Reporta
      ,Color
  FROM CRMCategoriasNovedades
    WHERE IdTipoNovedad = 'RECCLTE'
GO


PRINT ''
PRINT 'X. Tabla Funciones: Creo el menu desde CRMNovedadesABMRECCLTE.'
GO
INSERT INTO Funciones
           (Id
           ,Nombre
           ,Descripcion
           ,EsMenu
           ,EsBoton
           ,Enabled
           ,Visible
           ,IdPadre
           ,Posicion
           ,Archivo
           ,Pantalla
           ,Icono
           ,Parametros
           ,PermiteMultiplesInstancias
           ,Plus
           ,Express
           ,Basica
           ,PV)
SELECT 'CRMNovedadesABMTICKETS' AS XXId
      ,'Tickets' AS XXNombre
      ,'Tickets' AS XXDescripcion
      ,EsMenu
      ,EsBoton
      ,Enabled
      ,Visible
      ,IdPadre
      ,Posicion+1
      ,Archivo
      ,Pantalla
      ,Icono
      ,'TICKETS' AS XXParametros
      ,PermiteMultiplesInstancias
      ,Plus
      ,Express
      ,Basica
      ,PV
  FROM Funciones
  WHERE ID = 'CRMNovedadesABMRECCLTE'
GO

PRINT ''
PRINT 'X. Tabla Funciones: Creo el menu desde CRMNovedadesABMRECCLTE para Permisos especiales.'
GO
INSERT INTO Funciones
           (Id
           ,Nombre
           ,Descripcion
           ,EsMenu
           ,EsBoton
           ,Enabled
           ,Visible
           ,IdPadre
           ,Posicion
           ,Archivo
           ,Pantalla
           ,Icono
           ,Parametros
           ,PermiteMultiplesInstancias
           ,Plus
           ,Express
           ,Basica
           ,PV)
SELECT REPLACE(Id,'RECCLTE','TICKETS') AS XXId
      ,Nombre
      ,Descripcion
      ,EsMenu
      ,EsBoton
      ,Enabled
      ,Visible
      ,'CRMNovedadesABMTICKETS' AS XXIdPadre
      ,Posicion+1
      ,Archivo
      ,Pantalla
      ,Icono
      ,Parametros
      ,PermiteMultiplesInstancias
      ,Plus
      ,Express
      ,Basica
      ,PV
  FROM Funciones
 WHERE IdPadre = 'CRMNovedadesABMRECCLTE'
GO

PRINT ''
PRINT 'X. Tabla Funciones: Creo el menu desde los Informes.'
GO
INSERT INTO Funciones
           (Id
           ,Nombre
           ,Descripcion
           ,EsMenu
           ,EsBoton
           ,Enabled
           ,Visible
           ,IdPadre
           ,Posicion
           ,Archivo
           ,Pantalla
           ,Icono
           ,Parametros
           ,PermiteMultiplesInstancias
           ,Plus
           ,Express
           ,Basica
           ,PV)
SELECT REPLACE(Id,'RECCLTE','TICKETS') AS XXId
      , REPLACE(REPLACE(Nombre,'Reclamos','Tickets'),'Soporte','Tickets')
      , REPLACE(REPLACE(Descripcion,'Reclamos','Tickets'),'Soporte','Tickets')
      ,EsMenu
      ,EsBoton
      ,Enabled
      ,Visible
      ,IdPadre
      ,Posicion+1
      ,Archivo
      ,Pantalla
      ,Icono
      ,REPLACE(Id,'RECCLTE','TICKETS') AS XXParametros
      ,PermiteMultiplesInstancias
      ,Plus
      ,Express
      ,Basica
      ,PV
  FROM Funciones
  WHERE Id LIKE '%Informe%' AND Id LIKE '%RECCLTE%' 
GO

PRINT ''
PRINT 'X. Tabla RolesFunciones: Ajusto el Rol reasignandolo a Tickets.'
GO
INSERT INTO RolesFunciones
           (IdRol
           ,IdFuncion)
SELECT IdRol
      ,REPLACE(IdFuncion,'RECCLTE','TICKETS') AS XXIdFuncion
  FROM SIGA.RolesFunciones
  WHERE IdFuncion LIKE '%RECCLTE%'
GO

PRINT ''
PRINT 'X. Tabla CRMNovedades: Creo los registros desde Tablero RECCLTE.'
GO
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
      ,CentroEmisorPadre
  FROM CRMNovedades
    WHERE IdTipoNovedad = 'RECCLTE'
GO


PRINT ''
PRINT 'X. Tabla CRMNovedadesSeguimiento: Creo los registros desde Tablero RECCLTE.'
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
  FROM CRMNovedadesSeguimiento
    WHERE IdTipoNovedad = 'RECCLTE'
GO

PRINT ''
PRINT 'X. Tabla CRMNovedadesSeguimientoAdjuntos: Reasigno los Adjuntos de RECCLTE a Tickets.'
GO
UPDATE CRMNovedadesSeguimientoAdjuntos
   SET IdTipoNovedad = 'TICKETS'
 WHERE IdTipoNovedad = 'RECCLTE'
GO


PRINT ''
PRINT 'X. Tabla CRMNovedades: Reapunto los datos de clasificacion a los nuevos valores'
GO
UPDATE CRMNovedades
   SET IdPrioridadNovedad = IdPrioridadNovedad+436
      ,IdMetodoResolucionNovedad = IdMetodoResolucionNovedad+300
      ,IdMedioComunicacionNovedad = IdMedioComunicacionNovedad+120
      ,IdEstadoNovedad = IdEstadoNovedad+425
      ,IdCategoriaNovedad = IdCategoriaNovedad+417
	  ,Cantidad = 0
 WHERE IdTipoNovedad = 'TICKETS'
GO


PRINT ''
PRINT 'X. Tabla CRMTiposNovedades: Seteo % en Tablero de Tickets.'
GO
UPDATE CRMTiposNovedades
   SET UnidadDeMedida = '%'
      ,ReportaAvance = 'True'
	  ,ReportaCantidad = 'False'
 WHERE IdTipoNovedad = 'TICKETS'
GO

PRINT ''
PRINT 'X. Tabla CRMNovedades: Avance 100% a los Tickets Finalizados.'
GO
UPDATE CRMNovedades 
   SET CRMNovedades.Avance = 100
 FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades NE ON NE.IdTipoNovedad = N.IdTipoNovedad
                                AND NE.IdEstadoNovedad = N.IdEstadoNovedad
  WHERE N.IdTipoNovedad='TICKETS'
    AND NE.Finalizado = 'True'
GO
