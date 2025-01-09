
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ExportarClientesWeb', 'Exportar Clientes para Web', 'Exportar Clientes para Web', 'True', 'False', 'True', 'True',
      'Procesos', 210, 'Eniac.Win', 'ExportarClientesWeb', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExportarClientesWeb' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
