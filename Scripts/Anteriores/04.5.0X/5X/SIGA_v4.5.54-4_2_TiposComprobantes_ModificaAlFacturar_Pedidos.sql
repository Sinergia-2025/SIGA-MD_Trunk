
--SI ES VP
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                    AND P.ValorParametro IN ('30711162891'))	
BEGIN
    UPDATE TiposComprobantes
       SET ModificaAlFacturar = 'NO'
     WHERE Tipo IN ('PEDIDOSCLIE', 'PRESUPCLIE')
END

SELECT ModificaAlFacturar, *
  FROM TiposComprobantes
 WHERE Tipo IN ('PEDIDOSCLIE', 'PRESUPCLIE')
