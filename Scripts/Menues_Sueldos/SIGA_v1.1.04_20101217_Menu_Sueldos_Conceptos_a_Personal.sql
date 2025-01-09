
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosConceptosPersonal', 'Carga de Conceptos al Personal', 'Carga de Conceptos al Personal', 
    'True', 'False', 'True', 'True', 'Sueldos', 10, 'Eniac.Win', 'SueldosConceptosPersonal', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosConceptosPersonal' AS Pantalla FROM dbo.Roles
GO
