PRINT ''
PRINT '0. Nuevo Parametro: Habilita Cobranza ROELA'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'CTACTECOBRANZAELECTRONICAHABILITAROELA'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Habilita Cobranza ROELA'
	DECLARE @valorParametro VARCHAR(MAX)
	IF dbo.BaseConCuit('30714374938') = 1
		BEGIN
			 SET @valorParametro = 'True'
		END
	ELSE
		BEGIN
			 SET @valorParametro = 'False'
		END
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '1. Nuevo Parametro: Habilita Cobranza SirPlus'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'CTACTECOBRANZAELECTRONICAHABILITASIRPLUS'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Habilita Cobranza SirPlus'
	DECLARE @valorParametro VARCHAR(MAX)
	IF dbo.BaseConCuit('30714374938') = 1
		BEGIN
			 SET @valorParametro = 'True'
		END
	ELSE
		BEGIN
			 SET @valorParametro = 'False'
		END
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '2. Nuevo Parametro: Habilita Cobranza Debito Automatico'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'CTACTECOBRANZAELECTRONICAHABILITADEBITOAUTOMATICO'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Habilita Cobranza Debito Automatico'
	DECLARE @valorParametro VARCHAR(MAX) = 'True'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '3. Nuevo Campo: Entidad Cobranza'
IF dbo.ExisteCampo('Empleados','EntidadCobranza') =  0
BEGIN
	ALTER TABLE Empleados ADD EntidadCobranza Varchar(50) NULL
END
GO

PRINT ''
PRINT '4. Nuevo Campo: Entidad Cobranza'
IF dbo.ExisteCampo('Empleados','EntidadCobranza') =  1
BEGIN
	UPDATE Empleados SET EntidadCobranza = 'NINGUNO'
	ALTER TABLE Empleados ALTER COLUMN EntidadCobranza Varchar(50) NOT NULL
END
GO

PRINT ''
PRINT '5. Nuevo Campo Ventas'
IF dbo.ExisteCampo('Ventas','FechaVencimiento') =  0
BEGIN
	ALTER TABLE Ventas ADD FechaVencimiento		DateTime NULL
	ALTER TABLE Ventas ADD ImporteCuota			Decimal(14,2) NULL
	ALTER TABLE Ventas ADD FechaVencimiento2	DateTime NULL
	ALTER TABLE Ventas ADD ImporteVencimiento2	Decimal(14,2) NULL
	ALTER TABLE Ventas ADD FechaVencimiento3	DateTime NULL
	ALTER TABLE Ventas ADD ImporteVencimiento3	Decimal(14,2) NULL
	ALTER TABLE Ventas ADD CodigoDeBarra		Varchar(100) NULL
	ALTER TABLE Ventas ADD CodigoDeBarraSirplus Varchar(100) NULL
END
GO

PRINT ''
PRINT '1. Elimina Depositos y ubicaciones en Cero.-'
BEGIN
	DELETE FROM ProductosDepositos where stock = 0
	DELETE FROM ProductosUbicaciones where stock = 0
END
GO