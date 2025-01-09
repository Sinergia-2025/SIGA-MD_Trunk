
-- Plumas Aloe

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('50000000024', '23238857449'))	
BEGIN
    --CLIENTES   **********************************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESURLDELETE' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigacliente/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL DELETE' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESURLGET' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigacliente/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESURLGETCOUNT' AS IdParametro, 
                       '' ValorParametro ,  --NO SE PAGINA HASTA EL MOMENTO
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESURLPOST' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigacliente/' ValorParametro ,
                       'URL POST' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESTAMANOPAGINAPOST' AS IdParametro, 
                       '500' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESTAMANOPAGINAGET' AS IdParametro, 
                       '99999999' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESARCHIVOEXPORTACION' AS IdParametro, 
                       '' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    --PRODUCTOS   *********************************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSURLDELETE' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproducto/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL DELETE' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSURLGET' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductodesdehasta/CuitEmpresa/23238857449/Desde/{0}/Cantidad/{1}/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSURLGETCOUNT' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductoregistros/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSURLPOST' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproducto/' ValorParametro ,
                       'URL POST' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSTAMANOPAGINAPOST' AS IdParametro, 
                       '1000' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSTAMANOPAGINAGET' AS IdParametro, 
                       '1000' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSARCHIVOEXPORTACION' AS IdParametro, 
                       '' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    --PRODUCTOSSUCURSALES   ***********************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURURLDELETE' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursal/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL DELETE' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURURLGET' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursaldesdehasta/CuitEmpresa/23238857449/Desde/{0}/Cantidad/{1}/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURURLGETCOUNT' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalregistros/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURURLPOST' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursal/' ValorParametro ,
                       'URL POST' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURTAMANOPAGINAPOST' AS IdParametro, 
                       '5000' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURTAMANOPAGINAGET' AS IdParametro, 
                       '5000' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURARCHIVOEXPORTACION' AS IdParametro, 
                       '' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    --PRODUCTOSSUCURSALESPRECIOS   ****************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLDELETE' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalesprecio/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL DELETE' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLGET' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalespreciodesdehasta/CuitEmpresa/23238857449/Desde/{0}/Cantidad/{1}/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLGETCOUNT' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalesprecioregistros/CuitEmpresa/23238857449/' ValorParametro ,
                       'URL GET' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLPOST' AS IdParametro, 
                       'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalesprecio/' ValorParametro ,
                       'URL POST' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAPOST' AS IdParametro, 
                       '10000' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAGET' AS IdParametro, 
                       '10000' ValorParametro ,
                       'Tamaño Página' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSARCHIVOEXPORTACION' AS IdParametro, 
                       '' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);


    --SOLO PARA DEBUG   ***************************************************************************
/*
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESARCHIVOEXPORTACION' AS IdParametro, 
                       'c:\temp\_json\export\clientes_{0:000}.json' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSARCHIVOEXPORTACION' AS IdParametro, 
                       'c:\temp\_json\export\productos_{0:000}.json' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURARCHIVOEXPORTACION' AS IdParametro, 
                       'c:\temp\_json\export\productossucursales_{0:000}.json' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSARCHIVOEXPORTACION' AS IdParametro, 
                       'c:\temp\_json\export\productossucursalesprecios_{0:000}.json' ValorParametro ,
                       'Archivo Exportación' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);
*/
END


SELECT *
  FROM Parametros
 WHERE IdParametro IN ('WEBARCHIVOSCLIENTESURLDELETE',
                       'WEBARCHIVOSCLIENTESURLGET',
                       'WEBARCHIVOSCLIENTESURLGETCOUNT',        --
                       'WEBARCHIVOSCLIENTESURLPOST',
                       'WEBARCHIVOSCLIENTESTAMANOPAGINAGET',    --
                       'WEBARCHIVOSCLIENTESTAMANOPAGINAPOST',
                       'WEBARCHIVOSCLIENTESARCHIVOEXPORTACION',

                       'WEBARCHIVOSPRODUCTOSURLDELETE',
                       'WEBARCHIVOSPRODUCTOSURLGET',
                       'WEBARCHIVOSPRODUCTOSURLGETCOUNT',       --
                       'WEBARCHIVOSPRODUCTOSURLPOST',
                       'WEBARCHIVOSPRODUCTOSTAMANOPAGINAGET',   --
                       'WEBARCHIVOSPRODUCTOSTAMANOPAGINAPOST',
                       'WEBARCHIVOSPRODUCTOSARCHIVOEXPORTACION',

                       'WEBARCHIVOSPRODSUCURURLDELETE',
                       'WEBARCHIVOSPRODSUCURURLGET',
                       'WEBARCHIVOSPRODSUCURURLGETCOUNT',        --
                       'WEBARCHIVOSPRODSUCURURLPOST',
                       'WEBARCHIVOSPRODSUCURTAMANOPAGINAGET',   --
                       'WEBARCHIVOSPRODSUCURTAMANOPAGINAPOST',
                       'WEBARCHIVOSPRODSUCURARCHIVOEXPORTACION',

                       'WEBARCHIVOSPRODSUCURPRECIOSURLDELETE',
                       'WEBARCHIVOSPRODSUCURPRECIOSURLGET',
                       'WEBARCHIVOSPRODSUCURPRECIOSURLGETCOUNT',        --
                       'WEBARCHIVOSPRODSUCURPRECIOSURLPOST',
                       'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAGET',    --
                       'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAPOST',
                       'WEBARCHIVOSPRODSUCURPRECIOSARCHIVOEXPORTACION')
 ORDER BY IdParametro
;

