PRINT ''
PRINT '1. Tabla Ventas: Agrego campos Cbu y CbuAlias.'
ALTER TABLE dbo.Ventas ADD Cbu varchar(22) NULL
ALTER TABLE dbo.Ventas ADD CbuAlias varchar(20) NULL

PRINT ''
PRINT '2. Tabla CuentasCorrientes: Agrego campo FechaExportacion .'
ALTER TABLE dbo.CuentasCorrientes ADD FechaExportacion  Datetime NULL
GO

PRINT ''
PRINT '3. Tabla Clientes: Agrego campos SiMovilIdUsuario y SiMovilClave.'
ALTER TABLE dbo.Clientes ADD SiMovilIdUsuario varchar(100) NULL
ALTER TABLE dbo.Clientes ADD SiMovilClave varchar(100) NULL
GO
PRINT ''
PRINT '3.1. Tabla Clientes: Valores por defecto para SiMovilIdUsuario y SiMovilClave.'
UPDATE Clientes 
   SET SiMovilIdUsuario = CASE WHEN ISNULL(Cuit,'') <> '' THEN Cuit ELSE
                          CASE WHEN ISNULL(NroDocCliente, 0) <> 0 THEN CONVERT(VARCHAR(MAX), NroDocCliente) ELSE
                          CONVERT(VARCHAR(MAX), CodigoCliente) END END
     , SiMovilClave = CodigoCliente;
PRINT ''
PRINT '3.2. Tabla Clientes: NOT NULL en SiMovilIdUsuario y SiMovilClave.'
ALTER TABLE dbo.Clientes ALTER COLUMN SiMovilIdUsuario varchar(100) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN SiMovilClave varchar(100) NOT NULL
GO

PRINT ''
PRINT '4. Tabla AuditoriaClientes: Agrego campos SiMovilIdUsuario y SiMovilClave.'
ALTER TABLE dbo.AuditoriaClientes ADD SiMovilIdUsuario varchar(100) NULL
ALTER TABLE dbo.AuditoriaClientes ADD SiMovilClave varchar(100) NULL
GO

PRINT ''
PRINT '5. Tabla Prospectos: Agrego campos SiMovilIdUsuario y SiMovilClave.'
ALTER TABLE dbo.Prospectos ADD SiMovilIdUsuario varchar(100) NULL
ALTER TABLE dbo.Prospectos ADD SiMovilClave varchar(100) NULL
GO
PRINT ''
PRINT '5.1. Tabla Prospectos: Valores por defecto para SiMovilIdUsuario y SiMovilClave.'
UPDATE Prospectos
   SET SiMovilIdUsuario = ''
     , SiMovilClave = '';
ALTER TABLE dbo.Prospectos ALTER COLUMN SiMovilIdUsuario varchar(100) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN SiMovilClave varchar(100) NOT NULL
GO
PRINT ''
PRINT '5.2. Tabla AuditoriaProspectos: NOT NULL en SiMovilIdUsuario y SiMovilClave.'
ALTER TABLE dbo.AuditoriaProspectos ADD SiMovilIdUsuario varchar(100) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD SiMovilClave varchar(100) NULL
GO
