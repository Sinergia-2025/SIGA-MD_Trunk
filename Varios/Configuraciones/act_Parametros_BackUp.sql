DECLARE @codigoClienteSinergia VARCHAR(MAX) = ''
DECLARE @claveClienteSinergia  VARCHAR(MAX) = ''

MERGE INTO Parametros AS P
        USING (SELECT 'CODIGOCLIENTESINERGIA' AS IdParametro, @codigoClienteSinergia ValorParametro, 'Código de Cliente' DescripcionParametro UNION
               SELECT 'CLAVECLIENTESINERGIA'  AS IdParametro, @claveClienteSinergia  ValorParametro, 'Clave de Cliente' DescripcionParametro ) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
