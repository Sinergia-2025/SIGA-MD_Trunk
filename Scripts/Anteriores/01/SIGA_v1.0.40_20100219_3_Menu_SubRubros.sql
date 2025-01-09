
--Inserto la pantalla nueva


INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('SubRubros', 'SubRubros', 'SubRubros', 'True', 'False', 'True', 'True',
           'Archivos', 95, 'Eniac.Win', 'SubRubrosABM', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SubRubros' AS Pantalla FROM dbo.Roles
GO
