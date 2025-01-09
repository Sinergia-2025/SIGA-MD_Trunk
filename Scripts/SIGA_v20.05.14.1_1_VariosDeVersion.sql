PRINT ''
PRINT '1. Nueva Tabla: VentasFormasPagoSucursales'
CREATE TABLE VentasFormasPagoSucursales(
	IdSucursal INT NOT NULL,
	IdFormasPago INT NOT NULL,
	PRIMARY KEY(IdSucursal, IdFormasPago))
GO

PRINT ''
PRINT '1.1 Registros iniciales para la tabla: VentasFormasPagoSucursales'
INSERT INTO VentasFormasPagoSucursales (IdSucursal, IdFormasPago) 
SELECT S.IdSucursal, VFP.IdFormasPago FROM Sucursales S
CROSS JOIN VentasFormasPago VFP	 
GO

PRINT ''
PRINT '1.2 FOREIGN KEY VentasFormasPagoSucursales IdSucursal'
ALTER TABLE VentasFormasPagoSucursales ADD CONSTRAINT FK_VentasFormasPagoSucursales_Sucursales
    FOREIGN KEY (IdSucursal) REFERENCES Sucursales(IdSucursal)
GO

PRINT ''
PRINT '1.3 FOREIGN KEY VentasFormasPagoSucursales IdFormasPago'
ALTER TABLE VentasFormasPagoSucursales ADD CONSTRAINT FK_VentasFormasPagoSucursales_VentasFormasPago
    FOREIGN KEY (IdFormasPago) REFERENCES VentasFormasPago(IdFormasPago)
GO

PRINT ''
PRINT '2. Tabla CajasDetalle: Nuevos campos NumeroDeposito y IdTipoComprobante'
ALTER TABLE CajasDetalle ADD NumeroDeposito BIGINT NULL
ALTER TABLE CajasDetalle ADD IdTipoComprobante VARCHAR(15) NULL
GO

PRINT ''
PRINT '2.1. FOREIGN KEY CajasDetalle -> Depositos'
ALTER TABLE CajasDetalle ADD CONSTRAINT FK_CajasDetalle_Depositos
	FOREIGN KEY(IdSucursal, NumeroDeposito, IdTipoComprobante)REFERENCES Depositos(IdSucursal, NumeroDeposito, IdTipoComprobante)
GO

PRINT ''
PRINT '3. Tabla LibrosBancos: Nuevos Campos NumeroDeposito y IdTipoComprobante'
ALTER TABLE LibrosBancos ADD NumeroDeposito BIGINT NULL
ALTER TABLE LibrosBancos ADD IdTipoComprobante VARCHAR(15) NULL
GO

PRINT ''
PRINT '3.1. FOREIGN KEY LibrosBancos -> Depositos'
ALTER TABLE LibrosBancos ADD CONSTRAINT FK_LibrosBancos_Depositos
	FOREIGN KEY(IdSucursal, NumeroDeposito, IdTipoComprobante)REFERENCES Depositos(IdSucursal, NumeroDeposito, IdTipoComprobante)
GO

PRINT ''
PRINT '4. Tabla Clientes: Agrega columna PublicarEnWeb'
ALTER TABLE Clientes ADD PublicarEnWeb	bit	null
GO
UPDATE Clientes SET PublicarEnWeb = 'True'
ALTER TABLE Clientes ALTER COLUMN PublicarEnWeb	bit not	null
GO


PRINT ''
PRINT '5. Tabla AuditoriaClientes: Agrega columna PublicarEnWeb'
ALTER TABLE AuditoriaClientes ADD PublicarEnWeb	bit	null
GO
UPDATE AuditoriaClientes SET PublicarEnWeb = 'True'
ALTER TABLE AuditoriaClientes ALTER COLUMN PublicarEnWeb	bit not	null
GO


PRINT ''
PRINT '6. Tabla Prospectos: Agrega columna PublicarEnWeb'
ALTER TABLE Prospectos ADD PublicarEnWeb	bit	null
GO
UPDATE Prospectos SET PublicarEnWeb = 'True'
ALTER TABLE Prospectos ALTER COLUMN PublicarEnWeb	bit not	null
GO


PRINT ''
PRINT '7. Tabla AuditoriaProspectos: Agrega columna PublicarEnWeb'
ALTER TABLE AuditoriaProspectos ADD PublicarEnWeb	bit	null
GO
UPDATE AuditoriaProspectos SET PublicarEnWeb = 'True'
ALTER TABLE AuditoriaProspectos ALTER COLUMN PublicarEnWeb	bit not	null
GO

PRINT ''
PRINT '8. Nueva Tabla: DepositosCuentasBancos'
CREATE TABLE DepositosCuentasBancos(
	IdSucursal INT NOT NULL,
	NumeroDeposito BIGINT NOT NULL,
	IdTipoComprobante VARCHAR(15) NOT NULL,
	IdCuentaBanco INT NOT NULL,
	IdTipoCuenta VARCHAR(1) NOT NULL,
	Importe DECIMAL(10,2) NOT NULL,
	Observacion VARCHAR(100) NULL
	PRIMARY KEY(IdSucursal, NumeroDeposito, IdTipoComprobante, IdCuentaBanco)
)
GO

PRINT ''
PRINT '8.1 FOREIGN KEYs DepositosCuentasBancos > Depositos'
ALTER TABLE DepositosCuentasBancos ADD CONSTRAINT FK_DepositosCuentasBancos_Depositos
    FOREIGN KEY (IdSucursal,NumeroDeposito,IdTipoComprobante) REFERENCES Depositos(IdSucursal,NumeroDeposito,IdTipoComprobante)
GO

PRINT ''
PRINT '8.2 FOREIGN KEY DepositosCuentasBancos > CuentasBancos'
ALTER TABLE DepositosCuentasBancos ADD CONSTRAINT FK_DepositosCuentasBancos_CuentasBancos
    FOREIGN KEY (IdCuentaBanco) REFERENCES CuentasBancos(IdCuentaBanco)
GO


PRINT ''
PRINT '9. Nueva Tabla: DepositosTarjetasCupones'
CREATE TABLE DepositosTarjetasCupones(
	IdSucursal INT NOT NULL,
	NumeroDeposito BIGINT NOT NULL,
	IdTipoComprobante VARCHAR(15) NOT NULL,
	IdTarjetaCupon INT NOT NULL

	PRIMARY KEY (IdSucursal, NumeroDeposito, IdTipoComprobante, IdTarjetaCupon)
)
GO

PRINT ''
PRINT '9.1 FOREIGN KEY DepositosTarjetasCupones > Depositos'
ALTER TABLE DepositosTarjetasCupones ADD CONSTRAINT FK_DepositosTarjetasCupones_Depositos
    FOREIGN KEY (IdSucursal, NumeroDeposito, IdTipoComprobante) REFERENCES Depositos (IdSucursal, NumeroDeposito, IdTipoComprobante)
GO

PRINT ''
PRINT '9.2 FOREIGN KEY DepositosTarjetasCupones > TarjetasCupones'
ALTER TABLE DepositosTarjetasCupones ADD CONSTRAINT FK_DepositosTarjetasCupones_TarjetasCupones
    FOREIGN KEY (IdTarjetaCupon) REFERENCES TarjetasCupones (IdTarjetaCupon)
GO
