PRINT ''
PRINT '1. Nueva Función: ABM de Sucursales Depositos.'
IF dbo.ExisteFuncion('ABMSucursalesDepositos') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ABMSucursalesDepositos', 'ABM de Depósitos.-', 'ABM de Depósitos', 'True', 'False', 'True', 'True'
        ,'Stock', 155, 'Eniac.Win', 'SucursalesDepositosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ABMSucursalesDepositos' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Nueva Función: ABM de Estados de Ubicaciones.'
IF dbo.ExisteFuncion('ABMUbicacionesEstados') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ABMUbicacionesEstados', 'ABM de Estados de Ubicaciones.-', 'ABM de Estados de Ubicaciones.-', 'True', 'False', 'True', 'True'
        ,'Stock', 158, 'Eniac.Win', 'SucursalesUbicacionesEstadosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ABMUbicacionesEstados' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '3. Nueva Función: ABM de Sucursales Ubicaciones.'
IF dbo.ExisteFuncion('ABMSucursalesUbicaciones') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ABMSucursalesUbicaciones', 'ABM de Ubicaciones.-', 'ABM de Ubicaciones', 'True', 'False', 'True', 'True'
        ,'Stock', 175, 'Eniac.Win', 'SucursalesUbicacionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ABMSucursalesUbicaciones' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO