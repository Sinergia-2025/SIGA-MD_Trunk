PRINT ''
PRINT '1. Tabla Pedidos: Se agrega columna SaldoActualCtaCte'
IF dbo.ExisteCampo('Pedidos', 'SaldoActualCtaCte') = 0
BEGIN
    ALTER TABLE Pedidos ADD SaldoActualCtaCte decimal(14,2) null
END
GO

PRINT ''
PRINT '2. Tabla AlertasSistemaCondiciones: Corrección Campo OrdenCondicion en 0'
UPDATE AlertasSistemaCondiciones SET OrdenCondicion = 1 WHERE OrdenCondicion = 0


PRINT ''
PRINT '3. Parametros: Publica Categorias en la Web'
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
