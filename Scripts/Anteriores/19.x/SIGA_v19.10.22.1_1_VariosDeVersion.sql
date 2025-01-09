PRINT ''
PRINT '1. Parámetro por defecto para Ubicacion de Producto'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOUBICACIONPORDEFECTO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Ubicación por Defecto'
DECLARE @valorParametro VARCHAR(MAX) = ''
IF dbo.BaseConCuit('33631312379') = 'True'      --SOLO METALSUR
    SET @valorParametro = 'SIGA'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
