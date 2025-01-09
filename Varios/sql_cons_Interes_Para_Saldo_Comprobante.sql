DECLARE @fechaEmision nvarchar(20) = '20160815';
DECLARE @fechaRecibo  nvarchar(20) = '20160906';

SELECT CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1), *
  FROM (SELECT * FROM Intereses
        UNION
        SELECT TOP 1 DiasHasta + 1, 999999 
                    ,Interes + (((SELECT CONVERT(decimal(9,2), ISNULL(ValorParametro, 0)) AS Valor 
                                    FROM Parametros WHERE IdParametro = 'INTERESESADICIONALPROPORCIONALDIARIO') / 30) * 
                                    (CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1) - 
                                     DiasHasta)) FROM Intereses 
                                     CROSS JOIN (SELECT dateadd([month], datediff([month], '19000101', @fechaEmision), '19000101') AS PrimerDia) AS PrimerDiaMes
                                     ORDER BY DiasHasta DESC) Intereses
 CROSS JOIN (SELECT dateadd([month], datediff([month], '19000101', @fechaEmision), '19000101') AS PrimerDia) AS PrimerDiaMes
 WHERE 1 = 1
   AND DiasDesde <= CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1)
   AND DiasHasta >= CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1)


/*  PARA DIAS CORRIDOS */
--DECLARE @fechaEmision nvarchar(20) = '20160809';
--DECLARE @fechaRecibo  nvarchar(20) = '20160906';

SELECT CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, @fechaEmision)), *
  FROM (SELECT * FROM Intereses
        UNION
        SELECT TOP 1 DiasHasta + 1, 999999 
                    ,Interes + (((SELECT CONVERT(decimal(9,2), ISNULL(ValorParametro, 0)) AS Valor 
                                    FROM Parametros WHERE IdParametro = 'INTERESESADICIONALPROPORCIONALDIARIO') / 30) * 
                                    (CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, @fechaEmision)) - 
                                     DiasHasta)) FROM Intereses ORDER BY DiasHasta DESC) Intereses
 WHERE 1 = 1
   AND DiasDesde <= CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, @fechaEmision))
   AND DiasHasta >= CONVERT(int, CONVERT(datetime, @fechaRecibo) - CONVERT(datetime, @fechaEmision))
