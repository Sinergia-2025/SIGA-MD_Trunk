
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfHistoricoTarjetasCupones', 'Informe Historico de Cupones de Tarjetas', 'Informe Historico de Cupones de Tarjetas', 'True', 'False', 'True', 'True'
        ,'Caja', 998, 'Eniac.Win', 'InfHistoricoTarjetasCupones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InfHistoricoTarjetasCupones' FROM RolesFunciones WHERE IdFuncion = 'PlanillaDeCaja'

