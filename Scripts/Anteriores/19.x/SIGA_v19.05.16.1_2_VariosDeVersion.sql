PRINT ''
PRINT '1. Agregar menu Service en CRM'
IF dbo.ExisteFuncion('Service') = 'True' AND dbo.ExisteFuncion('CRM') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Agregar Opción de Menu'
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
          PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
         ('CRMNovedadesABMSERVICE', 'Service', 'Service', 'True', 'False', 'True', 'True', 
          'CRM', 5, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'SERVICE', 
          'True', 'S', 'N', 'N', 'N' )

    PRINT ''
    PRINT '1.2. Asigna Roles a CRMNovedadesABMSERVICE'
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMSERVICE' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

    PRINT ''
    PRINT '1.3. Agregar Función SERVICE-VerOtrosUsuarios'
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
         ('SERVICE-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 'False', 'False', 'True', 'False', 
          'CRMNovedadesABMSERVICE', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL,NULL, 'True', 'S', 'N', 'N', 'N' )
    PRINT ''
    PRINT '1.4. Asigna Roles a SERVICE-VerOtrosUsuarios'
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SERVICE-VerOtrosUsuarios' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

    PRINT ''
    PRINT '1.5. Agregar Función SERVICE-PuedeEliminar'
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
         ('SERVICE-PuedeEliminar', 'Permitir Eliminar Novedades', 'Permitir Eliminar Novedades', 'False', 'False', 'True', 'False', 
          'CRMNovedadesABMSERVICE', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL,NULL, 'True', 'S', 'N', 'N', 'N' )
    PRINT ''
    PRINT '1.6. Asigna Roles a SERVICE-PuedeEliminar'
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SERVICE-PuedeEliminar' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END

