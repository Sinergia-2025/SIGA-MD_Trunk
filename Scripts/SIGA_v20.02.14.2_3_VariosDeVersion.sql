PRINT ''
PRINT '0. Menu Turismo: Agregar y reorganizar Menu.'

IF dbo.ExisteFuncion('Turismo') = 'True'
BEGIN
    PRINT ''
    PRINT '1. Menu Reservas: Agregar función'
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('ReservasABM', 'Reservas', 'Reservas', 'True', 'False', 'True', 'True'
            ,'Turismo', 10, 'Eniac.Win', 'ReservasABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    PRINT ''
    PRINT '1.1. Menu Reservas: Agregar roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ReservasABM' FROM RolesFunciones WHERE IdFuncion = 'Turismo'

    PRINT ''
    PRINT '2. Menu ABM de Cursos: Agregar función'
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('TurismoCursosABM', 'ABM de Cursos', 'ABM de Cursos', 'True', 'False', 'True', 'True'
            ,'Turismo', 210, 'Eniac.Win', 'TurismoCursosABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    PRINT ''
    PRINT '2.1. Menu ABM de Cursos: Agregar roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TurismoCursosABM' FROM RolesFunciones WHERE IdFuncion = 'Turismo'

    PRINT ''
    PRINT '3. Menu ABM de Estados: Cambiar Posicion'
    UPDATE Funciones
       SET Posicion = 220
     WHERE Id = 'EstadosTurismoABM'

    PRINT ''
    PRINT '4. Menu ABM de Turnos: Agregar función'
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('TurismoTurnosABM', 'ABM de Turnos', 'ABM de Turnos', 'True', 'False', 'True', 'True'
            ,'Turismo', 230, 'Eniac.Win', 'TurismoTurnosABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    PRINT ''
    PRINT '4.1. Menu ABM de Turnos: Agregar roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TurismoTurnosABM' FROM RolesFunciones WHERE IdFuncion = 'Turismo'


    PRINT ''
    PRINT '5. Menu Sincronización Subida Web Turismo: Agregar función'
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('SincronizacionSubidaTurismo', 'Sincronización Subida Web Turismo', 'Sincronización Subida Web Turismo', 'True', 'False', 'True', 'True'
            ,'Turismo', 910, 'Eniac.Win', 'SincronizacionSubidaMovilTurismo', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    PRINT ''
    PRINT '5.1. Menu Sincronización Subida Web Turismo: Agregar roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'SincronizacionSubidaTurismo' FROM RolesFunciones WHERE IdFuncion = 'Turismo'

END
