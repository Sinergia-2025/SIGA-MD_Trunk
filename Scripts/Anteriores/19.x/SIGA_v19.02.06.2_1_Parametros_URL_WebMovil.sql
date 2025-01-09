MERGE INTO Parametros AS P
        USING (SELECT 'SIMOVILCOBRANZAURLBASE' AS IdParametro, 'http://w1021701.ferozo.com/webmovil/api/' ValorParametro, 'URL Base para Simovil Cobranza'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
