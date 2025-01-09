
UPDATE Funciones SET
    Nombre = 'C.C. Clientes'
  WHERE Id = 'CuentasCorrientes'
GO

UPDATE Funciones SET
    Nombre = 'C.C. Proveedores'
  WHERE Id = 'CuentasCorrientesProveedores'
GO

DELETE FROM RolesFunciones
 WHERE IdFuncion = 'CobranzasaRealizar'
GO
