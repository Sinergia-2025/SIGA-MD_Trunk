UPDATE Parametros
   SET ValorParametro = CONVERT(VARCHAR(MAX), DATEADD(DAY, -1, CONVERT(datetime,ValorParametro,103)), 103)
 WHERE IdParametro = 'VENCIMIENTOCERTIFICADOFE'
;
