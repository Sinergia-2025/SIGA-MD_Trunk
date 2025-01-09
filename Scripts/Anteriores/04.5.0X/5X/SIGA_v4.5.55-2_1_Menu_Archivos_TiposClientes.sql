
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
     IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('TiposClientesABM', 'Tipos de Clientes', 'Tipos de Clientes', 'True', 'False', 'True', 'True', 
      'Archivos', 175, 'Eniac.Win', 'TiposClientesABM', NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposClientesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO
