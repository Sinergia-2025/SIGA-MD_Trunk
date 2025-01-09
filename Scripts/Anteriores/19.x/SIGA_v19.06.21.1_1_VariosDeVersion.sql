PRINT ''
PRINT '1. Tabla MovilRutasListasDePrecios: Nuevo campo AplicaPreciosOferta'
ALTER TABLE dbo.MovilRutasListasDePrecios ADD AplicaPreciosOferta bit NULL
GO
PRINT ''
PRINT '1.1. Tabla MovilRutasListasDePrecios: Valor por defecto para AplicaPreciosOferta'
UPDATE MovilRutasListasDePrecios SET AplicaPreciosOferta = 0;
PRINT ''
PRINT '1.2. Tabla MovilRutasListasDePrecios: NOT NULL AplicaPreciosOferta'
ALTER TABLE dbo.MovilRutasListasDePrecios ALTER COLUMN AplicaPreciosOferta bit NOT NULL
GO

PRINT ''
PRINT '2. Tabla Clientes: Nuevos campos UtilizaAppSoporte, CantidadLocal, CantidadRemota, CantidadMovil y ObservacionAdministrativa'
ALTER TABLE dbo.Clientes ADD UtilizaAppSoporte bit null;
ALTER TABLE dbo.Clientes ADD CantidadLocal int null;
ALTER TABLE dbo.Clientes ADD CantidadRemota int null;
ALTER TABLE dbo.Clientes ADD CantidadMovil int null;
ALTER TABLE dbo.Clientes ADD ObservacionAdministrativa varchar(1000) null;
GO
PRINT ''
PRINT '2.1. Tabla Clientes: Valores por defecto para UtilizaAppSoporte y CantidadLocal'
UPDATE dbo.Clientes SET UtilizaAppSoporte  = 0, CantidadLocal  = CantidadDePCs;
PRINT ''
PRINT '2.2. Tabla Clientes: NOT NULL UtilizaAppSoporte'
ALTER TABLE dbo.Clientes ALTER COLUMN UtilizaAppSoporte bit NOT NULL

PRINT ''
PRINT '3. Tabla Prospectos: Nuevos campos UtilizaAppSoporte, CantidadLocal, CantidadRemota, CantidadMovil y ObservacionAdministrativa'
ALTER TABLE dbo.Prospectos ADD UtilizaAppSoporte bit null;
ALTER TABLE dbo.Prospectos ADD CantidadLocal int null;
ALTER TABLE dbo.Prospectos ADD CantidadRemota int null;
ALTER TABLE dbo.Prospectos ADD CantidadMovil int null;
ALTER TABLE dbo.Prospectos ADD ObservacionAdministrativa varchar(1000) null;
GO
PRINT ''
PRINT '3.1. Tabla Prospectos: Valores por defecto para UtilizaAppSoporte y CantidadLocal'
UPDATE dbo.Prospectos SET UtilizaAppSoporte  = 0, CantidadLocal  = CantidadDePCs;
PRINT ''
PRINT '3.2. Tabla Prospectos: NOT NULL UtilizaAppSoporte'
ALTER TABLE dbo.Prospectos ALTER COLUMN UtilizaAppSoporte bit NOT NULL

PRINT ''
PRINT '4. Tabla AuditoriaClientes: Nuevos campos UtilizaAppSoporte, CantidadLocal, CantidadRemota, CantidadMovil y ObservacionAdministrativa'
ALTER TABLE dbo.AuditoriaClientes ADD UtilizaAppSoporte bit null;
ALTER TABLE dbo.AuditoriaClientes ADD CantidadLocal int null;
ALTER TABLE dbo.AuditoriaClientes ADD CantidadRemota int null;
ALTER TABLE dbo.AuditoriaClientes ADD CantidadMovil int null;
ALTER TABLE dbo.AuditoriaClientes ADD ObservacionAdministrativa varchar(1000) null;

PRINT ''
PRINT '5. Tabla AuditoriaProspectos: Nuevos campos UtilizaAppSoporte, CantidadLocal, CantidadRemota, CantidadMovil y ObservacionAdministrativa'
ALTER TABLE dbo.AuditoriaProspectos ADD UtilizaAppSoporte bit null;
ALTER TABLE dbo.AuditoriaProspectos ADD CantidadLocal int null;
ALTER TABLE dbo.AuditoriaProspectos ADD CantidadRemota int null;
ALTER TABLE dbo.AuditoriaProspectos ADD CantidadMovil int null;
ALTER TABLE dbo.AuditoriaProspectos ADD ObservacionAdministrativa varchar(1000) null;
