
--Insertar Menu

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('TiposComprobantesABM', 'Tipos de Comprobantes', 'Tipos de Comprobantes', 'True', 'False', 'True',
      'True', 'Archivos', 175, 'Eniac.Win', 'TiposComprobantesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposComprobantesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
