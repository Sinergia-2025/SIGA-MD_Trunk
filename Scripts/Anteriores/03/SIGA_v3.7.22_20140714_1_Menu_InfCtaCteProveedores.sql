
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfCtaCteProveedores', 'Informe de Cta. Cte. de Proveedores', 'Informe de Cta. Cte. de Proveedores', 'True', 'False', 'True', 'True', 
      'CuentasCorrientesProveedores', 42, 'Eniac.Win', 'InfCtaCteProveedores', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCtaCteProveedores' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
