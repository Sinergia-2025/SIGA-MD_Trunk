
--Inserto el Menu nuevo

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('Estadisticas', 'Estadisticas', 'Estadisticas', 'True', 'False', 'True', 'True',
           NULL, 85, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Estadisticas' AS Pantalla FROM dbo.Roles
GO
