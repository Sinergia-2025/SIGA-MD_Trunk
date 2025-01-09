
DELETE Parametros wHERE IdParametro = 'MODULOCUENTACORRIENTE'
GO


INSERT INTO Parametros 
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
    ('MODULOCUENTACORRIENTECLIENTES', 'True', NULL, 'Compro el modulo de Cuenta Corriente de Clientes')
GO


INSERT INTO Parametros 
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
    ('MODULOCUENTACORRIENTEPROVEEDORES', 'True', NULL, 'Compro el modulo de Cuenta Corriente de Proveedores')
GO

