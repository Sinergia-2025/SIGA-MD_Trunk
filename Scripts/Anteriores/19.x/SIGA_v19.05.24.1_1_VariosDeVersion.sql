IF dbo.ExisteFuncion('InfTotaldeCobranzaPorDia') = 'False' AND dbo.ExisteFuncion('CuentasCorrientes') = 'True'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfTotaldeCobranzaPorDia', 'Informe Total de Cobranza por Dia', 'Informe Total de Cobranza por Dia', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes',59, 'Eniac.Win', 'InfTotaldeCobranzaPorDia', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfTotaldeCobranzaPorDia' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END;
