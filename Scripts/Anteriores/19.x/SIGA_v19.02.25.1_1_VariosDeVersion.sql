PRINT ''
PRINT '1. Parametro Nuevo CTACTECLIENTEPINTACUOTA'
DECLARE @ValorParametro varchar(max) = 'False'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('20081067490'))
BEGIN
    SET @ValorParametro = 'True'
END

MERGE INTO Parametros AS P
        USING (SELECT 'CTACTECLIENTEPINTACUOTA'   AS IdParametro, @ValorParametro     ValorParametro, 'Pinta Columna Cuota Cta Cte Clientes'   AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
select * from Parametros where IdParametro='CTACTECLIENTEPINTACUOTA'
