IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAQLAABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAQLAABM', 'ABM L�mite de Calidad Aceptable A (AQL A)', 'ABM L�mite de Calidad Aceptable A (AQL A)', 'True', 'False', 'True', 'True'
        ,'MRP', 2175, 'Eniac.Win', 'MRPAQLAABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAQLAABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAQLBABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAQLBABM', 'ABM L�mite de Calidad Aceptable B (AQL B)', 'ABM L�mite de Calidad Aceptable B (AQL B)', 'True', 'False', 'True', 'True'
        ,'MRP', 2175, 'Eniac.Win', 'MRPAQLBABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAQLBABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
