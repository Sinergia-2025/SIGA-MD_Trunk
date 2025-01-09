
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosPersonalABM', 'ABM de Personal', 'ABM de Personal', 
    'True', 'False', 'True', 'True', 'Sueldos', 60, 'Eniac.Win', 'SueldosPersonalABM', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosPersonalABM' AS Pantalla FROM dbo.Roles
GO
