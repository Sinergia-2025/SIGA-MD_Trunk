PRINT ''
PRINT '2. Nueva Función: Auditoria de Monedas.'
IF dbo.ExisteFuncion('InfAuditoriaMonedas') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfAuditoriaMonedas', 'Inf. Auditoría de Monedas', 'Inf. Auditoría de Monedas', 'True', 'False', 'True', 'True'
        ,'ArchivosAuditorias', 50, 'Eniac.Win', 'InfAuditoriaMonedas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfAuditoriaMonedas' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
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
PRINT ''
PRINT '1. Nueva Función: Estructura de Productos.'
IF dbo.ExisteFuncion('Produccion') = 1 AND dbo.ExisteFuncion('EstructuraProductos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('EstructuraProductos', 'Estructura de Productos.-', 'Estructura de Productos', 'True', 'False', 'True', 'True'
        ,'Produccion', 35, 'Eniac.Win', 'EstructuraProductos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'EstructuraProductos' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
PRINT '2. Nueva Función: ABM de Plazos de Entrega.'
IF dbo.ExisteFuncion('ABMPlazosEntrega') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ABMPlazosEntrega', 'Plazos de Entrega', 'Plazos de Entrega', 'True', 'False', 'True', 'True'
        ,'Archivos', 97, 'Eniac.Win', 'PlazosEntregaABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ABMPlazosEntrega' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
PRINT ''
PRINT '1. Nueva Función: ABM Modelos de Forma de Producción'
IF dbo.ExisteFuncion('ProduccionModelosFormasABM') = 0 AND dbo.ExisteFuncion('Produccion') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ProduccionModelosFormasABM', 'ABM Modelos de Forma de Producción', 'ABM Modelos de Forma de Producción', 'True', 'False', 'True', 'True'
        ,'Produccion', 210, 'Eniac.Win', 'ProduccionModelosFormasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProduccionModelosFormasABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Nueva Función: ABM de Tipos de Observaciones.'
IF dbo.ExisteFuncion('TiposObservacionesABM') = 0 AND dbo.ExisteFuncion('ArchivosTipos') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('TiposObservacionesABM', 'Tipos de Observaciones', 'Tipos de Observaciones', 'True', 'False', 'True', 'True'
        ,'ArchivosTipos', 196, 'Eniac.Win', 'TiposObservacionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TiposObservacionesABM' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
PRINT ''
PRINT '3. Nueva Función: Alerta Inconsistencias de Depositos vs Sucursales'
IF dbo.ExisteFuncion('InconsistDepositoVsSucursales') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistDepositoVsSucursales', 'Alerta Inconsistencias de Depositos vs Sucursales', 'Alerta Inconsistencias de Depositos vs Sucursales', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistDepositoVsSucursales', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistDepositoVsSucursales' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '4. Nueva Función: Alerta Inconsistencias de Depositos vs Ubicaciones'
IF dbo.ExisteFuncion('InconsistDepositoVsUbicaciones') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistDepositoVsUbicaciones', 'Alerta Inconsistencias de Depositos vs Ubicaciones', 'Alerta Inconsistencias de Depositos vs Ubicaciones', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistDepositoVsUbicaciones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistDepositoVsUbicaciones' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '5. Nueva Función: Alerta Inconsistencias de Depositos vs Movim. de Stock'
IF dbo.ExisteFuncion('InconsistDepositosVsMovStock') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistDepositosVsMovStock', 'Alerta Inconsistencias de Depositos vs MovStock', 'Alerta Inconsistencias de Depositos vs MovStock', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistDepositosVsMovStock', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistDepositosVsMovStock' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '6. Nueva Función: Alerta Inconsistencias de Ubicaciones vs Movim. de Stock'
IF dbo.ExisteFuncion('InconsistUbicacionesVsMovStock') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistUbicacionesVsMovStock', 'Alerta Inconsistencias de Ubicaciones vs MovStock', 'Alerta Inconsistencias de Ubicaciones vs MovStock', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistUbicacionesVsMovStock', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistUbicacionesVsMovStock' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
