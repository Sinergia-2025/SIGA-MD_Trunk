
  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Sueldos', 'Sueldos', '', 
    'True', 'False', 'True', 'True', NULL, 88, 'Eniac.Win', NULL, NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Sueldos' AS Pantalla FROM dbo.Roles
GO
