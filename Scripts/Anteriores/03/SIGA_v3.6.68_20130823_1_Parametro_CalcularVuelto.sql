
IF EXISTS (SELECT ValorParametro FROM Parametros
            WHERE IdParametro = 'FACTURACIONCONTADOESENPESOS'
              AND ValorParametro = 'False')
    BEGIN
		UPDATE Parametros
		   SET ValorParametro = 'NOOFRECER'
  	     WHERE IdParametro = 'FACTURACIONOFRECECALCULARVUELTO'
    END
GO
