ALTER TABLE dbo.ClientesBackups ADD Activo bit NULL
GO
UPDATE ClientesBackups SET Activo = 1;
ALTER TABLE dbo.ClientesBackups ALTER COLUMN Activo bit NOT NULL
GO
