PRINT ''
PRINT '1. Tabla Ventas: Observacion => VARCHAR(MAX)'
ALTER TABLE Ventas ALTER COLUMN Observacion VARCHAR(MAX) NULL
PRINT ''
PRINT '1.1. Tabla MovimientosVentas: Observacion => VARCHAR(MAX)'
IF dbo.ExisteTabla('MovimientosVentas') = 1
BEGIN
    ALTER TABLE MovimientosVentas ALTER COLUMN Observacion VARCHAR(MAX) NULL
END
PRINT ''
PRINT '1.1.1. Tabla MovimientosStock: Observacion => VARCHAR(MAX)'
IF dbo.ExisteTabla('MovimientosStock') = 1
BEGIN
    ALTER TABLE MovimientosStock ALTER COLUMN Observacion VARCHAR(MAX) NULL
END
PRINT ''
PRINT '1.2. Tabla CuentasCorrientes: Observacion => VARCHAR(MAX)'
ALTER TABLE CuentasCorrientes ALTER COLUMN Observacion VARCHAR(MAX) NULL
PRINT ''
PRINT '1.3. Tabla CuentasCorrientesPagos: Observacion => VARCHAR(MAX)'
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN Observacion VARCHAR(MAX) NULL

PRINT ''
PRINT '2. Tabla Clientes: Modifica campos IdEstadoCivil'
DECLARE @IdEstado AS Integer
SET @IdEstado = (SELECT IdEstadoCivil FROM EstadosCiviles WHERE NombreEstadoCivil = 'A Definir') 
BEGIN
	UPDATE Clientes SET IdEstadoCivil = @IdEstado WHERE IdEstadoCivil = 0
    UPDATE Prospectos SET IdEstadoCivil = @IdEstado WHERE IdEstadoCivil = 0
END
GO

PRINT ''
PRINT '2. Tabla Estados Civiles: Elimina IdEstadoCivil = 0'
BEGIN
	DELETE FROM EstadosCiviles WHERE IdEstadoCivil = 0
END
GO

DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCANTIDADCARACTERESOBSERVACIONES'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Cantidad caracteres en Observaciones'
DECLARE @valorParametro VARCHAR(MAX) = '100'
IF dbo.BaseConCuit('30711915695') = 1
    SET @valorParametro = '300'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
