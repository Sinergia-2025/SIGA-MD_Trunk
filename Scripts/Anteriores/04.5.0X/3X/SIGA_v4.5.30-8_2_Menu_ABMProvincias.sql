
-- Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ProvinciasABM', 'ABM de Provincias', 'ABM de Provincias', 'True', 'False', 'True', 'True',
      'AFIP', 150, 'Eniac.Win', 'ProvinciasABM', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProvinciasABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
