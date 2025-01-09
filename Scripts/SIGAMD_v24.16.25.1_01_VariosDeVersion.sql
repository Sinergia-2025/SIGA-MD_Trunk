PRINT ''
PRINT '1. Crea Campo Cantidad de Controles en Centro Productor.'
IF dbo.ExisteCampo('MRPCentrosProductores','CantidadControles') = 0
BEGIN
	ALTER TABLE MRPCentrosProductores ADD CantidadControles int NULL
END
GO

PRINT ''
PRINT '2. Actualiza Campo Cantidad de Controles en Centro Productor.'
IF dbo.ExisteCampo('MRPCentrosProductores','CantidadControles') = 1
BEGIN
	UPDATE MRPCentrosProductores SET CantidadControles = 1 WHERE CantidadControles IS NULL
	ALTER TABLE MRPCentrosProductores ALTER COLUMN  CantidadControles int NOT NULL
END
GO