PRINT ''
PRINT '2. Configura nuevo tablero'
IF dbo.ExisteFuncion('CRMNovedadesABMSERVICE') = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Agregar Nuevo Tablero'
    INSERT  [CRMTiposNovedades] 
           ([IdTipoNovedad], [NombreTipoNovedad], [UnidadDeMedida], [UsuarioRequerido], [UsuarioPorDefecto], 
            [ProximoContactoRequerido], [PrimerOrdenGrilla], [PrimerOrdenDesc], [SegundoOrdenGrilla], [SegundoOrdenDesc], 
            [VisualizaOtrasNovedades], [VisualizaRevisionAdministrativa], [PermiteBorrarComentarios], [DiasProximoContacto], 
            [PermiteIngresarNumero], [ReportaCantidad], [ReportaAvance], [LetrasHabilitadas]) 
    VALUES ('SERVICE', 'Service', '%', 'True', 'True',
            'False', 'N__FechaNovedad', 'False', NULL, 'False', 
            'True', 'False', 'True', 1, 
            'False', 'False', 'True', 'X')


    PRINT ''
    PRINT '2.2. Agregar Dinamico de Clientes al nuevo Tablero'
    INSERT  [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido], [Orden]) 
    VALUES ('SERVICE', 'CLIENTES', 1, 10)

    PRINT ''
    PRINT '2.3. Agregar Dinamico de Service al nuevo Tablero'
    INSERT  [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido], [Orden]) 
    VALUES ('SERVICE', 'SERVICE', 1, 1)

    PRINT ''
    PRINT '2.4. Copia Categorias de CRM a nuevo Tablero'
    INSERT INTO [CRMCategoriasNovedades]
               ([IdCategoriaNovedad],[NombreCategoriaNovedad],[Posicion],[IdTipoNovedad],[PorDefecto],  [Reporta], [Color], [PublicarEnWeb])
         SELECT [IdCategoriaNovedad] + 500,[NombreCategoriaNovedad],[Posicion],'SERVICE',[PorDefecto],  [Reporta], [Color], [PublicarEnWeb]
           FROM [CRMCategoriasNovedades]
          WHERE [IdTipoNovedad] = 'CRM'

    PRINT ''
    PRINT '2.5. Copia Estados de CRM a nuevo Tablero'
    INSERT INTO [CRMEstadosNovedades]
               ([IdEstadoNovedad],[NombreEstadoNovedad],[Posicion],[SolicitaUsuario],[Finalizado],[IdTipoNovedad],[PorDefecto],[Color], [DiasProximoContacto], [ActualizaUsuarioResponsable])
         SELECT [IdEstadoNovedad] + 500,[NombreEstadoNovedad],[Posicion],[SolicitaUsuario],[Finalizado],'SERVICE',[PorDefecto], [Color], [DiasProximoContacto], [ActualizaUsuarioResponsable]
      FROM [CRMEstadosNovedades]
          WHERE [IdTipoNovedad] = 'CRM'

    PRINT ''
    PRINT '2.6. Copia Medios de Comunicación de CRM a nuevo Tablero'
    INSERT INTO [CRMMediosComunicacionesNovedades]
               ([IdMedioComunicacionNovedad],[NombreMedioComunicacionNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
         SELECT [IdMedioComunicacionNovedad] + 500,[NombreMedioComunicacionNovedad],[Posicion],'SERVICE',[PorDefecto]
      FROM [CRMMediosComunicacionesNovedades]
          WHERE [IdTipoNovedad] = 'CRM'

    PRINT ''
    PRINT '2.7. Copia Métodos de Resolución de CRM a nuevo Tablero'
    INSERT INTO [CRMMetodosResolucionesNovedades]
               ([IdMetodoResolucionNovedad],[NombreMetodoResolucionNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
         SELECT [IdMetodoResolucionNovedad] + 500,[NombreMetodoResolucionNovedad],[Posicion],'SERVICE',[PorDefecto]
      FROM [CRMMetodosResolucionesNovedades]
          WHERE [IdTipoNovedad] = 'CRM'

    PRINT ''
    PRINT '2.8. Copia Prioridades de CRM a nuevo Tablero'
    INSERT INTO [CRMPrioridadesNovedades]
               ([IdPrioridadNovedad],[NombrePrioridadNovedad],[Posicion],[IdTipoNovedad],[PorDefecto])
         SELECT [IdPrioridadNovedad] + 500,[NombrePrioridadNovedad],[Posicion],'SERVICE',[PorDefecto]
      FROM [CRMPrioridadesNovedades]
          WHERE [IdTipoNovedad] = 'CRM'
END

PRINT ''
PRINT '3. Nuevos campos para CRMNovedades'
ALTER TABLE CRMNovedades ADD 
			IdSucursalService	int	null,
			IdTipoComprobanteService	varchar(15)	null,
			LetraService	varchar(1)	null,
			CentroEmisorService	int	null,
			NumeroComprobanteService bigint	null,
			IdProducto	varchar(15)	null,
			CantidadProducto	decimal(12, 2)	null,
			CostoReparacion	decimal(12, 2)	null,
			IdProductoPrestado	varchar(15)	null,
			CantidadProductoPrestado	decimal(12, 2)	null,
			ProductoPrestadoDevuelto bit null,
			IdProveedorService	bigint	null
GO

PRINT ''
PRINT '3.1. Valor por defecto para CRMNovedades.ProductoPrestadoDevuelto'
UPDATE CRMNovedades SET ProductoPrestadoDevuelto = 'False'
GO

PRINT ''
PRINT '3.2. CRMNovedades.ProductoPrestadoDevuelto NOT NULL'
ALTER TABLE CRMNovedades ALTER COLUMN ProductoPrestadoDevuelto bit not null
GO

PRINT ''
PRINT '4. Nuevos campo SolicitaProveedorService para CRMEstadosNovedades'
ALTER TABLE CRMEstadosNovedades ADD SolicitaProveedorService bit null
GO
PRINT ''
PRINT '4.1. Valor por defecto para CRMEstadosNovedades.SolicitaProveedorService'
UPDATE CRMEstadosNovedades SET SolicitaProveedorService = 'False'
GO
PRINT ''
PRINT '4.2. CRMEstadosNovedades.SolicitaProveedorService NOT NULL'
ALTER TABLE CRMEstadosNovedades ALTER COLUMN SolicitaProveedorService bit not null
GO

PRINT ''
PRINT '5. Eliminar parámetro que no está más (MODULOSERVICE)'
DELETE Parametros WHERE IdParametro = 'MODULOSERVICE'
