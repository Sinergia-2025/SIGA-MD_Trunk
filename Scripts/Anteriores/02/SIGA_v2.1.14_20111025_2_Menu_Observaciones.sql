
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ObservacionesABM', 'Observaciones', 'Observaciones', 'True', 'False', 'True', 'True',
      'Archivos', 95, 'Eniac.Win', 'ObservacionesABM', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ObservacionesABM' AS Pantalla FROM dbo.Roles
GO
