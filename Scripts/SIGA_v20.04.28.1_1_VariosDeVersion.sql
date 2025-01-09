DECLARE @cantidad int = (SELECT COUNT(1) FROM TiposComprobantesLetras
                          WHERE IdTipoImpresionFiscalArchivoAImprimir IS NULL OR 
                                IdTipoImpresionFiscalArchivoAImprimir2 IS NULL OR 
                                IdTipoImpresionFiscalArchivoAImprimirComplementario IS NULL OR 
                                IdTipoImpresionFiscalArchivoAExportar IS NULL)
PRINT ''
PRINT '1. Tabla TiposComprobantesLetras: Correccion IdTipoImpresionFiscal*. Cantidad registros: ' + CONVERT(VARCHAR(MAX), @cantidad)
IF @cantidad > 0
BEGIN
    PRINT ''
    PRINT '1.1. Tabla TiposComprobantesLetras: Valores por defecto para nuevos campos IdTipoImpresionFiscal*'
    DECLARE @tipoImpresionFiscal int = (SELECT P.ValorParametro FROM Parametros P INNER JOIN Sucursales S ON P.IdEmpresa = S.IdEmpresa WHERE P.IdParametro = 'TIPOIMPRESIONFISCAL' AND SoyLaCentral = 'True')

    UPDATE TiposComprobantesLetras SET
        IdTipoImpresionFiscalArchivoAImprimir = @tipoImpresionFiscal,
        IdTipoImpresionFiscalArchivoAImprimir2 = @tipoImpresionFiscal,
        IdTipoImpresionFiscalArchivoAImprimirComplementario = @tipoImpresionFiscal,
        IdTipoImpresionFiscalArchivoAExportar = @tipoImpresionFiscal

    PRINT ''
    PRINT '1.2. Tabla TiposComprobantesLetras: NOT NULL para nuevos campos IdTipoImpresionFiscal*'
    ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAImprimir INT NOT NULL
    ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAImprimir2 INT NOT NULL
    ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAImprimirComplementario INT NOT NULL
    ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAExportar INT NOT NULL
END
