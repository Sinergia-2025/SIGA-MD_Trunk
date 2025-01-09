
UPDATE Parametros 
   SET ValorParametro = 1000
 WHERE IdParametro = 'FACTURACIONCONTROLATOPECF'
   AND ISNUMERIC(ValorParametro) = 0
GO
