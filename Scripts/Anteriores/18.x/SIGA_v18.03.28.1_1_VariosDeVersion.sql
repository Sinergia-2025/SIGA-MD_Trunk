
PRINT '1. Nuevo Menu: Turnos\Informe de Turnos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
    BEGIN
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
    END;
GO

PRINT ''
PRINT '2. Nuevo Alerta: Alerta de Turnos No Efectivos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
    BEGIN
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
    END;
GO
