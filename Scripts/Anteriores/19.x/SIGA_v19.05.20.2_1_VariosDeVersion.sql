IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfVentasCobranzas')
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfVentasCobranzas', 'Informe de Ventas y Cobranzas', 'Informe de Ventas y Cobranzas', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 350, 'Eniac.Win', 'InfVentasCobranzas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
END;
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InfVentasCobranzas' FROM RolesFunciones WHERE IdFuncion = 'InfCoeficienteCobranzas';

GO

