ALTER TABLE dbo.Cheques ALTER COLUMN NroPlanillaIngreso int NULL
GO
ALTER TABLE dbo.Cheques ALTER COLUMN NroMovimientoIngreso int NULL
GO
ALTER TABLE dbo.Cheques ALTER COLUMN NroPlanillaEgreso int NULL
GO
ALTER TABLE dbo.Cheques ALTER COLUMN NroMovimientoEgreso int NULL
GO

UPDATE dbo.Cheques 
   SET NroPlanillaIngreso = NULL,
       NroMovimientoIngreso = NULL
 WHERE NroPlanillaIngreso = 0
GO

UPDATE dbo.Cheques 
   SET NroPlanillaEgreso = NULL,
       NroMovimientoEgreso = NULL
 WHERE NroPlanillaEgreso = 0
GO


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
ALTER TABLE dbo.CajasDetalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO

ALTER TABLE dbo.Cheques ADD CONSTRAINT
	FK_Cheques_CajasDetalle_Ingreso FOREIGN KEY
	(
	idSucursal,
	NroPlanillaIngreso,
	NroMovimientoIngreso
	) REFERENCES dbo.CajasDetalle
	(
	IdSucursal,
	NumeroPlanilla,
	NumeroMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.Cheques ADD CONSTRAINT
	FK_Cheques_CajasDetalle_Egreso FOREIGN KEY
	(
	idSucursal,
	NroPlanillaEgreso,
	NroMovimientoEgreso
	) REFERENCES dbo.CajasDetalle
	(
	IdSucursal,
	NumeroPlanilla,
	NumeroMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
