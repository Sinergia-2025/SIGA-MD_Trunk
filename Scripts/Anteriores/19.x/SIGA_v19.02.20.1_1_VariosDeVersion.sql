PRINT ''
PRINT '1. Parametro Nuevo COLORCONCILIADO y COLORNOCONCILIADO'
MERGE INTO Parametros AS P
        USING (SELECT 'COLORCONCILIADO'   AS IdParametro, '-1'     ValorParametro, 'Libro Banco utiliza Color Concilidado'   AS DescripcionParametro UNION ALL
               SELECT 'COLORNOCONCILIADO' AS IdParametro, '-47032' ValorParametro, 'Libro Banco utiliza Color Desconcilido'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;

PRINT ''
PRINT '2. Habilitar Consultas Multi Sucursal para todos - Parametro Nuevo PERMITECONSULTARMULTIPLESUCURSAL y CONSULTARMULTIPLESUCURSAL'
MERGE INTO Parametros AS P
        USING (SELECT 'PERMITECONSULTARMULTIPLESUCURSAL' AS IdParametro, 'True' ValorParametro, 'Permite Consultar Multiple Sucursal' AS DescripcionParametro UNION ALL
               SELECT 'CONSULTARMULTIPLESUCURSAL'        AS IdParametro, 'True' ValorParametro, 'Consultar Multiple Sucursal'         AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;

PRINT ''
PRINT '3. Corrige Percepciones Con Planilla y Sin Movimiento'
UPDATE PercepcionVentas
   SET NroPlanillaIngreso = NULL
 WHERE NroMovimientoIngreso IS NULL
   AND NroPlanillaIngreso IS NOT NULL

