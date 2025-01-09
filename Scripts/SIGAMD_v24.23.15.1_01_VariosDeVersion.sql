PRINT ''
PRINT '0. Nuevo Parametro Pedidos: -	Visualiza Precios en Dólares'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSMOSTRARPRECIOSENDOLARES'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedidos Visualiza Precios en Dólares'
	DECLARE @valorParametro VARCHAR(MAX) = 'PESOS'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '0. Nuevo Parametro Facturacion: -	Visualiza Precios en Dólares'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONMOSTRARPRECIOSENDOLARES'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Facturacion Visualiza Precios en Dólares'
	DECLARE @valorParametro VARCHAR(MAX) = 'PESOS'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO
