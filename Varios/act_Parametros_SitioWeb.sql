
--SELECT ValorParametro, REPLACE(ValorParametro, 'plumasaloe', 'nuevositio')
--  FROM Parametros
-- WHERE LEFT(IdParametro,3) = 'WEB'
--   AND ValorParametro LIKE '%plumasaloe%'
--GO

--SELECT ValorParametro, REPLACE( REPLACE(ValorParametro, '33711345499', '11111111111'), '23238857449', '11111111111')
--  FROM Parametros
-- WHERE LEFT(IdParametro,3) = 'WEB'
--   AND (ValorParametro LIKE '%33711345499%' OR ValorParametro LIKE '%23238857449%')
--GO

PRINT ''
PRINT '1. Modifico el Sitio WEB.'
GO

UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, 'plumasaloe', 'nuevositio')
 WHERE LEFT(IdParametro,3) = 'WEB'
   AND ValorParametro LIKE '%plumasaloe%'
GO

PRINT ''
PRINT '2. Modifico el CUIT.'
GO

UPDATE Parametros
   SET ValorParametro = REPLACE( REPLACE(ValorParametro, '33711345499', '11111111111'), '23238857449', '11111111111')
 WHERE LEFT(IdParametro,3) = 'WEB'
   AND (ValorParametro LIKE '%33711345499%' OR ValorParametro LIKE '%23238857449%')
GO
