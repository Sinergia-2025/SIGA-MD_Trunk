PRINT ''
PRINT '1. Tabla TiposComprobantesLetras: Nuevo Campo ArchivoAExportar y ArchivoAExportarEmbebido'
ALTER TABLE TiposComprobantesLetras ADD ArchivoAExportar VARCHAR(100) NULL
ALTER TABLE TiposComprobantesLetras ADD ArchivoAExportarEmbebido BIT NULL
GO
PRINT ''
PRINT '1.1. Tabla TiposComprobantesLetras: Valor por defecto para nuevo campo ArchivoAExportar y ArchivoAExportarEmbebido'
UPDATE TiposComprobantesLetras SET ArchivoAExportar = '', ArchivoAExportarEmbebido = 0;
PRINT ''
PRINT '1.2. Tabla TiposComprobantesLetras: NOT NULL para nuevo campo ArchivoAExportar y ArchivoAExportarEmbebido'
ALTER TABLE TiposComprobantesLetras ALTER COLUMN ArchivoAExportar VARCHAR(100) NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN ArchivoAExportarEmbebido BIT NOT NULL
GO


PRINT ''
PRINT '2. Nueva Tabla: TiposImpresionesFiscales'
CREATE TABLE TiposImpresionesFiscales(
    IdTipoImpresionFiscal INT PRIMARY KEY NOT NULL,
    NombreTipoImpresionFiscal VARCHAR(50)
)
GO

PRINT ''
PRINT '2.1. Tabla TiposImpresionesFiscales: Agregar datos iniciales'
INSERT INTO TiposImpresionesFiscales 
       (IdTipoImpresionFiscal, NombreTipoImpresionFiscal)
VALUES (1,'Original'),
       (2,'Original y Duplicado'),
       (3,'Original, Duplicado y Triplicado'),
       (4,'Original, Duplicado, Triplicado y Cuadriplicado')





PRINT ''
PRINT '3 Tabla TiposComprobantesLetras: Nuevos Campos IdTipoImpresionFiscal*'
ALTER TABLE TiposComprobantesLetras ADD IdTipoImpresionFiscalArchivoAImprimir INT NULL
ALTER TABLE TiposComprobantesLetras ADD IdTipoImpresionFiscalArchivoAImprimir2 INT NULL
ALTER TABLE TiposComprobantesLetras ADD IdTipoImpresionFiscalArchivoAImprimirComplementario INT NULL
ALTER TABLE TiposComprobantesLetras ADD IdTipoImpresionFiscalArchivoAExportar INT NULL
GO


PRINT ''
PRINT '3.1. Tabla TiposComprobantesLetras: Valores por defecto para nuevos campos IdTipoImpresionFiscal*'
DECLARE @tipoImpresionFiscal int = (SELECT P.ValorParametro FROM Parametros P INNER JOIN Sucursales S ON P.IdEmpresa = S.IdEmpresa WHERE P.IdParametro = 'TIPOIMPRESIONFISCAL' AND SoyLaCentral = 'True')

UPDATE TiposComprobantesLetras SET
    IdTipoImpresionFiscalArchivoAImprimir = @tipoImpresionFiscal,
    IdTipoImpresionFiscalArchivoAImprimir2 = @tipoImpresionFiscal,
    IdTipoImpresionFiscalArchivoAImprimirComplementario = @tipoImpresionFiscal,
    IdTipoImpresionFiscalArchivoAExportar = @tipoImpresionFiscal
GO

PRINT ''
PRINT '3.2. Tabla TiposComprobantesLetras: NOT NULL para nuevos campos IdTipoImpresionFiscal*'
ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAImprimir INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAImprimir2 INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAImprimirComplementario INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN IdTipoImpresionFiscalArchivoAExportar INT NOT NULL
GO

PRINT ''
PRINT '4. Tabla TiposComprobantesLetras: FK a TiposImpresionesFiscales'
ALTER TABLE TiposComprobantesLetras
    ADD CONSTRAINT FK_TiposComprobantesLetras_TiposImpresionesFiscales_IdTipoImpresionFiscalArchivoAImprimir
    FOREIGN KEY (IdTipoImpresionFiscalArchivoAImprimir) REFERENCES TiposImpresionesFiscales(IdTipoImpresionFiscal)
GO

ALTER TABLE TiposComprobantesLetras
    ADD CONSTRAINT FK_TiposComprobantesLetras_TiposImpresionesFiscales_IdTipoImpresionFiscalArchivoAImprimir2
    FOREIGN KEY (IdTipoImpresionFiscalArchivoAImprimir2) REFERENCES TiposImpresionesFiscales(IdTipoImpresionFiscal)
GO

ALTER TABLE TiposComprobantesLetras
    ADD CONSTRAINT FK_TiposComprobantesLetras_TiposImpresionesFiscales_IdTipoImpresionFiscalArchivoAImprimirComplementario
    FOREIGN KEY (IdTipoImpresionFiscalArchivoAImprimirComplementario) REFERENCES TiposImpresionesFiscales(IdTipoImpresionFiscal)
GO

ALTER TABLE TiposComprobantesLetras
    ADD CONSTRAINT FK_TiposComprobantesLetras_TiposImpresionesFiscales_IdTipoImpresionFiscalArchivoAExportar
    FOREIGN KEY (IdTipoImpresionFiscalArchivoAExportar) REFERENCES TiposImpresionesFiscales(IdTipoImpresionFiscal)

