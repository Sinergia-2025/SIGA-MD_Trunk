BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
GO

PRINT ''
PRINT '0.0. ENABLE TRIGGER ChequesActualizaHistorial'
GO
DISABLE TRIGGER dbo.ChequesActualizaHistorial ON dbo.Cheques;
GO

PRINT ''
PRINT '1. Tabla ChequesHistorial: Nuevos Campos IdTipoCheque y NroOperacion'
ALTER TABLE ChequesHistorial ADD IdTipoCheque VARCHAR(3) NULL
ALTER TABLE ChequesHistorial ADD NroOperacion VARCHAR(20) NULL
GO

PRINT ''
PRINT '1.1. Tabla ChequesHistorial: Actualización de registros pre-existentes'
UPDATE X SET X.IdTipoCheque = C.IdTipoCheque, X.NroOperacion = C.NroOperacion FROM ChequesHistorial X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
                      AND X.NumeroCheque = C.NumeroCheque
                      AND X.IdBanco = C.IdBanco
                      AND X.IdBancoSucursal = C.IdBancoSucursal
                      AND X.IdLocalidad = C.IdLocalidad
GO

PRINT '1.2. Tabla ChequesHistorial:  Por si los cheques fueron borrados y no se puede setear IdTipoCheque, se coloca el primer tipo de cheque que NO requiera Nro. Operación.'
DECLARE @tipo VARCHAR(3) = (SELECT TOP 1 IdTipoCheque FROM TiposCheques WHERE SolicitaNroOperacion = 'False')
UPDATE X SET X.IdTipoCheque = @tipo FROM ChequesHistorial X WHERE X.IdTipoCheque IS NULL
GO

PRINT ''
PRINT '1.3. Tabla ChequesHistorial: Cambio el campo IdTipoCheque a NOT NULL'
ALTER TABLE ChequesHistorial ALTER COLUMN IdTipoCheque VARCHAR(3) NOT NULL
GO

PRINT ''
PRINT '2. Tabla Cheques: Nuevo Campo IdCheque'
ALTER TABLE dbo.Cheques ADD IdCheque BIGINT NULL
PRINT ''
PRINT '2.1. Tabla ChequesHistorial: Nuevo Campo IdCheque'
ALTER TABLE dbo.ChequesHistorial ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3. DROP FK CHEQUES'
GO
ALTER TABLE dbo.LibrosBancos                    DROP CONSTRAINT FK_LibrosBancos_Cheques
ALTER TABLE dbo.VentasCheques                   DROP CONSTRAINT FK_VentasCheques_Cheques
ALTER TABLE dbo.VentasChequesRechazados         DROP CONSTRAINT FK_VentasChequesRechazados_Cheques
ALTER TABLE dbo.CuentasCorrientesProvCheques    DROP CONSTRAINT FK_CuentasCorrientesProvCheques_Cheques
ALTER TABLE dbo.CuentasCorrientesCheques        DROP CONSTRAINT FK_CuentasCorrientesCheques_Cheques
ALTER TABLE dbo.DepositosCheques                DROP CONSTRAINT FK_DepositosCheques_Cheques
ALTER TABLE dbo.Cheques                         DROP CONSTRAINT PK_Cheques
GO

PRINT ''
PRINT '3.1. Tabla Cheques: Actualización de registros pre-existentes con Nueva PK'
UPDATE X SET X.IdCheque = X.NuevoId FROM (SELECT IdCheque,ROW_NUMBER() OVER (ORDER BY NumeroCheque) AS NuevoId FROM Cheques) X
GO

