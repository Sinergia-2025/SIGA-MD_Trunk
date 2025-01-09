
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('EmpresasABM', 'Empresas', 'Empresas', 'True', 'False', 'True', 'True'
        ,'Archivos', 43, 'Eniac.Win', 'EmpresasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'EmpresasABM' FROM RolesFunciones WHERE IdFuncion = 'Sucursales'
