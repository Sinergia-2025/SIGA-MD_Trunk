
DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCONTROLATOPECF'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tope Consumidor Final'
DECLARE @valorParametro VARCHAR(MAX) = '10466'

UPDATE Parametros
   SET ValorParametro = CASE WHEN ValorParametro < 8736 THEN @valorParametro ELSE ValorParametro END
 WHERE IdParametro = @idParametro
