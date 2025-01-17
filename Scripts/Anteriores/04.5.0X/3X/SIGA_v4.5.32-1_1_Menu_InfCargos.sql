
-- Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfCargos', 'Informe de Liquidacion de Cargos', 'Informe de Liquidacion de Cargos', 'True', 'False', 'True', 'True',
      'Cargos', 80, 'Eniac.Win', 'InfCargos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCargos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
