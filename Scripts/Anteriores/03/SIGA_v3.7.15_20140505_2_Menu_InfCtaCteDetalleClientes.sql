
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfCtaCteDetalleClientes', 'Informe de Cta. Cte. Detalle de Clientes', 'Informe de Cta. Cte. Detalle de Clientes', 'True', 'False', 'True', 'True', 
      'CuentasCorrientes', 52, 'Eniac.Win', 'InfCtaCteDetalleClientes', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCtaCteDetalleClientes' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO 
