
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('ImportarProspectosExcel', 'Importar Prospectos desde Excel', 'Importar Prospectos desde Excel', 'True', 'False', 'True', 'True'
        ,'Procesos', 96, 'Eniac.Win', 'ImportarClientesExcel', NULL, 'PROSP'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarProspectosExcel' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

