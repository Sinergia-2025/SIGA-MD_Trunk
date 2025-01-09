PRINT ''
PRINT 'F0. Nuevo Menu Padre: MRP'
IF dbo.ExisteFuncion('MRP') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
	VALUES
		('MRP', 'MRP', 'MRP', 'True', 'False', 'True', 'True'
		, NULL, 140, NULL, NULL, NULL, NULL
		,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRP' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F1. Nuevo Menu Categoría de Empleados: MRP - ABM de Categoría Empleados'
IF dbo.ExisteFuncion('MRPCategoriasEmpleadosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPCategoriasEmpleadosABM', 'Categoría Empleados', 'Categoría Empleados', 'True', 'False', 'True', 'True'
        , 'Archivos', 13, 'Eniac.Win', 'MRPCategoriasEmpleadosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPCategoriasEmpleadosABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F2. Nuevo Menu Centros Productores: MRP - ABM de Centros Productores'
IF dbo.ExisteFuncion('MRPCentrosProductoresABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPCentrosProductoresABM', 'ABM de Centros Productores', 'ABM de Centros Productores', 'True', 'False', 'True', 'True'
        , 'MRP', 2100, 'Eniac.Win', 'MRPCentrosProductoresABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPCentrosProductoresABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F3. Nuevo Menu Mornas de Fabricación: MRP - ABM de Normas de Fabricación'
IF dbo.ExisteFuncion('MRPNormasFabricacionABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPNormasFabricacionABM', 'ABM de Normas de Fabricación', 'ABM de Normas de Fabricación', 'True', 'False', 'True', 'True'
        , 'MRP', 2200, 'Eniac.Win', 'MRPNormasFabricacionABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPNormasFabricacionABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F4. Nuevo Menu Secciones: MRP - ABM de Secciones'
IF dbo.ExisteFuncion('MRPSeccionesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPSeccionesABM', 'ABM de Secciones', 'ABM de Secciones', 'True', 'False', 'True', 'True'
        , 'MRP', 2300, 'Eniac.Win', 'MRPSeccionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPSeccionesABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F5. Nuevo Menu Tareas: MRP - ABM de Tareas'
IF dbo.ExisteFuncion('MRPTareasABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPTareasABM', 'ABM de Tareas', 'ABM de Tareas', 'True', 'False', 'True', 'True'
        , 'MRP', 2400, 'Eniac.Win', 'MRPTareasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPTareasABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F6. Nuevo Menu Procesos Productivos: MRP - ABM de Procesos Productivos'
IF dbo.ExisteFuncion('MRPProcesosProductivosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPProcesosProductivosABM', 'Procesos Productivos', 'Procesos Productivos', 'True', 'False', 'True', 'True'
        , 'MRP', 100, 'Eniac.Win', 'MRPProcesosProductivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPProcesosProductivosABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT 'F1. Nuevo Menu Procesos Productivos: MRP - ABM de Procesos Productivos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPProcesosProductivosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPProcesosProductivosABM', 'Procesos Productivos', 'Procesos Productivos', 'True', 'False', 'True', 'True'
        , 'MRP', 100, 'Eniac.Win', 'MRPProcesosProductivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPProcesosProductivosABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Menu: Orden Compra'
IF dbo.ExisteFuncion('OrdenCompraProv') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenCompraProv', 'Orden Compra Prov.', 'Orden Compra Proveedor', 'True', 'False', 'True', 'True'
        ,NULL, 25, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
DECLARE @tipo VARCHAR(MAX) = 'ORDENCOMPRAPROV'
IF dbo.ExisteFuncion('OrdenCompraProv') = 1 AND dbo.ExisteFuncion('OrdenCompraProveedor') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenCompraProveedor', 'Orden de Compra a Proveedor', 'Orden de Compra a Proveedor', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 10, 'Eniac.Win', 'PedidosProveedores', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('ConsultarOrdenCompraProv', 'Consultar Orden de Compra Proveedores', 'Consultar Orden de Compra Proveedores', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 20, 'Eniac.Win', 'ConsultarPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('AnularOrdenCompraProv', 'Anular Orden de Compra Proveedores', 'Anular Orden de Compra Proveedores', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 30, 'Eniac.Win', 'AnularPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('OrdenCompraAdminProv', 'Administracion de Orden de Compra Prov', 'Administracion de Orden de Compra Prov', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 40, 'Eniac.Win', 'PedidosAdminProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('EstadoOrdenCompraProvABM', 'ABM Estados de Orden Compra Proveedores', 'ABM Estados de Orden Compra Proveedores', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 50, 'Eniac.Win', 'EstadosPedidosProvABM', NULL, 'PRESUPPROV\,' + @tipo
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfOrdenCompraDetalladosProv', 'Inf. de Orden de Compra Detallado Prov', 'Inf. de Orden de Compra Detallado Prov', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 60, 'Eniac.Win', 'InfPedidosDetalladosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfOCSumaPorProductosProv', 'Inf. de Orden de Compra Suma por Productos Prov', 'Inf. de Orden de Compra Suma por Productos Prov', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 70, 'Eniac.Win', 'InfPedidosSumaPorProductosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('ConsultarOrdenCompraProv') = 1 AND dbo.ExisteFuncion('ConsultarOCProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConsultarOCProv-VerPre', 'Ver Precios en Consultar Orden Compra', 'Ver Precios en Consultar Orden Compra', 'False', 'False', 'True', 'True'
        ,'ConsultarOrdenCompraProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('InfOrdenCompraDetalladosProv') = 1 AND dbo.ExisteFuncion('InfOCDetalladosProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfOCDetalladosProv-VerPre', 'Ver Precios en Inf.Ped.Suma Por Productos', 'Ver Precios en Inf.Ped.Suma Por Productos', 'False', 'False', 'True', 'True'
        ,'InfOrdenCompraDetalladosProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('OrdenCompraAdminProv') = 1 AND dbo.ExisteFuncion('OrdenCompraAdminProv-Modif') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenCompraAdminProv-Modif', 'Modif. OrdenCompra', 'Modif. OrdenCompra', 'False', 'False', 'True', 'True'
        ,'OrdenCompraAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('OrdenCompraAdminProv-VerPre', 'Ver Precios en Admin OrdenCompra', 'Ver Precios en Admin OrdenCompra', 'False', 'False', 'True', 'True'
        ,'OrdenCompraAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END

UPDATE Funciones
   SET Parametros = @tipo
 WHERE IdPadre = 'OrdenCompraProv'
   AND ISNULL(Parametros, '') = ''

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT R.Id IdRol, F.Id IdFuncion
  FROM Funciones F
 CROSS JOIN (SELECT * FROM Roles WHERE Id IN ('Adm', 'Supervisor', 'Oficina')) R
 WHERE F.Plus = 'X'
   AND NOT EXISTS (SELECT * FROM RolesFunciones RF WHERE RF.IdRol = R.Id AND RF.IdFuncion = F.Id)

UPDATE Funciones
   SET Plus = 'S'
 WHERE Plus = 'X'

PRINT ''
PRINT '2. Menu: Orden Compra'
IF dbo.ExisteFuncion('RequerimientosCompras') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
	VALUES
		('RequerimientosCompras', 'Requerimientos', 'Requerimientos', 'True', 'False', 'True', 'True'
		,NULL, 23, 'Eniac.Win', NULL, NULL, NULL
		,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('RequerimientosComprasABM') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
	VALUES
		('RequerimientosComprasABM', 'Requerimiento de Compra', 'Requerimiento de Compra', 'True', 'False', 'True', 'True'
		,'RequerimientosCompras', 10, 'Eniac.Win', 'RequerimientosComprasABM', NULL, NULL
		,'True', 'S', 'N', 'N', 'N', 'True')
END
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT R.Id IdRol, F.Id IdFuncion
	FROM Funciones F
	CROSS JOIN (SELECT * FROM Roles WHERE Id IN ('Adm', 'Supervisor', 'Oficina')) R
	WHERE (F.Id = 'RequerimientosCompras' OR F.IdPadre = 'RequerimientosCompras')
	AND NOT EXISTS (SELECT * FROM RolesFunciones RF WHERE RF.IdRol = R.Id AND RF.IdFuncion = F.Id)
GO

IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('AnularRequerimientosCompras') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AnularRequerimientosCompras', 'Anular Requerimiento de Compra', 'Anular Requerimiento de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 210, 'Eniac.Win', 'AnularRequerimientosCompras', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AnularRequerimientosCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

--         1         2         3         4         5         6         7         8         9        10        11        12
--123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('InfRequerimientosCompras') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfRequerimientosCompras', 'Inf. Requerimiento de Compra', 'Inf. Requerimiento de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 510, 'Eniac.Win', 'InfRequerimientosCompras', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfRequerimientosCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

