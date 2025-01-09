
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConfiguracionServiciosSSS', 'Configuraci�n de Backup Autom�tico', 'Configuraci�n de Backup Autom�tico', 
    'True', 'False', 'True', 'True', 'Configuraciones', 50, 'Eniac.Win', 'ConfiguracionServiciosSSS', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConfiguracionServiciosSSS' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
