PRINT ''
PRINT '1. Menu: Informe de Backups de Clientes'
IF dbo.ExisteFuncion('Estadisticas') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Menu: Agregar nueva función Informe Backups de Clientes'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfClienteBackups', 'Informe Backups de Clientes', 'Informe Backups de Clientes', 'True', 'False', 'True', 'True'
        ,'Estadisticas', 70, 'Eniac.Win', 'InfClienteBackups', NULL, NULL
        ,'False', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '1.2. Menu: Asignar roles a nueva función Informe Backups de Clientes'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfClienteBackups' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Menu: Informe de Vencimiento de Licencias'
IF dbo.ExisteFuncion('Estadisticas') = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Menu: Agregar nueva función Informe de Vencimiento de Licencias'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfVencimientoLicencias', 'Informe de Vencimiento de Licencias', 'Informe de Vencimiento de Licencias', 'True', 'False', 'True', 'True'
        ,'Estadisticas', 80, 'Eniac.Win', 'InfVencimientoLicencias', NULL, NULL
        ,'False', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '2.2. Menu: Asignar roles a nueva función Vencimiento de Licencias de Clientes'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfVencimientoLicencias' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END