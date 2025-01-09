
PRINT ''
PRINT '1. Tabla ClientesDeudas: Agrego Campo monto_cuota.'
GO
ALTER TABLE ClientesDeudas ADD monto_cuota decimal(14,2) null
GO


PRINT ''
PRINT '2. Tabla ClientesDeudas: Ajusto Campo a cero.'
GO
UPDATE ClientesDeudas 
   SET monto_cuota = 0 
 WHERE monto_cuota IS NULL
GO
