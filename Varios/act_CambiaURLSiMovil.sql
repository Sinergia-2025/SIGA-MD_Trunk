DECLARE @servidorOriginal VARCHAR(MAX) = 'w1021701.ferozo.com'
DECLARE @servidorNuevo    VARCHAR(MAX) = 'sinergiamovil.com.ar'

UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, @servidorOriginal, @servidorNuevo)
 WHERE ValorParametro LIKE '%' + @servidorOriginal + '%'


SET @servidorOriginal = 'wi531792.ferozo.com'
SET @servidorNuevo    = 'sinergiamovil.com.ar'

UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, @servidorOriginal, @servidorNuevo)
  FROM Parametros
 WHERE ValorParametro LIKE '%' + @servidorOriginal + '%'
