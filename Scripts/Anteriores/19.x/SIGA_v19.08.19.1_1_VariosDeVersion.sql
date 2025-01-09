PRINT ''
PRINT '1. Tabla CategoriasFiscales: Nuevo campo UtilizaAlicuota2Producto'
ALTER TABLE dbo.CategoriasFiscales ADD UtilizaAlicuota2Producto bit NULL
GO
PRINT ''
PRINT '1.1. Tabla CategoriasFiscales: Valores por defecto para UtilizaAlicuota2Producto'
UPDATE CategoriasFiscales SET UtilizaAlicuota2Producto = 0;
PRINT ''
PRINT '1.2. Tabla CategoriasFiscales: NOT NULL para UtilizaAlicuota2Producto'
ALTER TABLE dbo.CategoriasFiscales ALTER COLUMN UtilizaAlicuota2Producto bit NOT NULL
GO

IF dbo.BaseConCuit('27347349076') = 'True'
BEGIN
    PRINT ''
    PRINT '1.3. Tabla CategoriasFiscales: Valores por defecto para UtilizaAlicuota2Producto (ZION)'
    UPDATE CategoriasFiscales SET UtilizaAlicuota2Producto = 1 WHERE IdCategoriaFiscal = 1;
END

PRINT ''
PRINT '2. Configurar TLS1.1 y TLS1.2 para BAZAR CELTA'
IF dbo.BaseConCuit('20250887265') = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Agregando parametro para Habilitar TLS1.1'
    DECLARE @idParametro VARCHAR(MAX) = 'WEBARCHIVOSHABILITARTLS1_1'
    DECLARE @descripcionParametro VARCHAR(MAX) = 'Habilitar TLS1.1'
    DECLARE @valorParametro VARCHAR(MAX) = 'True'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    PRINT ''
    PRINT '2.2. Agregando parametro para Habilitar TLS1.2'
    SET @idParametro = 'WEBARCHIVOSHABILITARTLS1_2'
    SET @descripcionParametro = 'Habilitar TLS1.2'
    SET @valorParametro = 'True'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

END
