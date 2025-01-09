PRINT ''
PRINT '1. Tabla Productos: Nuevo Campo EsComercial'
ALTER TABLE dbo.Productos ADD EsComercial bit null;
GO
PRINT ''
PRINT '1.1. Tabla Productos: Valor por defecto para EsComercial'
UPDATE dbo.Productos SET EsComercial  = 1;
PRINT ''
PRINT '1.2. Tabla Productos: NOT NULL para EsComercial'
ALTER TABLE dbo.Productos ALTER COLUMN EsComercial bit NOT NULL
GO

PRINT ''
PRINT '2. Tabla AuditoriaProductos: Nuevo Campo EsComercial'
ALTER TABLE dbo.AuditoriaProductos ADD EsComercial bit null;
GO
