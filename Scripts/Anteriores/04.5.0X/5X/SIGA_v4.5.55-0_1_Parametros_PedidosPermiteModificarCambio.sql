
DECLARE @valorParametro varchar(MAX)
SET @valorParametro = 'True'

-- VP
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                    AND P.ValorParametro IN ('30711162891'))	
BEGIN
    SET @valorParametro = 'False'
END

MERGE INTO Parametros AS P
     USING (SELECT 'PEDIDOSPERMITEMODIFICARCAMBIO' AS IdParametro
                   ,@valorParametro ValorParametro
                   ,NULL AS CategoriaParametro
                   ,'Permite Modificar tipo de cambio' AS DescripcionParametro) AS PT
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
 WHERE IdParametro = 'PEDIDOSPERMITEMODIFICARCAMBIO'
;
