DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCONTROLATOPECF'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tope Consumidor Final'
DECLARE @valorParametro_NuevoTope DECIMAL(12) = '95812'

UPDATE Parametros
   SET ValorParametro = CASE WHEN ValorParametro < @valorParametro_NuevoTope THEN @valorParametro_NuevoTope ELSE ValorParametro END
 WHERE IdParametro = @idParametro

