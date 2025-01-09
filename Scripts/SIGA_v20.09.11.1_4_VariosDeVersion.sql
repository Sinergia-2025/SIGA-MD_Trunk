PRINT ''
PRINT '0. Opciones de men� Metalsur'
IF dbo.BaseConCuit('33631312379') = 1
BEGIN
    PRINT ''
    PRINT '1.1. Nueva funci�n men� Pedidos Prov.'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
        ('PedidosProv', 'Pedidos Prov.', '', 'True', 'False', 'True', 'True',
         NULL, 70, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

   
    PRINT ''
    PRINT '1.2. Roles men� Pedidos Prov.'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PedidosProv' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


     --
    PRINT ''
    PRINT '2.1. Nueva funci�n men� Sincronizar Ordenes Compra'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('SincronizarOrdenesCompra', 'Sincronizar Ordenes Compra', 'Sincronizar Ordenes Compra', 'True', 'False', 'True', 'True'
        ,'PedidosProv', 500, 'Eniac.Win', 'SincronizarOrdenesCompra', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '2.2. Roles men� Sincronizar Ordenes Compra'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizarOrdenesCompra' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


     --
    PRINT ''
    PRINT '3.1. Nueva funci�n men� Productos Est�ndar'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Productos', 'Productos Est�ndar', 'Productos Est�ndar', 'True', 'False', 'True', 'True'
        ,'Archivos', 100, 'Eniac.Win', 'ProductosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.2. Roles men� Productos Est�ndar'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'Productos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm')


    PRINT ''
    PRINT '4.1. Nueva funci�n men� Informes Bejerman'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
        ('PedidosProvInfBej', 'Informes Bejerman', '', 'True', 'False', 'True', 'True',
         NULL, 200, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

   
    PRINT ''
    PRINT '4.2. Roles men� Informes Bejerman'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PedidosProvInfBej' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '5.1. Nueva funci�n men� Informe Vista OC Detalle'
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeVistaOCDetalle', 'Informe Vista OC Detalle', 'Informe Vista OC Detalle', 'True', 'False', 'True', 'True'
	    ,'PedidosProvInfBej', 30, 'Eniac.Win', 'InformeVistaOCDetalle', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '5.2. Roles men� Informe Vista OC Detalle'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeVistaOCDetalle' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '6.1. Nueva funci�n men� Informe Vista OC Cabecera'
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeVistaOCCabecera', 'Informe Vista OC Cabecera', 'Informe Vista OC Cabecera', 'True', 'False', 'True', 'True'
	    ,'PedidosProvInfBej', 20, 'Eniac.Win', 'InformeVistaOCCabecera', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '6.2. Roles men� Informe Vista OC Cabecera'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeVistaOCCabecera' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '7.1. Nueva funci�n men� Informe Vista Proveedores'
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeVistaOCProveedores', 'Informe Vista Proveedores', 'Informe Vista OC Proveedores', 'True', 'False', 'True', 'True'
	    ,'PedidosProvInfBej', 10, 'Eniac.Win', 'InformeVistaOCProveedores', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '7.2. Roles men� Informe Vista Proveedores'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeVistaOCProveedores' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '8.1. Nueva funci�n men� Consultar Pedidos Proveedores'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ConsultarPedidosProv', 'Consultar Pedidos Proveedores', 'Consultar Pedidos Proveedores', 'True', 'False', 'True', 'True'
        ,'PedidosProv', 50, 'Eniac.Win', 'ConsultarPedidosProv', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '8.2. Roles men� Consultar Pedidos Proveedores'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConsultarPedidosProv' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '9.1. Nueva funci�n men� CMD Sincronizaci�n OC Sincronizar'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCSincronizar', 'CMD Sincronizaci�n OC Sincronizar', 'CMD Sincronizaci�n OC Sincronizar', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCSincronizar', NULL, 'ReImportar=False;ReEnviar=False;DescargarTodo=False;EnviarWebProv=True;ExportarProv=True;EnviarWebProv=True;ExportarOC=True;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '9.2. Roles men� CMD Sincronizaci�n OC Sincronizar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCSincronizar' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '10.1. Nueva funci�n men� CMD Sincronizaci�n OC Descargar Respuestas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCDescargarResp', 'CMD Sincronizaci�n OC Descargar Respuestas', 'CMD Sincronizaci�n OC Descargar Respuestas', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCDescargarResp', NULL, 'DescargarTodo=False;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '10.2. Roles men� CMD Sincronizaci�n OC Sincronizar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCDescargarResp' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '11.1. Nueva funci�n men� CMD Sincronizaci�n OC Importar Bejerman'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCImportarBejerman', 'CMD Sincronizaci�n OC Importar Bejerman', 'CMD Sincronizaci�n OC Importar Bejerman', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCImportarBejerman', NULL, 'ReImportar=False;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '11.2. Roles men� CMD Sincronizaci�n OC Importar Bejerman'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCImportarBejerman' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


    PRINT ''
    PRINT '12.1. Nueva funci�n men� CMD Sincronizaci�n OC Enviar Web'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincroOCEnviarWeb', 'CMD Sincronizaci�n OC Enviar Web', 'CMD Sincronizaci�n OC Enviar Web', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroOCEnviarWeb', NULL, 'ReEnviar=False;EnviarWebProv=True;ExportarProv=True;EnviarWebOC=True;ExportarOC=True;'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '12.2. Roles men� CMD Sincronizaci�n OC Enviar Web'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroOCEnviarWeb' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END


PRINT ''
PRINT '0.1. Nueva funci�n men� CMD Sincronizaci�n Subida Novedades'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdSincroSubidaNovedades', 'CMD Sincronizaci�n Subida Novedades', 'CMD Sincronizaci�n Subida Novedades', 'False', 'False', 'True', 'True'
    ,NULL, 1000, 'Eniac.Win', 'CmdSincroSubidaNovedades', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

PRINT ''
PRINT '0.2. Roles men� CMD Sincronizaci�n Subida Novedades'
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdSincroSubidaNovedades' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

