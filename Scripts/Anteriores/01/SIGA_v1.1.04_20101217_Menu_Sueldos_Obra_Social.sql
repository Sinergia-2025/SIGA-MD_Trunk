
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosObraSocialABM', 'ABM de Obras Sociales', 'ABM de Obras Sociales', 
    'True', 'False', 'True', 'True', 'Sueldos', 90, 'Eniac.Win', 'SueldosObraSocialABM', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosObraSocialABM ' AS Pantalla FROM dbo.Roles
GO
