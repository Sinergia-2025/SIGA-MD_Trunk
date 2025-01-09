
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('AplicacionesFuncionesABM', 'Funciones Aplicaciones Moviles', 'Funciones Aplicaciones Moviles', 'True', 'False', 'True', 'True'
        ,'Seguridad', 310, 'Eniac.Win', 'AplicacionesFuncionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AplicacionesFuncionesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
