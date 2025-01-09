
SELECT * FROM Parametros
 WHERE IdParametro='versiondb'
GO

UPDATE Parametros
   SET ValorParametro='18.5.7.1'
 WHERE IdParametro='versiondb'
GO
