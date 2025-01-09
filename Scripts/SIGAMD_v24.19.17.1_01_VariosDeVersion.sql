
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPProductos') = 1
BEGIN
UPDATE funciones SET Nombre = 'Inf. Detalle Operaciones de Orden Producción', 
				     Descripcion = 'Inf. Detalle Operaciones de Orden Producción'
where id = 'InfOrdenProduccionMRPProductos'
END
GO

ALTER TABLE TarjetasCupones ALTER COLUMN Monto decimal(16,4) NOT NULL
ALTER TABLE TarjetasCuponesHistorial ALTER COLUMN Monto decimal(16,4) NOT NULL
ALTER TABLE CuentasCorrientesTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL
ALTER TABLE VentasTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

DECLARE @idParametro VARCHAR(MAX) = 'CTACTECANTIDADDIASPREMIOCOBRO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Cantidad de Dias de Cobro de Premio Por Cobranzas'
DECLARE @valorParametro VARCHAR(MAX) = '0'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

ALTER TABLE Depositos ALTER COLUMN ImporteTotal decimal(14,2) NOT NULL
ALTER TABLE Depositos ALTER COLUMN ImportePesos decimal(14,2) NOT NULL
ALTER TABLE Depositos ALTER COLUMN ImporteDolares decimal(14,2) NOT NULL
ALTER TABLE Depositos ALTER COLUMN ImporteEuros decimal(14,2) NOT NULL
ALTER TABLE Depositos ALTER COLUMN ImporteCheques decimal(14,2) NOT NULL
ALTER TABLE Depositos ALTER COLUMN ImporteTarjetas decimal(14,2) NOT NULL
ALTER TABLE Depositos ALTER COLUMN ImporteTickets decimal(14,2) NOT NULL

IF dbo.ExisteCampo('Empleados', 'CobraPremioCobranza') = 0
BEGIN
    ALTER TABLE Empleados ADD CobraPremioCobranza bit NULL
END
GO
IF dbo.ExisteCampo('Empleados', 'CobraPremioCobranza') = 1
BEGIN
	UPDATE Empleados SET CobraPremioCobranza = 0
    ALTER TABLE Empleados ALTER COLUMN CobraPremioCobranza bit NOT NULL
END
GO
