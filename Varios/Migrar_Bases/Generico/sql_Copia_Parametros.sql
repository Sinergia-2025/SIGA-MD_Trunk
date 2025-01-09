
MERGE INTO Parametros AS P
      USING (SELECT *
               FROM SiSeN_Tifon_WP_20170705.dbo.Parametros) AS PT
         ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
    UPDATE
       SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN
    INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
    VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
;

