  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosEstadoCivilABM', 'ABM de Estados Civiles', 'ABM de Estados Civiles', 
    'True', 'False', 'True', 'True', 'Sueldos', 80, 'Eniac.Win', 'SueldosEstadoCivilABM', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosEstadoCivilABM' AS Pantalla FROM dbo.Roles
GO
