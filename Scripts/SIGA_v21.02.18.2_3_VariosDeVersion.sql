PRINT ''
PRINT '1. Nueva Función: Informe de Saldos Antiguedad de Deuda Proveedores'
IF dbo.ExisteFuncion('CuentasCorrientesProveedores') = 1 AND dbo.ExisteFuncion('InfSaldosAntiguedadDeudaProv') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfSaldosAntiguedadDeudaProv', 'Informe de Saldos Antiguedad de Deuda Proveedores', 'Informe de Saldos Antiguedad de Deuda Proveedores', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientesProveedores', 45, 'Eniac.Win', 'InfSaldosAntiguedadDeudaProv', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfSaldosAntiguedadDeudaProv' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Nueva Tarea Programada: Bajada de Información de Tienda Nube'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdBajadaTiendaNube', 'CmdBajadaTiendaNube', 'CmdBajadaTiendaNube', 'False', 'False', 'True', 'True'
    ,NULL, 1000, 'Eniac.Win', 'CmdBajadaTiendaNube', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdBajadaTiendaNube' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

PRINT ''
PRINT '3. Nueva Tarea Programada: Subida de Información de Tienda Nube'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdSubidaTiendaNube', 'CmdSubidaTiendaNube', 'CmdSubidaTiendaNube', 'False', 'False', 'True', 'True'
    ,NULL, 1000, 'Eniac.Win', 'CmdSubidaTiendaNube', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdSubidaTiendaNube' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO



PRINT ''
PRINT '4. Nuevo Menu: Tiendas Web'
IF dbo.SoyHAR() = 1 OR dbo.BaseConCuit('20250887265') = 1
BEGIN
	IF dbo.ExisteFuncion('TiendasWeb') = 0
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
			('TiendasWeb', 'Tiendas Web', 'Tiendas Web', 'True', 'False', 'True', 'True'
			, NULL, 165, NULL, NULL, NULL, NULL
			,'True', 'S', 'N', 'N', 'N')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TiendasWeb' AS Pantalla FROM dbo.Roles
		 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
	
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('SincronizacionSubidaTiendaWeb', 'Sincronización Subida - Tienda Web', 'Sincronización Subida - Tienda Web', 'True', 'False', 'True', 'True'
        , 'TiendasWeb', 15, 'Eniac.Win', 'SincronizacionSubidaTiendaWeb', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaTiendaWeb' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '5. Nuevo Menu: Tiendas Web'
IF dbo.SoyHAR() = 1 OR dbo.BaseConCuit('20250887265') = 1
BEGIN
	IF dbo.ExisteFuncion('TiendasWeb') = 0
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
			('TiendasWeb', 'Tiendas Web', 'Tiendas Web', 'True', 'False', 'True', 'True'
			, NULL, 165, NULL, NULL, NULL, NULL
			,'True', 'S', 'N', 'N', 'N')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TiendasWeb' AS Pantalla FROM dbo.Roles
		 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
	
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('SincronizacionBajadaTiendaWeb', 'Sincronización Bajada - Tienda Web', 'Sincronización Bajada - Tienda Web', 'True', 'False', 'True', 'True'
        , 'TiendasWeb', 15, 'Eniac.Win', 'SincronizacionBajadaTiendaWeb', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizacionBajadaTiendaWeb' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END


PRINT ''
PRINT '6. Nueva Función: Administrador de Pedidos Tiendas Web'
IF dbo.ExisteFuncion('TiendasWeb') = 1
BEGIN	
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('AdministradorPedidosTiendasWeb', 'Administrador de Pedidos - Tiendas Web', 'Administrador de Pedidos - Tiendas Web', 'True', 'False', 'True', 'True'
        ,'TiendasWeb', 20, 'Eniac.Win', 'AdministradorPedidosTiendasWeb', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AdministradorPedidosTiendasWeb' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '7. Nueva Función: Tienda Nube - Vinculación Token'
IF dbo.ExisteFuncion('TiendasWeb') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('VinculacionToken', 'Tienda Nube - Vinculacion Token', 'Tienda Nube - Vinculacion Token', 'True', 'False', 'True', 'True'
        ,'TiendasWeb', 25, 'Eniac.Win', 'VinculacionToken', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'VinculacionToken' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
