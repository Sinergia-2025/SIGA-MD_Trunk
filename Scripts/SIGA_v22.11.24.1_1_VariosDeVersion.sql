PRINT ''
PRINT '1. Tabla EstadosVehiculos: Nuevo campo Predeterminado'
IF dbo.ExisteCampo('EstadosVehiculos', 'Predeterminado') = 0
BEGIN
    ALTER TABLE dbo.EstadosVehiculos ADD Predeterminado bit NULL
END
GO

PRINT ''
PRINT '1.1. Tabla EstadosVehiculos: Valor por defecto para Predeterminado en los registros Historicos'
UPDATE EstadosVehiculos SET Predeterminado = CASE WHEN IdEstadoVehiculo = 1 THEN 1 ELSE 0 END;
PRINT ''
PRINT '1.2. Tabla EstadosVehiculos: NOT NULL Predeterminado'
ALTER TABLE dbo.EstadosVehiculos ALTER COLUMN Predeterminado bit NOT NULL
GO

PRINT ''
PRINT '2. Tabla VentasTarjetas: NumeroLote = 0 cuando esté como NULL'
UPDATE VentasTarjetas
   SET NumeroLote = 0
 WHERE NumeroLote IS NULL
