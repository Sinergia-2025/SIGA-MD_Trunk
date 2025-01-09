
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfCtaCteClientes', 'Informe de Cta. Cte. de Clientes', 'Informe de Cta. Cte. de Clientes', 'True', 'False', 'True', 'True', 
      'CuentasCorrientes', 42, 'Eniac.Win', 'InfCtaCteClientes', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCtaCteClientes' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO


/****** Pantalla Descontinuada ******/

DELETE RolesFunciones
 WHERE IdFuncion = 'InfCtaCteClientesConSaldo'
GO

DELETE Funciones
 WHERE Id = 'InfCtaCteClientesConSaldo'
GO
