DELETE Bitacora WHERE IdFuncion IN ('ConcesionarioOperacionesABM', 'Concesionarios')
DELETE RolesFunciones WHERE IdFuncion IN ('ConcesionarioOperacionesABM', 'Concesionarios')
DELETE Funciones WHERE Id IN ('ConcesionarioOperacionesABM')
DELETE Funciones WHERE Id IN ('Concesionarios')

IF dbo.BaseConCuit('30701513890') = 1 OR dbo.SoyHAR() = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('Concesionarios', 'Concesionarios', 'Concesionarios', 'True', 'False', 'True', 'True'
        ,NULL, 100, '', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'Concesionarios' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

IF dbo.ExisteFuncion('Concesionarios') = 1 AND dbo.ExisteFuncion('ConcesionarioOperacionesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConcesionarioOperacionesABM', 'Operaciones', 'Operaciones', 'True', 'False', 'True', 'True'
        ,'Concesionarios', 100, 'Eniac.Win', 'ConcesionarioOperacionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConcesionarioOperacionesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
