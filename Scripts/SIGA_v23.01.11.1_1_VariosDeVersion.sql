PRINT ''
PRINT '1. Tabla Dispositivos: Borro todo para que se vuelva a tomar.' 
IF dbo.ExisteCampo('Dispositivos', 'VersionFramework') = 0
BEGIN
	DELETE dbo.Dispositivos;
END
GO

PRINT ''
PRINT '2. Tabla Dispositivos: Agrego Campos para control de Licencias'
IF dbo.ExisteCampo('Dispositivos', 'VersionFramework') = 0
BEGIN
	ALTER TABLE dbo.Dispositivos ADD
		NumeroSerieMotherboard varchar(100) NOT NULL,
		NumeroSerieDiscoPrimario varchar(100) NOT NULL,
		ResolucionPantalla varchar(20) NOT NULL,
		VersionFramework varchar(20) NOT NULL,
		Activo bit NOT NULL
END
GO

PRINT ''
PRINT '3. Tabla ClientesDispositivos: Agrego Campos para control de Licencias'
IF dbo.ExisteCampo('ClientesDispositivos', 'VersionFramework') = 0
BEGIN
	ALTER TABLE dbo.ClientesDispositivos ADD
		NumeroSerieMotherboard varchar(100) NULL,
		NumeroSerieDiscoPrimario varchar(100) NULL,
		ResolucionPantalla varchar(20) NULL,
		VersionFramework varchar(20) NULL,
		Activo bit NULL
END
GO

PRINT ''
PRINT '4. Tabla Dispositivos: Agrego Campo CONTROL1 para control de Licencias'
IF dbo.ExisteCampo('Dispositivos', 'Control1') = 0
BEGIN
	ALTER TABLE dbo.Dispositivos ADD Control1 varchar(100) NULL
END
GO

UPDATE dbo.Dispositivos 
  SET Control1 = 'fEZ4wBPvIb/S49k8BrQQYzSpn0ThIgs4BkNGp9fcQNM='
 WHERE Control1 IS NULL;
ALTER TABLE dbo.Dispositivos ALTER COLUMN Control1 varchar(100) NOT NULL;
GO


PRINT ''
PRINT '5. Tabla ClientesDispositivos: Agrego Campo CONTROL1 para control de Licencias'
IF dbo.ExisteCampo('ClientesDispositivos', 'Control1') = 0
BEGIN
	ALTER TABLE dbo.ClientesDispositivos ADD Control1 varchar(100) NULL
END
GO

