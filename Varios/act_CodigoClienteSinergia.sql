DECLARE @codigoEmpresa varchar(max) = '211'

MERGE INTO Parametros AS P
        USING (SELECT 'CODIGOCLIENTESINERGIA' AS IdParametro, @codigoEmpresa ValorParametro, 'Código de Cliente'  AS DescripcionParametro UNION ALL
               SELECT 'CLAVECLIENTESINERGIA' AS IdParametro, @codigoEmpresa ValorParametro, 'Clave de Cliente'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
