
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('Consolidado', 'Consolidado', 'Consolidado', 'True', 'False', 'True', 'True',
           'Caja', 110, 'Eniac.Win', 'Consolidado', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Consolidado' AS Pantalla FROM dbo.Roles
GO
