
ALTER TABLE [dbo].[CuentasCorrientes]
    ADD [IdCaja]           INT NULL,
        [NumeroPlanilla]   INT NULL,
        [NumeroMovimiento] INT NULL
GO


-- Habria que hacer un proceso que ponga lo correcto, pero por ahora es lo mejor.
UPDATE [dbo].[CuentasCorrientes]
   SET IdCaja = 1
     ,NumeroPlanilla = 
              (SELECT TOP 1 NumeroPlanilla FROM CajasDetalle
                WHERE IdSucursal = CuentasCorrientes.IdSucursal 
                 AND IdCuentaCaja = 2 ORDER BY NumeroPlanilla)
     ,NumeroMovimiento = 
              (SELECT TOP 1 NumeroMovimiento FROM CajasDetalle
                WHERE IdSucursal = CuentasCorrientes.IdSucursal 
                 AND IdCuentaCaja = 2 ORDER BY NumeroPlanilla)
 WHERE IdTipoComprobante = 'RECIBO'
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
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	FK_CuentasCorrientes_CajasDetalle FOREIGN KEY
	(
	IdSucursal,
	IdCaja,
	NumeroPlanilla,
	NumeroMovimiento
	) REFERENCES dbo.CajasDetalle
	(
	IdSucursal,
	IdCaja,
	NumeroPlanilla,
	NumeroMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
