  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosConceptosABM', 'ABM de Conceptos', 'ABM de Conceptos', 
    'True', 'False', 'True', 'True', 'Sueldos', 40, 'Eniac.Win', 'SueldosConceptosABM', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosConceptosABM' AS Pantalla FROM dbo.Roles
GO
