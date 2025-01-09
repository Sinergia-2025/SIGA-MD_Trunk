
SELECT ValorParametro FROM Parametros AS P
 WHERE P.IdParametro = 'FACTURACIONDETALLACHEQUESYTARJETAS';


IF NOT EXISTS (SELECT 1 FROM Parametros AS P
                WHERE P.IdParametro = 'CUITEMPRESA'
                  AND P.ValorParametro IN ('30714356921', '30708742550'))
    BEGIN
		UPDATE Parametros
		   SET ValorParametro = 'False'
		 WHERE IdParametro = 'FACTURACIONDETALLACHEQUESYTARJETAS';
    END;

/* -- Verifico -- */

SELECT ValorParametro FROM Parametros AS P
 WHERE P.IdParametro = 'FACTURACIONDETALLACHEQUESYTARJETAS';
