
-- CEAR

DECLARE @PEDIDOSMOSTRARFORMULA varchar(MAX)
SET @PEDIDOSMOSTRARFORMULA = 'False'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('30715213091'))	
BEGIN
    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMONEDAPRECIOVENTAPORTAMANO' AS IdParametro, '1' ValorParametro ,'Moneda Precio Venta por Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARTAMANO' AS IdParametro ,'False' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARUM' AS IdParametro ,'False' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRECIOVENTAPORTAMANO' AS IdParametro ,'False' ValorParametro ,'Moneda Precio Venta por Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARCOSTO' AS IdParametro ,'True' ValorParametro ,'Moneda Precio Venta por Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARMONEDA' AS IdParametro ,'False' ValorParametro ,'Moneda Precio Venta por Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARSEMAFORORENTABILIDADDETALLE' AS IdParametro ,'False' ValorParametro ,'Moneda Precio Venta por Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOESPPULGADAS' AS IdParametro ,'False' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOESPMM' AS IdParametro ,'False' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOSAE' AS IdParametro ,'False' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOPRODUCCIONPROCESO' AS IdParametro ,'False' ValorParametro
                       ,'Tamaño' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOPRODUCCIONFORMA' AS IdParametro ,'False' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOLARGOEXTALTO' AS IdParametro ,'True' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARPRODUCTOANCHOINTBASE' AS IdParametro ,'True' ValorParametro ,'Tamaño' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARURLPLANODETALLE' AS IdParametro, 'False' ValorParametro ,'Mostrar URL Plano Detalle' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);


    SET @PEDIDOSMOSTRARFORMULA = 'True'

END

    MERGE INTO Parametros AS P
         USING (SELECT 'PEDIDOSMOSTRARFORMULA' AS IdParametro, @PEDIDOSMOSTRARFORMULA ValorParametro ,'Mostrar Formula' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

SELECT *
  FROM Parametros
 WHERE IdParametro IN ('PEDIDOSMONEDAPRECIOVENTAPORTAMANO', 
                       'PEDIDOSMOSTRARTAMANO',
                       'PEDIDOSMOSTRARUM',
                       'PEDIDOSMOSTRARPRECIOVENTAPORTAMANO',
                       'PEDIDOSMOSTRARCOSTO',
                       'PEDIDOSMOSTRARMONEDA',
                       'PEDIDOSMOSTRARSEMAFORORENTABILIDADDETALLE',
                       'PEDIDOSMOSTRARPRODUCTOESPPULGADAS',
                       'PEDIDOSMOSTRARPRODUCTOESPMM',
                       'PEDIDOSMOSTRARPRODUCTOSAE',
                       'PEDIDOSMOSTRARPRODUCTOPRODUCCIONPROCESO',
                       'PEDIDOSMOSTRARPRODUCTOPRODUCCIONFORMA',
                       'PEDIDOSMOSTRARPRODUCTOLARGOEXTALTO',
                       'PEDIDOSMOSTRARPRODUCTOANCHOINTBASE',
                       'PEDIDOSMOSTRARURLPLANODETALLE',
                       'PEDIDOSMOSTRARFORMULA')
;
