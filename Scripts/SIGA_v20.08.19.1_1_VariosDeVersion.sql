IF dbo.SoyHAR() = 'True' OR dbo.ExisteFuncion('Archivos') = 'True'
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ClientesEstrellas', 'Clientes - Estrellas', 'Clientes - Estrellas', 'True', 'False', 'True', 'True'
        ,'Archivos', 26, 'Eniac.Win', 'ClientesEstrellas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ClientesEstrellas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END
