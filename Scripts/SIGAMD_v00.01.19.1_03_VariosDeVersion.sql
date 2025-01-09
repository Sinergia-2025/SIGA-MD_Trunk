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
