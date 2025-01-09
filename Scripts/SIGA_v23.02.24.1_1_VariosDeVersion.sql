PRINT ''
PRINT '1. Nuevo parámetro: Precios Tienda Nube.'
BEGIN
	MERGE INTO Parametros AS DEST
	USING (
			SELECT IdEmpresa, 
				'TIENDANUBEPRECIOPRODUCTO' AS IdParametro, 
				'DELPRODUCTO' ValorParametro, 
				'Tienda Nube' CategoriaParametro, 
				'Precio del Producto en Moneda' DescripcionParametro FROM Empresas) AS ORIG 
			ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
		VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO