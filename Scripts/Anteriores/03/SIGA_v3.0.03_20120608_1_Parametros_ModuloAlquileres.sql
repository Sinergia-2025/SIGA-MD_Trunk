
INSERT INTO Parametros 
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
    ('MODULOALQUILER', 'False', NULL, 'Utiliza el Modulo de Alquiler')
GO

UPDATE Parametros
   SET DescripcionParametro = 'Utiliza el Modulo ' + right(DescripcionParametro,LEN(DescripcionParametro)- 17)
 WHERE LEFT(DescripcionParametro,9) = 'Compro el'
GO

