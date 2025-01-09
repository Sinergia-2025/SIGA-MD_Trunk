
PRINT ''
PRINT '1. Tabla AuditoriasMonedas: Campo FactorConversion '
ALTER TABLE AuditoriaMonedas
ALTER COLUMN FactorConversion decimal(7,3) NOT NULL;
