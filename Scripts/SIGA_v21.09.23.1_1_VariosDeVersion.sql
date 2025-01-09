DECLARE @valorParametro VARCHAR(MAX) = 'True'

IF dbo.BaseConCUIT('30714356921') = 1
BEGIN
    SET @valorParametro = 'False'
END

    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 'FACTURACIONCONSERVAORDENPRODUCTO' AS IdParametro, @valorParametro ValorParametro, 'Facturacion' CategoriaParametro, 'FACTURACIONORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
            SELECT IdEmpresa, 'FACTURACIONRAPIDACONSERVAORDENPRODUCTO' AS IdParametro, @valorParametro ValorParametro, 'Facturacion RAPIDA' CategoriaParametro, 'FACTURACIONRAPIDAORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
            SELECT IdEmpresa, 'COMPRASCONSERVAORDENPRODUCTOS' AS IdParametro, @valorParametro ValorParametro, 'Compras' CategoriaParametro, 'COMPRASCONSERVAORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
            SELECT IdEmpresa, 'PEDIDOSCLIENTESCONSERVAORDENPRODUCTOS' AS IdParametro, @valorParametro ValorParametro, 'Pedidos Clientes' CategoriaParametro, 'PEDIDOSCLIENTESCONSERVAORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
            SELECT IdEmpresa, 'PEDIDOSPROVEEDORESCONSERVAORDENPRODUCTOS' AS IdParametro, @valorParametro ValorParametro, 'Pedidos Clientes' CategoriaParametro, 'PEDIDOSPROVEEDORESCONSERVAORDENPRODUCTOS' DescripcionParametro FROM Empresas
            ) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
