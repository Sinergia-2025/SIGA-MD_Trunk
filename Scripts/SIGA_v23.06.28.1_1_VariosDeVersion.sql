PRINT ''
PRINT '1. Tabla Pedidos: Se agrega columna SaldoActualCtaCte'
IF dbo.ExisteCampo('Pedidos', 'SaldoActualCtaCte') = 0
BEGIN
    ALTER TABLE Pedidos ADD SaldoActualCtaCte decimal(14,2) null
END
GO

PRINT ''
PRINT '2. Tabla ConcesionarioTiposUnidades: Se agrega columna SolicitaDistribucionEje'
IF dbo.ExisteCampo('ConcesionarioTiposUnidades', 'SolicitaDistribucionEje') = 0
BEGIN
    ALTER TABLE ConcesionarioTiposUnidades ADD SolicitaDistribucionEje bit NULL
END
GO

PRINT ''
PRINT '3. Tabla ConcecionarioTiposUnidades: Corrige columna SolicitaDistribucionEje'
IF dbo.ExisteCampo('ConcesionarioTiposUnidades', 'SolicitaDistribucionEje') = 1
BEGIN
    UPDATE ConcesionarioTiposUnidades SET SolicitaDistribucionEje = 0
	ALTER TABLE ConcesionarioTiposUnidades ALTER COLUMN SolicitaDistribucionEje bit NOT NULL
END
GO

PRINT ''
PRINT '4. Tabla AlertasSistemaCondiciones: OrdenCondicion = 1'
UPDATE AlertasSistemaCondiciones SET OrdenCondicion = 1 WHERE OrdenCondicion = 0

PRINT ''
PRINT '5. Parametros: Publica Categorias en la Web'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'ARBOREASINCRONIZACATEGORIAS'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Arborea sincroniza Categorias en la Web'
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
PRINT '6. Parametros: Imprimir Componentes Necesarios para Producir'
DECLARE @idParametro VARCHAR(MAX) = 'ORDPRODIMPRIMIRCOMPONENTESNECESARIOS'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Imprimir Componentes Necesarios para Producir'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30717588890') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

SET @idParametro = 'ORDPRODCANTIDADNECESARIAUNITARIA'
SET @descripcionParametro = 'Imprimir Cantidad Necesaria Unitaria'
SET @valorParametro = 'True'
IF dbo.BaseConCuit('30717588890') = 1
    SET @valorParametro = 'False'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

SET @idParametro = 'ORDPRODCANTIDADLINEASEPARACION'
SET @descripcionParametro = 'Imprimir Cantidad de linea de separación'
SET @valorParametro = '0'
IF dbo.BaseConCuit('30717588890') = 1
    SET @valorParametro = '2'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
