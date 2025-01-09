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