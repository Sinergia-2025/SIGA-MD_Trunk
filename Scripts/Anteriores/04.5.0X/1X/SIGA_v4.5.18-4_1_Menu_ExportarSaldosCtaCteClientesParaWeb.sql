
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ExportarSaldosCtaCtClientesWeb', 'Exportar Saldos Cta.Cte. Clientes para Web', 'Exportar Saldos Cta.Cte. Clientes para Web', 'True', 'False', 'True', 'True',
      'Procesos', 220, 'Eniac.Win', 'ExportarSaldosCtaCteClientesWeb', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExportarSaldosCtaCtClientesWeb' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
