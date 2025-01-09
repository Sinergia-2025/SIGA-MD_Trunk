PRINT ''
PRINT '1. Menu Nuevo: Turnos.'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
    BEGIN
        --Inserto el Menú del Módulo
        INSERT INTO Funciones
           (Id, Nombre, Descripcion
           ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
         VALUES
           ('Turnos', 'Turnos', '', 
            'True', 'False', 'True', 'True', NULL, 60, 'Eniac.Win', NULL, NULL);
        INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'Turnos' AS Pantalla FROM dbo.Roles
                WHERE Id IN ('Adm', 'Supervidor', 'Oficina');
    END;
PRINT ''
PRINT '2. Menu Nuevo: Turnos\CalendariosABM.'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CalendariosABM')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono)
          VALUES
             ('CalendariosABM', 'Calendarios', 'Calendarios', 'True', 'False', 'True', 'True',
              'Turnos', 10, 'Eniac.Win', 'CalendariosABM', NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'CalendariosABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;

PRINT ''
PRINT '3. Pantalla nueva de Turnos'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'TurnosABM')
  BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono)
          VALUES
             ('TurnosABM', 'Turnos', 'Turnos', 'True', 'False', 'True', 'True',
              'Turnos', 20, 'Eniac.Win', 'TurnosABM', NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TurnosABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;
GO
PRINT ''
PRINT '4. Nuevo Menu: ABM de Tipos de Turnos'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'TiposTurnosABM')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono)
          VALUES
             ('TiposTurnosABM', 'Tipos de Turnos', 'Tipos de Turnos', 'True', 'False', 'True', 'True',
              'Turnos', 200, 'Eniac.Win', 'TiposTurnosABM', NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TiposTurnosABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;
GO
PRINT '5. Nuevo Menu: Turnos\Informe de Turnos.'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfTurnosCalendarios')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono)
          VALUES
             ('InfTurnosCalendarios', 'Informe de Turnos', 'Informe de Turnos', 'True', 'False', 'True', 'True',
              'Turnos', 100, 'Eniac.Win', 'InfTurnosCalendarios', NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'InfTurnosCalendarios' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;
GO
PRINT ''
PRINT '6. Nuevo Alerta: Alerta de Turnos No Efectivos.'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'AlertaTurnos')
    BEGIN
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono)
          VALUES
             ('AlertaTurnos', 'Alerta de Turnos No Efectivos', 'Alerta de Turnos No Efectivos', 'False', 'False', 'True', 'False', 
              'Turnos', 9999, 'Eniac.Win', 'InfTurnos', NULL)

        INSERT INTO RolesFunciones (IdRol, IdFuncion)
        SELECT DISTINCT Id AS Rol, 'AlertaTurnos' AS Pantalla FROM Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END;
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'AlertaTurnos' AND IdPadre = 'TurnosAnt')
    BEGIN
        UPDATE Funciones
           SET IdPadre = 'Turnos'
         WHERE Id = 'AlertaTurnos';
    END;
GO
PRINT ''
PRINT '7. Nuevos Menues de Turnos.'
GO
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'TiposAntecedentesABM')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('TiposAntecedentesABM', 'ABM de Tipos Antecedentes', 'ABM de Tipos Antecedentes', 'True', 'False', 'True', 'True',
              'Turnos', 210, 'Eniac.Win', 'TiposAntecedentesABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TiposAntecedentesABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('AntecedentesABM', 'ABM de Antecedentes', 'ABM de Antecedentes', 'True', 'False', 'True', 'True',
              'Turnos', 220, 'Eniac.Win', 'AntecedentesABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'AntecedentesABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
                      --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('TableroTurnos', 'Tablero de Turnos', 'Tablero de Turnos', 'True', 'False', 'True', 'True',
              'Turnos', 30, 'Eniac.Win', 'Turnos', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TableroTurnos' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
                               --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ClientesAntecedentes', 'Antecedentes de Clientes', 'Antecedentes de Clientes', 'True', 'False', 'True', 'True',
              'Turnos', 40, 'Eniac.Win', 'ClientesAntecedentes', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'ClientesAntecedentes' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
                                    --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('Ingreso', 'Ingreso', 'Ingreso', 'True', 'False', 'True', 'True',
              'Turnos', 5, 'Eniac.Win', 'Ingreso', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'Ingreso' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;

PRINT ''
PRINT '8. Nueva Menu: Turnos\Excepciones de Calendarios.'
GO

IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CalendariosExcepciones')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('CalendariosExcepciones', 'Excepciones de Calendarios', 'Excepciones de Calendarios', 'True', 'False', 'True', 'True',
              'Turnos', 15, 'Eniac.Win', 'CalendariosExcepciones', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'CalendariosExcepciones' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
    END;
