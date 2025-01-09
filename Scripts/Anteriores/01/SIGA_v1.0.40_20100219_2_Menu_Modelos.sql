
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('Modelos', 'Modelos', 'Modelos', 'True', 'False', 'True', 'True',
           'Archivos', 85, 'Eniac.Win', 'ModelosABM', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Modelos' AS Pantalla FROM dbo.Roles
GO
