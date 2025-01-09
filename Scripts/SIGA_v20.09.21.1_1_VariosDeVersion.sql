PRINT ''
PRINT '1. Nuevo Parámetro para decidir si incluir/no incluir los Prooductos Clientes en la Subida SIMOVIL'
DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILSUBIDAINCLUIRPRODUCTOSCLIENTES'
DECLARE @descripcionParametro VARCHAR(MAX) = 'SiMovil: Incluir Productos Clientes en la Subida'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('33631312379') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO