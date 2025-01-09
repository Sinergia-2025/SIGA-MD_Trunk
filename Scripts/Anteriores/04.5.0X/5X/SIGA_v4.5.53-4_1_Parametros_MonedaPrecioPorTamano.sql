
DECLARE @idMoneda varchar(MAX)
SET @idMoneda = 1

-- VP
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                    AND P.ValorParametro IN ('30711162891'))	
BEGIN
    SET @idMoneda = 2
END

MERGE INTO Parametros AS P
     USING (SELECT 'PEDIDOSMONEDAPRECIOVENTAPORTAMANO' AS IdParametro
                   ,@idMoneda ValorParametro
                   ,NULL AS CategoriaParametro
                   ,'Moneda para Precio por Tamaño' AS DescripcionParametro) AS PT
        ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
    UPDATE
       SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN
    INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
    VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
;

SELECT *
  FROM Parametros
 WHERE IdParametro = 'PEDIDOSMONEDAPRECIOVENTAPORTAMANO'
;
