
MERGE INTO Parametros AS P
     USING (SELECT 'SOLICITARCAESELECCIONARTODOS' AS IdParametro, (SELECT CASE WHEN ValorParametro = '30711915695' 
                                                                     THEN 'False' ELSE 'True' END FROM Parametros 
                                                                    WHERE IdParametro = 'CUITEMPRESA') AS ValorParametro, NULL AS CategoriaParametro, 'Solicitar CAE inicia con todo seleccionado' AS DescripcionParametro) AS PT
                                                                    --DESHABILITADO SOLO PARA SEÑALAR
        ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
    UPDATE
       SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN
    INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
    VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro);

SELECT ValorParametro FROM Parametros WHERE IdParametro = 'SOLICITARCAESELECCIONARTODOS';
