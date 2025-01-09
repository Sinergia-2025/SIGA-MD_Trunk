
INSERT INTO Parametros 

  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)

SELECT 'CONSULTARPRECIOSCONIVA', (CASE WHEN ValorParametro = 'SI' THEN 'True' ELSE 'False' END), NULL, 'Precios: Consultar Precios Con IVA.'
  FROM Parametros
 WHERE IdParametro = 'PRECIOCONIVA'
 
GO
