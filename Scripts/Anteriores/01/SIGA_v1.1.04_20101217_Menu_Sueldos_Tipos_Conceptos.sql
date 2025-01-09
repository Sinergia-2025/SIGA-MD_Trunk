  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosTiposConceptosABM', 'ABM de Tipos de Conceptos', 'ABM de Tipos de Conceptos', 
    'True', 'False', 'True', 'True', 'Sueldos', 50, 'Eniac.Win', 'SueldosTiposConceptosABM', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosTiposConceptosABM' AS Pantalla FROM dbo.Roles
GO
