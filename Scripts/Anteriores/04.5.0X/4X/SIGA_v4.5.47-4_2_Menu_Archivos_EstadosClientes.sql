
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
     IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('EstadosClientesABM', 'Estados de Clientes', 'Estados de Clientes', 'True', 'False', 'True', 'True', 
      'Archivos', 45, 'Eniac.Win', 'EstadosClientesABM', NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosClientesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO
