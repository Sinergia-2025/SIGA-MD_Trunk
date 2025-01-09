
PRINT '1. Nueva Pantalla: ActualizarPreciosV2'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Precios')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ActualizarPreciosV2', 'Actualizar Precios V2', 'Actualizar Precios V2', 'True', 'False', 'True', 'True',
              'Precios', 10, 'Eniac.Win', 'ActualizarPreciosV2', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'ActualizarPreciosV2' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;