
-- Plumas Aloe

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('50000000024', '33711345499', '23238857449'))	
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

SELECT *
  FROM Parametros
 WHERE CategoriaParametro = 'WEB-ARCHIVOS'


--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSCLIENTESURLGETMAXFECHA', 'WEBARCHIVOSCLIENTESURLDELETE', 'WEBARCHIVOSCLIENTESURLPOST',
--                       'WEBARCHIVOSCLIENTESURLGETCOUNT', 'WEBARCHIVOSCLIENTESURLGET',
--                       'WEBARCHIVOSCLIENTESTAMANOPAGINAGET',
--                       'WEBARCHIVOSCLIENTESTAMANOPAGINAPOST',
--                       'WEBARCHIVOSCLIENTESARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSPRODUCTOSURLGETMAXFECHA', 'WEBARCHIVOSPRODUCTOSURLDELETE', 'WEBARCHIVOSPRODUCTOSURLPOST',
--                       'WEBARCHIVOSPRODUCTOSURLGETCOUNT', 'WEBARCHIVOSPRODUCTOSURLGET',
--                       'WEBARCHIVOSPRODUCTOSTAMANOPAGINAGET',
--                       'WEBARCHIVOSPRODUCTOSTAMANOPAGINAPOST',
--                       'WEBARCHIVOSPRODUCTOSARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSPRODSUCURURLGETMAXFECHA', 'WEBARCHIVOSPRODSUCURURLDELETE', 'WEBARCHIVOSPRODSUCURURLPOST',
--                       'WEBARCHIVOSPRODSUCURURLGETCOUNT', 'WEBARCHIVOSPRODSUCURURLGET',
--                       'WEBARCHIVOSPRODSUCURTAMANOPAGINAGET',
--                       'WEBARCHIVOSPRODSUCURTAMANOPAGINAPOST',
--                       'WEBARCHIVOSPRODSUCURARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSPRODSUCURPRECIOSURLGETMAXFECHA', 'WEBARCHIVOSPRODSUCURPRECIOSURLDELETE', 'WEBARCHIVOSPRODSUCURPRECIOSURLPOST',
--                       'WEBARCHIVOSPRODSUCURPRECIOSURLGETCOUNT', 'WEBARCHIVOSPRODSUCURPRECIOSURLGET',
--                       'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAGET',
--                       'WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAPOST',
--                       'WEBARCHIVOSPRODSUCURPRECIOSARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSLOCALIDADESURLGETMAXFECHA', 'WEBARCHIVOSLOCALIDADESURLDELETE', 'WEBARCHIVOSLOCALIDADESURLPOST',
--                       'WEBARCHIVOSLOCALIDADESURLGETCOUNT', 'WEBARCHIVOSLOCALIDADESURLGET',
--                       'WEBARCHIVOSLOCALIDADESTAMANOPAGINAGET',
--                       'WEBARCHIVOSLOCALIDADESTAMANOPAGINAPOST',
--                       'WEBARCHIVOSLOCALIDADESARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSRUBROSURLGETMAXFECHA', 'WEBARCHIVOSRUBROSURLDELETE', 'WEBARCHIVOSRUBROSURLPOST',
--                       'WEBARCHIVOSRUBROSURLGETCOUNT', 'WEBARCHIVOSRUBROSURLGET',
--                       'WEBARCHIVOSRUBROSTAMANOPAGINAGET',
--                       'WEBARCHIVOSRUBROSTAMANOPAGINAPOST',
--                       'WEBARCHIVOSRUBROSARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSSUBRUBROSURLGETMAXFECHA', 'WEBARCHIVOSSUBRUBROSURLDELETE', 'WEBARCHIVOSSUBRUBROSURLPOST',
--                       'WEBARCHIVOSSUBRUBROSURLGETCOUNT', 'WEBARCHIVOSSUBRUBROSURLGET',
--                       'WEBARCHIVOSSUBRUBROSTAMANOPAGINAGET',
--                       'WEBARCHIVOSSUBRUBROSTAMANOPAGINAPOST',
--                       'WEBARCHIVOSSUBRUBROSARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('WEBARCHIVOSSUBSUBRUBROSURLGETMAXFECHA', 'WEBARCHIVOSSUBSUBRUBROSURLDELETE', 'WEBARCHIVOSSUBSUBRUBROSURLPOST',
--                       'WEBARCHIVOSSUBSUBRUBROSURLGETCOUNT', 'WEBARCHIVOSSUBSUBRUBROSURLGET',
--                       'WEBARCHIVOSSUBSUBRUBROSTAMANOPAGINAGET',
--                       'WEBARCHIVOSSUBSUBRUBROSTAMANOPAGINAPOST',
--                       'WEBARCHIVOSSUBSUBRUBROSARCHIVOEXPORTACION')
-- ORDER BY IdParametro
--;
