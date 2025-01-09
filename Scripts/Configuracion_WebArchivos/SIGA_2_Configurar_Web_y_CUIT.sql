
-- Cambio el Link
UPDATE Parametros
   SET ValorParametro =  REPLACE(ValorParametro, 'www.plumasaloe.com.ar', 'www.c1250247.ferozo.com')
 WHERE CategoriaParametro = 'WEB-ARCHIVOS'
   AND ValorParametro LIKE '%www.plumasaloe.com.ar%'
GO


-- Cambio el CUIT
UPDATE Parametros
   SET ValorParametro =  REPLACE(REPLACE(ValorParametro, '33711345499', '30715507907'), '23238857449', '30715507907')
 WHERE CategoriaParametro = 'WEB-ARCHIVOS'
   AND ValorParametro LIKE '%33711345499%' OR ValorParametro LIKE '%23238857449%' 
GO
