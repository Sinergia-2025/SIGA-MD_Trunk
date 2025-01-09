PRINT '1. Tabla Clientes:  Nuevo campo EsClienteGenerico'
ALTER TABLE dbo.Clientes ADD EsClienteGenerico bit NULL
GO
PRINT ''
PRINT '1.1. Tabla Clientes: Valor por defecto para EsClienteGenerico'
UPDATE Clientes SET EsClienteGenerico = 0;
PRINT ''
PRINT '1.2. Tabla Clientes: NOT NULL para EsClienteGenerico'
ALTER TABLE dbo.Clientes ALTER COLUMN EsClienteGenerico bit NOT NULL
GO

PRINT ''
PRINT '2. Tabla AuditoriaClientes:  Nuevo campo EsClienteGenerico'
ALTER TABLE dbo.AuditoriaClientes ADD EsClienteGenerico bit NULL

PRINT ''
PRINT '3. Tabla Prospectos:  Nuevo campo EsClienteGenerico'
ALTER TABLE dbo.Prospectos ADD EsClienteGenerico bit NULL
GO
PRINT ''
PRINT '3.1. Tabla Prospectos: Valor por defecto para EsClienteGenerico'
UPDATE Prospectos SET EsClienteGenerico = 0;
PRINT ''
PRINT '3.2. Tabla Prospectos: NOT NULL para EsClienteGenerico'
ALTER TABLE dbo.Prospectos ALTER COLUMN EsClienteGenerico bit NOT NULL
GO

PRINT ''
PRINT '4. Tabla AuditoriaProspectos:  Nuevo campo EsClienteGenerico'
ALTER TABLE dbo.AuditoriaProspectos ADD EsClienteGenerico bit NULL
GO

ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO

PRINT ''
PRINT '5. Tabla Ventas: Nuevos campos NombreCliente, Cuit, TipoDocCliente, NroDocCliente'
ALTER TABLE Ventas ADD NombreCliente	varchar(100)	null
ALTER TABLE Ventas ADD Cuit	            varchar(13)	null
ALTER TABLE Ventas ADD TipoDocCliente	varchar(5)	null
ALTER TABLE Ventas ADD NroDocCliente	bigint	null
GO
