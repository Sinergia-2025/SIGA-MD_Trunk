
UPDATE Parametros
   SET ValorParametro = (CASE WHEN IdParametro = 'True' THEN 'OFRECER' ELSE 'NOOFRECER' END)
 WHERE IdParametro = 'FACTURACIONOFRECECALCULARVUELTO'
GO