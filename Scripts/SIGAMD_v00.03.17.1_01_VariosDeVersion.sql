PRINT ''
PRINT '1. Tabla CuentasCorrientesProv: Nuevo campo PromedioDiasPago'
IF dbo.ExisteCampo('CuentasCorrientesProv', 'PromedioDiasPago') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientesProv ADD PromedioDiasPago decimal(14, 8) NULL
END
GO
PRINT ''
PRINT '1.1. Tabla CuentasCorrientesProv: Campo PromedioDiasPago actualizar anteriores'
UPDATE CuentasCorrientesProv
   SET PromedioDiasPago = 0
 WHERE PromedioDiasPago IS NULL

PRINT ''
PRINT '1.2. Tabla CuentasCorrientesProv: Campo PromedioDiasPago NOT NULL'
ALTER TABLE dbo.CuentasCorrientesProv ALTER COLUMN PromedioDiasPago decimal(14, 8) NOT NULL


PRINT ''
PRINT '2. Parametro Imputación Automática: Aplicar D/R de la Forma de Pago del comprobante'
DECLARE @idParametro VARCHAR(MAX) = 'CTACTEPROVIMPUTACIONAUTOMATICADRFORMAPAGO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Imputación Automática: Aplicar D/R de la Forma de Pago del comprobante'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30676889376') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
