
INSERT INTO CRMTiposNovedades (IdTipoNovedad, NombreTipoNovedad, UnidadDeMedida)
                VALUES ('ACTIVIDAD', 'Actividades', 'HS')
GO

INSERT INTO CRMTiposNovedadesDinamicos (IdTipoNovedad,IdNombreDinamico,EsRequerido)
       VALUES ('ACTIVIDAD','SISTEMAS',1),
              ('ACTIVIDAD','FUNCIONES',1),
              ('ACTIVIDAD','CLIENTES',1),
              ('ACTIVIDAD','METODORESOLUCION',1)
GO

INSERT INTO CRMCategoriasNovedades
           (IdCategoriaNovedad,NombreCategoriaNovedad,Posicion,IdTipoNovedad,PorDefecto)
     SELECT IdCategoriaNovedad + 200,NombreCategoriaNovedad,Posicion,'ACTIVIDAD',PorDefecto
       FROM CRMCategoriasNovedades
      WHERE IdTipoNovedad = 'CRM'
GO

INSERT INTO CRMEstadosNovedades
           (IdEstadoNovedad,NombreEstadoNovedad,Posicion,SolicitaUsuario,Finalizado,IdTipoNovedad,PorDefecto)
     SELECT IdEstadoNovedad + 200,NombreEstadoNovedad,Posicion,SolicitaUsuario,Finalizado,'ACTIVIDAD',PorDefecto
  FROM CRMEstadosNovedades
      WHERE IdTipoNovedad = 'CRM'
GO

INSERT INTO CRMMediosComunicacionesNovedades
           (IdMedioComunicacionNovedad,NombreMedioComunicacionNovedad,Posicion,IdTipoNovedad,PorDefecto)
     SELECT IdMedioComunicacionNovedad + 200,NombreMedioComunicacionNovedad,Posicion,'ACTIVIDAD',PorDefecto
  FROM CRMMediosComunicacionesNovedades
      WHERE IdTipoNovedad = 'CRM'
GO

INSERT INTO CRMMetodosResolucionesNovedades
           (IdMetodoResolucionNovedad,NombreMetodoResolucionNovedad,Posicion,IdTipoNovedad,PorDefecto)
     SELECT IdMetodoResolucionNovedad + 200,NombreMetodoResolucionNovedad,Posicion,'ACTIVIDAD',PorDefecto
       FROM CRMMetodosResolucionesNovedades
      WHERE IdTipoNovedad = 'RECCLTE'
GO

INSERT INTO CRMPrioridadesNovedades
           (IdPrioridadNovedad,NombrePrioridadNovedad,Posicion,IdTipoNovedad,PorDefecto)
     SELECT IdPrioridadNovedad + 200,NombrePrioridadNovedad,Posicion,'ACTIVIDAD',PorDefecto
  FROM CRMPrioridadesNovedades
      WHERE IdTipoNovedad = 'CRM'
GO
