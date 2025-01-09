
INSERT INTO [CRMTiposNovedades] ([IdTipoNovedad],[NombreTipoNovedad])
                VALUES ('RECPROV','Reclamo a Proveedores')
GO

INSERT INTO [CRMTiposNovedadesDinamicos] ([IdTipoNovedad],[IdNombreDinamico],[EsRequerido])
                VALUES ('RECPROV','PROVEEDORES',1)
GO

INSERT INTO [CRMCategoriasNovedades]
           ([IdCategoriaNovedad],[NombreCategoriaNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
     SELECT [IdCategoriaNovedad] + 60,[NombreCategoriaNovedad],[Posicion],'RECPROV',[PorDefecto]
       FROM [CRMCategoriasNovedades]
      WHERE [IdTipoNovedad] = 'CRM'
GO

INSERT INTO [CRMEstadosNovedades]
           ([IdEstadoNovedad],[NombreEstadoNovedad],[Posicion],[SolicitaUsuario],[Finalizado],[IdTipoNovedad],[PorDefecto])
     SELECT [IdEstadoNovedad] + 60,[NombreEstadoNovedad],[Posicion],[SolicitaUsuario],[Finalizado],'RECPROV',[PorDefecto]
  FROM [CRMEstadosNovedades]
      WHERE [IdTipoNovedad] = 'CRM'
GO

INSERT INTO [CRMMediosComunicacionesNovedades]
           ([IdMedioComunicacionNovedad],[NombreMedioComunicacionNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
     SELECT [IdMedioComunicacionNovedad] + 60,[NombreMedioComunicacionNovedad],[Posicion],'RECPROV',[PorDefecto]
  FROM [CRMMediosComunicacionesNovedades]
      WHERE [IdTipoNovedad] = 'CRM'
GO

INSERT INTO [CRMMetodosResolucionesNovedades]
           ([IdMetodoResolucionNovedad],[NombreMetodoResolucionNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
     SELECT [IdMetodoResolucionNovedad] + 60,[NombreMetodoResolucionNovedad],[Posicion],'RECPROV',[PorDefecto]
  FROM [CRMMetodosResolucionesNovedades]
      WHERE [IdTipoNovedad] = 'CRM'
GO

INSERT INTO [CRMPrioridadesNovedades]
           ([IdPrioridadNovedad],[NombrePrioridadNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
     SELECT [IdPrioridadNovedad] + 60,[NombrePrioridadNovedad],[Posicion],'RECPROV',[PorDefecto]
  FROM [CRMPrioridadesNovedades]
      WHERE [IdTipoNovedad] = 'CRM'
GO
