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
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CajasDetalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cheques ADD IdCajaActual int NULL
ALTER TABLE dbo.Cheques ADD NroPlanillaActual int NULL
ALTER TABLE dbo.Cheques ADD NroMovimientoActual int NULL
GO
ALTER TABLE dbo.Cheques ADD CONSTRAINT FK_Cheques_CajasDetalleActual
    FOREIGN KEY (IdSucursal, IdCajaActual, NroPlanillaActual, NroMovimientoActual)
    REFERENCES dbo.CajasDetalle (IdSucursal, IdCaja, NumeroPlanilla, NumeroMovimiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Cheques SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.ChequesHistorial ADD IdCajaActual int NULL
ALTER TABLE dbo.ChequesHistorial ADD NroPlanillaActual int NULL
ALTER TABLE dbo.ChequesHistorial ADD NroMovimientoActual int NULL
GO
ALTER TABLE dbo.ChequesHistorial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
