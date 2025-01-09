DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONRAPIDAMUESTRAFOTOPRODUCTO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Facturación Rápida: Muestra Foto del producto'
DECLARE @valorParametro VARCHAR(MAX) = 'True'

SET @valorParametro = CASE WHEN (SELECT COUNT(1) FROM Productos WHERE Foto IS NOT NULL) > 10 THEN 'True' ELSE 'False' END

IF dbo.BaseConCuit('20384486658') = 'True'
    SET @valorParametro = 'False'


MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
