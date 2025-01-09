
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ExportarCtaCteClientes', 'Exportar Cta.Cte. Clientes', 'Exportar Cta.Cte. Clientes', 'True', 'False', 'True', 'True',
      'Procesos', 230, 'Eniac.Win', 'ExportarCtaCteClientes', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExportarCtaCteClientes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
