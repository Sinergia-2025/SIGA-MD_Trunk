DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILSOPORTEUSUARIODEFAULT'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Simovil: Soporte Usuario'
DECLARE @valorParametro VARCHAR(MAX) = ''
IF dbo.BaseConCuit('33631312379') = 'True'
    SET @valorParametro = 'admin'

IF dbo.SoyHAR() = 'True'
    SET @valorParametro = 'soporte'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
