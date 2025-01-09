PRINT ''
PRINT '1. Tabla Parametros: Importa marcas en proceso de subida Web - Arborea'
DECLARE @idParametro VARCHAR(MAX) = 'ARBOREAIMPORTAMARCASUBIDA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Importa Marcas de Productos en proceso de subida Web'
DECLARE @valorParametro VARCHAR(MAX) = '0'
BEGIN
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '2. Tabla Parametros: ID Parent de Marcas en proceso de subida Web - Arborea'
DECLARE @idParametro VARCHAR(MAX) = 'ARBOREAIMPORTAMARCASUBIDAID'
DECLARE @descripcionParametro VARCHAR(MAX) = 'ID Parent de Marcas de Productos en proceso de subida Web'
DECLARE @valorParametro VARCHAR(MAX) = '0'
BEGIN
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '3. Tabla Parametros: Actualiza costos y precios de ventas - Precio Costo'
DECLARE @idParametro VARCHAR(MAX) = 'COMPRASPRECIOCOSTO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Actualiza costos y precios de ventas - Precio Costo'
DECLARE @valorParametro VARCHAR(MAX) = 'ACTUAL'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
GO
