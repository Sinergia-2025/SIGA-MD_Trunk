PRINT ''
PRINT '1. Tabla AuditoriaMonedas: Cambio Factor de Conversion'

BEGIN
    ALTER TABLE AuditoriaMonedas ALTER COLUMN FactorConversion Decimal(7,3) NOT NULL
END