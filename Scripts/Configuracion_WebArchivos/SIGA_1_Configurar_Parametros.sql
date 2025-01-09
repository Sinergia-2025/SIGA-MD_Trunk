-- Borro todos los parametros
DELETE Parametros
 WHERE CategoriaParametro = 'WEB-ARCHIVOS'
--   AND ValorParametro = ''
GO


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



BEGIN
    --CLIENTES   **********************************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSCLIENTESURLGETMAXFECHA'  AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaclientejsonmax/CuitEmpresa/33711345499/'  ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSCLIENTESURLDELETE'       AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaclientejson/CuitEmpresa/33711345499/'     ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSCLIENTESURLPOST'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaclientejson/'                             ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSCLIENTESURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaclientejsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                              ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSCLIENTESURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaclientejsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'  ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSCLIENTESTAMANOPAGINAGET'         AS IdParametro, '99999999'      ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSCLIENTESTAMANOPAGINAPOST'        AS IdParametro, '500'           ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSCLIENTESARCHIVOEXPORTACION'      AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --PRODUCTOS   *********************************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODUCTOSURLGETMAXFECHA' AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductojsonmax/CuitEmpresa/33711345499/' ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODUCTOSURLDELETE'      AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductojson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODUCTOSURLPOST'        AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductojson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPRODUCTOSURLGETCOUNT'    AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductojsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                             ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODUCTOSURLGET'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductojsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}' ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPRODUCTOSTAMANOPAGINAGET'        AS IdParametro, '50'            ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODUCTOSTAMANOPAGINAPOST'       AS IdParametro, '50'            ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODUCTOSARCHIVOEXPORTACION'     AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --PRODUCTOSSUCURSALES   ***********************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURURLGETMAXFECHA' AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursaljsonmax/CuitEmpresa/33711345499/' ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURURLDELETE'      AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursaljson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURURLPOST'        AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursaljson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPRODSUCURURLGETCOUNT'    AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursaljsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                                ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURURLGET'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursaljsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'    ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPRODSUCURTAMANOPAGINAGET'        AS IdParametro, '50'            ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURTAMANOPAGINAPOST'       AS IdParametro, '50'            ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURARCHIVOEXPORTACION'     AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --PRODUCTOSSUCURSALESPRECIOS   ****************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLGETMAXFECHA'  AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalespreciojsonmax/CuitEmpresa/33711345499/' ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLDELETE'       AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalespreciojson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLPOST'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalespreciojson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalespreciojsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                                ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductossucursalespreciojsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'    ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAGET'     AS IdParametro, '100'         ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAPOST'    AS IdParametro, '100'         ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPRODSUCURPRECIOSARCHIVOEXPORTACION'  AS IdParametro, ''            ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --LOCALIDADES   ****************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSLOCALIDADESURLGETMAXFECHA'   AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigalocalidadjsonmax/CuitEmpresa/33711345499/'    ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSLOCALIDADESURLDELETE'        AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigalocalidadjson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSLOCALIDADESURLPOST'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigalocalidadjson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSLOCALIDADESURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigalocalidadjsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                                ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSLOCALIDADESURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigalocalidadjsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'    ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSLOCALIDADESTAMANOPAGINAGET'        AS IdParametro, '500'         ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSLOCALIDADESTAMANOPAGINAPOST'       AS IdParametro, '500'         ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSLOCALIDADESARCHIVOEXPORTACION'     AS IdParametro, ''            ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --RUBROS   ****************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSRUBROSURLGETMAXFECHA'   AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrojsonmax/CuitEmpresa/33711345499/' ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSURLDELETE'        AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrojson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSURLPOST'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrojson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSRUBROSURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrojsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                                ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrojsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'    ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSRUBROSTAMANOPAGINAGET'        AS IdParametro, '100'         ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSTAMANOPAGINAPOST'       AS IdParametro, '100'         ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSARCHIVOEXPORTACION'     AS IdParametro, ''            ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --SUBRUBROS   ****************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSSUBRUBROSURLGETMAXFECHA'   AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubrubrojsonmax/CuitEmpresa/33711345499/' ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBRUBROSURLDELETE'        AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubrubrojson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBRUBROSURLPOST'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubrubrojson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSSUBRUBROSURLGETCOUNT'      AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubrubrojsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                                ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBRUBROSURLGET'           AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubrubrojsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'    ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSSUBRUBROSTAMANOPAGINAGET'        AS IdParametro, '100'         ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBRUBROSTAMANOPAGINAPOST'       AS IdParametro, '100'         ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBRUBROSARCHIVOEXPORTACION'     AS IdParametro, ''            ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

    --SUBRUBROS   ****************************************************************
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSSUBSUBRUBROSURLGETMAXFECHA'   AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubsubrubrojsonmax/CuitEmpresa/33711345499/' ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBSUBRUBROSURLDELETE'        AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubsubrubrojson/CuitEmpresa/33711345499/'    ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBSUBRUBROSURLPOST'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubsubrubrojson/'                            ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSSUBSUBRUBROSURLGETCOUNT'      AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubsubrubrojsoncount/CuitEmpresa/33711345499/FechaActualizacion/{0}'                                ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBSUBRUBROSURLGET'           AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigasubsubrubrojsondesdehasta/CuitEmpresa/33711345499/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'    ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSSUBSUBRUBROSTAMANOPAGINAGET'        AS IdParametro, '100'         ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBSUBRUBROSTAMANOPAGINAPOST'       AS IdParametro, '100'         ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSSUBSUBRUBROSARCHIVOEXPORTACION'     AS IdParametro, ''            ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);

