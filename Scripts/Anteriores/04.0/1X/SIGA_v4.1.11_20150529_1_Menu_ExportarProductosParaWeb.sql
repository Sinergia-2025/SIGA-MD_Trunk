
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ExportarProductosWeb', 'Exportar Productos para Web', 'Exportar Productos para Web', 'True', 'False', 'True', 'True',
      'Procesos', 200, 'Eniac.Win', 'ExportarProductosWeb', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExportarProductosWeb' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
