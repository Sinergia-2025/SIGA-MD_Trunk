PRINT ''
PRINT '1. Tabla MRPCentrosProductores: Nuevo MantenimientoAutonomo'
IF dbo.ExisteCampo('MRPCentrosProductores', 'MantenimientoAutonomo') = 0
BEGIN
    ALTER TABLE MRPCentrosProductores ADD MantenimientoAutonomo bit NULL
END
GO

PRINT ''
PRINT '2. Tabla MRPCentrosProductores: Nuevo MantenimientoAutonomo'
IF dbo.ExisteCampo('MRPCentrosProductores', 'MantenimientoAutonomo') = 1
BEGIN
	UPDATE MRPCentrosProductores SET MantenimientoAutonomo = 0
    ALTER TABLE MRPCentrosProductores ALTER COLUMN MantenimientoAutonomo bit NOT NULL
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
GO
PRINT ''
PRINT '1. Actualiza IdCodigoTarea: MRP - Codigo Tarea'
BEGIN
	UPDATE MRPProcesosProductivosOperaciones SET IdCodigoTarea = (SELECT IdTarea FROM MRPTareas as T WHERE T.Descripcion = DescripcionOperacion)
	UPDATE OrdenesProduccionMRPOperaciones SET IdCodigoTarea = (SELECT IdTarea FROM MRPTareas as T WHERE T.Descripcion = DescripcionOperacion)
END
GO
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