END


MERGE INTO Parametros AS P
     USING (SELECT 'WEBARCHIVOSMARCASURLGETMAXFECHA'  AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajsonmax/CuitEmpresa/23238857449/'  ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASURLDELETE'       AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajson/CuitEmpresa/23238857449/'     ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASURLPOST'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajson/'                             ValorParametro, 'URL POST'          AS DescripcionParametro UNION

            SELECT 'WEBARCHIVOSMARCASURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajsoncount/CuitEmpresa/23238857449/FechaActualizacion/{0}'                              ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajsondesdehasta/CuitEmpresa/23238857449/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'  ValorParametro, 'URL GET'           AS DescripcionParametro UNION

            SELECT 'WEBARCHIVOSMARCASTAMANOPAGINAGET'         AS IdParametro, '99999999'      ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASTAMANOPAGINAPOST'        AS IdParametro, '500'           ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASARCHIVOEXPORTACION'      AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
            ) AS PT ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
 WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro)
;

BEGIN

	 --Config_Aloe_WebRubrosCompras 
   MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSRUBROSCOMPRASURLGETMAXFECHA'  AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrocomprajsonmax/CuitEmpresa/23238857449/'  ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSCOMPRASURLDELETE'       AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrocomprajson/CuitEmpresa/23238857449/'     ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSCOMPRASURLPOST'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrocomprajson/'                             ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSRUBROSCOMPRASURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrocomprajsoncount/CuitEmpresa/23238857449/FechaActualizacion/{0}'                              ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSCOMPRASURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigarubrocomprajsondesdehasta/CuitEmpresa/23238857449/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'  ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSRUBROSCOMPRASTAMANOPAGINAGET'         AS IdParametro, '99999999'      ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSCOMPRASTAMANOPAGINAPOST'        AS IdParametro, '500'           ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSRUBROSCOMPRASARCHIVOEXPORTACION'      AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);


	 --Config_Aloe_WebProveedores 
    MERGE INTO Parametros AS P
         USING (SELECT 'WEBARCHIVOSPROVEEDORESURLGETMAXFECHA'  AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproveedorjsonmax/CuitEmpresa/23238857449/'  ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPROVEEDORESURLDELETE'       AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproveedorjson/CuitEmpresa/23238857449/'     ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPROVEEDORESURLPOST'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproveedorjson/'                             ValorParametro, 'URL POST'          AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPROVEEDORESURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproveedorjsoncount/CuitEmpresa/23238857449/FechaActualizacion/{0}'                              ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPROVEEDORESURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproveedorjsondesdehasta/CuitEmpresa/23238857449/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'  ValorParametro, 'URL GET'           AS DescripcionParametro UNION

                SELECT 'WEBARCHIVOSPROVEEDORESTAMANOPAGINAGET'         AS IdParametro, '99999999'      ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPROVEEDORESTAMANOPAGINAPOST'        AS IdParametro, '200'           ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
                SELECT 'WEBARCHIVOSPROVEEDORESARCHIVOEXPORTACION'      AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
                ) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro);
END;

SELECT * FROM Parametros
 WHERE CategoriaParametro = 'WEB-ARCHIVOS'
GO