PRINT ''
PRINT '3.2. Tabla Cheques: Cambio el campo a NOT NULL'
ALTER TABLE dbo.Cheques ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.3. Tabla Cheques: Nueva PK Cheques: IdCheque'
ALTER TABLE dbo.Cheques ADD CONSTRAINT PK_Cheques PRIMARY KEY CLUSTERED (IdCheque)
       WITH (PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '3.4. Tabla ChequesHistorial: Actualización de registros pre-existentes de IdCheque'
UPDATE X SET X.IdCheque = C.IdCheque FROM ChequesHistorial X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
                      AND X.NumeroCheque = C.NumeroCheque
                      AND X.IdBanco = C.IdBanco
                      AND X.IdBancoSucursal = C.IdBancoSucursal
                      AND X.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.4.1. Tabla ChequesHistorial: Donde el cheque ya NO EXISTE, se coloca un IdCheque negativo porque no tenemos IdCheque'
UPDATE X SET X.IdCheque = X.NuevoId FROM (SELECT IdCheque,ROW_NUMBER() OVER (ORDER BY NumeroCheque) * -1 AS NuevoId FROM ChequesHistorial WHERE IdCheque IS NULL) X
GO

PRINT ''
PRINT '3.4.2. Tabla ChequesHistorial: Cambio el campo a NOT NULL'
ALTER TABLE ChequesHistorial ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.4.3. Tabla ChequesHistorial: DROP PK ANTERIOR'
ALTER TABLE ChequesHistorial DROP CONSTRAINT PK_ChequesHistorial
GO

PRINT ''
PRINT '3.4.4. Tabla ChequesHistorial: NUEVA PK_ChequesHistorial'
ALTER TABLE ChequesHistorial ADD CONSTRAINT PK_ChequesHistorial PRIMARY KEY (IdCheque, Orden)
       WITH (PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '3.4.5. Tabla ChequesHistorial: NULLEO PK ANTERIOR'
ALTER TABLE ChequesHistorial ALTER COLUMN NumeroCheque INT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN IdBanco INT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN IdBancoSucursal INT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN IdLocalidad INT NULL
GO

PRINT '3.5.1. Tabla Cheques: Actualizo el CUIT del Cheque con el CUIT del Cliente'
UPDATE X SET X.Cuit = C.Cuit FROM Cheques X
  INNER JOIN Clientes C ON X.IdCliente = C.IdCliente 
WHERE X.Cuit IS NULL OR X.Cuit = ''
GO

PRINT '3.5.2. Tabla Cheques: En caso que los cheques no tengan un cliente vinculado, se setea "1" como CUIT'
UPDATE X SET X.Cuit = 1 FROM Cheques X WHERE X.Cuit IS NULL OR X.Cuit = ''
GO

PRINT '3.5.3. Tabla Cheques: Cambio el campo CUIT a NOT NULL'
ALTER TABLE Cheques ALTER COLUMN Cuit VARCHAR(13) NOT NULL
GO

PRINT '3.5.4. Tabla Cheques: ALTERNATIVE KEY FK ANTERIOR'
ALTER TABLE Cheques 
	ADD CONSTRAINT AK_Cheques UNIQUE (IdSucursal,NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad, Cuit)
GO

PRINT ''
PRINT '3.6. Tabla LibrosBancos: Nuevo Campo IdCheque'
ALTER TABLE LibrosBancos ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.6.1. Tabla LibrosBancos: Crear la nueva asociación entre LibrosBancos y Cheques'
UPDATE LB SET LB.IdCheque = C.IdCheque FROM LibrosBancos LB
  INNER JOIN Cheques C ON LB.IdSucursal = C.IdSucursal
					  AND LB.NumeroCheque = C.NumeroCheque
					  AND LB.IdBancoCheque = C.IdBanco
					  AND LB.IdBancoSucursalCheque = C.IdBancoSucursal
					  AND LB.IdLocalidadCheque = C.IdLocalidad
GO

PRINT ''
PRINT '3.6.2. Tabla LibrosBancos: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'LibrosBancos.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'LibrosBancos.IdBancoCheque', 'IdBancoChequeAnterior'
EXEC SP_RENAME 'LibrosBancos.IdBancoSucursalCheque', 'IdBancoSucursalChequeAnterior'
EXEC SP_RENAME 'LibrosBancos.IdLocalidadCheque', 'IdLocalidadChequeAnterior'
GO

PRINT ''
PRINT '3.6.3. Tabla LibrosBancos: Nueva FK_LibrosBancos_Cheques'
ALTER TABLE LibrosBancos ADD CONSTRAINT FK_LibrosBancos_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.7. Tabla VentasCheques: Nuevo Campo IdCheque'
ALTER TABLE VentasCheques ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.7.1. Tabla VentasCheques: Crear la nueva asociación entre VentasCheques y Cheques'
UPDATE VC SET VC.IdCheque = C.IdCheque FROM VentasCheques VC
  INNER JOIN Cheques C ON VC.IdSucursal = C.IdSucursal
					  AND VC.NumeroCheque = C.NumeroCheque
					  AND VC.IdBanco = C.IdBanco
					  AND VC.IdBancoSucursal = C.IdBancoSucursal
					  AND VC.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.7.2. Tabla VentasCheques: Cambio el campo a NOT NULL'
ALTER TABLE dbo.VentasCheques ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.7.3. Tabla VentasCheques: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'VentasCheques.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'VentasCheques.IdBanco', 'IdBancoAnterior'
EXEC SP_RENAME 'VentasCheques.IdBancoSucursal', 'IdBancoSucursalAnterior'
EXEC SP_RENAME 'VentasCheques.IdLocalidad', 'IdLocalidadAnterior'
GO

PRINT ''
PRINT '3.7.4. Tabla VentasCheques: Nueva FK_VentasCheques_Cheques'
ALTER TABLE VentasCheques ADD CONSTRAINT FK_VentasCheques_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.7.5. Tabla VentasCheques: DROP FK Anterior + PK Anterior'
ALTER TABLE VentasCheques DROP CONSTRAINT PK_VentasCheques
GO

PRINT ''
PRINT '3.7.6. Tabla VentasCheques: NULLEO LA PK ANTERIOR'
ALTER TABLE VentasCheques ALTER COLUMN NumeroChequeAnterior     INT NULL
ALTER TABLE VentasCheques ALTER COLUMN IdBancoAnterior          INT NULL
ALTER TABLE VentasCheques ALTER COLUMN IdBancoSucursalAnterior  INT NULL
ALTER TABLE VentasCheques ALTER COLUMN IdLocalidadAnterior      INT NULL
GO

PRINT ''
PRINT '3.7.7. Tabla VentasCheques: Nueva PK VentasCheques'
ALTER TABLE VentasCheques ADD CONSTRAINT PK_VentasCheques PRIMARY KEY
    (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdCheque)
GO

PRINT ''
PRINT '3.8. Tabla VentasChequesRechazados: Nuevo Campo IdCheque'
ALTER TABLE VentasChequesRechazados ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.8.1. Tabla VentasChequesRechazados: Crear la nueva asociación entre VentasChequesRechazados y Cheques'
UPDATE VC SET VC.IdCheque = C.IdCheque FROM VentasChequesRechazados VC
  INNER JOIN Cheques C ON VC.IdSucursal = C.IdSucursal
					  AND VC.NumeroCheque = C.NumeroCheque
					  AND VC.IdBanco = C.IdBanco
					  AND VC.IdBancoSucursal = C.IdBancoSucursal
					  AND VC.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.8.2. Tabla VentasChequesRechazados: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'VentasChequesRechazados.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'VentasChequesRechazados.IdBanco', 'IdBancoAnterior'
EXEC SP_RENAME 'VentasChequesRechazados.IdBancoSucursal', 'IdBancoSucursalAnterior'
EXEC SP_RENAME 'VentasChequesRechazados.IdLocalidad', 'IdLocalidadAnterior'
GO

PRINT ''
PRINT '3.8.3. Tabla VentasChequesRechazados: DROP PK Anterior'
ALTER TABLE VentasChequesRechazados DROP CONSTRAINT PK_VentasChequesRechazados
GO

PRINT ''
PRINT '3.8.4. Tabla VentasChequesRechazados: NULLEO LA PK ANTERIOR'
ALTER TABLE VentasChequesRechazados ALTER COLUMN NumeroChequeAnterior       INT NULL
ALTER TABLE VentasChequesRechazados ALTER COLUMN IdBancoAnterior            INT NULL
ALTER TABLE VentasChequesRechazados ALTER COLUMN IdBancoSucursalAnterior    INT NULL
ALTER TABLE VentasChequesRechazados ALTER COLUMN IdLocalidadAnterior        INT NULL
GO

PRINT ''
PRINT '3.8.5. Tabla VentasChequesRechazados: Nueva FK_VentasChequesRechazados_Cheques'
ALTER TABLE VentasChequesRechazados ADD CONSTRAINT FK_VentasChequesRechazados_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.8.6. Tabla VentasChequesRechazados: Cambio el campo a NOT NULL'
ALTER TABLE VentasChequesRechazados ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.8.7. Tabla VentasChequesRechazados: Nueva PK_VentasChequesRechazados'
ALTER TABLE VentasChequesRechazados ADD CONSTRAINT PK_VentasChequesRechazados PRIMARY KEY
	(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdCheque)
GO

PRINT ''
PRINT '3.9. Tabla CuentasCorrientesProvCheques: Nuevo Campo IdCheque'
ALTER TABLE CuentasCorrientesProvCheques ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.9.1. Tabla CuentasCorrientesProvCheques: Crear la nueva asociación entre CuentasCorrientesProvCheques y Cheques'
UPDATE X SET X.IdCheque = C.IdCheque FROM CuentasCorrientesProvCheques X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBanco = C.IdBanco
					  AND X.IdBancoSucursal = C.IdBancoSucursal
					  AND X.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.9.2. Tabla CuentasCorrientesProvCheques: Cambio el campo a NOT NULL'
ALTER TABLE CuentasCorrientesProvCheques ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.9.3. Tabla CuentasCorrientesProvCheques: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'CuentasCorrientesProvCheques.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'CuentasCorrientesProvCheques.IdBanco', 'IdBancoAnterior'
EXEC SP_RENAME 'CuentasCorrientesProvCheques.IdBancoSucursal', 'IdBancoSucursalAnterior'
EXEC SP_RENAME 'CuentasCorrientesProvCheques.IdLocalidad', 'IdLocalidadAnterior'
GO

PRINT ''
PRINT '3.9.4. Tabla CuentasCorrientesProvCheques: DROP PK ANTERIOR'
ALTER TABLE CuentasCorrientesProvCheques DROP CONSTRAINT PK_CuentasCorrientesProvCheques
GO

PRINT ''
PRINT '3.9.5. Tabla CuentasCorrientesProvCheques: NULLEO LA PK ANTERIOR'
ALTER TABLE CuentasCorrientesProvCheques ALTER COLUMN NumeroChequeAnterior      INT NULL
ALTER TABLE CuentasCorrientesProvCheques ALTER COLUMN IdBancoAnterior           INT NULL
ALTER TABLE CuentasCorrientesProvCheques ALTER COLUMN IdBancoSucursalAnterior   INT NULL
ALTER TABLE CuentasCorrientesProvCheques ALTER COLUMN IdLocalidadAnterior       INT NULL
GO

PRINT ''
PRINT '3.9.6. Tabla CuentasCorrientesProvCheques: Nueva FK_CuentasCorrientesProvCheques_Cheques'
ALTER TABLE CuentasCorrientesProvCheques ADD CONSTRAINT FK_CuentasCorrientesProvCheques_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.9.7. Tabla CuentasCorrientesProvCheques: NUEVA PK_CuentasCorrientesProvCheques'
ALTER TABLE CuentasCorrientesProvCheques ADD CONSTRAINT PK_CuentasCorrientesProvCheques PRIMARY KEY
	(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdCheque)
GO

PRINT ''
PRINT '3.10. Tabla CuentasCorrientesCheques: Nuevo Campo IdCheque'
ALTER TABLE CuentasCorrientesCheques ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.10.1. Tabla CuentasCorrientesCheques: Crear la nueva asociación entre CuentasCorrientesCheques y Cheques'
UPDATE X SET X.IdCheque = C.IdCheque FROM CuentasCorrientesCheques X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBancoCheque = C.IdBanco
					  AND X.IdBancoSucursalCheque = C.IdBancoSucursal
					  AND X.IdLocalidadCheque = C.IdLocalidad
GO

PRINT ''
PRINT '3.10.2. Tabla CuentasCorrientesCheques: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'CuentasCorrientesCheques.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'CuentasCorrientesCheques.IdBancoCheque', 'IdBancoChequeAnterior'
EXEC SP_RENAME 'CuentasCorrientesCheques.IdBancoSucursalCheque', 'IdBancoSucursalChequeAnterior'
EXEC SP_RENAME 'CuentasCorrientesCheques.IdLocalidadCheque', 'IdLocalidadChequeAnterior'
GO

PRINT ''
PRINT '3.10.3. Tabla CuentasCorrientesCheques: Cambio el campo a NOT NULL'
ALTER TABLE CuentasCorrientesCheques ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.10.4. Tabla CuentasCorrientesCheques: Nueva FK_CuentasCorrientesCheques_Cheques'
ALTER TABLE CuentasCorrientesCheques ADD CONSTRAINT FK_CuentasCorrientesCheques_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.10.5. Tabla CuentasCorrientesCheques: DROP PK ANTERIOR'
ALTER TABLE CuentasCorrientesCheques DROP CONSTRAINT PK_CuentasCorrientesCheques
GO

PRINT ''
PRINT '3.10.6. Tabla CuentasCorrientesCheques: NULLEO LA PK ANTERIOR'
ALTER TABLE CuentasCorrientesCheques ALTER COLUMN NumeroChequeAnterior          INT NULL
ALTER TABLE CuentasCorrientesCheques ALTER COLUMN IdBancoChequeAnterior         INT NULL
ALTER TABLE CuentasCorrientesCheques ALTER COLUMN IdBancoSucursalChequeAnterior INT NULL
ALTER TABLE CuentasCorrientesCheques ALTER COLUMN IdLocalidadChequeAnterior     INT NULL
GO

PRINT ''
PRINT '3.10.7. Tabla CuentasCorrientesCheques: NUEVA PK_CuentasCorrientesCheques'
ALTER TABLE CuentasCorrientesCheques ADD CONSTRAINT PK_CuentasCorrientesCheques PRIMARY KEY
	(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdCheque)
GO

PRINT ''
PRINT '3.11. Tabla DepositosCheques: Nuevo Campo IdCheque'
ALTER TABLE DepositosCheques ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.11.1. Tabla DepositosCheques: Crear la nueva asociación entre DepositosCheques y Cheques'
UPDATE X SET X.IdCheque = C.IdCheque FROM DepositosCheques X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBanco = C.IdBanco
					  AND X.IdBancoSucursal = C.IdBancoSucursal
					  AND X.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.11.2. Tabla DepositosCheques: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'DepositosCheques.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'DepositosCheques.IdBanco', 'IdBancoAnterior'
EXEC SP_RENAME 'DepositosCheques.IdBancoSucursal', 'IdBancoSucursalAnterior'
EXEC SP_RENAME 'DepositosCheques.IdLocalidad', 'IdLocalidadAnterior'
GO

PRINT ''
PRINT '3.11.3. Tabla DepositosCheques: Nueva FK_DepositosCheques_Cheques'
ALTER TABLE DepositosCheques ADD CONSTRAINT FK_DepositosCheques_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.11.4. Tabla DepositosCheques: Cambio el campo a NOT NULL'
ALTER TABLE DepositosCheques ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.11.5. Tabla DepositosCheques: DROP FK ANTERIOR'
ALTER TABLE DepositosCheques DROP CONSTRAINT PK_DepositosCheques
GO

PRINT ''
PRINT '3.11.6. Tabla DepositosCheques: NULLEO PK ANTERIOR'
ALTER TABLE DepositosCheques ALTER COLUMN NumeroChequeAnterior      INT NULL
ALTER TABLE DepositosCheques ALTER COLUMN IdBancoAnterior           INT NULL
ALTER TABLE DepositosCheques ALTER COLUMN IdBancoSucursalAnterior   INT NULL
ALTER TABLE DepositosCheques ALTER COLUMN IdLocalidadAnterior       INT NULL

PRINT ''
PRINT '3.11.7. Tabla DepositosCheques: NUEVA PK_DepositosCheques'
ALTER TABLE DepositosCheques ADD CONSTRAINT PK_DepositosCheques PRIMARY KEY
	(IdSucursal, NumeroDeposito, IdTipoComprobante, IdCheque)
GO

PRINT ''
PRINT '3.12. Tabla ComprasCheques: Nuevo Campo IdCheque'
ALTER TABLE ComprasCheques ADD IdCheque BIGINT NULL
GO

PRINT ''
PRINT '3.12.1. Tabla ComprasCheques: Crear la nueva asociación entre ComprasCheques y Cheques'
UPDATE X SET X.IdCheque = C.IdCheque FROM ComprasCheques X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBanco = C.IdBanco
					  AND X.IdBancoSucursal = C.IdBancoSucursal
					  AND X.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.12.2. Tabla ComprasCheques: Agrego un "Anterior" a la FK anterior (se guarda por las dudas durante un tiempo)'
EXEC SP_RENAME 'ComprasCheques.NumeroCheque', 'NumeroChequeAnterior'
EXEC SP_RENAME 'ComprasCheques.IdBanco', 'IdBancoAnterior'
EXEC SP_RENAME 'ComprasCheques.IdBancoSucursal', 'IdBancoSucursalAnterior'
EXEC SP_RENAME 'ComprasCheques.IdLocalidad', 'IdLocalidadAnterior'
GO

PRINT ''
PRINT '3.12.3. Tabla ComprasCheques: Nueva FK_ComprasCheques_Cheques'
ALTER TABLE ComprasCheques
	ADD CONSTRAINT FK_ComprasCheques_Cheques
	FOREIGN KEY (IdCheque) REFERENCES Cheques (IdCheque)
GO

PRINT ''
PRINT '3.12.4. Tabla ComprasCheques: Cambio el campo a NOT NULL'
ALTER TABLE ComprasCheques ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.12.5. Tabla ComprasCheques: DROP FK ANTERIOR'
ALTER TABLE ComprasCheques DROP CONSTRAINT PK_ComprasCheques
GO

PRINT ''
PRINT '3.12.6. Tabla ComprasCheques: NULLEO PK ANTERIOR'
ALTER TABLE ComprasCheques ALTER COLUMN NumeroChequeAnterior INT NULL
ALTER TABLE ComprasCheques ALTER COLUMN IdBancoAnterior INT NULL
ALTER TABLE ComprasCheques ALTER COLUMN IdBancoSucursalAnterior INT NULL
ALTER TABLE ComprasCheques ALTER COLUMN IdLocalidadAnterior INT NULL

PRINT ''
PRINT '3.12.7. Tabla ComprasCheques: NUEVA PK_ComprasCheques'
ALTER TABLE ComprasCheques ADD CONSTRAINT PK_ComprasCheques PRIMARY KEY
	(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor, IdCheque)
GO

PRINT ''
PRINT '3.13. Tabla RepartosCobranzasCheques: Nuevo Campo Cuit'
ALTER TABLE RepartosCobranzasCheques ADD Cuit VARCHAR(13) NULL
GO

PRINT ''
PRINT '3.13.1. Tabla RepartosCobranzasCheques: Actualización de registros pre-existentes RepartosCobranzasCheques'
UPDATE X SET X.Cuit = C.Cuit FROM RepartosCobranzasCheques X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBanco = C.IdBanco
					  AND X.IdBancoSucursal = C.IdBancoSucursal
					  AND X.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.13.1.1. Tabla RepartosCobranzasCheques: Actualización de registros pre-existentes RepartosCobranzasCheques en caso que hayan quedado sin CUIT'
UPDATE X SET X.Cuit = C.Cuit FROM RepartosCobranzasCheques X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBanco = C.IdBanco
					  AND X.IdBancoSucursal = C.IdBancoSucursal
					  AND X.Importe = C.Importe
WHERE X.Cuit IS NULL
GO

PRINT ''
PRINT '3.13.1.2. Tabla RepartosCobranzasCheques: Actualización de registros pre-existentes RepartosCobranzasCheques en caso que hayan quedado sin CUIT'
UPDATE X SET X.Cuit = 1 FROM RepartosCobranzasCheques X WHERE X.Cuit IS NULL
GO

PRINT ''
PRINT '3.13.2. Tabla ChequesHistorial: Actualización de registros pre-existentes '
UPDATE X SET X.IdCheque = C.IdCheque FROM ChequesHistorial X
  INNER JOIN Cheques C ON X.IdSucursal = C.IdSucursal
					  AND X.NumeroCheque = C.NumeroCheque
					  AND X.IdBanco = C.IdBanco
					  AND X.IdBancoSucursal = C.IdBancoSucursal
					  AND X.IdLocalidad = C.IdLocalidad
GO

PRINT ''
PRINT '3.13.3. Tabla ChequesHistorial: Donde el cheque ya NO EXISTE, se coloca un IdCheque negativo'
UPDATE X SET X.IdCheque = X.NuevoId FROM (SELECT IdCheque,ROW_NUMBER() OVER (ORDER BY NumeroCheque) * -1 AS NuevoId FROM ChequesHistorial WHERE IdCheque IS NULL) X
GO

PRINT ''
PRINT '3.13.3.1. Tabla ChequesHistorial: Cambio el campo a NOT NULL'
ALTER TABLE ChequesHistorial ALTER COLUMN IdCheque BIGINT NOT NULL
GO

PRINT ''
PRINT '3.13.3.2. Tabla ChequesHistorial: DROP PK ANTERIOR'
ALTER TABLE ChequesHistorial DROP CONSTRAINT PK_ChequesHistorial
GO

PRINT ''
PRINT '3.13.3.3. Tabla ChequesHistorial: NUEVA PK_ChequesHistorial'
ALTER TABLE ChequesHistorial ADD CONSTRAINT PK_ChequesHistorial PRIMARY KEY
	(IdCheque, Orden)
GO

PRINT ''
PRINT '3.13.3.4. Tabla ChequesHistorial: NULLEO PK ANTERIOR'
ALTER TABLE ChequesHistorial ALTER COLUMN NumeroCheque INT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN IdBanco INT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN IdBancoSucursal INT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN IdLocalidad INT NULL
GO

PRINT ''
PRINT '4. Nueva Tabla: Chequeras'
CREATE TABLE Chequeras(
	IdChequera INT NOT NULL, 
	IdCuentaBancaria INT NOT NULL,
	NumeroDesde INT NULL,
	NumeroHasta INT NULL,
	NombreChequera VARCHAR(50) NULL,
	NumeroActual INT NULL,
	Descripcion VARCHAR(100) NULL,
	Activo BIT NOT NULL
	PRIMARY KEY (IdChequera))
GO

PRINT ''
PRINT '4.1. Tabla Chequeras: FK_Chequeras_CuentasBancarias'
ALTER TABLE Chequeras ADD CONSTRAINT FK_Chequeras_CuentasBancarias
	FOREIGN KEY (IdCuentaBancaria) REFERENCES CuentasBancarias (IdCuentaBancaria)
GO

PRINT ''
PRINT '4.2. Tabla Chequeras: Creación de Chequeras base'
INSERT INTO Chequeras (IdChequera, IdCuentaBancaria, NumeroDesde, NumeroHasta, NombreChequera, NumeroActual, Descripcion, Activo)
    SELECT 
	    ROW_NUMBER() OVER (ORDER BY IdCuentaBancaria) IdChequera,
	    IdCuentaBancaria, NULL, NULL, NULL, NULL, NULL, 'True'
FROM CuentasBancarias
GO

PRINT '4.3. Tabla Chequeras: Seteo los valores HASTA (Multiplos de 25) - Form: 25-(X MOD 25)+X, donde X es el MAX numero de cheque encontrado'
UPDATE X
   SET X.NumeroDesde = 1
     , X.NumeroHasta = (25 - (SELECT MAX(C.NumeroCheque) FROM Cheques C WHERE C.IdCuentaBancaria = X.IdCuentaBancaria) % 25 + (SELECT MAX(C.NumeroCheque) FROM Cheques C WHERE C.IdCuentaBancaria = X.IdCuentaBancaria))
  FROM Chequeras X
GO

PRINT ''
PRINT '4.3.1. Tabla Chequeras: Si alguno quedó vacio, le asigno 25'
UPDATE X SET X.NumeroHasta = 25 FROM Chequeras X WHERE X.NumeroHasta IS NULL
GO

PRINT ''
PRINT '4.3.2. Tabla Chequeras: Seteo los valores NRO ACTUAL'
UPDATE X SET X.NumeroActual = (SELECT MAX(C.NumeroCheque) FROM Cheques C WHERE C.IdCuentaBancaria = X.IdCuentaBancaria) FROM Chequeras X
GO

PRINT ''
PRINT '4.3.3. Tabla Chequeras: Si alguno quedó vacio, le asigno 0'
UPDATE X SET X.NumeroActual = 0 FROM Chequeras X WHERE X.NumeroActual IS NULL
GO

PRINT ''
PRINT '4.4 Tabla Chequeras: Seteo el nombre de la Chequera (sugerido)'
UPDATE X SET X.NombreChequera = 'Desde ' + CONVERT(VARCHAR, X.NumeroDesde) + ' A ' + CONVERT(VARCHAR, X.NumeroHasta) FROM Chequeras X
GO

PRINT ''
PRINT '4.5. Tabla Chequeras: Chequeras_AK'
ALTER TABLE Chequeras
	ADD CONSTRAINT AK_Chequeras UNIQUE (IdCuentaBancaria, NumeroDesde)
GO

PRINT ''
PRINT '4.6. Tabla Chequeras: Nuevo Campo IdChequera en Cheques (FK Nulable, sólo para cheques propios)'
ALTER TABLE Cheques ADD IdChequera INT NULL
GO

PRINT ''
PRINT '4.7. Tabla Chequeras: FK_Cheques_Chequeras'
ALTER TABLE Cheques ADD CONSTRAINT FK_Cheques_Chequeras
	FOREIGN KEY (IdChequera) REFERENCES Chequeras (IdChequera)
GO

PRINT ''
PRINT '4.8. Tabla Chequeras: Actualización de registros pre-existentes'
UPDATE X SET X.IdChequera = C.IdChequera FROM Cheques X
	INNER JOIN Chequeras C ON X.IdCuentaBancaria = C.IdCuentaBancaria
GO

PRINT ''
PRINT '5. Tabla LibrosBancos: Nuevo Campo FechaActualizacionAsiento'
ALTER TABLE LibrosBancos
	ADD FechaActualizacionAsiento DATETIME NULL
GO

PRINT ''
PRINT '5.1. Tabla LibrosBancos: Actualización de registros pre-existentes'
UPDATE LB SET LB.FechaActualizacionAsiento = LB.FechaMovimiento FROM LibrosBancos LB
GO

PRINT ''
PRINT '5.2. Tabla LibrosBancos: Cambio el campo a NOT NULL'
ALTER TABLE LibrosBancos
	ALTER COLUMN FechaActualizacionAsiento DATETIME NOT NULL
GO

PRINT ''
PRINT '6. Tabla Productos: Corrección de IdUnidadDeMedida y Conversion'
DECLARE @um char(2) = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas WHERE IdUnidadDeMedida = 'UN')
IF @um IS NULL SET @um = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas)

