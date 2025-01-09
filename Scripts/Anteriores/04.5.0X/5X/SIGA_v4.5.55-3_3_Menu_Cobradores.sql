
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
     IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CobradoresABM', 'Cobradores', 'Cobradores', 'True', 'False', 'True', 'True', 
      'Archivos', 35, 'Eniac.Win', 'CobradoresABM', NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CobradoresABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO

