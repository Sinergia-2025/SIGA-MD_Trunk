-- SOLO AIMARO
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('20220876013'))
BEGIN
    MERGE INTO Parametros AS P
            USING (SELECT 'FACTURACIONPOSICIONNOMBREPRODUCTO' AS IdParametro, 'True' ValorParametro, 'Permitir Posicionar en Nombre del Producto en Lugar del Codigo'  AS DescripcionParametro UNION ALL
                   SELECT 'PRODUCTOBUSQUEDACOMBINACODIGONOMBRE' AS IdParametro, 'True' ValorParametro, 'Al buscar por nombre combinar la búsqueda con el código'  AS DescripcionParametro UNION ALL
                   SELECT 'MONEDAPARACONSULTARPRECIOS' AS IdParametro, '1' ValorParametro, 'Al Consultar Precios mostrar el precio utilizando la Moneda'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
        WHEN MATCHED THEN
            UPDATE SET P.ValorParametro = PT.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
    ;
END

--MONEDAPARACONSULTARPRECIOS