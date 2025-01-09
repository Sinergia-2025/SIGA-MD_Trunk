PRINT ''
PRINT '0. Habilitar Ticket a Metalsur.'
IF dbo.BaseConCuit('33631312379') = 'True'
BEGIN
    
    PRINT ''
    PRINT '1. Menu: Crear opciones de menú necesarias (se inicializar marcadas con una Y en Plus'
    MERGE INTO Funciones AS DEST
            USING (SELECT 'CRM'                           Id, NULL  IdPadre, 175 Posicion, 'True' EsMenu, 'CRM' AS Nombre, 'CRM' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL

                   SELECT 'CRMNovedadesABMTICKETS'        Id, 'CRM' IdPadre, 800 Posicion, 'True' EsMenu, 'Tickets' AS Nombre, 'Tickets' Descripcion, 'Eniac.Win' Archivo, 'CRMNovedadesABM' Pantalla, 'TICKETS' Parametros UNION ALL
                   SELECT 'TICKETS-PuedeAdjuntar'         Id, 'CRMNovedadesABMTICKETS' IdPadre, 1000 Posicion, 'False' EsMenu, 'Permitir Adjuntar archivos a Novedades' AS Nombre, 'Permitir Adjuntar archivos a Novedades' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL
                   SELECT 'TICKETS-PuedeEliminar'         Id, 'CRMNovedadesABMTICKETS' IdPadre, 1000 Posicion, 'False' EsMenu, 'Permitir Eliminar Novedades' AS Nombre, 'Permitir Eliminar Novedades' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL
                   SELECT 'TICKETS-VerOtrosUsuarios'      Id, 'CRMNovedadesABMTICKETS' IdPadre, 1000 Posicion, 'False' EsMenu, 'Permitir ver novedades de otros usuarios' AS Nombre, 'Permitir ver novedades de otros usuarios' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL
                   SELECT 'TICKETS-VerOtrUsrAlertas'      Id, 'CRMNovedadesABMTICKETS' IdPadre, 1000 Posicion, 'False' EsMenu, 'Permitir ver novedades de otros usuarios en Alertas' AS Nombre, 'Permitir ver novedades de otros usuarios en Alertas' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL

                   SELECT 'CRMActualizacionMasivaTICKETS' Id, 'CRM' IdPadre, 810 Posicion, 'True' EsMenu, 'Actualizacion Masiva de Tickets' AS Nombre, 'Actualizacion Masiva de Tickets' Descripcion, 'Eniac.Win' Archivo, 'CRMActualizacionMasiva' Pantalla, 'TICKETS' Parametros UNION ALL


                   SELECT 'SincronizarNovedades'          Id, 'CRM'     IdPadre, 1200 Posicion, 'True' EsMenu, 'Sincronizar' AS Nombre, 'Sincronizar' Descripcion, 'Eniac.Win' Archivo, 'SincronizarNovedades' Pantalla, NULL Parametros UNION ALL
                   SELECT 'SincronizacionSubidaMovil'     Id, 'CRM'     IdPadre, 1210 Posicion, 'True' EsMenu, 'Sincronizar - Clientes' AS Nombre, 'Sincronizar - Clientes' Descripcion, 'Eniac.Win' Archivo, 'SincronizacionSubidaMovil' Pantalla, NULL Parametros UNION ALL

                   SELECT 'CRMABMs'                       Id, 'CRM'     IdPadre, 1500 Posicion, 'True' EsMenu, 'ABMs' AS Nombre, 'ABMs' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMCategoriasNovedadesABM'     Id, 'CRMABMs' IdPadre,   10 Posicion, 'True' EsMenu, 'ABM de Categorias Novedades' AS Nombre, 'ABM de Categorias Novedades' Descripcion, 'Eniac.Win' Archivo, 'CRMCategoriasNovedadesABM' Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMEstadosNovedadesABM'        Id, 'CRMABMs' IdPadre,   20 Posicion, 'True' EsMenu, 'ABM de Estados Novedades'    AS Nombre, 'ABM de Estados Novedades'    Descripcion, 'Eniac.Win' Archivo, 'CRMEstadosNovedadesABM' Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMMediosComunicacionesABM'    Id, 'CRMABMs' IdPadre,   30 Posicion, 'True' EsMenu, 'ABM de Medios Comunicación'  AS Nombre, 'ABM de Medios Comunicación'  Descripcion, 'Eniac.Win' Archivo, 'CRMMediosComunicacionesNovedadesABM' Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMMetodosResolucionesABM'     Id, 'CRMABMs' IdPadre,   40 Posicion, 'True' EsMenu, 'ABM de Metodos Resolución'   AS Nombre, 'ABM de Metodos Resolución'   Descripcion, 'Eniac.Win' Archivo, 'CRMMetodosResolucionesNovedadesABM' Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMPrioridadesNovedadesABM'    Id, 'CRMABMs' IdPadre,   50 Posicion, 'True' EsMenu, 'ABM de Prioridades'          AS Nombre, 'ABM de Prioridades'          Descripcion, 'Eniac.Win' Archivo, 'CRMPrioridadesNovedadesABM' Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMTiposComentariosNovABM'     Id, 'CRMABMs' IdPadre,   60 Posicion, 'True' EsMenu, 'ABM de Tipos de Comentarios' AS Nombre, 'ABM de Tipos de Comentarios' Descripcion, 'Eniac.Win' Archivo, 'CRMTiposComentariosNovedadesABM' Pantalla, NULL Parametros UNION ALL
                   SELECT 'CRMTiposNovedadesABM'          Id, 'CRMABMs' IdPadre,   70 Posicion, 'True' EsMenu, 'ABM de Tipos Novedades'      AS Nombre, 'ABM de Tipos Novedades'      Descripcion, 'Eniac.Win' Archivo, 'CRMTiposNovedadesABM' Pantalla, NULL Parametros UNION ALL

                   SELECT 'CRMInformes'                   Id, 'CRM'     IdPadre, 1550 Posicion, 'True' EsMenu, 'Informes' AS Nombre, 'Informes' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL

                   SELECT 'InformeDeNovedadesTICKETS'     Id, 'CRMInformes' IdPadre,  800 Posicion, 'True' EsMenu, 'Informe de Tickets' AS Nombre, 'Informe de Tickets' Descripcion, 'Eniac.Win' Archivo, 'InformeDeNovedades' Pantalla, 'TICKETS' Parametros UNION ALL
                   SELECT 'InformeDeNovSeguimTICKETS'     Id, 'CRMInformes' IdPadre,  810 Posicion, 'True' EsMenu, 'Informe de Tickets Detallado'    AS Nombre, 'Informe de Tickets Detallado'    Descripcion, 'Eniac.Win' Archivo, 'InformeDeNovedadesDetallado' Pantalla, 'TICKETS' Parametros

                  ) AS ORIG ON DEST.Id = ORIG.Id
        WHEN NOT MATCHED THEN 
            INSERT (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
                   ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                   ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUEs (ORIG.Id, ORIG.Nombre, ORIG.Descripcion, ORIG.EsMenu, 'False', 'True', 'True'
                   ,ORIG.IdPadre, ORIG.Posicion, ORIG.Archivo, ORIG.Pantalla, NULL, ORIG.Parametros
                   ,'True', 'Y', 'N', 'N', 'N')
    ;

    PRINT ''
    PRINT '1.1. Menu: Asignar todas las funciones marcadas con Y a los roles'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT R.Id, F.Id FROM Funciones F CROSS JOIN Roles R 
        WHERE F.Plus = 'Y' AND R.Id IN ('Adm', 'Supervisor', 'Oficina');

    PRINT ''
    PRINT '1.2. Menu: Desmarcar las funciones marcadas con Y'
    UPDATE Funciones SET Plus = 'S' WHERE Plus = 'Y';

    
    PRINT ''
    PRINT '2. Iniaicalizar las tablas de CRM (por las dudas las limpio por si hay datos basura'
    DELETE FROM CRMTiposComentariosNovedades WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMPrioridadesNovedades WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMEstadosNovedades WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMCategoriasNovedades WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMMediosComunicacionesNovedades WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMMetodosResolucionesNovedades WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMTiposNovedadesDinamicos WHERE IdTipoNovedad = 'TICKETS'
    DELETE FROM CRMTiposNovedades WHERE IdTipoNovedad = 'TICKETS'

    PRINT ''
    PRINT '2.1. Tabla CRMTiposNovedades: Agregando TICKETS'
    INSERT CRMTiposNovedades
           (IdTipoNovedad, NombreTipoNovedad, UnidadDeMedida, UsuarioRequerido, UsuarioPorDefecto,
            ProximoContactoRequerido, PrimerOrdenGrilla, PrimerOrdenDesc, SegundoOrdenGrilla, SegundoOrdenDesc,
            VisualizaOtrasNovedades, VisualizaRevisionAdministrativa, PermiteBorrarComentarios, DiasProximoContacto, PermiteIngresarNumero,
            ReportaCantidad, ReportaAvance, LetrasHabilitadas, VerCambios)
    VALUES ('TICKETS', 'Tickets', '%', 'True', 'True',
            'False', 'N__FechaNovedad', 'True', '', 'False',
            'True', 'True', 'True', 1, 'False',
            'False', 'True', 'X', 'False')

    PRINT ''
    PRINT '2.2. Tabla CRMTiposComentariosNovedades: Agregando TICKETS'
    INSERT CRMTiposComentariosNovedades 
           (IdTipoComentarioNovedad, NombreTipoComentarioNovedad, Posicion, PorDefecto, Color, IdTipoNovedad, VisibleParaCliente, VisibleParaRepresentante)
    VALUES (1, 'COMENTARIO',         1, 'True',  NULL,      'TICKETS', 'False', 'True'),
           (2, 'ADJUNTO',            2, 'False', -16711681, 'TICKETS', 'False', 'True'),
           (3, 'COMENTARIO PUBLICO', 3, 'False', -8323328,  'TICKETS', 'True', 'True')

    PRINT ''
    PRINT '2.3. Tabla CRMPrioridadesNovedades: Agregando TICKETS'
    INSERT CRMPrioridadesNovedades 
           (IdPrioridadNovedad, NombrePrioridadNovedad, Posicion, IdTipoNovedad, PorDefecto) 
    VALUES (1, 'MUY ALTA', 1, 'TICKETS', 'False'),
           (2, 'ALTA', 2, 'TICKETS', 'True'),
           (3, 'MEDIA', 3, 'TICKETS', 'False'),
           (4, 'BAJA', 4, 'TICKETS', 'False')

    PRINT ''
    PRINT '2.4. Tabla CRMEstadosNovedades: Agregando TICKETS'
    INSERT CRMEstadosNovedades 
           (IdEstadoNovedad, NombreEstadoNovedad, Posicion, SolicitaUsuario, Finalizado, IdTipoNovedad, PorDefecto, Color, DiasProximoContacto, ActualizaUsuarioResponsable, SolicitaProveedorService, Imprime, Reporte, Embebido, AcumulaContador1, AcumulaContador2) 
    VALUES (1, 'NUEVO',      10, 'True', 'False', 'TICKETS', 'True', -65536,    NULL, 'False', 'False', 'False', NULL, 'False', 'False', 'False'),
           (2, 'ASIGNADO',   20, 'True', 'False', 'TICKETS', 'False', NULL,     NULL, 'True',  'False', 'False', NULL, 'False', 'False', 'False'),
           (3, 'EN PROCESO', 30, 'True', 'False', 'TICKETS', 'False', -8323328, NULL, 'True',  'False', 'False', NULL, 'False', 'False', 'False'),
           (4, 'FINALIZADO', 40, 'True', 'True',  'TICKETS', 'False', NULL,     NULL, 'False', 'False', 'False', NULL, 'False', 'False', 'False'),
           (5, 'CANCELADO',  50, 'True', 'True',  'TICKETS', 'False', NULL,     NULL, 'False', 'False', 'False', NULL, 'False', 'False', 'False')

    PRINT ''
    PRINT '2.5. Tabla CRMCategoriasNovedades: Agregando TICKETS'
    INSERT CRMCategoriasNovedades
           (IdCategoriaNovedad, NombreCategoriaNovedad, Posicion, IdTipoNovedad, PorDefecto, Reporta, Color, PublicarEnWeb)
    VALUES (1, 'CONSULTA', 1, 'TICKETS', 'True',  'NO', NULL,   'True'),
           (2, 'RECLAMO',  2, 'TICKETS', 'False', 'NO', -32768, 'True')

    PRINT ''
    PRINT '2.6. Tabla CRMMediosComunicacionesNovedades: Agregando TICKETS'
    INSERT CRMMediosComunicacionesNovedades
           (IdMedioComunicacionNovedad, NombreMedioComunicacionNovedad, Posicion, IdTipoNovedad, PorDefecto, Color)
    VALUES ( 1, 'CORREO',                1, 'TICKETS', 'False', NULL),
           ( 2, 'TELEFONICO',            2, 'TICKETS', 'False', NULL),
           ( 3, 'CELULAR',               3, 'TICKETS', 'False', NULL),
           ( 4, 'WHATSAPP',              4, 'TICKETS', 'False', NULL),
           ( 5, 'WEB',                   5, 'TICKETS', 'False', NULL),
           ( 6, 'PERSONALMENTE',         6, 'TICKETS', 'False', NULL),
           ( 7, 'FACEBOOK',              7, 'TICKETS', 'False', NULL),
           ( 8, 'TWITTER',               8, 'TICKETS', 'False', NULL),
           ( 9, 'TEAMVIEWER',            9, 'TICKETS', 'False', NULL),
           (10, 'CELULAR PERSONAL',     10, 'TICKETS', 'False', NULL),
           (11, 'SKYPE / ZOOM / OTRO',  11, 'TICKETS', 'False', NULL),
           (12, 'APP POST-VENTA',       12, 'TICKETS', 'True',  NULL)

    PRINT ''
    PRINT '2.7. Tabla CRMMetodosResolucionesNovedades: Agregando TICKETS'
    INSERT CRMMetodosResolucionesNovedades
           (IdMetodoResolucionNovedad, NombreMetodoResolucionNovedad, Posicion, IdTipoNovedad, PorDefecto)
    VALUES (1, 'CLIENTE',       1, 'TICKETS', 'False'),
           (2, 'REMOTO',        2, 'TICKETS', 'False'),
           (3, 'OFICINA',       3, 'TICKETS', 'True'),
           (4, 'FUERA OFICINA', 4, 'TICKETS', 'False')

    PRINT ''
    PRINT '2.8. Tabla CRMTiposNovedadesDinamicos: Agregando TICKETS'
    INSERT CRMTiposNovedadesDinamicos 
           (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden) 
    VALUES ('TICKETS', 'CLIENTES', 'True', 10)


    PRINT ''
    PRINT '3. Parametros: Inicializar parámetros'
    DECLARE @idParametro VARCHAR(MAX)
    DECLARE @descripcionParametro VARCHAR(MAX)
    DECLARE @valorParametro VARCHAR(MAX)

    SET @idParametro = 'SIMOVILCOBRANZAINCLUIRCLIENTES'
    SET @descripcionParametro = 'Incluir Clientes'
    SET @valorParametro = 'TodosLosClientes'

    PRINT ''
    PRINT '3.1. Parametros: Incluir Clientes = TodosLosClientes'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    SET @idParametro = 'SIMOVILSUBIDAINCLUIRCUENTASCORRIENTES'
    SET @descripcionParametro = 'Cuentas Corrientes'
    SET @valorParametro = 'False'

    PRINT ''
    PRINT '3.2. Parametros: Incluir Cuentas Corrientes = False'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

END
