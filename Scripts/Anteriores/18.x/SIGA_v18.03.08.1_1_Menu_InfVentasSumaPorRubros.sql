
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Ventas')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('InfVentasSumaPorRubros', 'Inf. Ventas Suma por Rubro', 'Inf. Ventas Suma por Rubro', 'True', 'False', 'True', 'True',
              'Ventas', 165, 'Eniac.Win', 'InfVentasSumaPorRubros', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'InfVentasSumaPorRubros' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;
