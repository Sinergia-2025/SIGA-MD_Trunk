PRINT ''
PRINT '1. Tabla Categorias: Agrego Campo ActualizarVersion/ActualizarAplicacion'
ALTER TABLE dbo.Categorias ADD ActualizarVersion bit null;
ALTER TABLE dbo.Categorias ADD ActualizarAplicacion bit null;
GO
PRINT ''
PRINT '1.1. Tabla Categorias: Valores por defecto para ActualizarVersion/ActualizarAplicacion'
UPDATE dbo.Categorias SET ActualizarVersion  = 0;
UPDATE dbo.Categorias SET ActualizarAplicacion  = 0;
PRINT ''
PRINT '1.2. Tabla Categorias: NOT NULL para ActualizarVersion/ActualizarAplicacion'
ALTER TABLE dbo.Categorias ALTER COLUMN ActualizarVersion bit NOT NULL
ALTER TABLE dbo.Categorias ALTER COLUMN ActualizarAplicacion bit NOT NULL
GO