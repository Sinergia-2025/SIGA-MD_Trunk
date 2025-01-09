
-- Generico / Plumas Aloe
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '23238857449'))
BEGIN
    --POST
    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSURLWEBPOST' AS IdParametro
                       ,'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'URL Web Pedidos' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
    MERGE INTO Parametros AS P
         USING (SELECT 'ESTADOPEDIDOPENDIENTEWEBPOST' AS IdParametro
                       ,'PENDIENTE' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'Estado de Pedido a Enviar' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
    MERGE INTO Parametros AS P
         USING (SELECT 'ESTADOPEDIDOENVIADOWEBPOST' AS IdParametro
                       ,'ENTREGADO' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'Estado de Pedido Enviado' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;

    --GET
    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSURLWEBGET' AS IdParametro
                       ,'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido/CuitEmpresa/23238857449' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'URL Web Pedidos' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSWEBFORMATO' AS IdParametro
                       ,'SiGA' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'Formato Web Pedidos' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;

    --PUT
    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSURLWEBPUT' AS IdParametro
                       ,'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido/id/{0}/estado/{1}' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'URL Web Pedidos' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
END

SELECT *
  FROM Parametros
 WHERE IdParametro IN ('PEDIDOSURLWEBPOST',
                       'ESTADOPEDIDOPENDIENTEWEBPOST',
                       'ESTADOPEDIDOENVIADOWEBPOST',
                       'PEDIDOSURLWEBGET',
                       'PEDIDOSWEBFORMATO',
                       'PEDIDOSURLWEBPUT')
;
