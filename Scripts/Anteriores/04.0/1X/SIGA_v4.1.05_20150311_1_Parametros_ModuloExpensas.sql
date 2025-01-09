
DELETE Parametros 
 WHERE IdParametro = 'PRODUCTOLIQUIDAEXPENSAS'
GO


INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('MODULOEXPENSAS', 'False', NULL, 'Utiliza el Modulo de Expensas')
GO

