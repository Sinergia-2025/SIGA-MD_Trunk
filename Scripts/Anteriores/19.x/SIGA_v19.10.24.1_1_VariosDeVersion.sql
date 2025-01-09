PRINT ''
PRINT '1. Tabla TiposComprobantes: Agrego Campo Orden'
ALTER TABLE dbo.TiposComprobantes ADD Orden Integer null;
GO
PRINT ''
PRINT '1.1. Tabla TiposComprobantes: Valores por defecto para el campo Orden'
UPDATE dbo.TiposComprobantes SET Orden  = 1;
PRINT ''
PRINT '1.1. Tabla TiposComprobantes: NOT NULL para el campo Orden'
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN Orden Integer NOT NULL
GO
