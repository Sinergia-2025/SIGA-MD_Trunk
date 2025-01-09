SELECT * FROM Parametros WHERE IdParametro = 'TIPOIMPRESIONFISCAL';

SELECT ArchivoAImprimir FROM TiposComprobantesLetras WHERE IdTipoComprobante = 'eFACT';

MERGE INTO Parametros AS P
     USING (SELECT 'TIPOIMPRESIONFISCAL' AS IdParametro
                  ,ISNULL(MAX(CASE WHEN ArchivoAImprimir LIKE '%3%' THEN 3 ELSE 
                              CASE WHEN ArchivoAImprimir LIKE '%2%' THEN 2 ELSE 1 END END), 2) ValorParametro
                  ,NULL AS CategoriaParametro
                  ,'Tipo de Impresión Fiscal' AS DescripcionParametro
              FROM TiposComprobantesLetras
             WHERE IdTipoComprobante = 'eFACT') AS PT
        ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
    UPDATE
       SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN
    INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
    VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro);

SELECT * FROM Parametros WHERE IdParametro = 'TIPOIMPRESIONFISCAL';
