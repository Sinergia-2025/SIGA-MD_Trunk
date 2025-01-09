
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfAuditoriaProductos', 'Informe de Auditoría Productos', 'Informe de Auditoría Productos', 'True', 'False', 'True', 'True',
      'Archivos', 125, 'Eniac.Win', 'InfAuditoriaProductos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfAuditoriaProductos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
