PRINT ''
PRINT '1. Nuevo Parametro Facturación: -	Visualiza columna de Depósito desde Facturacion'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONVISUALIZADEPOSITO'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Visualizar columna de Deposito desde Facturacion'
	DECLARE @valorParametro VARCHAR(MAX) = 'True'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '2. Nuevo Parametro Facturación: -	Visualiza columna de Ubicacion desde Facturacion'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONVISUALIZAUBICACION'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Visualizar columna de Deposito desde Facturacion'
	DECLARE @valorParametro VARCHAR(MAX) = 'True'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '3. Nuevo Parametro Facturación: -	Publicar Precio por Embalaje'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILPRECIOPOREMBALAJE'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Publicar Precio por Embalaje'
	DECLARE @valorParametro VARCHAR(MAX) = 'True'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '4. Redefino Tamaño de Campo FactorConversion'
ALTER TABLE UnidadesDeMedidasConversiones ALTER COLUMN FactorConversion decimal(20,10) NOT NULL
ALTER TABLE UnidadesDeMedidas ALTER COLUMN ConversionAKilos decimal(20,10) NOT NULL

ALTER TABLE RequerimientosComprasProductos ALTER COLUMN FactorConversionCompra decimal(20,10) NOT NULL
ALTER TABLE ProductosComponentes ALTER COLUMN FactorConversionProduccion decimal(20,10) NOT NULL
ALTER TABLE Productos ALTER COLUMN FactorConversionCompra decimal(20,10) NOT NULL
ALTER TABLE Productos ALTER COLUMN FactorConversionProduccion decimal(20,10) NOT NULL

ALTER TABLE PedidosProductosProveedores ALTER COLUMN FactorConversionCompra decimal(20,10) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN FactorConversionCompra decimal(20,10) NOT NULL

ALTER TABLE AuditoriaProductos ALTER COLUMN FactorConversionCompra decimal(20,10) NULL
ALTER TABLE AuditoriaProductos ALTER COLUMN FactorConversionProduccion decimal(20,10) NULL
GO

PRINT ''
PRINT '5. Agregado de Campos en tabla WVentas'
If dbo.ExisteTabla('WVenta') = 1
BEGIN
	ALTER TABLE WVentas ADD GUID UNIQUEIDENTIFIER;
	ALTER TABLE WVentas ADD FechaProcesado DATETIME;
END
GO