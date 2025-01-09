IF dbo.ExisteFuncion('Contabilidad') = 'True'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ContabilidadRenumeracion', 'Renumeración de Asientos', 'Renumeración de Asientos', 'True', 'False', 'True', 'True'
        ,'Contabilidad', 212, 'Eniac.Win', 'ContabilidadRenumeracionAsientos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ContabilidadRenumeracion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
