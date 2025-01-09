
--Insertar Menu

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('TiposContactosABM', 'Tipos de Contactos', 'Tipos de Contactos', 'True', 'False', 'True',
      'True', 'Archivos', 180, 'Eniac.Win', 'TiposContactosABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposContactosABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
