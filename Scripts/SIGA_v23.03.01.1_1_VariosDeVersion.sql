PRINT ''
PRINT '1. Facturacion: Parametro de cantidad de producto por defecto'
IF dbo.BaseConCuit(20167456341) = 0
BEGIN
	MERGE INTO Parametros AS DEST
	USING (
			SELECT IdEmpresa, 
				'FACTURACIONCANTIDADDEFECTO' AS IdParametro, 
				'True' ValorParametro, 
				'' CategoriaParametro, 
				'Cantidad para Producto por Defecto es 1' DescripcionParametro FROM Empresas) AS ORIG 
			ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
		VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