PRINT ''
PRINT '6.1. Tabla Productos: Actualización de registros pre-existentes'
UPDATE P SET P.IdUnidadDeMedida = @um, P.Tamano = 1 FROM Productos P WHERE P.IdUnidadDeMedida IS NULL
UPDATE P SET P.Conversion = 1 FROM Productos P WHERE P.Conversion = 0
GO

PRINT ''
PRINT '6.1.1. Tabla AuditoriaProductos: Actualización de los registros pre-existentes'
UPDATE AP SET AP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM AuditoriaProductos AP
 INNER JOIN Productos P ON AP.IdProducto = P.IdProducto
WHERE AP.IdUnidadDeMedida IS NULL
GO

PRINT ''
PRINT '6.1.1 Tabla AuditoriaProductos: Actualización de los registros pre-existentes (productos que ya no existen)'
DECLARE @um char(2) = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas WHERE IdUnidadDeMedida = 'UN')
IF @um IS NULL SET @um = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas)
UPDATE AP SET AP.IdUnidadDeMedida = @um FROM AuditoriaProductos AP
  WHERE AP.IdUnidadDeMedida IS NULL
GO

PRINT ''
PRINT '6.2. Tabla VentasProductos: Actualización de los registros pre-existentes'
UPDATE VP SET VP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM VentasProductos VP
 INNER JOIN Productos P ON VP.IdProducto = P.IdProducto
WHERE VP.IdUnidadDeMedida IS NULL
GO

PRINT ''
PRINT '6.3. Tabla PedidosProductos: Actualización de los registros pre-existentes'
UPDATE PP SET PP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM PedidosProductos PP
 INNER JOIN Productos P ON PP.IdProducto = P.IdProducto
WHERE PP.IdUnidadDeMedida IS NULL
GO

PRINT ''
PRINT '7. Cambio el campo a NOT NULL'
ALTER TABLE Productos ALTER COLUMN IdUnidadDeMedida VARCHAR(2) NOT NULL
GO

PRINT ''
PRINT '7.1. Cambio el campo a NOT NULL'
ALTER TABLE AuditoriaProductos ALTER COLUMN IdUnidadDeMedida VARCHAR(2) NOT NULL
GO

PRINT ''
PRINT '0.1. ENABLE TRIGGER ChequesActualizaHistorial'
GO
ENABLE TRIGGER dbo.ChequesActualizaHistorial ON dbo.Cheques;
GO
