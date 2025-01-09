UPDATE Parametros
   SET ValorParametro = 'ePRE-' + ValorParametro
 WHERE (IdParametro = 'IDNDEBGL'  AND ValorParametro = 'NDEB') OR
       (IdParametro = 'IDNCREDGL' AND ValorParametro = 'NCRED')
