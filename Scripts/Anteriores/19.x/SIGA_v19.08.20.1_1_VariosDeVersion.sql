PRINT ''
PRINT '1. Menu: Nueva opción de menú Informe de Stock'
IF dbo.ExisteFuncion('Stock') = 'True'
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '1.1. Menu: Creo la opción Informe de Stock'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InformedeStock', 'Informe de Stock', 'Informe de Stock', 'True', 'False', 'True', 'True'
        ,'Stock', 35, 'Eniac.Win', 'InformedeStock', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '1.2. Menu: Permisos para la opción Informe de Stock'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformedeStock' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END;
