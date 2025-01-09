
PRINT ''
PRINT '1. Tabla Clientes: Nuevo campo VarPesosCotizDolar'
IF dbo.ExisteCampo('Clientes', 'VarPesosCotizDolar') = 0
BEGIN
    ALTER TABLE dbo.Clientes ADD VarPesosCotizDolar decimal(12,2) null;
END
GO
PRINT ''
PRINT '2. Tabla Prospectos: Nuevo campo VarPesosCotizDolar'
IF dbo.ExisteCampo('Prospectos', 'VarPesosCotizDolar') = 0
BEGIN
    ALTER TABLE dbo.Prospectos ADD VarPesosCotizDolar decimal(12,2) null;
END
GO
PRINT ''
PRINT '3. Tabla AuditoriaClientes: Nuevo campo VarPesosCotizDolar'
IF dbo.ExisteCampo('AuditoriaClientes', 'VarPesosCotizDolar') = 0
BEGIN
    ALTER TABLE dbo.AuditoriaClientes ADD VarPesosCotizDolar decimal(12,2) null;
END
PRINT ''
PRINT '4. Tabla AuditoriaProspectos: Nuevo campo VarPesosCotizDolar'
IF dbo.ExisteCampo('AuditoriaProspectos', 'VarPesosCotizDolar') = 0
BEGIN
    ALTER TABLE dbo.AuditoriaProspectos ADD VarPesosCotizDolar decimal(12,2) null;
END

IF dbo.ExisteCampo('FechasSincronizaciones', 'FechaInicioSubida') = 0
BEGIN
    ALTER TABLE dbo.FechasSincronizaciones ADD FechaInicioSubida datetime NULL
    ALTER TABLE dbo.FechasSincronizaciones ADD FechaInicioBajada datetime NULL
    ALTER TABLE dbo.FechasSincronizaciones ADD MetodoGrabacion char(1) NULL
    ALTER TABLE dbo.FechasSincronizaciones ADD IdFuncion varchar(30) NULL
END
GO

UPDATE FechasSincronizaciones
   SET MetodoGrabacion = ' '
     , IdFuncion = ''
 WHERE MetodoGrabacion IS NULL

UPDATE FechasSincronizaciones
   SET FechaInicioSubida = FechaSubida
 WHERE FechaInicioSubida IS NULL AND FechaSubida IS NOT NULL

UPDATE FechasSincronizaciones
   SET FechaInicioBajada = FechaBajada
 WHERE FechaInicioBajada IS NULL AND FechaBajada IS NOT NULL

ALTER TABLE dbo.FechasSincronizaciones ALTER COLUMN MetodoGrabacion char(1) NOT NULL
ALTER TABLE dbo.FechasSincronizaciones ALTER COLUMN IdFuncion varchar(30) NOT NULL
GO
