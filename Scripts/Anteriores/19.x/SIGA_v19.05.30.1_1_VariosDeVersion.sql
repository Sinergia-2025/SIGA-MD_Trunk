PRINT ''
PRINT '1. Tabla TiposComprobantesLetras: Agrego campo ArchivoAImprimirComplementario .'
ALTER TABLE dbo.TiposComprobantesLetras ADD ArchivoAImprimirComplementario  varchar(100) null;
ALTER TABLE dbo.TiposComprobantesLetras ADD ArchivoAImprimirComplementarioEmbebido bit null;
GO
PRINT ''
PRINT '1.1. Tabla TiposComprobantesLetras: Valores por defecto para ArchivoAImprimirComplementario .'
UPDATE TiposComprobantesLetras SET ArchivoAImprimirComplementario  ='';
UPDATE TiposComprobantesLetras SET ArchivoAImprimirComplementarioEmbebido  = 0;
PRINT ''
PRINT '1.2. Tabla TiposComprobantesLetras: ArchivoAImprimirComplementario NOT NULL.'
ALTER TABLE dbo.TiposComprobantesLetras ALTER COLUMN ArchivoAImprimirComplementario varchar(100) NOT NULL;
ALTER TABLE dbo.TiposComprobantesLetras ALTER COLUMN ArchivoAImprimirComplementarioEmbebido bit NOT NULL;
GO