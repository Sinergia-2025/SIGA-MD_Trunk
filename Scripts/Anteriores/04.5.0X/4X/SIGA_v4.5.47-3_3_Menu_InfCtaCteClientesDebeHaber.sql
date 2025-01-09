
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfCtaCteClientesDebeHaber', 'Informe de Cta.Cte. de Clientes - Debe y Haber (General)', 'Informe de Cta.Cte. de Clientes - Debe y Haber (General)', 'True', 'False', 'True', 'True', 
      'CuentasCorrientes', 44, 'Eniac.Win', 'InfCtaCteClientesDebeHaber', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCtaCteClientesDebeHaber' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
