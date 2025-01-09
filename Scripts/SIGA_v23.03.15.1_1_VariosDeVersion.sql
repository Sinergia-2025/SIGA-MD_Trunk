PRINT ''
PRINT '1. Parametro FACTURACIONINVOCADOSMANTIENEVENDEDOR: Normalizar valores que no son válidos'
UPDATE Parametros
   SET ValorParametro = CASE WHEN ValorParametro = 'True' THEN 'INVOCADO' ELSE 'NO' END
 WHERE IdParametro = 'FACTURACIONINVOCADOSMANTIENEVENDEDOR'
   AND ValorParametro IN ('True', 'False')

PRINT ''
PRINT '2. Nuevo Parametro: lista de precios cliente nuevo - Arborea.-'
BEGIN
	MERGE INTO Parametros AS DEST
	USING (
			SELECT IdEmpresa, 
				'ARBOREALISTAPRECIOSCLNUEVO' AS IdParametro, 
				'-1' ValorParametro, 
				'Tienda Web' CategoriaParametro, 
				'ARBOREALISTAPRECIOSCLNUEVO' DescripcionParametro FROM Empresas) AS ORIG 
			ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
		VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '3. Buscador bancos: Cambiar nombre de columnas IdBanco y NombreBanco'
DECLARE @idBanco Int = (Select IdBuscador FROM Buscadores WHERE Titulo = 'Bancos')
BEGIN
	UPDATE BuscadoresCampos 
		SET Titulo = 'Banco'
		WHERE IdBuscadornombreCampo = 'IdBanco' AND IdBuscador = @IDBanco

	UPDATE BuscadoresCampos 
		SET Titulo = 'Nombre Banco'
		WHERE IdBuscadornombreCampo = 'NombreBanco' AND IdBuscador = @IDBanco
END
GO
