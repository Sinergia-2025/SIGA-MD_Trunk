PRINT ''
PRINT '1. Nuevo Campo Producto: EsDevuelto'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Productos' AND COLUMN_NAME = 'EsDevuelto')
BEGIN
	ALTER TABLE Productos ADD EsDevuelto bit NULL
END
GO

PRINT ''
PRINT '2. Nuevo Campo Producto: EsDevuelto'
BEGIN
	UPDATE Productos SET EsDevuelto = 0
END
GO

PRINT ''
PRINT '1. Nuevo Campo AuditoriaProducto: EsDevuelto'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AuditoriaProductos' AND COLUMN_NAME = 'EsDevuelto')
BEGIN
	ALTER TABLE AuditoriaProductos ADD EsDevuelto bit NULL
END
GO

PRINT ''
PRINT '2. Nuevo Campo Producto: EsDevuelto'
BEGIN
	UPDATE AuditoriaProductos SET EsDevuelto = 0
END
GO

PRINT ''
PRINT '1. Nuevo Campo: IdRegimenIIBBComplem'
IF dbo.ExisteCampo('Proveedores','IdRegimenIIBBComplem') =  0
BEGIN
	ALTER TABLE Proveedores ADD IdRegimenIIBBComplem Int NULL

	ALTER TABLE Proveedores ADD CONSTRAINT
		FK_Proveedores_Regimenes_IIBBComplem FOREIGN KEY (IdRegimenIIBBComplem) REFERENCES dbo.Regimenes (IdRegimen) 
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 

END
GO

PRINT ''
PRINT '1. Nuevo Tipo de Impuesto: RIIBC'
IF NOT EXISTS (SELECT * FROM TiposImpuestos WHERE IdTipoImpuesto = 'RIIBC')
BEGIN
	INSERT INTO [dbo].[TiposImpuestos]
			   ([IdTipoImpuesto]
			   ,[NombreTipoImpuesto]
			   ,[Tipo]
			   ,[IdCuentaDebe]
			   ,[IdCuentaHaber]
			   ,[IdCuentaCaja]
			   ,[AplicativoAfip]
			   ,[CodigoArticuloInciso]
			   ,[ArticuloInciso])
		 VALUES
			   ('RIIBC',	'Ret. de IIBB Complementaria',	'RETENCION',	NULL,	NULL,	13,	'DRAGMA',	NULL,	NULL)
END
GO
PRINT ''
PRINT '2. Nuevo Campo: SecuenciaRetencion'
IF dbo.ExisteCampo('CuentasCorrientesProvRetenciones','SecuenciaRetencion') =  0
BEGIN
	ALTER TABLE CuentasCorrientesProvRetenciones ADD SecuenciaRetencion Int NULL
END
GO