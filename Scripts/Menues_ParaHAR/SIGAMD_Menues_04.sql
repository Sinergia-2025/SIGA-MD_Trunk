UPDATE Funciones
   SET Parametros = 'ORDENCOMPRAPROV\,PEDIDOSPROV'
 WHERE Id = 'EstadoOrdenCompraProvABM'

UPDATE Funciones
   SET Parametros = 'PRESUPPROV\,ORDENCOMPRAPROV'
 WHERE Id = 'EstadoPresupuestosProvABM'

DECLARE @idViejo VARCHAR(MAX) = 'ConsultarOrdenCompraProv'
DECLARE @idNuevo VARCHAR(MAX) = 'ConsultarOCProv'

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = @idViejo)
BEGIN
    INSERT INTO Funciones
          (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
         , IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias
         , Plus, Express, Basica, PV, IdModulo, EsMDIChild)
    SELECT @idNuevo Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
         , IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias
         , Plus, Express, Basica, PV, IdModulo, EsMDIChild
      FROM Funciones
     WHERE Id = @idViejo
END

UPDATE RolesFunciones SET IdFuncion = @idNuevo WHERE IdFuncion = @idViejo

UPDATE Bitacora SET IdFuncion = @idNuevo WHERE IdFuncion = @idViejo
UPDATE Traducciones SET IdFuncion = @idNuevo WHERE IdFuncion = @idViejo
UPDATE Funciones SET IdPadre = @idNuevo WHERE IdPadre = @idViejo

DELETE Funciones WHERE Id = @idViejo

IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('InfReqComprasDetProducto') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfReqComprasDetProducto', 'Inf. Req. de Compra Det. Producto', 'Inf. Req. de Compra Det. Producto', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 550, 'Eniac.Win', 'InfReqComprasDetProducto', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfReqComprasDetProducto' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPCostosProcesosProductivos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPCostosProcesosProductivos', 'Calculo de Costos de Procesos Productivos', 'Calculo de Costos de Procesos Productivos', 'True', 'False', 'True', 'True'
        ,'MRP', 300, 'Eniac.Win', 'MRPCostosProcesosProductivos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPCostosProcesosProductivos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('RequerimientosComprasAdmin') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('RequerimientosComprasAdmin', 'Administración de Requerimientos de Compra', 'Administración de Requerimientos de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 50, 'Eniac.Win', 'RequerimientosComprasAdmin', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'RequerimientosComprasAdmin' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT 'F1. Nuevo Menu Procesos Productivos: MRP - ABM de Procesos Productivos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPPlanificacionProduccion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPPlanificacionProduccion', 'Planificacion de Necesidades de Producción.', 'Planificacion de Necesidades de Producción.', 'True', 'False', 'True', 'True'
        ,'MRP', 400, 'Eniac.Win', 'MRPPlanificacionNecesidadesProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPPlanificacionProduccion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

------------------------------------------------------------------------------------------------------------------------

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPConceptosNoProductivosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPConceptosNoProductivosABM', 'ABM de Conceptos No Productivos', 'ABM de Conceptos No Productivos', 'True', 'False', 'True', 'True'
        ,'MRP', 2150, 'Eniac.Win', 'MRPConceptosNoProductivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPConceptosNoProductivosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT 'F1. Nuevo Menu Planificacion de Requerimientos: MRP - ABM de Planificacion de Requerimientos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPPlanificacionRequerimientos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPPlanificacionRequerimientos', 'Planificacion de Requerimientos de Producción.', 'Planificacion de Requerimientos de Producción.', 'True', 'False', 'True', 'True'
        ,'MRP', 450, 'Eniac.Win', 'MRPPlanificacionRequerimientosProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPPlanificacionRequerimientos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT 'F1. Nuevo Menu Asignacion de Actividades: MRP - asignacion de Actividades'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAsignacionActividades') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAsignacionActividades', 'Asignacion de Actividades.', 'Asignacion de Actividades.', 'True', 'False', 'True', 'True'
        ,'MRP', 470, 'Eniac.Win', 'MRPAsignacionActividades', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAsignacionActividades' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('ProcesoDeclaracionProduccion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ProcesoDeclaracionProduccion', 'Declaración de Producción.', 'Declaración de Producción.', 'True', 'False', 'True', 'True'
        ,'MRP', 450, 'Eniac.Win', 'ProcesoDeclaracionProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProcesoDeclaracionProduccion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

MERGE INTO Funciones AS D 
    USING (SELECT Id + 'V2' Id, Nombre + ' (v2)' Nombre, Descripcion + ' (v2)' Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
                  IdPadre, Posicion, Archivo, 'PedidosAdminProvV2' Pantalla, Icono, Parametros,
                  PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild
             FROM Funciones
            WHERE Pantalla = 'PedidosAdminProv') O 
       ON O.Id = D.Id
    WHEN NOT MATCHED THEN 
        INSERT (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
                IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
                PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild)
        VALUES (O.Id, O.Nombre, O.Descripcion, O.EsMenu, O.EsBoton, O.[Enabled], O.Visible, 
                O.IdPadre, O.Posicion, O.Archivo, O.Pantalla, O.Icono, O.Parametros,
                O.PermiteMultiplesInstancias, O.Plus, O.Express, O.Basica, O.PV, O.IdModulo, O.EsMDIChild)
;
GO
MERGE INTO RolesFunciones AS D
    USING (SELECT IdRol, RF.IdFuncion + 'V2' IdFuncion
             FROM RolesFunciones RF
            INNER JOIN Funciones F ON F.Id = RF.IdFuncion
            WHERE Pantalla = 'PedidosAdminProv') O
       ON O.IdFuncion = D.IdFuncion AND D.IdRol = O.IdRol
    WHEN NOT MATCHED THEN 
        INSERT (IdRol,IdFuncion)
        VALUES (O.IdRol,O.IdFuncion)
;

MERGE INTO Funciones AS D 
    USING (SELECT Id + 'V2' Id, Nombre + ' (v2)' Nombre, Descripcion + ' (v2)' Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
                  IdPadre, Posicion, Archivo, 'OrdenesProduccionAdminV2' Pantalla, Icono, Parametros,
                  PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild
             FROM Funciones
            WHERE Pantalla = 'OrdenesProduccionAdmin') O 
       ON O.Id = D.Id
    WHEN NOT MATCHED THEN 
        INSERT (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
                IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
                PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild)
        VALUES (O.Id, O.Nombre, O.Descripcion, O.EsMenu, O.EsBoton, O.[Enabled], O.Visible, 
                O.IdPadre, O.Posicion, O.Archivo, O.Pantalla, O.Icono, O.Parametros,
                O.PermiteMultiplesInstancias, O.Plus, O.Express, O.Basica, O.PV, O.IdModulo, O.EsMDIChild)
;
GO
MERGE INTO RolesFunciones AS D
    USING (SELECT IdRol, RF.IdFuncion + 'V2' IdFuncion
             FROM RolesFunciones RF
            INNER JOIN Funciones F ON F.Id = RF.IdFuncion
            WHERE Pantalla = 'OrdenesProduccionAdmin') O
       ON O.IdFuncion = D.IdFuncion AND D.IdRol = O.IdRol
    WHEN NOT MATCHED THEN 
        INSERT (IdRol,IdFuncion)
        VALUES (O.IdRol,O.IdFuncion)
;
GO

