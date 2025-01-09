PRINT ''
PRINT '1. Tabla TiposComprobantes: Agregar nuevo campo ImportaObservGrales'
ALTER TABLE TiposComprobantes ADD ImportaObservGrales BIT NULL
GO

PRINT ''
PRINT '1.1. Tabla TiposComprobantes: Valores por defecto para campo ImportaObservGrales'
UPDATE TiposComprobantes SET ImportaObservGrales = ImportaObservDeInvocados

PRINT ''
PRINT '1.2. Tabla ContabilidadAsientosCuentas: NOT NULL para campo IdEjercicio'
ALTER TABLE TiposComprobantes ALTER COLUMN ImportaObservGrales BIT NOT NULL
