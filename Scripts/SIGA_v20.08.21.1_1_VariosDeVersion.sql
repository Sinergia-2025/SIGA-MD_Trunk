PRINT ''
PRINT '1. Parametros: Actualizacion Tope CF'

IF dbo.GetValorParametro('FACTURACIONCONTROLATOPECF') <= 7700
	UPDATE Parametros 
	   SET ValorParametro = 8736 
	 WHERE IdParametro = 'FACTURACIONCONTROLATOPECF' 

GO