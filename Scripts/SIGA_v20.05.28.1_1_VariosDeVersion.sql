/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

PRINT ''
PRINT '1. Tabla HistorialPrecios: Nuevo campo IdFuncion'
ALTER TABLE dbo.HistorialPrecios ADD IdFuncion varchar(30) NULL
GO
PRINT ''
PRINT '1.1. Tabla HistorialPrecios: FK a Funciones'
ALTER TABLE dbo.HistorialPrecios ADD CONSTRAINT FK_HistorialPrecios_Funciones
    FOREIGN KEY (IdFuncion)
    REFERENCES dbo.Funciones (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.HistorialPrecios SET (LOCK_ESCALATION = TABLE)
GO


PRINT ''
PRINT '2. Tabla UsuariosAccesos: Nuevo campo UsuarioWindows'
ALTER TABLE dbo.UsuariosAccesos ADD UsuarioWindows varchar(100) NULL
GO
PRINT ''
PRINT '2.1. Tabla UsuariosAccesos: Default value para UsuarioWindows'
ALTER TABLE dbo.UsuariosAccesos ADD CONSTRAINT DF_UsuariosAccesos_UsuarioWindows DEFAULT '' FOR UsuarioWindows
GO
PRINT ''
PRINT '2.2. Tabla UsuariosAccesos: Valor por defecto para UsuarioWindows para registros pre-existentes'
UPDATE UsuariosAccesos SET UsuarioWindows = '';
PRINT ''
PRINT '2.2. Tabla UsuariosAccesos: NOT NULL para UsuarioWindows'
ALTER TABLE dbo.UsuariosAccesos ALTER COLUMN UsuarioWindows varchar(100) NOT NULL
GO


PRINT ''
PRINT '3. Nueva Tabla: TiposCheques'
CREATE TABLE TiposCheques(
		IdTipoCheque VARCHAR(3) NOT NULL,
		NombreTipoCheque VARCHAR(50) NOT NULL,
		SolicitaNroOperacion BIT NOT NULL
		PRIMARY KEY (IdTipoCheque)
)
GO
PRINT ''
PRINT '3.1. Tabla TiposCheques: Valores iniciales'
INSERT INTO TiposCheques (IdTipoCheque, NombreTipoCheque, SolicitaNroOperacion)
	VALUES 
		('F', 'Físico', 'False'),
		('E', 'Electrónico', 'True')
GO


PRINT ''
PRINT '4. Tabla Cheques: Nuevos Campos IdTipoCheque y NroOperacion'
ALTER TABLE Cheques ADD IdTipoCheque VARCHAR(3) NULL
ALTER TABLE Cheques ADD NroOperacion VARCHAR(20) NULL
GO
PRINT ''
PRINT '4.1. Tabla Cheques: FK TiposCheques > IdTipoCheque'
ALTER TABLE Cheques
	ADD CONSTRAINT FK_Cheques_TiposCheques
	FOREIGN KEY (IdTipoCheque) REFERENCES TiposCheques(IdTipoCheque)
GO
PRINT ''
PRINT '4.2. Tabla Cheques: Actualización de los valores actuales de los cheques'
UPDATE Cheques SET IdTipoCheque = 'F'
GO
PRINT ''
PRINT '4.3. Tabla Cheques: NOT NULL en IdTipoCheque'
ALTER TABLE Cheques ALTER COLUMN IdTipoCheque VARCHAR(3) NOT NULL
GO



PRINT ''
PRINT '5. Tabla CuentasCorrientesProv: Nuevo campo CotizacionDolar'
ALTER TABLE CuentasCorrientesProv ADD CotizacionDolar decimal(10, 3) NULL
GO

PRINT ''
PRINT '5.1. Tabla CuentasCorrientesProv: Copiar el valor de CotizacionDolar de CuentasCorrientes a CuentasCorrientesPago'
UPDATE CuentasCorrientesProv 
   SET CuentasCorrientesProv.CotizacionDolar = C.CotizacionDolar
 FROM CuentasCorrientesProv CC 
 INNER JOIN Compras C ON C.IdSucursal = CC.IdSucursal
 AND C.IdTipoComprobante = CC.IdTipoComprobante
 AND C.Letra = CC.letra
 AND C.CentroEmisor = CC.CentroEmisor
 AND C.NumeroComprobante = CC.NumeroComprobante
 AND C.IdProveedor = CC.IdProveedor
GO

PRINT ''
PRINT '5.2. Tabla CuentasCorrientesProv: Inicializar en 1 las CotizacionDolar que quedaron en NULL del paso anterior'
UPDATE CuentasCorrientesProv SET CotizacionDolar = 1 where CotizacionDolar IS NULL
GO

PRINT ''
PRINT '5.3. Tabla CuentasCorrientesProv: NOT NULL para campo CotizacionDolar'
ALTER TABLE CuentasCorrientesProv ALTER COLUMN 	CotizacionDolar decimal(10, 3) NOT NULL
GO
