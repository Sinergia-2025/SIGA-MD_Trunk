IF dbo.ExisteFuncion('Ayuda') = 1 AND dbo.ExisteFuncion('SolicitarSoporteConsulta') = 0
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('SolicitarSoporteConsulta', 'Consulta Estado Soporte', 'Consulta Estado Soporte', 'True', 'False', 'True', 'True'
        ,'Ayuda', 110, 'Eniac.Win', 'SolicitarSoporteConsulta', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SolicitarSoporteConsulta' AS Pantalla FROM dbo.Roles
END