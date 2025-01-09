DECLARE @idParametro VARCHAR(MAX) = 'FORZARLISTADEPRECIOSCLIENTE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Alta de Clientes: Forzar la selección de una Lista de Precios'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30715507907') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
