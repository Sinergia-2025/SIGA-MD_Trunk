PRINT ''
PRINT '0. Opciones de menú Metalsur'
IF dbo.BaseConCuit('33631312379') = 1
BEGIN
    PRINT ''
    PRINT '1.1. Nueva función menú Pedidos Prov.'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
        ('PedidosProv', 'Pedidos Prov.', '', 'True', 'False', 'True', 'True',
         NULL, 70, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

   
    PRINT ''
    PRINT '1.2. Roles menú Pedidos Prov.'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PedidosProv' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


     --
    PRINT ''
    PRINT '2.1. Nueva función menú Sincronizar Ordenes Compra'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('SincronizarOrdenesCompra', 'Sincronizar Ordenes Compra', 'Sincronizar Ordenes Compra', 'True', 'False', 'True', 'True'
        ,'PedidosProv', 500, 'Eniac.Win', 'SincronizarOrdenesCompra', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '2.2. Roles menú Sincronizar Ordenes Compra'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizarOrdenesCompra' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


     --
    PRINT ''
    PRINT '3.1. Nueva función menú Productos Estándar'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Productos', 'Productos Estándar', 'Productos Estándar', 'True', 'False', 'True', 'True'
        ,'Archivos', 100, 'Eniac.Win', 'ProductosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.2. Roles menú Productos Estándar'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'Productos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm')


    PRINT ''
    PRINT '4.1. Nueva función menú Informes Bejerman'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
        ('PedidosProvInfBej', 'Informes Bejerman', '', 'True', 'False', 'True', 'True',
         NULL, 200, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

   
    PRINT ''
    PRINT '4.2. Roles menú Informes Bejerman'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PedidosProvInfBej' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '5.1. Nueva función menú Informe Vista OC Detalle'
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeVistaOCDetalle', 'Informe Vista OC Detalle', 'Informe Vista OC Detalle', 'True', 'False', 'True', 'True'
	    ,'PedidosProvInfBej', 30, 'Eniac.Win', 'InformeVistaOCDetalle', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '5.2. Roles menú Informe Vista OC Detalle'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeVistaOCDetalle' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '6.1. Nueva función menú Informe Vista OC Cabecera'
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeVistaOCCabecera', 'Informe Vista OC Cabecera', 'Informe Vista OC Cabecera', 'True', 'False', 'True', 'True'
	    ,'PedidosProvInfBej', 20, 'Eniac.Win', 'InformeVistaOCCabecera', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '6.2. Roles menú Informe Vista OC Cabecera'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeVistaOCCabecera' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '7.1. Nueva función menú Informe Vista Proveedores'
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeVistaOCProveedores', 'Informe Vista Proveedores', 'Informe Vista OC Proveedores', 'True', 'False', 'True', 'True'
	    ,'PedidosProvInfBej', 10, 'Eniac.Win', 'InformeVistaOCProveedores', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '7.2. Roles menú Informe Vista Proveedores'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeVistaOCProveedores' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '8.1. Nueva función menú Consultar Pedidos Proveedores'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ConsultarPedidosProv', 'Consultar Pedidos Proveedores', 'Consultar Pedidos Proveedores', 'True', 'False', 'True', 'True'
        ,'PedidosProv', 50, 'Eniac.Win', 'ConsultarPedidosProv', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '8.2. Roles menú Consultar Pedidos Proveedores'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConsultarPedidosProv' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '9.1. Nueva función menú CMD Sincronización OC Sincronizar'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCSincronizar', 'CMD Sincronización OC Sincronizar', 'CMD Sincronización OC Sincronizar', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCSincronizar', NULL, 'ReImportar=False;ReEnviar=False;DescargarTodo=False;EnviarWebProv=True;ExportarProv=True;EnviarWebProv=True;ExportarOC=True;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '9.2. Roles menú CMD Sincronización OC Sincronizar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCSincronizar' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '10.1. Nueva función menú CMD Sincronización OC Descargar Respuestas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCDescargarResp', 'CMD Sincronización OC Descargar Respuestas', 'CMD Sincronización OC Descargar Respuestas', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCDescargarResp', NULL, 'DescargarTodo=False;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '10.2. Roles menú CMD Sincronización OC Sincronizar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCDescargarResp' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '11.1. Nueva función menú CMD Sincronización OC Importar Bejerman'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCImportarBejerman', 'CMD Sincronización OC Importar Bejerman', 'CMD Sincronización OC Importar Bejerman', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCImportarBejerman', NULL, 'ReImportar=False;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '11.2. Roles menú CMD Sincronización OC Importar Bejerman'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCImportarBejerman' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '12.1. Nueva función menú CMD Sincronización OC Enviar Web'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCEnviarWeb', 'CMD Sincronización OC Enviar Web', 'CMD Sincronización OC Enviar Web', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCEnviarWeb', NULL, 'ReEnviar=False;EnviarWebProv=True;ExportarProv=True;EnviarWebOC=True;ExportarOC=True;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '12.2. Roles menú CMD Sincronización OC Enviar Web'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCEnviarWeb' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END


PRINT ''
PRINT '0.1. Nueva función menú CMD Sincronización Subida Novedades'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdSincroSubidaNovedades', 'CMD Sincronización Subida Novedades', 'CMD Sincronización Subida Novedades', 'False', 'False', 'True', 'True'
    ,NULL, 1000, 'Eniac.Win', 'CmdSincroSubidaNovedades', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

PRINT ''
PRINT '0.2. Roles menú CMD Sincronización Subida Novedades'
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdSincroSubidaNovedades' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

