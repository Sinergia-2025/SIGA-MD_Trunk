
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfCtaCteDetalleProveedores', 'Informe de Cta. Cte. Detallada de Proveedores', 'Informe de Cta. Cte. Detallada de Proveedores', 'True', 'False', 'True', 'True', 
      'CuentasCorrientesProveedores', 52, 'Eniac.Win', 'InfCtaCteDetalleProveedores', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCtaCteDetalleProveedores' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
