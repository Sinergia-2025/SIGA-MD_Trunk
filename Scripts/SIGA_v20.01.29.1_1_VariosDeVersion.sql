PRINT ''
PRINT '1. Menu: Nueva Función Jerarquía de Productos'
GO
IF dbo.ExisteFuncion('Produccion') = 'True' AND dbo.BaseConCuit('30714374938') = 'True'
    BEGIN
        PRINT ''
        PRINT '1.1. Menu: Agregar Función Jerarquía de Productos'
        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('JerarquiaProductos', 'Jerarquía de Productos', 'Jerarquía de Productos', 'True', 'False', 'True', 'True'
                ,'Produccion', 46, 'Eniac.Win', 'JerarquiaProductos', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N');

        PRINT ''
        PRINT '1.2. Menu: Agregar Roles a Jerarquía de Productos'
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'JerarquiaProductos' FROM RolesFunciones WHERE IdFuncion = 'Produccion';

	END


PRINT ''
PRINT '2. Calendarios Sucursales: Agregar los registros faltantes'
GO
MERGE INTO CalendariosSucursales AS DEST
        USING (SELECT s.IdSucursal AS IdSuc, IdCalendario, NULL idcaja FROM Calendarios 
			cross join Sucursales s) AS ORIG ON DEST.IdCalendario = ORIG.IdCalendario 
			AND DEST.IdSucursal = ORIG.IdSuc
    WHEN NOT MATCHED THEN 
	 INSERT   ( IdSucursal
           ,IdCalendario
           ,IdCaja) VALUES (ORIG.IdSuc, IdCalendario, NULL);
