IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CuentasCorrientes')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
          VALUES
             ('ModificarRecibosAClientes', 'Modificar Recibo de Cliente', 'Modificar Recibo de Cliente', 'True', 'False', 'True', 'True',
              'CuentasCorrientes', 19, 'Eniac.Win', 'ConsultarRecibosAClientes', NULL, 'MODIFICAR',
              'True', 'S', 'O', 'O', 'O');

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT IdRol, 'ModificarRecibosAClientes' IdFuncion FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('AnulacionRecibosAClientes');
    END;
