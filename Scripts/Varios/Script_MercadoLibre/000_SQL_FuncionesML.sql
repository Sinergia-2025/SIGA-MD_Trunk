------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'A1. Nueva Tarea Programada: Bajada de Información de Mercado Libre'
IF dbo.ExisteFuncion('CmdSubidaMercadoLibre') = 0
BEGIN    
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('CmdSubidaMercadoLibre', 'CmdSubidaMercadoLibre', 'CmdSubidaMercadoLibre', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSubidaMercadoLibre', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSubidaMercadoLibre' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'A2. Nueva Tarea Programada: Subida de Información de Mercado Libre'       
IF dbo.ExisteFuncion('CmdBajadaMercadoLibre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('CmdBajadaMercadoLibre', 'CmdBajadaMercadoLibre', 'CmdBajadaMercadoLibre', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdBajadaMercadoLibre', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdBajadaMercadoLibre' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'A3. Nuevo Menu: Tiendas Web'
IF dbo.ExisteFuncion('TiendasWeb') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
	VALUES
		('TiendasWeb', 'Tiendas Web', 'Tiendas Web', 'True', 'False', 'True', 'True'
		, NULL, 165, NULL, NULL, NULL, NULL
		,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TiendasWeb' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'A4. Nuevo Menu: Tiendas Web - Sincronizacion Bajada - Mercado Libre'
IF dbo.ExisteFuncion('SincronizacionSubidaTiendaWeb') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('SincronizacionSubidaTiendaWeb', 'Sincronización Subida - Tienda Web', 'Sincronización Subida - Tienda Web', 'True', 'False', 'True', 'True'
        , 'TiendasWeb', 15, 'Eniac.Win', 'SincronizacionSubidaTiendaWeb', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaTiendaWeb' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
----------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'A5. Nuevo Menu: Tiendas Web - Sincronizacion Subida - Mercado Libre'
IF dbo.ExisteFuncion('SincronizacionBajadaTiendaWeb') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('SincronizacionBajadaTiendaWeb', 'Sincronización Bajada - Tienda Web', 'Sincronización Bajada - Tienda Web', 'True', 'False', 'True', 'True'
        , 'TiendasWeb', 15, 'Eniac.Win', 'SincronizacionBajadaTiendaWeb', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizacionBajadaTiendaWeb' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'A6. Nuevo Menu: Tiendas Web - Administrador de Pedidos - Mercado Libre'
IF dbo.ExisteFuncion('AdministradorPedidosTiendasWeb') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('AdministradorPedidosTiendasWeb', 'Administrador de Pedidos - Tiendas Web', 'Administrador de Pedidos - Tiendas Web', 'True', 'False', 'True', 'True'
        ,'TiendasWeb', 20, 'Eniac.Win', 'AdministradorPedidosTiendasWeb', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AdministradorPedidosTiendasWeb' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'A7. Nuevo Menu: Tiendas Web - Vinculacion de Token - Mercado Libre'

IF dbo.ExisteFuncion('VinculacionTokenML') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('VinculacionTokenML', 'Mercado Libre - Vinculacion Token', 'Mercado Libre - Vinculacion Token', 'True', 'False', 'True', 'True'
        ,'TiendasWeb', 30, 'Eniac.Win', 'VinculacionTokenML', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'VinculacionTokenML' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO