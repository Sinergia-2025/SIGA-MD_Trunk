
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosCheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cheques ADD
	IdEstadoCheque varchar(10) NULL,
	IdEstadoChequeAnt varchar(10) NULL
GO
ALTER TABLE dbo.Cheques ADD CONSTRAINT
	FK_Cheques_EstadosCheques FOREIGN KEY
	(
	IdEstadoCheque
	) REFERENCES dbo.EstadosCheques
	(
	IdEstadoCheque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cheques ADD CONSTRAINT
	FK_Cheques_EstadosChequesAnt FOREIGN KEY
	(
	IdEstadoChequeAnt
	) REFERENCES dbo.EstadosCheques
	(
	IdEstadoCheque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* --------------------- */ 

UPDATE dbo.Cheques SET
    IdEstadoCheque = 'ENCARTERA',
    IdEstadoChequeAnt = NULL
 WHERE NroPlanillaIngreso>0 AND NroPlanillaEgreso IS NULL
GO

UPDATE dbo.Cheques SET
    IdEstadoCheque = 'DEPOSITADO',
    IdEstadoChequeAnt = 'ENCARTERA'
 WHERE EXISTS 
     ( SELECT * FROM DepositosCheques DC
       WHERE DC.IdSucursal = Cheques.IdSucursal
         AND DC.IdBanco = Cheques.IdBanco
         AND DC.IdBancoSucursal = Cheques.IdBancoSucursal
         AND DC.IdLocalidad = Cheques.IdLocalidad
         AND DC.NumeroCheque = Cheques.NumeroCheque
     )
GO

UPDATE dbo.Cheques SET
    IdEstadoCheque = 'PROVEEDOR',
    IdEstadoChequeAnt = 'ENCARTERA'
 WHERE EXISTS 
     ( SELECT * FROM dbo.CuentasCorrientesProvCheques CCPC
       WHERE CCPC.IdSucursal = Cheques.IdSucursal
         AND CCPC.IdBanco = Cheques.IdBanco
         AND CCPC.IdBancoSucursal = Cheques.IdBancoSucursal
         AND CCPC.IdLocalidad = Cheques.IdLocalidad
         AND CCPC.NumeroCheque = Cheques.NumeroCheque
     )
GO

UPDATE dbo.Cheques SET
    IdEstadoCheque = 'EGRESOCAJA',
    IdEstadoChequeAnt = 'ENCARTERA'
 WHERE NroPlanillaEgreso>0 AND IdEstadoCheque IS NULL
GO

/* ------------------- */ 

ALTER TABLE dbo.Cheques ALTER COLUMN IdEstadoCheque varchar(10) NOT NULL 
GO

