IF dbo.ExisteFuncion('ClientesDebitosAutomaticos') = 'True' OR dbo.BaseConCuit('30703543444') = 'True'
BEGIN

    IF dbo.ExisteFuncion('CobranzaElectronica') = 'False'
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('CobranzaElectronica', 'Cobranza Electronica', 'Cobranza Electronica', 'True', 'False', 'True', 'True'
            ,'CuentasCorrientes', 490, '', '', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N');

        IF dbo.BaseConCuit('30703543444') = 'True'
	        INSERT INTO RolesFunciones (IdRol,IdFuncion)
	        SELECT DISTINCT Id AS Rol, 'CobranzaElectronica' AS Pantalla FROM dbo.Roles
	         WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
        ELSE
            INSERT INTO RolesFunciones (IdRol,IdFuncion)
            SELECT IdRol, 'CobranzaElectronica' FROM RolesFunciones WHERE IdFuncion = 'ClientesDebitosAutomaticos';
    END

    UPDATE Funciones
       SET IdPadre = 'CobranzaElectronica', Posicion = 10
     WHERE Id = 'ClientesDebitosAutomaticos';

    UPDATE Funciones
       SET IdPadre = 'CobranzaElectronica', Posicion = 30
     WHERE Id = 'ClientesRecepDebitosAuto';

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ClientesDebitosAutomaticosPMC', 'Generación Achivo Pago Mis Cuentas', 'Generación Achivo Pago Mis Cuentas', 'True', 'False', 'True', 'True'
        ,'CobranzaElectronica', 20, 'Eniac.Win', 'ClientesDebitosAutomaticosPMC', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ClientesDebitosAutomaticosPMC' FROM RolesFunciones WHERE IdFuncion = 'CobranzaElectronica';

    IF dbo.ExisteFuncion('ClientesRecepDebitosAuto') = 'False'
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('ClientesRecepDebitosAuto', 'Leer Archivo de Respuesta de Debitos Automaticos', 'Leer Archivo de Respuesta de Debitos Automaticos', 'True', 'False', 'True', 'True'
            ,'CobranzaElectronica', 30, 'Eniac.Win', 'ClientesRecepDebitosAutomaticos', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')

        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'ClientesRecepDebitosAuto' FROM RolesFunciones WHERE IdFuncion = 'CobranzaElectronica'
    END

END
