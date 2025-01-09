SELECT Periodo, Posicion FROM
(
SELECT TOP (12) PeriodoFiscal, RIGHT(PeriodoFiscal,4) AS Periodo, ROUND(Posicion/1000,2) AS Posicion
  FROM PeriodosFiscales
   WHERE PeriodoFiscal< CONVERT(INTEGER,REPLACE(LEFT(CONVERT(VARCHAR(11), GETDATE(), 120),7),'-',''))
 ORDER BY 1 DESC
) T1
ORDER BY 1

