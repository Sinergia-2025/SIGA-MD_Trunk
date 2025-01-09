
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosCategoriasABM', 'ABM de Categorias', 'ABM de Categorias', 
    'True', 'False', 'True', 'True', 'Sueldos', 70, 'Eniac.Win', 'SueldosCategoriasABM', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosCategoriasABM' AS Pantalla FROM dbo.Roles
GO
