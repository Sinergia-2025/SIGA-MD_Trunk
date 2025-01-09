--Menu_MovimientosDeComprasV2-------------------------------------------------------------------------------------------------------------------------------------------

PRINT ''
PRINT '1. Nuevo Menu: Compras\Movimientos de Compras (v2).'
GO

--Inserto la pantalla nueva
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
    VALUES
        ('MovimientosDeComprasV2', 'Movimientos de Compras (v2)', 'Movimientos de Compras (v2)', 'True', 'True', 'True', 'True',
        'Compras', 6, 'Eniac.Win', 'MovimientosDeComprasV2', NULL, NULL);

INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT IdRol, 'MovimientosDeComprasV2' AS Pantalla FROM dbo.RolesFunciones
    WHERE IdFuncion='MovimientosDeCompras' ;

--Datos_Impuestos-------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Tabla Impuestos: Nuevos IVAs 2.5 y 5%.'
GO
INSERT Impuestos (IdTipoImpuesto, Alicuota, Activo, IdCuentaCompras, IdCuentaVentas) 
          VALUES ('IVA',          2.50,     'True', NULL,			 NULL)
GO
INSERT Impuestos (IdTipoImpuesto, Alicuota, Activo, IdCuentaCompras, IdCuentaVentas) 
          VALUES ('IVA',          5.00,     'True', NULL,			 NULL)
GO

--Menu_Permiso_AbrirCajaF6.-------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Nuevo Permiso: FacturaciionRapida\AbrirCajaF6.'
GO
--Inserto la pantalla nueva
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
    VALUES
        ('FacturacionRapida-AbrirCaja', 'Fact. Rapida - Abrir Caja F6', 'Fact. Rapida - Abrir Caja F6', 'False', 'False', 'True', 'True',
        'FacturacionRapida', 999, 'Eniac.Win', 'FacturacionRapida-AbrirCaja', NULL, NULL);

INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FacturacionRapida-AbrirCaja' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


--Web_Proveedores-------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '4. Sincronizacion Web: Proveedores.'
GO
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('50000000024', '33711345499', '23238857449'))	
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


--Menu_InfComparativoDiario-------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '5. Nuevo Menu: Ventas\Inf. Ventas Comparativo Diario.'
GO

--Inserto la pantalla nueva
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
    VALUES
        ('InfComparativoDiario', 'Inf. Ventas Comparativo Diario', 'Inf. Ventas Comparativo Diario', 'True', 'False', 'True', 'True',
        'Ventas', 210, 'Eniac.Win', 'InfComparativoDiario', NULL, NULL);

INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComparativoDiario' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
