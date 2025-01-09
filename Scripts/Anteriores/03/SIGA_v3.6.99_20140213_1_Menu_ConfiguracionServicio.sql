
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConfiguracionServiciosSSS', 'Configuración de Backup Automático', 'Configuración de Backup Automático', 
    'True', 'False', 'True', 'True', 'Configuraciones', 50, 'Eniac.Win', 'ConfiguracionServiciosSSS', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConfiguracionServiciosSSS' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
