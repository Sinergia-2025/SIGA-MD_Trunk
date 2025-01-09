
INSERT INTO Parametros 
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
SELECT 'FACTURACIONPERMITECANTIDADNEGATIVAACUMULADA' as xxIdParametro
      , ValorParametro
      , CategoriaParametro
      , 'Permite Permite Cantidad en Negativo Aculumada' AS xxDescripcionParametro 
  FROM Parametros 
    WHERE IdParametro = 'FACTURACIONPERMITECANTIDADNEGATIVA'
GO
