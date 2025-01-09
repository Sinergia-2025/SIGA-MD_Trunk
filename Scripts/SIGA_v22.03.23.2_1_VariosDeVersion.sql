IF dbo.ExisteFuncion('SincronizacionSubida') = 1 AND dbo.ExisteFuncion('SincronizacionSubidaAdmin') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('SincronizacionSubidaAdmin', 'SincronizacionSubida-Administrador', 'SincronizacionSubida-Administrador', 'True', 'False', 'True', 'True'
        ,'SincronizacionSubida', 999, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaAdmin' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm')
END
